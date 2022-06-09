using Ninject;
using Ninject.Modules;
using SerializeAppForDigitSpace.BusinessLayer.Infrastructure;
using SerializeAppForDigitSpace.BusinessLayer.Interfaces;
using SerializeAppForDigitSpace.BusinessLayer.Service;
using SerializeAppForDigitSpace.DataAccessLayer.Models;
using SerializeAppForDigitSpace.PresentationLayer;
using SerializeAppForDigitSpace.PresentationLayer.Util;
using System.Collections.Generic;

namespace SerializeAppForDigitSpace
{
    class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
       
        static void Main(string[] args)
        {

            NinjectModule personModule = new PersonModule();
            NinjectModule serviceModule = new ServiceModule();
            var kernel = new StandardKernel(personModule, serviceModule);
            var viewPersons = new ViewPersons(kernel);
            viewPersons.ShowMenu();
            Console.ReadKey();
        }
    }
}
