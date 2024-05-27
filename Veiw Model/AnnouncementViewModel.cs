using LMSLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_3___3.Veiw_Model
{
    public class AnnouncementViewModel
    {
        public AnnouncementViewModel(List<Announcement> announcements)
        {
            Announcement = new Announcement();
            Announcements = announcements;
        }

        public AnnouncementViewModel(List<Announcement> announcements, String selected)
        {
            Announcement = new Announcement();
            for (int i = 0; i < announcements.Count(); i++)
            {
                if (selected.IndexOf(announcements[i].Name.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    Announcement = announcements[i];
                }
            }
            Announcements = announcements;
        }

        public Announcement Announcement { get; set; }
        public List<Announcement> Announcements;

        public String Name
        {
            get { return Announcement.Name; }
            set { Announcement.Name = value; }
        }

        public String Content
        {
            get { return Announcement.Content; }
            set { Announcement.Content = value; }
        }

        public void AddAnnouncement()
        {
            Announcements.Add(Announcement);
        }

        public void ModifyAnnouncement()
        {

        }

        public void RemoveAnnouncement()
        {
            Announcements.Remove(Announcement);
        }
    }

}
