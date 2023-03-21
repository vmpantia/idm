namespace IDM.Business.Models.Request
{
    public class RequestBase
    {
        public string FunctionID { get; set; }
        public string RequestStatus { get; set; }


        public Guid UserID { get; set; }    
    }
}
