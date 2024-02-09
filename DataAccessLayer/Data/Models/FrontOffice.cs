using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    public class Visitor : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string? Purpose { get; set; }
        public string? Name { get; set; } 

        public string? Phone { get; set; }  
        
        public DateTime? Date { get; set; }
        public TimeOnly InTime { get; set; }
        public TimeOnly OutTime { get; set; }
        public bool Status { get; set; } = true;

    }
    public class PhoneCallLog : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public DateTime? NextFollowUpDate { get; set; }
        public string? CallType { get; set;}
        public string? Remarks { get; set;}
    }

    public class PostalDispatch : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string? ToTitle { get; set; }
        public string? FromTitle { get; set;}
        public string? Reference { get; set; }
        public string? ToPhoneNumber { get; set; }
        public DateTime? Date { get; set; }
        public string? Action { get; set; }

    }

    public class PostalReceive : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string? FromTitle { get; set;}
        public string? ToTitle { get; set; }
        public string? Reference { get; set;}
        public DateTime? Date { get; set; }
        public string? Action { get; set; }
    }

    public class Complain : BaseModel
    {
        [Key]
        public int Id { get; set; }
        public string? ComplainName { get; set; }
        public string? ComplainType { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public DateTime? Date { get; set; }
        public string? Action { get; set; }
    }
}
