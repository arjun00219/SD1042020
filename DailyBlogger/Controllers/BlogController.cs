using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DailyBlogger.Models;


namespace DailyBlogger.Controllers
{
    public class BlogController : Controller
    {
        private BlogContext _context;

        public BlogController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult Details(int id)
        {
            BlogPost blogPost = _context.blogPost.Find(id);
            return View(blogPost);
        }

        public IActionResult List()
        {
            IEnumerable<BlogPost> posts =   _context.blogPost.ToList<BlogPost>();
            return View(posts);
        }

        public IActionResult New()
        {
            BlogPost blogPost = new BlogPost();

            return View(blogPost);

        }

        public IActionResult Edit(int id)
        {
            BlogPost blogPost = _context.blogPost.Find(id);
            return View(blogPost);
        }


        public IActionResult Delete([Bind("id")] int id)
        {
            BlogPost blogPost = _context.blogPost.Find(id);
            _context.Remove(blogPost);
            _context.SaveChanges();
            return RedirectToAction(nameof(List));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([Bind("blogTitle,content,blogDate,id")] BlogPost blog)
        {
            if (ModelState.IsValid)
            {
                _context.Update(blog);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(blog);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("blogTitle,content,blogDate")] BlogPost blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                _context.SaveChanges();
                return RedirectToAction(nameof(List));
            }
            return View(blog);
        }

    }
}