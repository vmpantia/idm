namespace IDM.Web.Models
{
    public class Account
    {
        public Guid InternalID { get; set; }
        public string AccountName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public string FullName { 
            get
            {
                if(string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName))
                    return "N/A";

                return string.Concat(LastName,", ", FirstName);
            } 
        }
    }
}
