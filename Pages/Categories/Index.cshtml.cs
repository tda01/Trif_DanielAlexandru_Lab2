﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Trif_DanielAlexandru_Lab2.Data;
using Trif_DanielAlexandru_Lab2.Models;
using Trif_DanielAlexandru_Lab2.Models.ViewModels;

namespace Trif_DanielAlexandru_Lab2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Trif_DanielAlexandru_Lab2.Data.Trif_DanielAlexandru_Lab2Context _context;

        public IndexModel(Trif_DanielAlexandru_Lab2.Data.Trif_DanielAlexandru_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public BookData bookData { get; set; }
        public int CategoryID { get; set; }

        public async Task OnGetAsync(int? id, int? bookCategoryID)
        {
            bookData = new BookData();
            bookData = new BookData();
            bookData.Categories = await _context.Category
                .Include(c => c.BookCategories)
                .ThenInclude(bc => bc.Book)
                .ThenInclude(b => b.Author)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = bookData.Categories.SingleOrDefault(c => c.ID == id.Value);

                if (category != null)
                {
                    bookData.Books = category.BookCategories.Select(bc => bc.Book).ToList();
                }
            }
        }
    }
}
