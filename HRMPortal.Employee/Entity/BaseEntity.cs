using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRMPortal.Employee.Entity
{
    public abstract class BaseEntity 
    {
        
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
       
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
    
   
}
