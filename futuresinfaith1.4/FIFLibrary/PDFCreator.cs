using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using System.IO;
using System.Windows.Forms;
using System.Net.Mail;

namespace FIFLibrary
{
    public class PDFCreator
    {
        private Investor2 Investor;
        public PDFCreator(Investor2 investor)
        {
            this.Investor = investor;
        }
        public void createPDF(Investment2 newInvestment, string EmailORPrint)
        {
            SavePDFToDisk(newInvestment); //always save PDF to disk

            if (EmailORPrint == "print")
            {
                PrintPDF(newInvestment);
            }

            else
            {
                EmailPDF(newInvestment);
            }
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
                System.Diagnostics.Process process = new System.Diagnostics.Process();
                
                    process.StartInfo.FileName = tempPath;
                    process.StartInfo.Verb = "printto";
                    process.StartInfo.Arguments = "\"" + printerPath + "\"";

                    process.Start();

                    // I have to use this in case of Adobe Reader to close the window
                    process.WaitForInputIdle();
                    process.Kill();
                    File.Delete(tempPath);
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
            string path;
            //Code that works for emailing and saving, hopefully printing too
            string FileName = "\\FIF_" + this.Investor.LastName + this.Investor.FirstName + "_" + newInvestment.CertificateNumber + ".pdf";

            if(!Directory.Exists(Globals.SaveFilePath))
            {
                MessageBox.Show("Please select a folder to save the PDF to.  This folder will become the default location for future saves.  The default location can be changed in the user settings window.");
                FolderBrowserDialog FBD = new FolderBrowserDialog();
                if(FBD.ShowDialog() != DialogResult.OK)
                {
                    MessageBox.Show(string.Format("Unable to save PDF at this time."));
                    return false;
                }
                if(FBD.SelectedPath == "")
                {
                    MessageBox.Show(string.Format("Unable to save PDF at this time."));
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
                MessageBox.Show(string.Format("Unable to save PDF at this time.  \nError Message: {0}", ex.Message));
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
                    FileName = "FIF_" + this.Investor.LastName + this.Investor.FirstName + ".pdf";
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
                MessageBox.Show(string.Format("Unable to generate PDF.  \nError Message: {0}", ex.Message));
                return false;
            }

            //PDF is created and in memory stream.  
            try
            {
                MailMessage mm = new MailMessage(Globals.AdminEmail, this.Investor.Email);
                mm.Subject = newInvestment.Date.Year.ToString() + " - St. Gabriel Futures in Faith Stock Certificate";
                mm.Body = CreateEmailMessage(newInvestment.Date, Globals.ProgramStartDate, Globals.ProgramEndDate, this.Investor.FirstName);
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
            catch(Exception ex)
            {
                MessageBox.Show(string.Format("Unable to email PDF.  \nError Message: {0}",ex.Message));
                return false;
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
    }
}
