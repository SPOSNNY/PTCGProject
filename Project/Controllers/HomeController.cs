using Dapper;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using PTCGProject.Models;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private IDbConnection _dbConnection;
        public HomeController(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public IActionResult Index()
        {
            List<CardModel> cards =  _dbConnection.Query<CardModel>("select * from PKM_DETAIL").ToList();
            return View(cards);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
