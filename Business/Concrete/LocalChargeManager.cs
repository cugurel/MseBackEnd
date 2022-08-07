using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class LocalChargeManager : ILocalChargeService
    {
        public IResult Add(LocalCharge localCharge)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(LocalCharge localCharge)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<LocalCharge>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<LocalCharge> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(LocalCharge localCharge)
        {
            throw new NotImplementedException();
        }
    }
}
