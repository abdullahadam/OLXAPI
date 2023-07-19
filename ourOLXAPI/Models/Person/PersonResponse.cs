using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ourOLXAPI.Models
{

    public class PersonResponse
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }

        public List<Person> Result { get; set; }
        
    }

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Occupation { get; set; }

        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string IDNumber { get; set; }


    }

    public class CreatePersonRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string IDNumber { get; set; }
    }
    //public class UpdatePersonRequest
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string SurName { get; set; }
    //    public string DateOfBirth { get; set; }
    //    public int Age { get; set; }
    //    public string Gender { get; set; }
    //    public string IDNumber { get; set; }
    //    public FieldsToUpdate FieldsToUpdate { get; set; }
    //}
    public class FieldsToUpdate
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }
    }

    public class DeletePersonRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }

        public string DateOfBirth { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string IDNumber { get; set; }
    }

}
