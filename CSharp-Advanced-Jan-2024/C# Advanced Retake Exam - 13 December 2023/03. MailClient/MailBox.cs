using System.Text;

namespace MailClient
{
    public class MailBox
    {
        public int Capacity { get; set; }
        public List<Mail> Inbox { get; set; }
        public List<Mail> Archive { get; set; }

        public MailBox(int capacity)
        {
            Capacity = capacity;
            Inbox = new List<Mail>();
            Archive = new List<Mail>();
        }

        public void IncomingMail(Mail mail)
        {
            if (Capacity > 0)
            {
                Inbox.Add(mail);
                Capacity--;
            }
        }

        public bool DeleteMail(string sender)
        {
            Mail mail = Inbox.FirstOrDefault(x => x.Sender == sender);
            if (mail != null)
            {
                Inbox.Remove(mail);
                Capacity++;
                return true;
            }
            return false;
        }

        public int ArchiveInboxMessages()
        {
            int count = 0;
            foreach (var mail in Inbox)
            {
                Capacity++;
                Archive.Add(mail);
                count++;
            }
            Inbox.Clear();
            return count;
        }

        public string GetLongestMessage()
        {
            Mail mail = Inbox.MaxBy(x => x.Body.Length);
            return mail.ToString();
        }

        public string InboxView()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Inbox:");
            foreach (var mail in Inbox)
            {
                sb.AppendLine(mail.ToString().Trim());
            }
            return sb.ToString().Trim();
        }
    }
}
