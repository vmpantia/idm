namespace IDM.Web.Models
{
    public class Mail
    {
        public Guid InternalID { get; set; }
        public string MailAddress { get; set; }
        public string AliasName { get; set; }
        public string MailType { get; set; }
        public string ReceiveType { get; set; }
        public int PrimaryFlag { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
