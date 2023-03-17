namespace IDM.Web.Models
{
    public class Group
    {
        public Guid InternalID { get; set; }
        public string SGAliasName { get; set; }
        public string SGDisplayName { get; set; }
        public string SGClass { get; set; }
        public Guid Owner_InternalID { get; set; }
        public Guid Admin1_InternalID { get; set; }
        public Guid Admin2_InternalID { get; set; }
        public Guid Admin3_InternalID { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
