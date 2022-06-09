using SerializeAppForDigitSpace.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAppForDigitSpace.DataAccessLayer.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
       public IRepository<Person> GetPersons { get; }   
    }
}
