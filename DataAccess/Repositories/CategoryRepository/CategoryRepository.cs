﻿using System;
using DataAccess.DbContexts;
using BussinessObject.Models;
using DataAccess.Infrastructure;

namespace DataAccess.CategoryRepository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(NewspaperDbContext db) : base(db)
        {

        }
    }
}

