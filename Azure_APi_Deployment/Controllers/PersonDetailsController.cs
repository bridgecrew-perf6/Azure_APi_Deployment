﻿using API_CURD_BAL.Service;
using APICURD_DAL.Interface;
using APICURD_DAL.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure_APi_Deployment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonDetailsController : ControllerBase
    {
        private readonly PersonService _personService;
        private readonly IRepository<Person> _person;

        public PersonDetailsController(IRepository<Person> Person, PersonService PersonService)
        {
            _personService = PersonService;
            _person = Person;
        }

        //Add Person
        [HttpPost("AddPerson")]
        public async Task<Object> AddPerson([FromBody] Person person)
        {
            try
            {
                await _personService.AddPerson(person);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        //Delete Person
        [HttpDelete("DeletePerson")]
        public bool DeletePerson(string UserEmail)
        {
            
                try
                {
                    _personService.DeletePerson(UserEmail);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            
        }

        //Update Person
        [HttpPut("UpdatePerson")]
        public bool UpdatePerson(Person Object)
        {
            try
            {
                _personService.UpdatePerson(Object);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }


        //GET All Person by Name  
        [HttpGet("GetAllPersonByName")]
        public Object GetAllPersonByName(string UserEmail)
        {
            var data = _personService.GetPersonByUserName(UserEmail);
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }

        //GET All Person  
        [HttpGet("GetAllPersons")]
        public Object GetAllPersons()
        {
            var data = _personService.GetALLPerson();
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                }
            );
            return json;
        }
    }
}
