﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeAppForDigitSpace.DataAccessLayer.Interfaces
{
    public  interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
    }
}
