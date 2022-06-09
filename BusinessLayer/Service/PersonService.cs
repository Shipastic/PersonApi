using SerializeAppForDigitSpace.BusinessLayer.DTO;
using SerializeAppForDigitSpace.BusinessLayer.Interfaces;
using SerializeAppForDigitSpace.DataAccessLayer.Interfaces;
using AutoMapper;
using SerializeAppForDigitSpace.DataAccessLayer.Models;
using System.Text.Json;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using System.Text;

namespace SerializeAppForDigitSpace.BusinessLayer.Service
{
    public class PersonService : IPersonService
    {
        IUnitOfWork DataPersons { get; set; }
        public PersonService(IUnitOfWork dataPersons)
        {
            DataPersons = dataPersons;
        }

        public  void WriteToFile(IEnumerable<PersonDTO> GetPersonDTOs)
        {
            string folderPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\Persons.json";

            using (FileStream fs = new FileStream(folderPath, FileMode.Create, FileAccess.Write))
            {
                var options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.BasicLatin, UnicodeRanges.Cyrillic),
                    WriteIndented = true
                };
                string json = JsonSerializer.Serialize(GetPersonDTOs, options);
                byte[] buffer = Encoding.UTF8.GetBytes(json);
                fs.Write(buffer, 0, buffer.Length);

                Console.WriteLine(@"Данные сериализованы и сохранены в файл ""Persons.json""");
            }
        }

        public  IEnumerable<PersonDTO> ReadFromFile()
        {
            string folderPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}\\Persons.json";

            using (FileStream fs = new FileStream(folderPath, FileMode.OpenOrCreate))
            {

                try
                {
                    IEnumerable<PersonDTO> personDTOs = JsonSerializer.Deserialize<IEnumerable<PersonDTO>>(fs);

                    return personDTOs;
                }
                catch(JsonException jsex)
                {
                    return Enumerable.Empty<PersonDTO>();
                }
            }
        }

        public IEnumerable<PersonDTO> GetPersonDTOs()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Person, PersonDTO>();
                cfg.CreateMap<PersonDTO, Person>();
                cfg.CreateMap<Child, ChildDTO>();
                cfg.CreateMap<ChildDTO, Child>();
                cfg.CreateMap<Gender, GenderDTO>();
                cfg.CreateMap<GenderDTO, Gender>();
            });

            var mapper = new Mapper(configuration);

            return mapper.Map<IEnumerable<Person>, IEnumerable<PersonDTO>>(DataPersons.GetPersons.GetAll());
        }

        public double AvgAgeChild(IEnumerable<PersonDTO> personDTOs)
        {
            DateTime dateTime = DateTime.Now;

            int year = dateTime.Year;
            double[] avgAgeArray = new double[] {};

            double avAge = 0.0;
            try
            {
                avgAgeArray = personDTOs.Where(c => c.Children.Length > 0).Select(p => p.Children.Average(child => Math.Abs(child.BirthDate / 31556926 - (year - 1970)))).ToArray();

                avAge = Math.Abs(avgAgeArray.Average(avg => avg));

                return avAge;
            }
            catch(System.InvalidOperationException ioe)
            {
                return 0;
            }
        }

        private bool disposedValue = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            Console.WriteLine("Память очищена!");
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DataPersons.Dispose();
                }
                disposedValue = true;
            }
        }

        public IEnumerable<PersonDTO> GetPersonDTOWithCreditCardNumbers(IEnumerable<PersonDTO> personDTOs)
        {
            try
            {
                var personWithCreditCardNumbers = personDTOs.Where(c => c.CreditCardNumbers.Count() > 0);

                return personWithCreditCardNumbers;
            }

            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Enumerable.Empty<PersonDTO>();
            }
        }
    }
}
