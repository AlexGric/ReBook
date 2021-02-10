using DataAccess.Infrastructure;
using DataAccess.UnitOfWork;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Service
{
    class TagService
    {
        private readonly IUnitOfWork unitOfWork;
        public TagService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        public async Task<OperationDetail> CreateAsync(Tag entity)
        {
            var res = await unitOfWork.TagRepository.CreateAsync(entity);
            await unitOfWork.SaveChangesAsync();
            return res;
        }

        public async Task<IReadOnlyCollection<Tag>> FindByConditionAsync(Expression<Func<Tag, bool>> predicat)
        {
            return await unitOfWork.TagRepository.FindByConditionAsync(predicat);
        }


        public async Task<IReadOnlyCollection<Tag>> GetAllAsync()
        {
            return await unitOfWork.TagRepository.GetAllAsync();
        }
    }
}
