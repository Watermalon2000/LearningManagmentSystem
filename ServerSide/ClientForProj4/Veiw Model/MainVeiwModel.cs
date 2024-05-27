
using LMSLibrary;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Project_3___3.Dialogs;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using LMSLibrary.Models;
using SupportTicketApplication;
using Newtonsoft.Json;
using Windows.Devices.Enumeration.Pnp;

namespace Project_3___3.Veiw_Model
{
    internal class MainVeiwModel : INotifyPropertyChanged
    {
        public Person user;
        private Course selectedCourse;
        private AssignmentGroup selectedAssignmentGroup;
        private Module selectedModule;
        public MainVeiwModel()
        {
            title = "Courses";
            privateMasterRoster = new List<Person>();
            masterRoster = new ObservableCollection<Person>();
            courses = new ObservableCollection<Course>();
            var response = new WebRequestHandler().Get("http://localhost:5291/Course").Result;
            var obj = JsonConvert.DeserializeObject<Dictionary<String, Course> >(response);
            foreach (var course in obj)
            {
                courses.Add(course.Value);
                courseDict.Add(course.Key, course.Value);
            }
            selectedCourse = courseDict["COP2220"];
            selectedAssignmentGroup = selectedCourse.AssignmentGroups[0];
            selectedModule= selectedCourse.Modules[0];
            people = new ObservableCollection<Person>();
            assignmentGroups = new ObservableCollection<AssignmentGroup>();
            assignments = new ObservableCollection<Assignment>();
            modules = new ObservableCollection<Module>();
            announcements = new ObservableCollection<Announcement>();
            contentItems = new ObservableCollection<ContentItem>();
            Student person = new Student();
            var response2 = new WebRequestHandler().Get("http://localhost:5291/Person").Result;
            var obj2 = JsonConvert.DeserializeObject<List<Person> >(response2);
            for (int i = 0; i < obj2.Count; i++)
            {
                if (obj2[i].type == 1)
                {
                    obj2[i] = new Student(obj2[i]);

                }
                else if (obj2[i].type == 2)
                {
                    obj2[i] = new Instructor(obj2[i]);

                }
                else if (obj2[i].type == 3)
                {
                    obj2[i] = new TeacherAssistant(obj2[i]);

                }
                privateMasterRoster.Add(obj2[i]);
            }
            user = privateMasterRoster[0];
        }


        private String title;
            
        public String Title
        {
            get
            {
                return title;
            }
        }
        public Dictionary<String, Course> courseDict = new Dictionary<string, Course>();

        private ObservableCollection<Person> people;

        public ObservableCollection<Person> People{
            get
            {
                people.Clear();
                foreach (var person in courseDict[selectedCourse.Code].Roster)
                {
                    people.Add(person);
                }
                return people;
            }

        }

        private ObservableCollection<AssignmentGroup> assignmentGroups;

        public ObservableCollection<AssignmentGroup> AssignmentGroups
        {
            get
            {
                assignmentGroups.Clear();
                foreach (var assignmentGroup in courseDict[selectedCourse.Code].AssignmentGroups)
                {
                    assignmentGroups.Add(assignmentGroup);
                }
                return assignmentGroups;
            }

        }

        private ObservableCollection<Assignment> assignments;

        public ObservableCollection<Assignment> Assignments
        {
            get
            {
                assignments.Clear();
                foreach (var assignment in selectedAssignmentGroup.AssignmentList)
                {
                    assignments.Add(assignment);
                }
                return assignments;
            }

        }

        private ObservableCollection<Module> modules;

        public ObservableCollection<Module> Modules
        {
            get
            {
                modules.Clear();
                foreach (var module in courseDict[selectedCourse.Code].Modules)
                {
                    modules.Add(module);
                }
                return modules;
            }

        }


        private ObservableCollection<ContentItem> contentItems;

        public ObservableCollection<ContentItem> ContentItems
        {
            get
            {
                contentItems.Clear();
                foreach (var contentItem in selectedModule.Content)
                {
                    contentItems.Add(contentItem);
                }
                return contentItems;
            }

        }

        private ObservableCollection<Announcement> announcements;

        public ObservableCollection<Announcement> Announcements
        {
            get
            {
                announcements.Clear();
                foreach (var announcement in courseDict[selectedCourse.Code].Announcements)
                {
                    announcements.Add(announcement);
                }
                return announcements;
            }

        }


        public String Search { get; set; }

        private ObservableCollection<Course> courses;
        public ObservableCollection<Course> Courses{
            get
            {
                courses.Clear();
                foreach (var course in courseDict)
                {
                    courses.Add(course.Value);
                }
                return courses;
            }
            
        }

        private List<Person> privateMasterRoster;

        private ObservableCollection<Person> masterRoster;

        public ObservableCollection<Person> MasterRoster {
            get
            {
                masterRoster.Clear();
                foreach (var person in privateMasterRoster)
                {
                    masterRoster.Add(person);
                }
                return masterRoster;
            }
        }



        public void SearchCourses()
        {
            courses.Clear();
            foreach (var course in courseDict)
            {
                courses.Add(course.Value);
            }

            for (int i = 0; i < courses.Count(); i++) {
                if (Search == null || courses[i].Code.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    courses[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0){
                    if (user is Student)
                    {
                        if (user.Classes.Count == 0)
                        {
                            courses.Clear();
                        }
                        else
                        {
                            bool found = false;
                            foreach (var course in user.Classes)
                            {
                                if (i < courses.Count)
                                {
                                    if (course.CourseCode == courses[i].Code && courses[i].Semester == user.Semester && courses[i].Year == user.Year) { 
                                        
                                        found = true;
                                    }
                                }
                            }
                            if (!found)
                            {
                                courses.Remove(courses[i]);
                                i--;
                            }
                        }
                    }
                }
                else
                {
                    courses.Remove(courses[i]);
                    i--;
                }
            }
        }

        public async void AddCourse()
        {
            var diolog = new AddCourseDialog(courseDict);
            if (diolog != null) { 
                await diolog.ShowAsync();
            }
            SearchCourses();
        }

        public async void ModifyCourse(String selected)
        {
            var diolog = new ModifyCourseDialog(courseDict, selected);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchCourses();
        }

        public void RemoveCourse(String selected)
        {
            CourseVeiwModel model = new CourseVeiwModel(courseDict, selected);
            model.RemoveCourse();
            SearchCourses();
        }

        public void SelectCourse(String selected)
        {
            CourseVeiwModel model = new CourseVeiwModel(courseDict, selected);
            selectedCourse = model.SelectCourse();
            if(People != null)
            {
                NotifyPropertyChanged("PersonList");
            }
            if (AssignmentGroups != null)
            {
                NotifyPropertyChanged("AssignmentGroupList");
            }
            if (Modules != null)
            {
                NotifyPropertyChanged("Modules");
            }
            if (Announcements != null)
            {
                NotifyPropertyChanged("Announcements");
            }
            if (MasterRoster != null)
            {
                NotifyPropertyChanged("MasterRoster");
            }
            title = selectedCourse.FullDisplay();
            NotifyPropertyChanged("Title"); 
        }

        public void ChangeTitleToMasterRoster()
        {
            title = "Master Roster";
            NotifyPropertyChanged("Title");
        }

        public void SelectCourseItem(String selected)
        {
            if (selected == "People"){

            }else if (selected == "AssignmentGroups"){

            }else if (selected == "Modules"){

            }else if (selected == "Anouncements"){

            }
        }

        public void ReturnToCourses()
        {
            title = "Courses";
            NotifyPropertyChanged("Title");
        }

        public void ReturnToCourse()
        {
            title = selectedCourse.FullDisplay();
            NotifyPropertyChanged("Title");
        }

        public void SearchPeople()
        {
            People.Clear();
            foreach (var person in selectedCourse.Roster)
            {
                People.Add(person);
            }

            for (int i = 0; i < People.Count(); i++)
            {
                if (Search == null)
                {

                }
                else if (People[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    People[i].Classification.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {

                }
                else
                {
                    People.Remove(People[i]);
                    i--;
                }
            }
        }

        public void SearchMasterRoster()
        {
            masterRoster.Clear();
            foreach (var person in privateMasterRoster)
            {
                masterRoster.Add(person);
            }

            for (int i = 0; i < masterRoster.Count(); i++)
            {
                if (Search == null)
                {

                }
                else if (masterRoster[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    masterRoster[i].Classification.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {

                }
                else
                {
                    masterRoster.Remove(masterRoster[i]);
                    i--;
                }
            }
        }

        public async void AddPerson()
        {
            var diolog = new AddPersonDialog(privateMasterRoster);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchMasterRoster();
        }

        public async void SelectPerson()
        {
            var diolog = new SelectPersonDialog(selectedCourse, MasterRoster);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchPeople();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public async void ModifyPerson(String selected)
        {
            var diolog = new ModifyPersonDialog(privateMasterRoster, selected);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchMasterRoster();
        }

        public void RemovePerson(String selected)
        {
            PersonVeiwModel model = new PersonVeiwModel(privateMasterRoster, selected);
            model.RemovePerson();
            SearchMasterRoster();
        }

        public void RemovePersonFromClass(String selected)
        {
            PersonVeiwModel model = new PersonVeiwModel(selectedCourse.Roster, selected);
            model.RemovePerson();
            SearchPeople();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public async void ViewFullPersonInformation(String selected)
        {
            var diolog = new ViewPersonInformationDialog(selectedCourse.Roster, selected);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
        }


        public void SearchAssignmentGroup()
        {
            assignmentGroups.Clear();
            foreach (var assignmentGroup in selectedCourse.AssignmentGroups)
            {
                assignmentGroups.Add(assignmentGroup);
            }

            for (int i = 0; i < assignmentGroups.Count(); i++)
            {
                if (Search == null)
                {

                }
                else if (assignmentGroups[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {

                }
                else
                {
                    assignmentGroups.Remove(assignmentGroups[i]);
                    i--;
                }
            }
        }

        public async void AddAssignmentGroup()
        {
            var diolog = new AddAssignmentGroupDialog(selectedCourse.AssignmentGroups);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchAssignmentGroup();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public async void ModifyAssignmentGroup(String selected)
        {
            var diolog = new ModifyAssignmentGroupDialog(selectedCourse.AssignmentGroups, selected);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchAssignmentGroup();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public void RemoveAssignmentGroup(String selected)
        {
            AssignmentGroupViewModel model = new AssignmentGroupViewModel(selectedCourse.AssignmentGroups, selected);
            model.RemoveAssignmentGroup();
            SearchAssignmentGroup();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }


        public void SelectAssignmentGroup(String selected)
        {
            AssignmentGroupViewModel model = new AssignmentGroupViewModel(selectedCourse.AssignmentGroups, selected);
            selectedAssignmentGroup = model.SelectAssignmentGroup();
            title = selectedAssignmentGroup.ToString();
            NotifyPropertyChanged("Title");
        }


        public void SearchAssignments()
        {
            assignments.Clear();
            foreach (var assignment in selectedAssignmentGroup.AssignmentList)
            {
                assignments.Add(assignment);
            }

            for (int i = 0; i < assignments.Count(); i++)
            {
                if (Search == null)
                {

                }
                else if (assignments[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {

                }
                else
                {
                    assignments.Remove(assignments[i]);
                    i--;
                }
            }
        }

        public async void AddAssignment()
        {
            var diolog = new AddAssignmentDialog(selectedAssignmentGroup.AssignmentList);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchAssignments();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public async void ModifyAssignment(String selected)
        {
            var diolog = new ModifyAssignmentDialog(selectedAssignmentGroup.AssignmentList, selected);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchAssignments();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public void RemoveAssignment(String selected)
        {
            AssignmentViewModel model = new AssignmentViewModel(selectedAssignmentGroup.AssignmentList, selected);
            model.RemoveAssignment();
            SearchAssignments();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public async void AssignGrade(String selected)
        {
            ObservableCollection <Student> students = new ObservableCollection<Student>();
            foreach(var person in selectedCourse.Roster)
            {
                if(person is Student)
                {
                    students.Add(person as Student);
                }
            }
            var diolog = new AssignGradeDialog(selectedCourse, students, selectedAssignmentGroup, selected);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
        }



        public void SearchModules()
        {
            modules.Clear();
            foreach (var module in selectedCourse.Modules)
            {
                modules.Add(module);
            }

            for (int i = 0; i < modules.Count(); i++)
            {
                if (Search == null)
                {

                }
                else if (modules[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {

                }
                else
                {
                    modules.Remove(modules[i]);
                    i--;
                }
            }
        }

        public async void AddModule()
        {
            var diolog = new AddModuleDialog(selectedCourse.Modules);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchModules();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public async void ModifyModule(String selected)
        {
            var diolog = new ModifyModuleDialog(selectedCourse.Modules, selected);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchModules();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public void RemoveModule(String selected)
        {
            ModuleViewModel model = new ModuleViewModel(selectedCourse.Modules, selected);
            model.RemoveModule();
            SearchModules();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public void SelectModule(String selected)
        {
            ModuleViewModel model = new ModuleViewModel(selectedCourse.Modules, selected);
            selectedModule = model.SelectModule();
            title = selectedModule.ToString();
            NotifyPropertyChanged("Title");
        }


        public void SearchContentItems()
        {
            contentItems.Clear();
            foreach (var contentItem in selectedModule.Content)
            {
                contentItems.Add(contentItem);
            }

            for (int i = 0; i < contentItems.Count(); i++)
            {
                if (Search == null)
                {

                }
                else if (contentItems[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {

                }
                else
                {
                    contentItems.Remove(contentItems[i]);
                    i--;
                }
            }
        }

        public async void AddContentItem()
        {
            ObservableCollection<Assignment> assignList = new ObservableCollection<Assignment>();
            foreach(var assignmentGroup in selectedCourse.AssignmentGroups)
            {
                foreach(var assignment in assignmentGroup.AssignmentList)
                {
                    assignList.Add(assignment);
                }
            }
            var diolog = new AddContentItemDialog(selectedModule.Content, assignList);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchContentItems();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public async void ModifyContentItem(String selected)
        {
            var diolog = new ModifyContentItemDialog(selectedModule.Content, selected);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchContentItems();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public void RemoveContentItem(String selected)
        {
            ContentItemViewModel model = new ContentItemViewModel(selectedModule.Content, selected);
            model.RemoveContentItem();
            SearchContentItems();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }


        public void SearchAnnouncements()
        {
            announcements.Clear();
            foreach (var announcement in selectedCourse.Announcements)
            {
                announcements.Add(announcement);
            }

            for (int i = 0; i < announcements.Count(); i++)
            {
                if (Search == null)
                {

                }
                else if (announcements[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {

                }
                else
                {
                    announcements.Remove(announcements[i]);
                    i--;
                }
            }
        }

        public async void AddAnnouncement()
        {
            var diolog = new AddAnnouncementDialog(selectedCourse.Announcements);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchAnnouncements();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public async void ModifyAnnouncement(String selected)
        {
            var diolog = new ModifyAnnouncementDialog(selectedCourse.Announcements, selected);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            SearchAnnouncements();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public void RemoveAnnouncement(String selected)
        {
            AnnouncementViewModel model = new AnnouncementViewModel(selectedCourse.Announcements, selected);
            model.RemoveAnnouncement();
            SearchAnnouncements();
            var respose = new WebRequestHandler().Post("http://localhost:5291/Course", selectedCourse);
        }

        public async void LaunchUserSelection()
        {
            var diolog = new ChooseUserDialog(masterRoster, user);
            if (diolog != null)
            {
                await diolog.ShowAsync();
            }
            user = diolog.User;
            NotifyPropertyChanged("user");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
