using Dapper;
using Microsoft.AspNetCore.Mvc;
using Project.Models;
using PTCGProject.DataProcess;
using PTCGProject.Models;
using PTCGProject.Service;
using System;
using System.Data;
using System.Data.Common;
using System.Diagnostics;

namespace Project.Controllers
{
    public class HomeController : Controller
    {
        private CardService _CardService;
        public HomeController(IDbConnection dbConnection)
        {
            _CardService = new CardService(dbConnection);
        }

        public IActionResult Index()
        {
            List<CardModel> InitCards = Init();
            return View(InitCards);
        }

        /// <summary>
        /// 點擊查詢依卡牌條件查詢卡牌列表
        /// </summary>
        /// <param name="cardModel">卡牌條件</param>
        /// <returns>卡牌列表</returns>
        [HttpPost]
        public IActionResult Index(CardModel cardModel)
        {
            List<CardModel> cards = _CardService.GetCardsDetail(cardModel);
            Init();
            return View(cards);
        }

        //初始化查詢選單下拉式列表
        private List<CardModel> Init()
        {
            List<CardModel> InitCards = _CardService.GetCardsDetail();
            ViewBag.CardAttributes = InitCards.Select(c => c.CardAttribute).Distinct();
            ViewBag.CardTypes = InitCards.Select(c => c.CardType).Distinct();
            ViewBag.CardRarities = InitCards.Select(c => c.CardRarity).Distinct();
            ViewBag.CardVersions = InitCards.Select(c => c.CardVersion).Distinct();
            return InitCards;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
