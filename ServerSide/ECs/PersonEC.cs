using LMSLibrary;
using LMSLibrary.Models;
using LMSLibrary2._0.DTO_s;

namespace ServerSideForProj4.ECs
{
    public class PersonEC
    {
        public static int currentId = FakeDatabase.People.Count();
        public PersonDTO AddOrUpdatePerson(PersonDTO dto)
        {
            if (dto.Id > 0)
            {
                var itemToUpdate = FakeDatabase.People.FirstOrDefault(c => c.Id == dto.Id);

                if (itemToUpdate != null)
                {
                    FakeDatabase.People.Remove(itemToUpdate);
                    FakeDatabase.People.Add(new Person(dto));
                }

            }
            else
            {
                var lastId = FakeDatabase.People.Select(c => c).Max();
                dto.Id = ++currentId;
                FakeDatabase.People.Add(new Person(dto));
            }


            return dto;
        }

        public PersonDTO RemovePerson(PersonDTO dto)
        {

            if (dto.Id > 0)
            {
                var itemToUpdate = FakeDatabase.People.FirstOrDefault(c => c.Id == dto.Id);

                if (itemToUpdate != null)
                {
                    FakeDatabase.People.Remove(itemToUpdate);
                }

            }
            return dto;
        }
    }
}

