using System.ComponentModel.DataAnnotations;

namespace EF_Core.Data.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

    }
}
