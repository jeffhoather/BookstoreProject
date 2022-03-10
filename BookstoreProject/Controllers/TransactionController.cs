using BookstoreProject.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookstoreProject.Controllers
{
    public class TransactionController : Controller
    {
        private ITransactionRepository repo { get; set; }
        private Basket basket { get; set; }
        public TransactionController(ITransactionRepository temp, Basket b)
        {
            repo = temp;
            basket = b;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Transaction());
        }

        [HttpPost]
        public IActionResult Checkout(Transaction transaction)
        {
            if(basket.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                transaction.Lines = basket.Items.ToArray();
                repo.SaveTransaction(transaction);
                basket.ClearBasket();

                return RedirectToPage("/TransactionCompleted");
            }
            else
            {
                return View();
            }
        }
    }
}
