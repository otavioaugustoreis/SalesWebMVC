using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SalesWebMVC.Patterns;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace SalesWebMVC.Data.Entity
{
    //Vendedor 
    [Table("TB_SELLER")]
    public class SellerEntity : EntityPattern
    {
        [Column("ds_email")]
        public string DsEmail { get; set; }

        [Display(Name = "Name")]
        [Column("ds_nome")]
        public string DsNome { get; set; }

        [Column("dh_aniversario")]
        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DhAniversario { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Salary")]
        [Column("nr_salario")]
        public double NrSalario { get; set; }

        public DepartmentEntity Department { get; set; }

        [Column("fk_departamento")]
        public int FkDepartamento { get; set; } 

        public List<SalesRecordEntity> SalesRecords { get; set; }

        public SellerEntity() : base() { }

        public SellerEntity(int id, string dsEmail, string dsNome, DateTime dhAniversario, double nrSalario, DepartmentEntity departmentEntity) :
            base(id)
        {
            DsEmail = dsEmail;
            DsNome = dsNome;
            DhAniversario = dhAniversario;
            NrSalario = nrSalario;
            Department = departmentEntity;
        }

        public void addSales(SalesRecordEntity salesRecordEntity)
        {
            SalesRecords.Add(salesRecordEntity);
        }

        public void removeSales(SalesRecordEntity salesRecordEntity)
        {
            SalesRecords.Remove(salesRecordEntity);
        }

        public double totalSales(DateTime initial, DateTime final)
        {
            return SalesRecords.Where(d => d.DhInclusao >= initial && d.DhInclusao <= final)
                               .Select(s => s.Valor)
                               .Sum();
        }
    }
}
