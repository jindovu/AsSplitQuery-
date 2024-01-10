using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Entity
{
    public class FabricTestResultTo
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public int FabricTestId { get; set; }
        public int UserId { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public virtual FabricTest FabricTest { get; set; }
        public virtual User User { get; set; }
    }
}
