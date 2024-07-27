using PTCGProject.DataProcess;
using PTCGProject.Models;
using System.Data;

namespace PTCGProject.Service
{
    public class CardService
    {
        private CardDataProcess _CardDataProcess;
        public CardService(IDbConnection dbConnection) 
        {
            //實作注入CardDataProcess
            _CardDataProcess = new CardDataProcess(dbConnection);
        }

        /// <summary>
        /// 依查詢條件取得卡牌明細資訊
        /// </summary>
        /// <param name="cardModel">卡牌查詢條件</param>
        /// <returns>卡牌明細資訊列表</returns>
        public List<CardModel> GetCardsDetail(CardModel cardModel = null) 
        {
           return _CardDataProcess.GetCardsDetail(cardModel);
        }
    }
}
