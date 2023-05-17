using Ninject.Modules;
using SerializeAppForDigitSpace.BusinessLayer.Interfaces;
using SerializeAppForDigitSpace.BusinessLayer.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAppForDigitSpace.PresentationLayer.Util
{
    internal class PersonModule : NinjectModule
    {
        public override void Load()
        {
            //Bind(Type.GetType("SerializeAppForDigitSpace.BusinessLayer.Interfaces.IPersonService, SerializeAppForDigitSpace.BusinessLayer.Service.PersonService")).ToSelf().InSingletonScope();
            Bind(typeof(IPersonService)).To(typeof(PersonService)).InSingletonScope();
        }
    }
}
