
using Dapper;
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

        public List<CardModel> GetCardsDetail(string attribute, string type, string rarity, string version, string name) 
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

            if (!string.IsNullOrEmpty(attribute)) 
            {
                sql.Append("AND CardAttribute = @CardAttribute ");
            }

            if (!string.IsNullOrEmpty(type))
            {
                sql.Append("AND CardType = @CardType ");
            }

            if (!string.IsNullOrEmpty(rarity))
            {
                sql.Append("AND CardRarity = @CardRarity ");
            }

            if (!string.IsNullOrEmpty(version))
            {
                sql.Append("AND CardVersion = @CardVersion ");
            }

            if (!string.IsNullOrEmpty(name))
            {
                sql.Append("AND CardName LIKE @CardName ");
            }

            var param = new
            {
                CardAttribute = attribute,
                CardType = type,
                CardRarity = rarity,
                CardVersion = version,
                CardName = string.Format(@"%{0}%", name)
            };

           List<CardModel> cards = _dbConnection.Query<CardModel>(sql.ToString(), param).ToList();
            return cards;
        }
    }
}
