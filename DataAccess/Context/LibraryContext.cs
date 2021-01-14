using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class LibraryContext : IdentityDbContext<User>
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            // Database.EnsureDeleted(); // on program strart delete database
            // Database.EnsureCreated(); // on program strart create database
        }


    }
}
