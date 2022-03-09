using APICURD_DAL.Interface;
using APICURD_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API_CURD_BAL.Service
{
    public class PersonService
    {
        private readonly IRepository<Person> _Person;
        public PersonService(IRepository<Person>  person)
        {
            _Person = person;
        }

        //get Person Details By Person ID

        public IEnumerable<Person> GetpersonUserID(string UserId)
        {
            return _Person.GetAll().Where(x => x.UserEmail == UserId).ToList();
        }

        //Get All Person Details

        public IEnumerable<Person> GetALLPerson()
        {
            try
            {
                return _Person.GetAll().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        //get person by Person Name
        public Person GetPersonByUserName(string UserName)
        {
            return _Person.GetAll().Where(x => x.UserEmail == UserName).FirstOrDefault();
        }

        //AddPerson
        public async Task<Person> AddPerson(Person _person)
        {
            return await _Person.Create(_person);
        }

        
        //Delete Person 
        public bool DeletePerson(string UserEmail)
        {
            try
            {
                var DataList = _Person.GetAll().Where(x => x.UserEmail == UserEmail).ToList();
                foreach (var item in DataList)
                {
                    _Person.Delete(item);
                }
                return true;
            }
            catch(Exception)
            {
                return true;
            }
        }

        //Update Person

        public bool UpdatePerson(Person person)
        {
            try
            {
                var DataList = _Person.GetAll().Where(x => x.IsDeleted != true).ToList();
                foreach (var item in DataList)
                {
                    _Person.Update(item);
                }
                return true;
            }

            catch(Exception)
            {
                return true;
            }
        }


    }
}
