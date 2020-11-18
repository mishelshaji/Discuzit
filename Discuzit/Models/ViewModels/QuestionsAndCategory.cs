using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Discuzit.Models.ViewModels
{
    public class QuestionsAndCategory
    {
        public ICollection<Question> Questions { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}