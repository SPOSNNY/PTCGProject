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

        /// <summary>
        /// 卡牌管理主頁
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CardManage()
        {
            List<CardModel> InitCards = _CardService.GetCardsDetail();
            return View(InitCards);
        }

        /// <summary>
        /// 新增卡牌頁面
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult AddCard()
        {
            //預設給一個卡牌物件防止前端Model Null
            CardModel Card = new CardModel();
            return View(Card);
        }

        /// <summary>
        /// 新增卡牌頁面後跳轉至卡牌管理主頁
        /// </summary>
        /// <param name="Card">卡牌明細</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(CardModel Card)
        {
            _CardService.CreateCardsDetail(Card);
            return RedirectToAction("CardManage", "CardManage");
        }

        /// <summary>
        /// 編輯卡牌資料頁面
        /// </summary>
        /// <param name="Card">卡牌明細</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult EditCard(CardModel Card)
        {
            return View(Card);
        }

        /// <summary>
        /// 轉跳編輯卡牌頁面前的資料查詢方法
        /// </summary>
        /// <param name="id">卡牌編號</param>
        /// <param name="version">卡牌版本</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult EditCard(string id,string version)
        {
            CardModel Card = new CardModel();
            Card.CardId = id;
            Card.CardVersion = version;

            //依卡牌編號及版本查詢卡牌明細
            Card = _CardService.GetCardsDetail(Card).FirstOrDefault();

            //回傳Json至前端進行跳轉編輯卡牌資料頁面
            return Json(new { redirectUrl = Url.Action("EditCard", "CardManage", Card) });
        }

        /// <summary>
        /// 更新卡牌資料後轉跳卡牌管理主頁
        /// </summary>
        /// <param name="Card">卡牌明細</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Update(CardModel Card) 
        {
            _CardService.UpdateCardsDetail(Card);
            return RedirectToAction("CardManage", "CardManage");
        }

        /// <summary>
        /// 刪除卡牌頁面後跳轉至卡牌管理主頁
        /// </summary>
        /// <param name="Card">卡牌明細</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult DeleteCard(string id, string version)
        {
            CardModel Card = new CardModel();
            Card.CardId = id;
            Card.CardVersion = version;
            _CardService.DeleteCardsDetail(Card);
            return Json(new { redirectUrl = Url.Action("CardManage", "CardManage") });
        }
    }
}
