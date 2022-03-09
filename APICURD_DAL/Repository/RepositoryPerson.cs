using APICURD_DAL.Data;
using APICURD_DAL.Interface;
using APICURD_DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICURD_DAL.Repository
{
    public class RepositoryPerson : IRepository<Person>
    {
        ApplicationDbContext _DbContext;
        public RepositoryPerson(ApplicationDbContext applicationDbContext)
        {
             _DbContext= applicationDbContext ;
        }


        public async Task<Person> Create(Person _object)
        {
            var obj = await _DbContext.Persons.AddAsync(_object);
            _DbContext.SaveChanges();
            return obj.Entity;
        }

        public void Delete(Person _object)
        {
            _DbContext.Remove(_object);
            _DbContext.SaveChanges();
        }

        public IEnumerable<Person> GetAll()
        {
            try
            {
                return _DbContext.Persons.Where(x => x.IsDeleted == false).ToList();
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Person GetById(int Id)
        {
            return _DbContext.Persons.Where(x => x.IsDeleted == false && x.Id == Id).FirstOrDefault();
        }

        public void Update(Person _object)
        {
            _DbContext.Persons.Update(_object);
            _DbContext.SaveChanges();
        }
    }
}
