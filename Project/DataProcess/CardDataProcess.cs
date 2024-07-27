
using Dapper;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using PTCGProject.Models;
using System.Data;
using System.Text;

namespace PTCGProject.DataProcess
{
    public class CardDataProcess : BaseDataProcess
    {
        public CardDataProcess(IDbConnection dbConnection) : base(dbConnection)
        {
        }

        /// <summary>
        /// 依查詢條件取得卡牌明細資訊
        /// </summary>
        /// <param name="cardModel">卡牌查詢條件</param>
        /// <returns>卡牌明細資訊列表</returns>
        public List<CardModel> GetCardsDetail(CardModel cardModel)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT RIGHT('000' + CAST(CardId AS VARCHAR(3)), 3) AS CardId
                          　 　,CardName
                               ,CardAttribute
                          	   ,CardType
                          	   ,CardRarity
                               ,CardVersion
                           FROM [dbo].[PKM_DETAIL]
                          WHERE 1 = 1 ");

            if (cardModel != null)
            {
                if (!string.IsNullOrEmpty(cardModel.CardAttribute))
                {
                    sql.Append("AND CardAttribute = @CardAttribute ");
                }

                if (!string.IsNullOrEmpty(cardModel.CardType))
                {
                    sql.Append("AND CardType = @CardType ");
                }

                if (!string.IsNullOrEmpty(cardModel.CardRarity))
                {
                    sql.Append("AND CardRarity = @CardRarity ");
                }

                if (!string.IsNullOrEmpty(cardModel.CardVersion))
                {
                    sql.Append("AND CardVersion = @CardVersion ");
                }

                if (!string.IsNullOrEmpty(cardModel.CardName))
                {
                    sql.Append("AND CardName LIKE @CardName ");
                }
            }

            return _dbConnection.Query<CardModel>(sql.ToString(), cardModel).ToList();
        }
    }
}
