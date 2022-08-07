﻿using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    internal interface ILocalChargeService
    {
        IDataResult<List<LocalCharge>> GetAll();
        IResult Add(LocalCharge localCharge);
        IResult Delete(LocalCharge localCharge);
        IResult Update(LocalCharge localCharge);
        IDataResult<LocalCharge> GetById(int id);
    }
}