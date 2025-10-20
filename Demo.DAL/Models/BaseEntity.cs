using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DAL.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }//user id
        
        public DateTime CreatedOn { get; set; }//insertion date
        public int LastModifiedBy { get; set; }//user id

        public DateTime LastModifiedOn { get; set; }//update date
        public bool IsDeleted { get; set; }//to apply soft delete
    }
}
