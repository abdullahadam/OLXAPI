using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ourOLXAPI.Models;

namespace ourOLXAPI.Services.Interfaces
{
    public interface IPersonService
    {
        PersonResponse GetAllPersons();
        PersonResponse CreateAllPersons(CreatePersonRequest request);
        PersonResponse UpdateAllPersons( FieldsToUpdate request);
        PersonResponse DeleteAllPersons(DeletePersonRequest request);




    }
}
