using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Discuzit.Models
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Name is required")]
        [MinLength(1)]
        [MaxLength(20)]
        public string CategoryName { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(10)]
        [MaxLength(2000)]
        public string Description { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}