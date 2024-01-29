using Microsoft.EntityFrameworkCore;
using NewsProject.Server.Context;
using NewsProject.Shared.Models;

namespace NewsProject.Server.Repository.Services
{
    public class CategoriesServices : MainServices<Category>
    {
     private readonly AppDbContext _context;
        public CategoriesServices(AppDbContext context):base(context)
        {
            _context = context;
        }

        public new async Task<Category?> AddRowe(Category entity)
        {
            var cate = _context.Categories.FirstAsync(e => e.Name == entity.Name);
            if (cate==null) 
            {
                await _context.Categories.AddAsync(entity);
                _context.SaveChanges();
                return null;
            }
            else return null;



        }

    }
}
