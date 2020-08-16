using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DailyBlogger.Models
{
    public class BlogPost
    {
        [Key]
        public int id {get; set;}
        [Display(Name = "Post Title")]
        public string blogTitle { get; set; }
        [Display(Name = "Write Blog Post Below")]
        public string content { get; set; }
        [Display(Name = "Date")]
        public DateTime blogDate { get; set; }
    }
}
