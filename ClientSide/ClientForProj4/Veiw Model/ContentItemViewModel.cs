using LMSLibrary.Models;
using LMSLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.UI;

namespace Project_3___3.Veiw_Model
{
    public class ContentItemViewModel
    {
        public ContentItemViewModel(List<ContentItem> contentItems)
        {
            ContentItem = new ContentItem();
            AssignmentItem = new AssignmentItem();
            PageItem = new PageItem();
            FileItem = new FileItem();
            ContentItems = contentItems;
        }

        public ContentItemViewModel(List<ContentItem> contentItems, ObservableCollection<Assignment> assignments)
        {
            ContentItem = new ContentItem();
            AssignmentItem = new AssignmentItem();
            PageItem = new PageItem();
            FileItem = new FileItem();
            ContentItems = contentItems;
            Assignments = assignments;

        }

        public ContentItemViewModel(List<ContentItem> contentItmes, String selected)
        {
            for (int i = 0; i < contentItmes.Count(); i++)
            {
                if (selected.IndexOf(contentItmes[i].Name.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    if (contentItmes[i] is AssignmentItem)
                    {
                       AssignmentItem = (contentItmes[i] as AssignmentItem);
                        ContentItem = new ContentItem();
                        PageItem = new PageItem();
                        FileItem = new FileItem();
                    }
                    else if (contentItmes[i] is FileItem)
                    {
                        FileItem = (contentItmes[i] as FileItem);
                        ContentItem = new ContentItem();
                        AssignmentItem = new AssignmentItem();
                        PageItem = new PageItem();
                    }
                    else if (contentItmes[i] is PageItem)
                    {
                        PageItem = (contentItmes[i] as PageItem);
                        ContentItem = new ContentItem();
                        AssignmentItem = new AssignmentItem();
                        FileItem = new FileItem();
                    }
                    ContentItem = contentItmes[i];
                    break;
                }
            }
            ContentItems = contentItmes;
        }

        public String Search { get; set; }
        public ContentItem ContentItem { get; set; }
        public AssignmentItem AssignmentItem { get; set; }
        public  FileItem FileItem { get; set; }
        public PageItem PageItem { get; set; }

        public List<ContentItem> ContentItems;

        public ObservableCollection<Assignment> Assignments { get; set; }

        public String Name
        {
            get { return ContentItem.Name; }
            set {ContentItem.Name = value; }
        }

        public String Description
        {
            get { return ContentItem.Description; }
            set { ContentItem.Description = value; }
        }


        public Assignment Assignment
        {
            get { return AssignmentItem.assignment; }
            set { AssignmentItem.assignment = value; }
        }

        public String HTMLBody
        {
            get { return PageItem.HTMLBody; }
            set { PageItem.HTMLBody = value; }
        }

        public String FilePath
        {
            get { return FileItem.FilePath; }
            set { FileItem.FilePath = value; }
        }


        public void AddContentItem(int type)
        {
            if (type == 0)
            {
                AssignmentItem.Name = ContentItem.Name;
                AssignmentItem.Description = ContentItem.Description;
                ContentItems.Add(AssignmentItem);
            }
            else if (type == 1)
            {
               PageItem.Name = ContentItem.Name;
               PageItem.Description = ContentItem.Description;
                ContentItems.Add(PageItem);
            }
            else if (type == 2)
            {
                FileItem.Name = ContentItem.Name;
                FileItem.Description = ContentItem.Description;
                ContentItems.Add(FileItem);
            }
        }

        public void AddContentItem(int type, Assignment assignment)
        {
            if (type == 0)
            {
                AssignmentItem.Name = ContentItem.Name;
                AssignmentItem.Description = ContentItem.Description;
                AssignmentItem.assignment = assignment;
                ContentItems.Add(AssignmentItem);
            }
            else if (type == 1)
            {
                PageItem.Name = ContentItem.Name;
                PageItem.Description = ContentItem.Description;
                ContentItems.Add(PageItem);
            }
            else if (type == 2)
            {
                FileItem.Name = ContentItem.Name;
                FileItem.Description = ContentItem.Description;
                ContentItems.Add(FileItem);
            }
        }

        /* public void AddContentItem(string selected)
         {
             for (int i = 0; i < Assignments.Count(); i++)
             {
                 if (selected.IndexOf(Assignments[i].Name.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                 {
                     (ContentItem as AssignmentItem).assignment = Assignments[i];
                 }
             }
             ContentItems.Add(ContentItem);
         }*/

        public void ModifyContentItem()
        {

        }

        public void RemoveContentItem()
        {
            ContentItems.Remove(ContentItem);
        }

        public void SearchContentItem()
        {

            for (int i = 0; i < ContentItems.Count(); i++)
            {
                if (Search == null)
                {

                }
                else if (ContentItems[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {

                }
                else
                {
                    ContentItems.Remove(ContentItems[i]);
                    i--;
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
