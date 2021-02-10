using DataAccess.Context;
using DataAccess.Repository.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(LibraryContext context) : base(context)
        {

        }
        public async Task<Tag> GetByIdAsync(int id)
        {
            return await libraryContext.Tags.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
