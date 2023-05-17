using Ninject;
using SerializeAppForDigitSpace.BusinessLayer.DTO;
using SerializeAppForDigitSpace.BusinessLayer.Interfaces;
using SerializeAppForDigitSpace.BusinessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAppForDigitSpace.PresentationLayer
{
    public  class ViewPersons : IDisposable
    {
        IPersonService personService;
       
        public ViewPersons(IKernel kernel)
        {
            personService = kernel.Get<PersonService>();
        }
       
        public void ShowMenu()
        {
            while (true)
            {
                Console.WriteLine("Выберите пункт меню:\n\r" +
                              "1 - Вывод количества сгенерированных лиц\n\r" +
                              "2 - Вывод лиц, именющих записи с номерами кредитных карт\n\r" +
                              "3 - Вывод среднего значения возраста ребенка\n\r" +
                              "4 - Cформировать Json-файл\n\r" +
                              "5 - Открыть Json-файл\n\r" +
                              "6 - Очистить память\n\r" +
                              "q - Для выхода из программы\n\r");

                string number = Console.ReadLine();

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Q)
                    Environment.Exit(0); 
                switch (number)
                {
                    case "1":
                        CountPersons();
                        break;
                    case "2":
                        CountPersonsWithNumbersCCard();
                            break;
                    case "3":
                        ShowAvgAgeChild();
                        break;
                    case "4":
                        GenerateJsonFile();
                        break;
                    case "5":
                        ReadJsonFile();
                        break;
                    case "6":
                        Dispose(true);
                        break;
                    case "q":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Вы ввели несуществующую команду\n\r");
                        break;
                }
            }
        }


        private void CountPersonsWithNumbersCCard()
        {
            IEnumerable<PersonDTO> personDTOs = personService.ReadFromFile();

            var personDTOsWithNumbers = personService.GetPersonDTOWithCreditCardNumbers(personDTOs);

            int countPerson = personDTOsWithNumbers.Count();

            if(countPerson == 0)
            {
                Console.WriteLine("Лица, с номерами кредитных карт, отсутствуют \n\r");
            }
            else
            {
                Console.WriteLine($"Количество лиц с номерами крединых карт:{countPerson} \n\r");
            }
        }

        /// <summary>
        /// Вывод количества лиц
        /// </summary>
        /// <returns></returns>
        public void CountPersons()
        {
            IEnumerable<PersonDTO> personDTOs = personService.ReadFromFile();

            var countPerson = personDTOs.Count();

            Console.WriteLine($"Количество сгенерированных лиц: {countPerson}\n\r");

            countPerson = 0;
        }

        /// <summary>
        /// Выбор генерации Json-Файла
        /// </summary>
        public void GenerateJsonFile()
        {
            IEnumerable<PersonDTO> personDTOs = personService.GetPersonDTOs();

            personService.WriteToFile(personDTOs);
        }

        /// <summary>
        /// Вывод содержимого файла на консоль
        /// </summary>
        public void ReadJsonFile()
        {
            IEnumerable<PersonDTO> personDTOs = personService.ReadFromFile();

            if (personDTOs == null)
            {
                Console.WriteLine("Список пуст!\n\r");
            }
            else
            {
                foreach (var personDTO in personDTOs)
                {
                    string phoneNum = null;
                    string cardNumber = null;

                    if (personDTO.Phones.Length == 0)
                    {
                        phoneNum = "Телефонные номера отсутствуют";
                    }
                    else
                    {
                        phoneNum = string.Join("\n\r", personDTO.Phones);
                    }


                    if (personDTO.CreditCardNumbers.Length == 0)
                    {
                        cardNumber = "Номера кредитных карт отсутствуют";
                    }
                    else
                    {
                        cardNumber = string.Join("\n\r", personDTO.CreditCardNumbers);
                    }


                    var childInfo = from child in personDTO.Children
                                    select new
                                    {
                                        Id = child.Id,
                                        firstName = child.FirstName,
                                        lastName = child.LastName,
                                        birthDate = child.BirthDate,
                                        gender = child.Gender
                                    };


                    Console.WriteLine($"{personDTO.FirstName} {personDTO.LastName}:\n\r" +
                                      $"TransportId: {personDTO.TransportId}\n\r" +
                                      $"SequenceId: {personDTO.SequenceId}\n\r" +
                                      $"Age: {personDTO.Age}\n\r" +
                                      $"Birthday: {personDTO.BirthDate}\n\r" +
                                      $"Salary: {personDTO.Salary}\n\r" +
                                      $"IsMarred: {personDTO.IsMarred}\n\r" +
                                      $"Gender: {personDTO.Gender}\n\r" +
                                      $"Номера телефонов:\n\r{phoneNum}\n\r" +
                                      $"Номера кредитных карт:\n\r{cardNumber}\n\r" +
                                      $"Дети:\n\r{string.Join("\n\r", childInfo)}\n\r" +
                                      $"================================================================================================================================\n");
                }
            }
        }

        /// <summary>
        /// Вывод среднего возраста ребенка
        /// </summary>
        public void ShowAvgAgeChild()
        {
            IEnumerable<PersonDTO> personDTOs = personService.GetPersonDTOs();

            var avgChildAge = personService.AvgAgeChild(personDTOs);

            Console.WriteLine($"Средний возраст ребенка: {Math.Round(avgChildAge)}\n\r");
        }

        private bool disposedValue = false;
        /// <summary>
        /// Очистка коллекции
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    personService.Dispose();
                }
                disposedValue = true;
            }
        }
    }
}
