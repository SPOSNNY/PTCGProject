using System.ComponentModel.DataAnnotations;

namespace PTCGProject.Models
{
    public class CardModel
    {
        public int CardId { get; set; }

        [Display(Name = "卡片名稱")]
        public string CardName { get; set; }

        [Display(Name = "卡片屬性")]
        public string? CardAttribute { get; set; }

        [Display(Name = "卡片類別")]
        public string? CardType { get; set; }

        [Display(Name = "卡片稀有度")]
        public string? CardRarity { get; set; }

        [Display(Name = "卡片版本代號")]
        public string? CardVersion { get; set; }
    }
}
