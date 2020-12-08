using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Discuzit.Models
{
    public class Question
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(70)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(10000)]
        public string Body { get; set; }

        public int TotalAnswers { get; set; }
        public int TotalUpVotes { get; set; }
        public int TotalDownVotes { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public string CreatedBy { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}