using Microsoft.EntityFrameworkCore;
using NewsProject.Server.Context;
using NewsProject.Shared.Dto;
using NewsProject.Shared.Models;
using System.Collections.Generic;

namespace NewsProject.Server.Repository.Services
{
    public class NewsListServices : MainServices<NewsList> 
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NewsListServices(AppDbContext context, IWebHostEnvironment web) : base(context) 
        {
            _context = context;
            _webHostEnvironment = web;
        }

        public async Task<IEnumerable<NewsList>?> GetAllbyTitle(string Title)
        {
            var respons = await _context.NewsLists.Include(e => e.Category).Where(e => e.Title.Contains(Title)).ToListAsync();
            if (respons == null)
                return null;
            return respons;
        }
        public async Task<IEnumerable<NewsList>?> GetbyCategory(int id) 
        {
            var respons=  await _context.NewsLists.Include(e=>e.Category).Where(e=>e.CategoryId==id).ToListAsync();
            if (respons == null)
                return null;
            return respons;            
        }
        public new async  Task<NewsList?> GetbyId(int id)
        {
            var respons = await _context.NewsLists.Include(e => e.Category).FirstAsync(e=>e.Id==id);
            if (respons == null)
                return null;
            //var result = new NewsListDto()
            //{
            //    CategoryId = respons.CategoryId,
            //    Title = respons.Title,
            //    Details = respons.Details,
            //    ShortDetails = respons.ShortDetails,
            //    SubTitle = respons.SubTitle,
            // //   Image = respons

            //};
            return respons;
        }
        public async Task<NewsList> AddRowe(NewsListDto newsListDto)
        {   
            string FileName = "";
            if(newsListDto.Image!= null) 
            {
                string FullPath = Path.Combine(_webHostEnvironment.WebRootPath, "UploadNewsImage");
                if(!Directory.Exists(FullPath)) 
                {
                    Directory.CreateDirectory(FullPath);
                }
                FileName = Guid.NewGuid() + "_" + newsListDto.Image.FileName;
                string ImagePath = Path.Combine(FullPath, FileName);
                using (var Stream = new FileStream(ImagePath, FileMode.Create))
                {
                   await newsListDto.Image.CopyToAsync(Stream);
                    Stream.Dispose();
                }
            }
            #region  this is way for upload image
            // this is way for upload image  
            //using var Stream = new MemoryStream();
            //await newsListDto.Image.CopyToAsync(Stream);
            #endregion
            var entity = new NewsList()
            {
                Title = newsListDto.Title,
                ShortDetails = newsListDto.ShortDetails,
                SubTitle = newsListDto.SubTitle,
                CategoryId = newsListDto.CategoryId,
                Details = newsListDto.Details,
                Imagepath = FileName                  
            };
            await _context.NewsLists.AddAsync(entity);   
            _context.SaveChanges();
            return entity;
        }

    }
}
