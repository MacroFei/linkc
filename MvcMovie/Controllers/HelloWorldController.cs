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
        public string Index()
        {
            return "This is my default action...";
        }

        /// <summary>
        /// https://localhost:44312/HelloWorld/Welcome?name=Rick&numtimes=4
        /// </summary>
        /// <param name="name"></param>
        /// <param name="numTimes"></param>
        /// <returns></returns>
        public string Welcome(string name , int numTimes  = 1 )
        {
            return HtmlEncoder.Default.Encode($"Hello {name} , NumTime is : {numTimes}");
        }

        public string Welcome2(string name, int ID = 1)
        {
            return HtmlEncoder.Default.Encode($"Hello {name}, ID: {ID}");
        }
    }
}
