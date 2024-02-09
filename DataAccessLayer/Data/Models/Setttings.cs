using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    public class BaseModel
    {
        public DateTime? FiscalYear { get; set; }
        public DateTime? DateAdded { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool? IsDeleted { get; set; }
        public string? AddedBy { get; set; }
    }
    public class Unit : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UnitName { get; set; }
        public string UnitDescription { get; set; } = string.Empty;
    }

    public class IncomeHead : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string IncomeName { get; set; }
        public string IncomeType { get; set; }
        public string? IncomeTypeDescription { get; set; }
    }

    public class ExpenseHead : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Heading { get; set; }
        public string? ExpenseHeadingDescription { get; set; }
    }

    public class AddWork : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Heading { get; set; }
        public int Rate { get; set; }
        public string? Remarks { get; set; }
    }

    public class PaymentMethod : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string PaymentMethodName { get; set; }
        public string? Remarks { get; }
    }

    public class AddWorkProcess : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Remarks { get; set; }
    }
}