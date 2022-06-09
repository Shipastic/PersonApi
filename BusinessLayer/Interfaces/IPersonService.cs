using SerializeAppForDigitSpace.BusinessLayer.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAppForDigitSpace.BusinessLayer.Interfaces
{
    public interface IPersonService
    {
        public void WriteToFile(IEnumerable<PersonDTO> GetPersonDTOs);

        public IEnumerable<PersonDTO> ReadFromFile();

        public IEnumerable<PersonDTO> GetPersonDTOs();

        public IEnumerable<PersonDTO> GetPersonDTOWithCreditCardNumbers(IEnumerable<PersonDTO> personDTOs);

        public Double AvgAgeChild(IEnumerable<PersonDTO> personDTO);

        void Dispose();
    }
}
