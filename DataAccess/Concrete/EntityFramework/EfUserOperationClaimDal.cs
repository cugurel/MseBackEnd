using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entity.Concrete;
using Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserOperationClaimDal : EfEntityRepositoryBase<UserOperationClaim, ContextDb>, IUserOperationClaimDal
    {
        public List<UserOperationClaimDto> GetListDto(int userId)
        {
            using (var context = new ContextDb())
            {
                var result = from userOperationClaim in context.UserOperationClaims.Where(x => x.UserId == userId)
                             join operationClaim in context.OperationClaims
                             on userOperationClaim.OperationClaimId equals operationClaim.Id
                             select new UserOperationClaimDto
                             {
                                 UserId = userId,
                                 Id = operationClaim.Id,
                                 OperationClaimId = operationClaim.Id,
                                 OperationDescription = operationClaim.Description,
                                 Name = operationClaim.Name,
                             };
                return result.ToList();
            }
        }
    }
}
