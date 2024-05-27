using LMSLibrary;
using LMSLibrary.Models;
using Newtonsoft.Json;
using SupportTicketApplication;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Project_3___3.Veiw_Model
{
    public class PersonVeiwModel
    {
        public PersonVeiwModel(List<Person> people) {
            Person = new Person();
            People = people;
        }

        public PersonVeiwModel(Course course, ObservableCollection<Person> obPeople)
        {
            People = course.Roster;
            ObPeople = obPeople;
            Course = course;
        }

        public PersonVeiwModel(ObservableCollection<Person> obPeople, Person user)
        {
            Semester = "Spring";
            NotifyPropertyChanged("Semester");
            Year = 2023;
            NotifyPropertyChanged("Year");
            Person = user;
            ObPeople = obPeople;
            People = new List<Person>();
            foreach(var person in obPeople)
            {
                People.Add(person);
            }
        }

        public PersonVeiwModel(List<Person> people, String selected)
        {
            for(int i = 0; i < people.Count(); i++)
            {
                if (selected.IndexOf(people[i].Id.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    Person = people[i];
                }
            }
            People = people;
           FullPersonDisplay = Person.FullDisplay();
           NotifyPropertyChanged("FullDisplay");
        }

        public String Semester { get; set;}

        public int Year { get; set; }

        public String Search { get; set; }
        public String FullPersonDisplay { get; set; }
        public Person Person { get; set; }
        public List<Person> People;

        private Course Course;

        public ObservableCollection<Person> ObPeople { get; set; }

        public String Name
        {
            get{ return Person.Name; }
            set { Person.Name = value; }
        }

        public String Classification
        {
            get { return Person.Classification; }
            set { Person.Classification = value; }
        }

        public int Id
        {
            get { return Person.Id; }
        }

        public void AddNewPerson(int type)
        {
            if(type == 0)
            {
                Person = new Student(Person);
            }else if(type == 1)
            {
                Person = new Instructor(Person);
            }
            else if(type == 2)
            {
                Person = new TeacherAssistant(Person);
            }
            if (Person is Student)
            {
                var response = new WebRequestHandler().Post("http://localhost:5291/Student", Person);
                var obj = JsonConvert.DeserializeObject<Person>(response.Result);
                Person.Id = obj.Id;
            }
            else if (Person is Instructor)
            {
                var response = new WebRequestHandler().Post("http://localhost:5291/Instructor", Person);
                var obj = JsonConvert.DeserializeObject<Person>(response.Result);
                Person.Id = obj.Id;
            }
            else if (Person is TeacherAssistant)
            {
                var response = new WebRequestHandler().Post("http://localhost:5291/TeacherAssistant", Person);
                var obj = JsonConvert.DeserializeObject<Person>(response.Result);
                Person.Id = obj.Id;
            }
            else if (Person is Person)
            {
                var response = new WebRequestHandler().Post("http://localhost:5291/Person", Person);
                var obj = JsonConvert.DeserializeObject<Person>(response.Result);
                Person.Id = obj.Id;
            }
            People.Add(Person);

        }

        public void AddPerson(string selected)
        {
            for (int i = 0; i < ObPeople.Count(); i++)
            {
                if (selected.IndexOf(ObPeople[i].Id.ToString(), StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    Person = ObPeople[i];
                }
            }
            ClassItem ci = new ClassItem();
            ci.CourseCode = Course.Code;
            ci.CourseName = Course.Name;
            ci.CreditHours = Course.CreditHours;
            ci.Room = Course.Room;
            ci.Semester = Course.Semester;
            ci.Year = Course.Year;
            Person.Classes.Add(ci);
            People.Add(Person);
        }

        public void ModifyPerson()
        {
            if (Person is Student)
            {
                var respose = new WebRequestHandler().Post("http://localhost:5291/Student", Person);
            }
            else if (Person is Instructor)
            {
                var respose = new WebRequestHandler().Post("http://localhost:5291/Instructor", Person);
            }
            else if (Person is TeacherAssistant)
            {
                var respose = new WebRequestHandler().Post("http://localhost:5291/TeacherAssistant", Person);
            }else if (Person is Person)
            {
                var respose = new WebRequestHandler().Post("http://localhost:5291/Person", Person);
            }
        }

        public void RemovePerson()
        {
            People.Remove(Person);
            if (Person is Student)
            {
                var respose = new WebRequestHandler().Delete("http://localhost:5291/Student", Person);
            }
            else if (Person is Instructor)
            {
                var respose = new WebRequestHandler().Delete("http://localhost:5291/Instructor", Person);
            }
            else if (Person is TeacherAssistant)
            {
                var respose = new WebRequestHandler().Delete("http://localhost:5291/TeacherAssistant", Person);
            }
            if (Person is Person)
            {
                var respose = new WebRequestHandler().Delete("http://localhost:5291/Person", Person);
            }
        }

        public void SearchPeople()
        {
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

        public void SearchUser()
        {
            ObPeople.Clear();
            foreach (var person in People)
            {
                ObPeople.Add(person);
            }

            for (int i = 0; i < ObPeople.Count(); i++)
            {
                if (Search == null)
                {

                }
                else if (ObPeople[i].Name.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0 ||
                    ObPeople[i].Classification.IndexOf(Search, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {

                }
                else
                {
                    ObPeople.Remove(ObPeople[i]);
                    i--;
                }

            }
        }

        public void CalculateGPA()
        {
            if (Person is Student)
            {
                double GPA = 0;
                double creditHours = 0;
                for (int i = 0; i < Person.Classes.Count; i++)
                {
                    if (Person.Classes[i].CourseGrade >= 97)
                    {
                        GPA += 4.0 * Person.Classes[i].CreditHours;
                    }
                    else if (Person.Classes[i].CourseGrade >= 93)
                    {
                        GPA += 4.0 * Person.Classes[i].CreditHours;
                    }
                    else if (Person.Classes[i].CourseGrade >= 90)
                    {
                        GPA += 3.7 * Person.Classes[i].CreditHours;
                    }
                    else if (Person.Classes[i].CourseGrade >= 87)
                    {
                        GPA += 3.3 * Person.Classes[i].CreditHours;
                    }
                    else if (Person.Classes[i].CourseGrade >= 83)
                    {
                        GPA += 3.0 * Person.Classes[i].CreditHours;
                    }
                    else if (Person.Classes[i].CourseGrade >= 80)
                    {
                        GPA += 2.7 * Person.Classes[i].CreditHours;
                    }
                    else if (Person.Classes[i].CourseGrade >= 77)
                    {
                        GPA += 2.3 * Person.Classes[i].CreditHours;
                    }
                    else if (Person.Classes[i].CourseGrade >= 73)
                    {
                        GPA += 2.0 * Person.Classes[i].CreditHours;
                    }
                    else if (Person.Classes[i].CourseGrade >= 70)
                    {
                        GPA += 1.7 * Person.Classes[i].CreditHours;
                    }
                    else if (Person.Classes[i].CourseGrade >= 67)
                    {
                        GPA += 1.3 * Person.Classes[i].CreditHours;
                    }
                    else if (Person.Classes[i].CourseGrade >= 65)
                    {
                        GPA += 1 * Person.Classes[i].CreditHours;
                    }
                    else
                    {
                    }
                    creditHours += Person.Classes[i].CreditHours;
                }
                if (creditHours != 0)
                {
                    (Person as Student).Grade = GPA / creditHours;
                }

                NotifyPropertyChanged("Person");
            }
        }

        public void SelectUser()
        {
            Person.Semester = Semester;
            Person.Year = Year;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
