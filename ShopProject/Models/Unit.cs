using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopProject.Models
{
    [Table("UnitInfo")]
    public class Unit
    {
        [Key]
        public int Id { get; set; }
        public string UnitName { get; set; }
    }
}
