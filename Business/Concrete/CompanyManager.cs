using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Aspects.Caching;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CompanyManager : ICompanyService
    {
        private readonly ICompanyDal _companyDal;

        public CompanyManager(ICompanyDal companyDal)
        {
            _companyDal = companyDal;
        }

        [SecuredOperation("Company.Add")]
        [ValidationAspect(typeof(CompanyValidator))]
        public IResult Add(Company company)
        {
            _companyDal.Add(company);
            return new SuccessResult(Messages.addedCompany);
        }

        public IDataResult<List<Company>> GetAll()
        {
            return new SuccessDataResult<List<Company>>(_companyDal.GetAll(),Messages.listedCompany);
        }

     
    }
}
