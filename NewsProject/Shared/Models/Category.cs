using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsProject.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="الفئة مطلوب")]
        [MaxLength(10,ErrorMessage ="baha hala")]
        public string Name { get; set; }

    }
}
