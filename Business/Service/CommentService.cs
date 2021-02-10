using DataAccess.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Service
{
    public class CommentService
    {
        private IUnitOfWork unitOfWork;

        public CommentService(IUnitOfWork unitOfWork)
        { this.unitOfWork = unitOfWork; }

    }
}
