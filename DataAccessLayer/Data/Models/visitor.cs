using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data.Models
{
    public class Visitor
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
}
