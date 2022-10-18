using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    [Table("ItemInfo")]
    public class Item
    {
        [Key]
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal? PurchasePrice { get; set; }
        public decimal SellPrice { get; set; }
    }
}
