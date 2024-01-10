using Demo.Entity;
using Demo.Repository.DTO;
using Demo.Repository.Repository;

namespace Demo.Repository
{
    public interface IFabricTestRepository : IRepository<FabricTest>
    {
        bool InsertFabric(FabricTest fabricTest);
        FabricTestSearchResult GetAll(FabricTestSearchDto model);
    }
}
