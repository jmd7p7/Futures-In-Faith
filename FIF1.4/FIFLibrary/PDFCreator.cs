using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using System.Net.Mail;
using Common.MessageBuilder;
using FIFLibrary.EmailMessage;

namespace FIFLibrary
{
    public class PDFCreator
    {
        private Investor2 Investor;
        public PDFCreator(Investor2 investor)
        {
            this.Investor = investor;
        }
        public bool createPDF(Investment2 newInvestment, string EmailORPrint)
        {
            bool success = false;
            success = SavePDFToDisk(newInvestment); //always save PDF to disk

            if(EmailORPrint == "email")
            {
               success = EmailPDF(newInvestment);
            }
            return success;
        }

        private void stampFields(PdfStamper stamper, Investment2 newInvestment)
        {
            string creditTo;
            string ifWin;
            if(newInvestment.YouthID != -1)
            {
                creditTo = Globals.GlobalYouth.Where(y => y.YouthID == newInvestment.YouthID).Select(y => y.FirstName + " " + y.LastName).Single();
            }
            else if (newInvestment.CreditTo == "general fund")
            {
                creditTo = "General Fund";
            }
            else
            {
                creditTo = "";
            }

            if(newInvestment.Reinvst == true)
            {
                ifWin = "Reinvest";
            }
            else
            {
                ifWin = "Check";
            }
            stamper.AcroFields.SetField("YEAR HEADER", newInvestment.Date.Year.ToString());
            stamper.AcroFields.SetField("Certificate Number", newInvestment.CertificateNumber);
            stamper.AcroFields.SetField("YEAR", newInvestment.Date.Year.ToString());
            stamper.AcroFields.SetField("DONATION", "$" + newInvestment.Amount.ToString());
            stamper.AcroFields.SetField("YOUTH CREDIT", creditTo);
            stamper.AcroFields.SetField("INVESTOR NAME", this.Investor.FirstName + " " + this.Investor.LastName);
            stamper.AcroFields.SetField("DATE", DateTime.Now.ToShortDateString());
            stamper.AcroFields.SetField("START DATE", Globals.ProgramStartDate.ToShortDateString());
            stamper.AcroFields.SetField("END DATE", Globals.ProgramEndDate.ToShortDateString());
            stamper.AcroFields.SetField("ADDRESS", this.Investor.Address);
            stamper.AcroFields.SetField("CITY", this.Investor.City);
            stamper.AcroFields.SetField("STATE", this.Investor.State);
            stamper.AcroFields.SetField("ZIP", this.Investor.Zip);
            stamper.AcroFields.SetField("PHONE", this.Investor.Phone);
            stamper.AcroFields.SetField("EMAIL", this.Investor.Email);
            stamper.AcroFields.SetField("IF WIN", ifWin);

            stamper.FormFlattening = true;
        }

        private bool PrintPDF(Investment2 newInvestment)
        {
            //Create the PDF for printing
            string FileName = "FIF_" + this.Investor.LastName + this.Investor.FirstName + ".pdf";
            string tempPath = Path.GetTempPath() + FileName;
            try
            {
                //Working code that creates a printable in-memory pdf
                using (PdfReader reader = new PdfReader(Properties.Resources.FIF_CertificateTemplate))
                {
                    using (FileStream fs = new FileStream(tempPath, FileMode.Create))
                    {
                        using (PdfStamper stamper = new PdfStamper(reader, fs))
                        {
                            stampFields(stamper, newInvestment);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(String.Format("Unable to create or print pdf file. \nError Message: {0}", ex.Message));
                File.Delete(tempPath);
                return false;
            }
            try
            {
                string printerPath = "";
                PrintDialog pd = new PrintDialog();
                var result = pd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    printerPath = pd.PrinterSettings.PrinterName;
                }
                else
                {
                    File.Delete(tempPath);
                    return false;
                }

                using (System.Diagnostics.Process process = new System.Diagnostics.Process())
                {

                    process.StartInfo.FileName = tempPath;
                    process.StartInfo.Verb = "printto";
                    process.StartInfo.Arguments = "\"" + printerPath + "\"";

                    process.Start();

                    // I have to use this in case of Adobe Reader to close the window
                    process.WaitForInputIdle();
                    process.Kill();
                    File.Delete(tempPath);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(String.Format("Unable to send PDF to the printer.  \nError Message: ", ex.Message));
                File.Delete(tempPath);
                return false;
            }
            return true;
        }

        private bool SavePDFToDisk(Investment2 newInvestment)
        {
            //Code that works for emailing and saving, printing
            string FileName = "\\FIF_" + this.Investor.LastName + this.Investor.FirstName + "_" + newInvestment.CertificateNumber + ".pdf";

            if(!Directory.Exists(Globals.SaveFilePath))
            {
                MessageBox.Show("Please select a folder to save the PDF to.  This folder will become the default location for future saves.  The default location can be changed in the user settings window.");
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if(FBD.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show(string.Format("A valid file path is required.  Unable to create and save PDF(s) at this time."));
                    return false;
                }
                if(FBD.SelectedPath == "")
                {
                    MessageBox.Show(string.Format("A valid file path is required.  Unable to create and save PDF(s) at this time."));
                    return false;
                }
                else
                {
                    Globals.SaveFilePath = FBD.SelectedPath;
                }
            }
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    //Create the PDF
                    using (PdfReader reader = new PdfReader(Properties.Resources.FIF_CertificateTemplate))
                    {
                        using (PdfStamper stamper = new PdfStamper(reader, memoryStream))
                        {
                            stampFields(stamper, newInvestment);
                        }
                    }
                    byte[] bytes = memoryStream.ToArray();
                    File.WriteAllBytes(Globals.SaveFilePath + FileName, bytes);
                    memoryStream.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("There was a problem creating and saving a PDF for at least one of the investments.  Please check your records.  \nError Message: {0}", ex.Message));
                return false;
            }
            return true;
        }

        private bool EmailPDF(Investment2 newInvestment)
        {
            byte[] bytes;
            string FileName;
            try //Try to generate the PDF in memory
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {

                    //Create the PDF
                    FileName = "FIF_" + this.Investor.LastName + this.Investor.FirstName + "_" + newInvestment.CertificateNumber + ".pdf";
                    using (PdfReader reader = new PdfReader(Properties.Resources.FIF_CertificateTemplate))
                    {
                        using (PdfStamper stamper = new PdfStamper(reader, memoryStream))
                        {
                            stampFields(stamper, newInvestment);
                        }
                    }
                    bytes = memoryStream.ToArray();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("For at least one of the investments the program was unable to generate PDF for emailing.  Please check your records to verify.  \nError Message: {0}", ex.Message));
                return false;
            }

            //PDF is created and in memory stream.  

            IMessageVariablesProvider[] emailVariableProviders = { 
                this.Investor, newInvestment, new ProgramVariablesAndValuesProvider()
            };
            try
            {
                EmailMessageCreator emailMessageCreator = new EmailMessageCreator(emailVariableProviders);
                try
                {
                    MailMessage mm = new MailMessage(Globals.AdminEmail, this.Investor.Email);
                    mm.Subject = emailMessageCreator.getInjectedEmailSubject();
                    mm.Body = emailMessageCreator.getInjectedEmailMessage();
                    mm.Attachments.Add(new Attachment(new MemoryStream(bytes), FileName));
                    mm.IsBodyHtml = true;
                    SmtpClient smpt = new SmtpClient();
                    smpt.Host = "smtp." + Globals.AdminEmail.Substring(Globals.AdminEmail.IndexOf("@") + 1);
                    smpt.EnableSsl = true;
                    System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                    NetworkCred.UserName = Globals.AdminEmail;
                    NetworkCred.Password = Globals.AdminPassword;
                    smpt.UseDefaultCredentials = true;
                    smpt.Credentials = NetworkCred;
                    smpt.Port = 587;
                    smpt.Send(mm);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(string.Format("For at least one of the investments the program was unable to email PDF.  Please check your records to verify.  \nError Message: {0}", ex.Message));
                    return false;
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            return true;
        }

        private string CreateEmailMessage(DateTime DateOfCertificate, DateTime AwardsBegin, DateTime AwardsEnd, string RecipientFirstName)
        {
            string message = String.Format(@"Dear {0},<br/><br/>
                                             Thank You for supporting the St. Gabriel Youth fundraiser, 
                                             Futures in Faith {1}.<br/><br/>
                                             Attached should be your Stock Certificate(s) in PDF format.   Please read it carefully to verify the accuracy of your information, 
                                             including the street address which will be used for mailing the newsletters and 
                                             invitation to the Stockholders’ Meeting.  Any corrections can be sent by replying 
                                             to this email.<br/><br/>
                                             Secondly, the certificate includes information about how the weekly winner is 
                                             determined by:<br/>
                                               - the stock certificate number (upper middle area) AND<br/>
                                               - the Dow Jones Industrial Average closing points (as published in the newspaper 
                                             and on-line).<br/>
                                             The weekly dividend ($50 prize) to be awarded on each Friday begins {2} and 
                                             concludes {3}.<br/><br/>
                                             May God bless and guide us through this year!  And, again, THANK
                                             YOU very much for your generosity and support of St. Gabriel Youth!", RecipientFirstName, DateOfCertificate.Year, AwardsBegin.ToShortDateString(), AwardsEnd.ToShortDateString());
            return message;
        }

        public string GetEmailMessageBody(Investment2 investment)
        {
            StringBuilder injectedMessage = new StringBuilder();
            bool getNextChar = false;
            bool skipNext = false;
            bool indexOverNine = false;
            for (int i = 0; i < Globals.EmailMessage.Length; i++)
            {
                if(skipNext)
                {
                    skipNext = false;
                    continue;
                }
                if (getNextChar)
                {
                    int currentIndex = Convert.ToInt32(System.Char.GetNumericValue(Globals.EmailMessage[i]));

                    if (indexOverNine)
                    {
                        currentIndex = Convert.ToInt32(Globals.EmailMessage[i].ToString() + Globals.EmailMessage[i+1].ToString());
                        skipNext = true;
                    }

                    injectWordIntoEmailMessageBody(injectedMessage, currentIndex, investment);
                    getNextChar = false;

                    if (currentIndex == 9)
                    {
                        indexOverNine = true;
                    }

                    continue;
                }
                else if (Globals.EmailMessage[i] == '{')
                {
                    getNextChar = true;
                    continue;
                }
                else if (Globals.EmailMessage[i] == '}')
                {
                    getNextChar = false;
                    continue;
                }
                else
                {
                    injectedMessage.Append(Globals.EmailMessage[i]);
                }
            }

            System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("\n");
            string result = rgx.Replace(injectedMessage.ToString(), "<br>");
            return result;
        }

        public string GetEmailMessageSuject(Investment2 investment)
        {
            StringBuilder injectedMessage = new StringBuilder();
            bool getNextChar = false;
            foreach (char c in Globals.EmailSubject)
            {
                if (getNextChar)
                {
                    injectWordIntoEmailMessageSubject(injectedMessage, Convert.ToInt32(System.Char.GetNumericValue(c)), investment);
                    getNextChar = false;
                    continue;
                }
                else if (c == '{')
                {
                    getNextChar = true;
                    continue;
                }
                else if (c == '}')
                {
                    getNextChar = false;
                    continue;
                }
                else
                {
                    injectedMessage.Append(c);
                }
            }
            System.Text.RegularExpressions.Regex rgx = new System.Text.RegularExpressions.Regex("\n");
            string result = rgx.Replace(injectedMessage.ToString(), "<br>");
            return result;
        }

        private void injectWordIntoEmailMessageBody(StringBuilder strBldr, int index, Investment2 _investment)
        {
            switch (Globals.EmailMessageVariables[index])
            {
                case "Amount":
                    foreach (char c in _investment.Amount.ToString())
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "CertificateNumber":
                    foreach (char c in _investment.CertificateNumber)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "Date":
                    foreach (char c in _investment.Date.ToShortDateString())
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "Address":
                    foreach (char c in Investor.Address)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "City":
                    foreach (char c in Investor.City)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "State":
                    foreach (char c in Investor.State)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "Zip":
                    foreach (char c in Investor.Zip)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "Email":
                    foreach (char c in Investor.Email)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "FirstName":
                    foreach (char c in Investor.FirstName)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "LastName":
                    foreach (char c in Investor.LastName)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "LabelName":
                    foreach (char c in Investor.LabelName)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "Phone":
                    foreach (char c in Investor.Phone)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "ProgramStartDate":
                    foreach (char c in Globals.ProgramStartDate.ToShortDateString())
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "ProgramEndDate":
                    foreach (char c in Globals.ProgramEndDate.ToShortDateString())
                    {
                        strBldr.Append(c);
                    }
                    break;
                default:
                    break;
            }
        }

        private void injectWordIntoEmailMessageSubject(StringBuilder strBldr, int index, Investment2 _investment)
        {
            switch (Globals.EmailSubjectVariables[index])
            {
                case "Amount":
                    foreach (char c in _investment.Amount.ToString())
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "CertificateNumber":
                    foreach (char c in _investment.CertificateNumber)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "Date":
                    foreach (char c in _investment.Date.ToShortDateString())
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "Address":
                    foreach (char c in Investor.Address)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "City":
                    foreach (char c in Investor.City)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "State":
                    foreach (char c in Investor.State)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "Zip":
                    foreach (char c in Investor.Zip)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "Email":
                    foreach (char c in Investor.Email)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "FirstName":
                    foreach (char c in Investor.FirstName)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "LastName":
                    foreach (char c in Investor.LastName)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "LabelName":
                    foreach (char c in Investor.LabelName)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "Phone":
                    foreach (char c in Investor.Phone)
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "ProgramStartDate":
                    foreach (char c in Globals.ProgramStartDate.ToShortDateString())
                    {
                        strBldr.Append(c);
                    }
                    break;
                case "ProgramEndDate":
                    foreach (char c in Globals.ProgramEndDate.ToShortDateString())
                    {
                        strBldr.Append(c);
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
