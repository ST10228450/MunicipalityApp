using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Announcement
    {
        public string AnnouncementId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public Announcement CreatedAnnouncement { get; private set; }
    }
}
