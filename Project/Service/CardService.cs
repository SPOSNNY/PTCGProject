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
            _CardDataProcess = new CardDataProcess(dbConnection);
        }

        public List<CardModel> GetCardsDetail(string attribute = "", string type = "", string rarity = "", string version = "", string name = "") 
        {
           return _CardDataProcess.GetCardsDetail(attribute, type, rarity, version, name);
        }
    }
}
