using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace SalesWebMVC.Models.DTO
{
    public class ProductDTO
    {
        public int? Id { get; set; }

        [DisplayName("Nome")]
        public string DsNome { get; set; }

        [DisplayName("Quantidade")]
        public int Quantity { get; set; }
    }
}
