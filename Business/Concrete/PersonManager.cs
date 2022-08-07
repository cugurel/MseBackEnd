using Business.Abstract;
using Business.BusinessAspects;
using Business.Constants;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonManager : IPersonService
    {
        private readonly IPersonDal _personDal;

        public PersonManager(IPersonDal personDal)
        {
            _personDal = personDal;
        }

        public IResult Add(Person person)
        {
            person.IsActive= true;
            _personDal.Add(person);
            return new SuccessResult(Messages.addedPerson);
        }

        //[SecuredOperation("Company.Delete")]
        public IResult Delete(Person person)
        {
            _personDal.Delete(person);
            return new SuccessResult(Messages.deletedPerson);
        }

        public IDataResult<List<Person>> GetAll()
        {
            return new SuccessDataResult<List<Person>>(_personDal.GetAll());
        }

        public IDataResult<Person> GetById(int id)
        {
            return new SuccessDataResult<Person>(_personDal.Get(x => x.Id == id));
        }

        public IResult Update(Person person)
        {
            _personDal.Update(person);
            return new SuccessResult(Messages.updatedPerson);
        }
    }
}
