using Microsoft.AspNetCore.Mvc;
using PTCGProject.Models;
using PTCGProject.Service;
using System.Data;

namespace PTCGProject.Controllers
{
    public class CardManageController : Controller
    {
        private CardService _CardService;
        public CardManageController(IDbConnection dbConnection)
        {
            _CardService = new CardService(dbConnection);
        }

        public IActionResult CardManage()
        {
            List<CardModel> InitCards = _CardService.GetCardsDetail();
            return View(InitCards);
        }

        [HttpGet]
        public IActionResult EditCard(CardModel Card)
        {
            return View(Card);
        }

        [HttpPost]
        public IActionResult EditCard(string id,string version)
        {
            CardModel Card = new CardModel();
            Card.CardId = id;
            Card.CardVersion = version;

            Card = _CardService.GetCardsDetail(Card).FirstOrDefault();

            return Json(new { redirectUrl = Url.Action("EditCard", "CardManage", Card) });
        }

        [HttpPost]
        public IActionResult Update(CardModel Card) 
        {

            return RedirectToAction("CardManage", "CardManage");
        }

        [HttpGet]
        public IActionResult AddCard()
        {
            CardModel Card = new CardModel();
            return View(Card);
        }

        [HttpPost]
        public IActionResult Create(CardModel Card)
        {
            return View(Card);
        }

        public IActionResult DeleteCard()
        {
            return RedirectToAction("CardManage", "CardManage");
        }
    }
}
