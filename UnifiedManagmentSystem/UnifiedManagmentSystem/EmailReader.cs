using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net.Mail;
using AE.Net.Mail;


namespace UnifiedManagmentSystem
{
    /// <summary>
    /// Pulls relevant content from a recieved email
    /// in a specified account from a specified sender.
    /// </summary>
    class EmailReader
    {

        public void Run()
        {
             using (var ic = new AE.Net.Mail.ImapClient("imap.gmail.com", "email@gmail.com", "mypassword", ImapClient.AuthMethods.Login, 993, true))
             {
                 ic.SelectMailbox("INBOX");

                //AE.Net.Mail.MailMessage mm = 
                ic.NewMessage
                 //(0, 1, false, false);

         
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

    ic.Disconnect();
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
