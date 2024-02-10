using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using NewsProject.Server.Context;
using NewsProject.Shared.Models;
using System.Security.Cryptography;

namespace NewsProject.Server.Repository.Services
{
    public class CategoriesServices : MainServices<Category>
    {
     private readonly AppDbContext _context;
        public CategoriesServices(AppDbContext context):base(context)
        {
            _context = context;
        }
        //public async Task <bool> Exesist(Category entity) 
        //{
        //    return await _context.Categories.AnyAsync(e => e.Name == entity.Name);  
               
        //}

    }
}
