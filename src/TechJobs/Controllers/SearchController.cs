using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchType.Equals("all"))
            {

                List<Dictionary<string, string>> searchJobs = new List<Dictionary<string, string>>();
                foreach (Dictionary<string, string> job in JobData.FindAll())
                {
                    bool searchBool = false;
                    foreach (KeyValuePair<string, string> each in job)
                    {
                        string aValue = each.Value;
                        if (aValue.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                        {
                            searchBool = true;
                        }
                    }
                    if (searchBool == true)
                    {
                        searchJobs.Add(job);
                    }
                }
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search Jobs";
                ViewBag.jobs = searchJobs;
                return View("Index");

            }

            else
            {
                List<Dictionary<string, string>> jobs = new List<Dictionary<string, string>>();

                foreach (Dictionary<string, string> row in JobData.FindAll())
                {
                    string aValue = row[searchType];

                    if (aValue.IndexOf(searchTerm, StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        jobs.Add(row);
                    }
                }
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search Jobs";
                ViewBag.jobs = jobs;
                return View("Index");
            }
            

        }

        
        // TODO #1 - Create a Results action method to process 
        // search request and display results

    }
}
