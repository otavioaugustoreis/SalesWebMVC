using SalesWebMVC.Patterns;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SalesWebMVC.Data.Entity
{
    //Departamento 
    [Table("TB_DEPARTMENT")]
    public class DepartmentEntity : EntityPattern
    {
        
        [Column("ds_nome")]
        public string DsNome { get; set; }

        [JsonIgnore]
        public List<SellerEntity> ListSeller { get; set; } = new List<SellerEntity>();

        public DepartmentEntity(int id, string DsNome) : base(id)
        {
            this.DsNome = DsNome;
        }

        public DepartmentEntity() :
            base()
        {
        }

        public void AddSeller(SellerEntity seller)
        {
            ListSeller.Add(seller);
        }

        public double totalSales(DateTime initial, DateTime final)
        {
            /*Jeito que eu fiz
             double value = 0.0;

            ListSeller.ForEach(p =>
            {
              value +=  p.SalesRecords.Where(d => d.DhInclusao >= initial && d.DhInclusao <= final)
                               .Select(s => s.Valor)
                               .Sum();
            });

            return value;*/

            //Jeito do nélio
            return ListSeller.Sum(seller => seller.totalSales(initial, final));
        }
    }
}
