

namespace ClassLibrary
{
    public class ServiceRequest
    {
        public string RequestId { get; set; } = "";
        public string Category { get; set; } = "";
        public string Location { get; set; } = "";
        public string Priority { get; set; } = "Medium";
        public string Status { get; set; } = "Submitted";
        public string Description { get; set; } = "";
        public DateTime SubmittedDate { get; set; } = DateTime.Today;

        public List<string> History { get; set; } = new List<string>();
    }
}
