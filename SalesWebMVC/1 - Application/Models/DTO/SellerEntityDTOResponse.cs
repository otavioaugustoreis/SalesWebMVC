using SalesWebMVC.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SalesWebMVC.Models.DTO
{
    public class SellerEntityDTOResponse()
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string DsNome { get; set; }

        [Display(Name = "E-mail")]
        public string DsEmail { get; set; }

        [Display(Name = "Birth Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DhAniversario { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Salary")]
        public double NrSalario { get; set; }

        public int FkDepartamento { get; set; }
        public DepartmentEntity Department { get; set; }
    }
}
