using SerializeAppForDigitSpace.DataAccessLayer.Interfaces;
using SerializeAppForDigitSpace.DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAppForDigitSpace.DataAccessLayer.Repositories
{
    internal class EFUnitOfWork : IUnitOfWork
    {
        private InitializeCollectionPerson collectionPerson;

        private PersonRepository personRepository;
        public EFUnitOfWork()
        {
            collectionPerson = new InitializeCollectionPerson();
        }

        public IRepository<Person> GetPersons   {
            get
            {
                if (personRepository == null)
                    personRepository = new PersonRepository(collectionPerson);
                return personRepository;
            }
        }

        public void Dispose()
        {
            try
            {
                GC.SuppressFinalize(this);
            }
            catch(NullReferenceException nrex)
            {
                Console.WriteLine("Память уже очищена!");
            }
        }

        private bool disposedValue = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    personRepository.Dispose();
                }
                disposedValue = true;
            }
        }
    }
}
