using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    [Table("OrderInfo")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderDate { get; set; }
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public Customer? Customer { get; set; }
        public int ItemId { get; set; }
        [ForeignKey("ItemId")]
        public Item? Item { get; set; }
        public int UnitId { get; set; }
        [ForeignKey("UnitId")]
        public Unit? Unit { get; set; }
        public decimal? Rate { get; set; } = 0;
        public decimal? Quantity { get; set; } = 0;
        public decimal? Total { get; set; } = 0;
        public decimal? DiscountPer { get; set; } = 0;
        public decimal? DiscountAmount { get; set; } = 0;
        public decimal? GrossTotal { get; set; } = 0;
        public decimal? Paid { get; set; } = 0;
        public decimal? Due { get; set; } = 0;
    }
}
