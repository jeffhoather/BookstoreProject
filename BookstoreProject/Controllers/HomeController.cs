﻿using BookstoreProject.Models;
using BookstoreProject.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository repo;

        public HomeController (IBookstoreRepository temp)
        {
            repo = temp;
        }

        public IActionResult Index(string bookType, int pageNum)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = repo.Books
                .Where(b => b.Category == bookType || bookType == null)
                .OrderBy(b => b.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = (bookType == null 
                        ? repo.Books.Count() 
                        : repo.Books.Where(x => x.Category == bookType).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };
        
                return View(x);
         }
     }
 }

