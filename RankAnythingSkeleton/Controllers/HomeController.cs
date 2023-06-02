using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RankAnythingSkeleton.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            List<RankingItem> items = new List<RankingItem>();// RankingDataAccess.GetAllItems();
            return View(items);
        }


        [HttpPost]
        public ActionResult SubmitItem(string itemName, string imageUrl)
        {
            // Insert the item into the database and set the initial vote count
            // You can use the existing InsertItem method and set the VoteCount to 1
            RankingItem item = new RankingItem
            {
                Name = itemName,
                ImageUrl = imageUrl,
                VoteCount = 1
            };
            // Call the appropriate method from RankingAccess to insert the item
            // (e.g., rankingAccess.InsertItem(item);)

            // Optionally, redirect the user to a success page or back to the index page
            return RedirectToAction("Index");
        }
    }
}