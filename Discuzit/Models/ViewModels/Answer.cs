using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Discuzit.Models.ViewModels
{
    public class Answer
    {
        [MinLength(5)]
        [MaxLength(2000)]
        public string Body { get; set; }

    }
}