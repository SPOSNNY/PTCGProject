using System.ComponentModel.DataAnnotations;

namespace PTCGProject.Models
{
    /// <summary>
    /// 卡牌明細檔
    /// </summary>
    public class CardModel
    {
        /// <summary>
        /// 卡片編號
        /// </summary>
        [Display(Name = "卡片編號")]
        public string CardId { get; set; }

        /// <summary>
        /// 卡片名稱
        /// </summary>
        [Display(Name = "卡片名稱")]
        public string CardName { get; set; }

        /// <summary>
        /// 卡片屬性
        /// </summary>
        [Display(Name = "卡片屬性")]
        public string? CardAttribute { get; set; }

        /// <summary>
        /// 卡片類別
        /// </summary>
        [Display(Name = "卡片類別")]
        public string? CardType { get; set; }

        /// <summary>
        /// 卡片稀有度
        /// </summary>
        [Display(Name = "卡片稀有度")]
        public string? CardRarity { get; set; }

        /// <summary>
        /// 卡片版本代號
        /// </summary>
        [Display(Name = "卡片版本代號")]
        public string? CardVersion { get; set; }
    }
}
