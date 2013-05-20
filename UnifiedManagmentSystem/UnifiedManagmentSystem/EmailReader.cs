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
        private const int MILLIS_TO_WAIT_refine = 10;//lower these numbers to possibly speed up response
        private const int MILLIS_TO_WAIT_main = 20;
        Lazy<MailMessage>[] messages=new Lazy<MailMessage>[10];
       
        public void Run(){
            Console.WriteLine("running");

            while(true){
                Console.WriteLine("GOT HERE");
                using (var ic = new AE.Net.Mail.ImapClient("IMAP.gmail.com", "pilhlip@gmail.com", /*PhillipsPassword*/, ImapClient.AuthMethods.Login, 993, true)){
                    ic.SelectMailbox("INBOX");
                    bool headersOnly = false;
                    //initial population of new/unseen messages
                    Console.WriteLine("connected?");
                    try
                    {
                        Monitor.Enter(this);
                        messages = ic.SearchMessages(SearchCondition.Unseen(), headersOnly);
                    }
                    finally
                    {
                        Monitor.Exit(this);
                    }
                    
                    Console.WriteLine("spawning child thread");
                    //need to spawn a thread with the mesages array to check for more conditions
                    Thread messageSearcher = new Thread(new ThreadStart(refine));
                    messageSearcher.Start();
                    Console.WriteLine("Child Spawned");
                    messageSearcher.Join();
                    Console.WriteLine("child joined");
                }
            }
        }
        public void refine()
        {
            Console.WriteLine("in child code");
            try
            {

                Monitor.Enter(this);
                foreach (Lazy<MailMessage> message in messages)
                {
                    MailMessage m = message.Value;
                    string sender = m.From.Address;

                    Console.WriteLine("Email with subject {0} was sent by sender {1}, at {2}", m.Subject, sender, m.Date);


                }
            }
            finally
            {
                Monitor.Exit(this);
                Console.WriteLine("exiting");
            }
        }
#region unused code
                //AE.Net.Mail.MailMessage mm = 
                 //(0, 1, false, false);
    /*public List<MailMessage> ReadMail()
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
    }*/
         
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
#endregion


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
