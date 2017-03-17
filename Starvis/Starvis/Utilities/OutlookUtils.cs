using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OutLookApp = Microsoft.Office.Interop.Outlook.Application;
using System.Runtime.InteropServices;
using MicrosoftOutLook = Microsoft.Office.Interop.Outlook;
using StarvisDB;

namespace Starvis.Utilities
{
    public class OutlookUtils
    {
        public void HandleOutlookOperations(int rowID)
        {
            var db = new Models();
            OutlookDB row = db.OutlookDB.Where(w => w.OutlookID == rowID).FirstOrDefault();
            if (row.Type != null)
            {
                switch (row.Type)
                {
                    case "Read Email":
                        ReadAnEmail(row);
                        break;
                    case "Search Email":
                        SearchEmail(row);
                        break;
                    case "Compose Email":
                        OpenComposeEmail(row);
                        break;
                }
            }
        }

        public void ReadAnEmail(OutlookDB row)
        {
            try
            {
                List<string> mailsToBeRead = new List<string>();
                OutLookApp app = new OutLookApp();
                MicrosoftOutLook.NameSpace outlookNS = app.GetNamespace("MAPI");
                MicrosoftOutLook.MAPIFolder inboxFolder
                  = outlookNS.GetDefaultFolder(MicrosoftOutLook.OlDefaultFolders.olFolderInbox);

                MicrosoftOutLook.Items items = inboxFolder.Items.Restrict("[Unread] = true");

                foreach (object mail in items)
                {
                    if (mail is MicrosoftOutLook.MailItem)
                    {
                        MicrosoftOutLook.MailItem email = (MicrosoftOutLook.MailItem)mail;
                        if (!string.IsNullOrWhiteSpace(row.SearchKey))
                        {
                            if (!email.Body.Contains(row.SearchKey))
                            {
                                continue;
                            }
                        }

                        //if (!string.IsNullOrWhiteSpace(row.From) && row.From != email.SenderEmailAddress)
                        //{
                        //    continue;
                        //}

                        //if (!string.IsNullOrWhiteSpace(row.To))
                        //{
                        //    foreach (MicrosoftOutLook.Recipient recepient in email.Recipients)
                        //    {

                        //    }
                        //}
                        if (mailsToBeRead.Count > row.UnReadMailCount)
                        {
                            continue;
                        }
                        mailsToBeRead.Add("From:" + email.SenderName + ", Subject:" + email.Subject + ", MailBody:" + email.Body);
                    }
                }
                int mailNumber = 1;
                foreach (string email in mailsToBeRead)
                {
                    TextToSpeech.Speak("Mail: " + mailNumber + "," + email);
                    mailNumber++;
                }
            }
            catch (Exception ex)
            {

            }
        }

        public void OpenComposeEmail(OutlookDB row)
        {
            try
            {
                string outlookPath = @"C:\Program Files\Microsoft Office\Office15\outlook.exe";
                string arguments = "/c ipm.note /m \"" + row.To + @"&subject=" + row.Subject + @"&body=" + row.Body + "\"";
                System.Diagnostics.Process.Start(outlookPath, arguments);
            }
            catch (Exception ex)
            {

            }
        }


        public void SearchEmail(OutlookDB row)
        {
            try
            {
                List<string> mailsToBeRead = new List<string>();
                OutLookApp app = new OutLookApp();
                MicrosoftOutLook.NameSpace outlookNS = app.GetNamespace("MAPI");
                MicrosoftOutLook.MAPIFolder inboxFolder
                  = outlookNS.GetDefaultFolder(MicrosoftOutLook.OlDefaultFolders.olFolderInbox);

                MicrosoftOutLook.Items items = inboxFolder.Items.Restrict("[Unread] = true");

                foreach (object mail in items)
                {
                    if (mail is MicrosoftOutLook.MailItem)
                    {
                        MicrosoftOutLook.MailItem email = (MicrosoftOutLook.MailItem)mail;
                        if (!string.IsNullOrWhiteSpace(row.SearchKey))
                        {
                            if (!email.Body.Contains(row.SearchKey))
                            {
                                continue;
                            }
                        }

                        //if (!string.IsNullOrWhiteSpace(row.From) && row.From != email.SenderEmailAddress)
                        //{
                        //    continue;
                        //}

                        //if (!string.IsNullOrWhiteSpace(row.To))
                        //{
                        //    foreach (MicrosoftOutLook.Recipient recepient in email.Recipients)
                        //    {

                        //    }
                        //}
                        //if (mailsToBeRead.Count > row.UnReadMailCount)
                        //{
                        //    continue;
                        //}
                        mailsToBeRead.Add("From:" + email.SenderName + ", Subject:" + email.Subject);
                    }
                }
                int mailNumber = 1;
                foreach (string email in mailsToBeRead)
                {
                    TextToSpeech.Speak("Mail Number: " + mailNumber + "," + email);
                    mailNumber++;
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}
