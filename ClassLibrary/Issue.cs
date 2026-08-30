

namespace ClassLibrary
{
    public class Issue
    {
        public string Id { get; set; }
        public string? Location { get; set; }
        public string? Category { get; set; }
        public string? Description { get; set; }
        public string? FilePath { get; set; }

        public override string ToString()
        {
            return $"{Category} Issue in {Location}. \nDescription: {Description}";
        }
    }


}
