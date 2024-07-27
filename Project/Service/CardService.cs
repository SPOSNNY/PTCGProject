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

        /// <summary>
        /// 新增卡牌明細資訊
        /// </summary>
        /// <param name="cardModel">卡牌明細</param>
        /// <returns>卡牌明細資訊列表</returns>
        public void CreateCardsDetail(CardModel cardModel)
        {
            _CardDataProcess.CreateCardsDetail(cardModel);
        }

        /// <summary>
        /// 依卡牌編號與版本更新對應的卡牌明細資訊
        /// </summary>
        /// <param name="cardModel">卡牌明細</param>
        /// <returns>卡牌明細資訊列表</returns>
        public void UpdateCardsDetail(CardModel cardModel)
        {
            _CardDataProcess.UpdateCardsDetail(cardModel);
        }

        /// <summary>
        /// 依卡牌編號與版本刪除對應的卡牌明細資訊
        /// </summary>
        /// <param name="cardModel">卡牌明細</param>
        /// <returns>卡牌明細資訊列表</returns>
        public void DeleteCardsDetail(CardModel cardModel)
        {
            _CardDataProcess.DeleteCardsDetail(cardModel);
        }
    }
}
