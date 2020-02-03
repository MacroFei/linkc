using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovie.Controllers
{
    public class HelloWorldController : Controller
    {
        // GET: /<controller>/
        /// <summary>
        /// https://localhost:44312/helloworld/index
        /// </summary>
        /// <returns></returns>
        //public string Index()
        //{
        //    return "This is my default action...";
        //}
        public IActionResult Index()
        {
            return View();
        }

        ///// <summary>
        ///// https://localhost:44312/HelloWorld/Welcome?name=Rick&numtimes=4
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="numTimes"></param>
        ///// <returns></returns>
        //public string Welcome(string name , int numTimes  = 1 )
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name} , NumTime is : {numTimes}");
        //}
        ///// <summary>
        ///// https://localhost:44312/HelloWorld/Welcome2/3?name=Rick
        ///// </summary>
        ///// <param name="name"></param>
        ///// <param name="ID"></param>
        ///// <returns></returns>

        //public string Welcome2(string name, int ID = 1)
        //{
        //    return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        //}

        //public IActionResult Welcome(string name , int numTimes = 1)
        //{
        //    ViewData["Message"] = "Hello " + name;
        //    ViewData["NumTimes"] = numTimes;
        //    return View();
        //}

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
