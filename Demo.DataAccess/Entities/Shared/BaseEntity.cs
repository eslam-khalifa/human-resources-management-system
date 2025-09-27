using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Entities.Shared
{
    public class BaseEntity
    {
        public int Id { get; set; } // Primary key
        public int CreatedBy { get; set; } // User ID who created the record
        public DateOnly? CreatedOn { get; set; }
        public int LastModifiedBy { get; set; } // User ID who last modified the record
        public DateOnly? LastModifiedOn { get; set; }
        public bool IsDeleted { get; set; } // Soft delete flag
    }
}
