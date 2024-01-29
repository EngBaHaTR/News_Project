using Microsoft.AspNetCore.Http;

namespace NewsProject.Shared.Dto
{
    public class NewsListDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string ShortDetails { get; set; }
        public string Details { get; set; }
        public IFormFile Image { get; set; }
        public int CategoryId { get; set; }
    }
}
