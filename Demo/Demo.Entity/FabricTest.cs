using System.Data;

namespace Demo.Entity
{
    public class FabricTest
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<FabricTestResultTo> FabricTestResultTo { get; set; }
    }
}
