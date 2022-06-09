using SerializeAppForDigitSpace.DataAccessLayer.Interfaces;
using SerializeAppForDigitSpace.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAppForDigitSpace.DataAccessLayer.Repositories
{
    internal class PersonRepository : IRepository<Person>, IDisposable
    {
        private InitializeCollectionPerson collectionPerson;
        public PersonRepository(InitializeCollectionPerson _collectionPerson)
        {
            collectionPerson = _collectionPerson;
        }
        public IEnumerable<Person> GetAll()
        {
            return collectionPerson.GetPersons();
        }

        public void Dispose()
        {
            try
            {
                List<Person> people = collectionPerson.GetPersons().ToList();

                people.Clear();

                GC.SuppressFinalize(this);
            }
            catch (System.NullReferenceException nrex)
            {
                Console.WriteLine("Коллекция уже пуста!");
            }
        }

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    collectionPerson.Dispose();
                }
                disposedValue = true;
            }
        }
    }
}
