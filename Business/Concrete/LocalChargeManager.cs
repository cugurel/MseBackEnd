using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
namespace Business.Concrete
{
    public class LocalChargeManager : ILocalChargeService
    {
        private readonly ILocalChargeDal _localChargeDal;

        public LocalChargeManager(ILocalChargeDal localChargeDal)
        {
            _localChargeDal = localChargeDal;
        }

        public IResult Add(LocalCharge localCharge)
        {
            _localChargeDal.Add(localCharge);
            return new SuccessResult(Messages.addedLocalService);
        }

        public IResult Delete(LocalCharge localCharge)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<LocalCharge>> GetAll()
        {
            return new SuccessDataResult<List<LocalCharge>>(_localChargeDal.GetAll());
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
