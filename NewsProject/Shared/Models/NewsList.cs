using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Models
{
    public class NewsList
    {
        public int Id { get; set; }
        public DateTime NewsDate { get; set; } = DateTime.Now;
        public string Title { get; set; }  
        public string SubTitle {  get; set; }
        public string ShortDetails { get; set; }
        public string Details { get; set; }
        public string? Imagepath { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
