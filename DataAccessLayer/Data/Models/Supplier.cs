using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    public class Supplier:BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? ContactNumber { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; } 
        public string? VatPanNo { get; set; }    
        public string? BankName { get;set; }
        public string? BankAcNumber { get; set;}
        public string? BankBranch { get; set; }
        public string? Remarks { get;set;}

    }
}
