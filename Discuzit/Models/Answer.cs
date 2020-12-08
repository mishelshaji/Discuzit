using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Discuzit.Models
{
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 Id { get; set; }

        [MinLength(5)]
        [MaxLength(2000)]
        public string Body { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LastUpdated { get; set; }

        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Question Question { get; set; }
        public Int64 QuestionId { get; set; }
    }
}