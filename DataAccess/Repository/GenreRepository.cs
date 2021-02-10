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
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(LibraryContext context) : base(context) { }
        public async Task<Genre> GetByIdAsync(int id)
        {
            return await libraryContext.Genres.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
