using Microsoft.EntityFrameworkCore;
using NewsProject.Server.Context;
using NewsProject.Server.Repository.Main;

namespace NewsProject.Server.Repository.Services
{
    public class MainServices<T> : MainInterface<T> where T : class
    {
        private readonly AppDbContext _context;      
        public MainServices(AppDbContext context) { _context = context; }
        public async Task<IEnumerable<T>?> GetAll()
        {
           var respons=await _context.Set<T>().ToListAsync();
            if (respons == null)
                return null;
            return respons;
        }
        //Get All With include 
        public async Task<IEnumerable<T>?> GetAll(string include)
        {
            var respons = await _context.Set<T>().Include(include).ToListAsync();
            if (respons == null)
                return null;
            return respons;
        }
        public async Task<T?> GetbyId(int id)
        {
            var respons = await _context.Set<T>().FindAsync(id);
            if (respons == null)
                return null;
            return respons;
        }

        public  async Task<T> AddRowe(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            _context.SaveChanges(); 
            return entity;
        }
        public async Task<T?> Update(int id, T entity)
        {
            var item = await GetbyId(id);
            if (item == null)
                return null;
            _context.Set<T>().Update(item);
            _context.SaveChanges();
            return item;

            //----Other way for Update without id----
            //DbSet<T> st = _context.Set<T>();
            //st.Attach(entity);
            // _context.Entry(entity).State = EntityState.Modified;
            //return entity;
        }
        public async Task Delete(int id)
        {
              var item = await GetbyId(id);
              if (item == null)
                return ;
              _context.Set<T>().Remove(item);
              _context.SaveChanges(); 
        }

        
    }
}
