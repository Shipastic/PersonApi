using Ninject.Modules;
using SerializeAppForDigitSpace.DataAccessLayer.Interfaces;
using SerializeAppForDigitSpace.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAppForDigitSpace.BusinessLayer.Infrastructure
{
    internal class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IUnitOfWork>().To<EFUnitOfWork>();

            //Bind(Type.GetType("SerializeAppForDigitSpace.DataAccessLayer.Interfaces.IUnitOfWork, SerializeAppForDigitSpace.DataAccessLayer.Repositories.EFUnitOfWork")).ToSelf().InSingletonScope();
            Bind(typeof(IUnitOfWork)).To(typeof(EFUnitOfWork)).InSingletonScope();
        }
    }
}
