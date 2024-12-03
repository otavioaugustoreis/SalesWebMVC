using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Patterns
{
    public abstract class EntityPattern
    {
       
        [Required]
        [Column("pk_id")]
        public int Id { get; set; }

        [Column("dh_inclusao")]
        public DateTime DhInclusao { get; set; } = DateTime.Now;

        protected EntityPattern()
        {
        }
        protected EntityPattern(int id)
        {
            Id = id;
        }
    }
}
