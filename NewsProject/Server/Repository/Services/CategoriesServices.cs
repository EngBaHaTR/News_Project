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

        public new async Task<String?> AddRowe(Category entity)
        {
           

                await _context.Categories.AddAsync(entity);
                        _context.SaveChanges();      
            return "this is olredyyyyyyy";

        }
        public async Task<string?> Exesist(string name) 
        {
            var c = await _context.Categories.Where(e=>e.Name == name).FirstOrDefaultAsync();
            if (c != null) 
              return "Exext";

            return null;

        }





    }
}
