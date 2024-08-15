using LMSLibrary;
using Project_3___3.Veiw_Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ClientForProj4
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            DataContext = new MainVeiwModel();
            (DataContext as MainVeiwModel).LaunchUserSelection();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (CourseList.Visibility == Visibility.Visible)
            {
                (DataContext as MainVeiwModel).SearchCourses();
            }
            else if (PersonList.Visibility == Visibility.Visible)
            {
                (DataContext as MainVeiwModel).SearchPeople();
            }
            else if (AssignmentGroupList.Visibility == Visibility.Visible)
            {
                (DataContext as MainVeiwModel).SearchAssignmentGroup();
            }
            else if (ModulesList.Visibility == Visibility.Visible)
            {
                (DataContext as MainVeiwModel).SearchModules();
            }
            else if (AnnouncementsList.Visibility == Visibility.Visible)
            {
                (DataContext as MainVeiwModel).SearchAnnouncements();
            }
            else if (MasterRosterList.Visibility == Visibility.Visible)
            {
                (DataContext as MainVeiwModel).SearchMasterRoster();
            }
            else if (AssignmentList.Visibility == Visibility.Visible)
            {
                (DataContext as MainVeiwModel).SearchAssignments();
            }
            else if (ContentItemList.Visibility == Visibility.Visible)
            {
                (DataContext as MainVeiwModel).SearchContentItems();
            };
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            if (!((DataContext as MainVeiwModel).user is Student))
            {
                if (CourseList.Visibility == Visibility.Visible)
                {
                    (DataContext as MainVeiwModel).AddCourse();
                }
                else if (PersonList.Visibility == Visibility.Visible)
                {
                    (DataContext as MainVeiwModel).SelectPerson();
                }
                else if (AssignmentGroupList.Visibility == Visibility.Visible)
                {
                    (DataContext as MainVeiwModel).AddAssignmentGroup();
                }
                else if (ModulesList.Visibility == Visibility.Visible)
                {
                    (DataContext as MainVeiwModel).AddModule();
                }
                else if (AnnouncementsList.Visibility == Visibility.Visible)
                {
                    (DataContext as MainVeiwModel).AddAnnouncement();
                }
                else if (MasterRosterList.Visibility == Visibility.Visible)
                {
                    (DataContext as MainVeiwModel).AddPerson();
                }
                else if (AssignmentList.Visibility == Visibility.Visible)
                {
                    (DataContext as MainVeiwModel).AddAssignment();
                }
                else if (ContentItemList.Visibility == Visibility.Visible)
                {
                    (DataContext as MainVeiwModel).AddContentItem();
                }
            }
            else
            {
                AddButton.Visibility = Visibility.Collapsed;
                ModifyButton.Visibility = Visibility.Collapsed;
                RemoveButton.Visibility = Visibility.Collapsed;
                MasterRoster.Visibility = Visibility.Collapsed;
            }
        }

        private void Modify_Click(object sender, RoutedEventArgs e)
        {
            if (!((DataContext as MainVeiwModel).user is Student))
            {
                if (CourseList.Visibility == Visibility.Visible && CourseList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).ModifyCourse(CourseList.SelectedItem.ToString());
                }
                else if (PersonList.Visibility == Visibility.Visible && PersonList.SelectedItem != null)
                {
                    //(DataContext as MainVeiwModel).ModifyPerson(PersonList.SelectedItem.ToString());
                }
                else if (AssignmentGroupList.Visibility == Visibility.Visible && AssignmentGroupList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).ModifyAssignmentGroup(AssignmentGroupList.SelectedItem.ToString());
                }
                else if (ModulesList.Visibility == Visibility.Visible && ModulesList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).ModifyModule(ModulesList.SelectedItem.ToString());
                }
                else if (AnnouncementsList.Visibility == Visibility.Visible && AnnouncementsList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).ModifyAnnouncement(AnnouncementsList.SelectedItem.ToString());
                }
                else if (MasterRosterList.Visibility == Visibility.Visible && MasterRosterList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).ModifyPerson(MasterRosterList.SelectedItem.ToString());
                }
                else if (AssignmentList.Visibility == Visibility.Visible && AssignmentList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).ModifyAssignment(AssignmentList.SelectedItem.ToString());
                }
                else if (ContentItemList.Visibility == Visibility.Visible && ContentItemList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).ModifyContentItem(ContentItemList.SelectedItem.ToString());
                }
            }
            else
            {
                AddButton.Visibility = Visibility.Collapsed;
                ModifyButton.Visibility = Visibility.Collapsed;
                RemoveButton.Visibility = Visibility.Collapsed;
                MasterRoster.Visibility = Visibility.Collapsed;
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            if (!((DataContext as MainVeiwModel).user is Student))
            {
                if (CourseList.Visibility == Visibility.Visible && CourseList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).RemoveCourse(CourseList.SelectedItem.ToString());
                }
                else if (PersonList.Visibility == Visibility.Visible && PersonList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).RemovePersonFromClass(PersonList.SelectedItem.ToString());
                }
                else if (AssignmentGroupList.Visibility == Visibility.Visible && AssignmentGroupList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).RemoveAssignmentGroup(AssignmentGroupList.SelectedItem.ToString());
                }
                else if (ModulesList.Visibility == Visibility.Visible && ModulesList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).RemoveModule(ModulesList.SelectedItem.ToString());
                }
                else if (AnnouncementsList.Visibility == Visibility.Visible && AnnouncementsList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).RemoveAnnouncement(AnnouncementsList.SelectedItem.ToString());
                }
                else if (MasterRosterList.Visibility == Visibility.Visible && MasterRosterList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).RemovePerson(MasterRosterList.SelectedItem.ToString());
                }
                else if (AssignmentList.Visibility == Visibility.Visible && AssignmentList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).RemoveAssignment(AssignmentList.SelectedItem.ToString());
                }
                else if (ContentItemList.Visibility == Visibility.Visible && ContentItemList.SelectedItem != null)
                {
                    (DataContext as MainVeiwModel).RemoveContentItem(ContentItemList.SelectedItem.ToString());
                }
            }
            else
            {
                AddButton.Visibility = Visibility.Collapsed;
                ModifyButton.Visibility = Visibility.Collapsed;
                RemoveButton.Visibility = Visibility.Collapsed;
                MasterRoster.Visibility = Visibility.Collapsed;
            }
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            if (CourseList.Visibility == Visibility.Visible && CourseList.SelectedItem != null)
            {
                (DataContext as MainVeiwModel).SelectCourse(CourseList.SelectedItem.ToString());
                CourseList.Visibility = Visibility.Collapsed;
                MasterRoster.Visibility = Visibility.Collapsed;
                ChooseUser.Visibility = Visibility.Collapsed;
                if (AssignmentGroups.IsChecked == true)
                {
                    AssignmentGroupList.Visibility = Visibility.Visible;
                }
                else if (Modules.IsChecked == true)
                {
                    ModulesList.Visibility = Visibility.Visible;
                }
                else if (Announcements.IsChecked == true)
                {
                    AnnouncementsList.Visibility = Visibility.Visible;
                }
                else
                {
                    PersonList.Visibility = Visibility.Visible;
                }
                People.Visibility = Visibility.Visible;
                AssignmentGroups.Visibility = Visibility.Visible;
                Modules.Visibility = Visibility.Visible;
                Announcements.Visibility = Visibility.Visible;
            }
            else if (PersonList.Visibility == Visibility.Visible && PersonList.SelectedItem != null)
            {
                (DataContext as MainVeiwModel).ViewFullPersonInformation(PersonList.SelectedItem.ToString());
            }
            else if (AssignmentGroupList.Visibility == Visibility.Visible && AssignmentGroupList.SelectedItem != null)
            {
                (DataContext as MainVeiwModel).SelectAssignmentGroup(AssignmentGroupList.SelectedItem.ToString());
                (DataContext as MainVeiwModel).SearchAssignments();
                AssignmentGroupList.Visibility = Visibility.Collapsed;
                People.Visibility = Visibility.Collapsed;
                AssignmentGroups.Visibility = Visibility.Collapsed;
                Modules.Visibility = Visibility.Collapsed;
                Announcements.Visibility = Visibility.Collapsed;
                AssignmentList.Visibility = Visibility.Visible;
                if ((DataContext as MainVeiwModel).user is Student)
                {
                    AssignGrade.Visibility = Visibility.Collapsed;
                }
                else
                {
                    AssignGrade.Visibility = Visibility.Visible;
                }
            }
            else if (ModulesList.Visibility == Visibility.Visible && ModulesList.SelectedItem != null)
            {
                (DataContext as MainVeiwModel).SelectModule(ModulesList.SelectedItem.ToString());
                (DataContext as MainVeiwModel).SearchModules();
                AssignmentGroupList.Visibility = Visibility.Collapsed;
                People.Visibility = Visibility.Collapsed;
                AssignmentGroups.Visibility = Visibility.Collapsed;
                Modules.Visibility = Visibility.Collapsed;
                Announcements.Visibility = Visibility.Collapsed;
                ContentItemList.Visibility = Visibility.Visible;
                ModulesList.Visibility = Visibility.Collapsed;
            }

            if ((DataContext as MainVeiwModel).user is Student)
            {
                AddButton.Visibility = Visibility.Collapsed;
                ModifyButton.Visibility = Visibility.Collapsed;
                RemoveButton.Visibility = Visibility.Collapsed;
                MasterRoster.Visibility = Visibility.Collapsed;
            }
            else
            {
                AddButton.Visibility = Visibility.Visible;
                ModifyButton.Visibility = Visibility.Visible;
                RemoveButton.Visibility = Visibility.Visible;
            }
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (PersonList.Visibility == Visibility.Visible || AssignmentGroupList.Visibility == Visibility.Visible ||
                ModulesList.Visibility == Visibility.Visible || AnnouncementsList.Visibility == Visibility.Visible ||
                MasterRosterList.Visibility == Visibility.Visible)
            {
                (DataContext as MainVeiwModel).ReturnToCourses();
                CourseList.Visibility = Visibility.Visible;
                ChooseUser.Visibility = Visibility.Visible;
                if ((DataContext as MainVeiwModel).user is Student)
                {
                    MasterRoster.Visibility = Visibility.Collapsed;
                }
                else
                {
                    MasterRoster.Visibility = Visibility.Visible;
                }
                PersonList.Visibility = Visibility.Collapsed;
                AssignmentGroupList.Visibility = Visibility.Collapsed;
                ModulesList.Visibility = Visibility.Collapsed;
                AnnouncementsList.Visibility = Visibility.Collapsed;
                People.Visibility = Visibility.Collapsed;
                AssignmentGroups.Visibility = Visibility.Collapsed;
                Modules.Visibility = Visibility.Collapsed;
                Announcements.Visibility = Visibility.Collapsed;
                MasterRosterList.Visibility = Visibility.Collapsed;
            }
            else if (AssignmentList.Visibility == Visibility.Visible || ContentItemList.Visibility == Visibility.Visible)
            {
                (DataContext as MainVeiwModel).ReturnToCourse();
                CourseList.Visibility = Visibility.Collapsed;
                MasterRoster.Visibility = Visibility.Collapsed;
                if (AssignmentGroups.IsChecked == true)
                {
                    AssignmentGroupList.Visibility = Visibility.Visible;
                }
                else if (Modules.IsChecked == true)
                {
                    ModulesList.Visibility = Visibility.Visible;
                }
                else if (Announcements.IsChecked == true)
                {
                    AnnouncementsList.Visibility = Visibility.Visible;
                }
                else
                {
                    PersonList.Visibility = Visibility.Visible;
                }
                People.Visibility = Visibility.Visible;
                AssignmentGroups.Visibility = Visibility.Visible;
                Modules.Visibility = Visibility.Visible;
                Announcements.Visibility = Visibility.Visible;
                MasterRosterList.Visibility = Visibility.Collapsed;
                AssignmentList.Visibility = Visibility.Collapsed;
                AssignGrade.Visibility = Visibility.Collapsed;
                ContentItemList.Visibility = Visibility.Collapsed;
            }
        }

        private void Handle_Check(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            //(DataContext as MainVeiwModel).SelectCourseItem(rb.Name);
            if (rb.Name == "People")
            {
                PersonList.Visibility = Visibility.Visible;
                AssignmentGroupList.Visibility = Visibility.Collapsed;
                ModulesList.Visibility = Visibility.Collapsed;
                AnnouncementsList.Visibility = Visibility.Collapsed;
            }
            else if (rb.Name == "AssignmentGroups")
            {
                PersonList.Visibility = Visibility.Collapsed;
                AssignmentGroupList.Visibility = Visibility.Visible;
                ModulesList.Visibility = Visibility.Collapsed;
                AnnouncementsList.Visibility = Visibility.Collapsed;
            }
            else if (rb.Name == "Modules")
            {
                PersonList.Visibility = Visibility.Collapsed;
                AssignmentGroupList.Visibility = Visibility.Collapsed;
                ModulesList.Visibility = Visibility.Visible;
                AnnouncementsList.Visibility = Visibility.Collapsed;
            }
            else if (rb.Name == "Announcements")
            {
                PersonList.Visibility = Visibility.Collapsed;
                AssignmentGroupList.Visibility = Visibility.Collapsed;
                ModulesList.Visibility = Visibility.Collapsed;
                AnnouncementsList.Visibility = Visibility.Visible;
            }
        }

        private void MasterRoster_Click(object sender, RoutedEventArgs e)
        {
            if (!((DataContext as MainVeiwModel).user is Student))
            {
                CourseList.Visibility = Visibility.Collapsed;
                MasterRoster.Visibility = Visibility.Collapsed;
                PersonList.Visibility = Visibility.Collapsed;
                People.Visibility = Visibility.Collapsed;
                AssignmentGroups.Visibility = Visibility.Collapsed;
                Modules.Visibility = Visibility.Collapsed;
                Announcements.Visibility = Visibility.Collapsed;
                MasterRosterList.Visibility = Visibility.Visible;
                (DataContext as MainVeiwModel).ChangeTitleToMasterRoster();
            }
            else
            {
                AddButton.Visibility = Visibility.Collapsed;
                ModifyButton.Visibility = Visibility.Collapsed;
                RemoveButton.Visibility = Visibility.Collapsed;
                MasterRoster.Visibility = Visibility.Collapsed;
            }
        }

        private void AssignGrade_Click(object sender, RoutedEventArgs e)
        {
            if (AssignmentList.SelectedItem != null)
            {
                (DataContext as MainVeiwModel).AssignGrade(AssignmentList.SelectedItem.ToString());
            }
        }

        private void ChooseUser_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainVeiwModel).LaunchUserSelection();
            BadButton.Visibility = Visibility.Visible;
        }

        private void BadButton_Click(object sender, RoutedEventArgs e)
        {
            if ((DataContext as MainVeiwModel).user is Student)
            {
                AddButton.Visibility = Visibility.Collapsed;
                ModifyButton.Visibility = Visibility.Collapsed;
                RemoveButton.Visibility = Visibility.Collapsed;
                MasterRoster.Visibility = Visibility.Collapsed;
            }
            else
            {
                AddButton.Visibility = Visibility.Visible;
                ModifyButton.Visibility = Visibility.Visible;
                RemoveButton.Visibility = Visibility.Visible;
                MasterRoster.Visibility = Visibility.Visible;
            }
            BadButton.Visibility = Visibility.Collapsed;
            (DataContext as MainVeiwModel).SearchCourses();
        }
    }
}
