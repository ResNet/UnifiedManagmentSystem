using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AE.Net.Mail;


namespace UnifiedManagmentSystem
{
    /// <summary>
    /// Pulls relevant content from a recieved email
    /// in a specified account from a specified sender.
    /// </summary>
    class EmailReader
    {

        //public void Run()
            /* using (var ic = new AE.Net.Mail.ImapClient("imap.gmail.com", "email@gmail.com", "mypassword", ImapClient.AuthMethods.Login, 993, true))
             {    ic.SelectMailbox("INBOX");
                  ic.NewMessage ice = new EventHandler<AE.Net.Mail.Imap.MessageEventArgs>(object sender, EventArgs e);
             }*/
                //AE.Net.Mail.MailMessage mm = 
                 //(0, 1, false, false);
    public List<MailMessage> ReadMail()
    {
        List<MailMessage> msgs;
        using (var ic = new AE.Net.Mail.ImapClient("imap.gmail.com", "username@gmail.com", "pass-to-gmail", ImapClient.AuthMethods.Login, 993, true))
        {
            ic.SelectMailbox("INBOX");
            msgs = new List<MailMessage>(ic.GetMessageCount());
            msgs = ic.GetMessages(0, 100, false, true).ToList();

            ic.Disconnect();
        }
        return msgs;
    }
         
    //            Logger.WriteLine("IMAP : Found " + mm.Count() + " messages in Inbox");

    //            foreach (MailMessage m in mm.Where(itm => itm.Subject.ToLower().Contains(“mysubject”)))
    //            {
    //                var attachment = m.Attachments.Where(itm => itm.Filename.ToLower().StartsWith(“myattachment)).FirstOrDefault(); //ignore image attachments, etc

    //    if (attachment != null)
    //    {
    //        if (SendToDB(attachment))
    //        {
    //            ic.DeleteMessage(m);
    //            Logger.WriteLine(string.Format("{0} Email deleted”, m.Uid));
    //        }
    //    }
    //}

    //ic.Disconnect();
  }
}


        //open a connection to a given email account
        
        //start a thread that checks for the latest DateTime email
        //if there is an earlier DateTime email this is a new email
        //note* need to check this quickly or if emails come in at
        //note* close intervals item will be missed.

        //if this new email is from a sender that is contained in the
        //"workorder senders" list, we have a useful email

        //grab the clients full name, argonetID, room#, Description
        //of problem, and if filed in Magic or SchoolDude

        //create an email object with this data
    }
}
