using Demo.Entity;
using Demo.Repository.DTO;
using Demo.Repository.Repository;
using Microsoft.EntityFrameworkCore;

namespace Demo.Repository
{
    public class FabricTestRepository : Repository<FabricTest>, IFabricTestRepository
    {
        private readonly IUnitOfWork _unitOfWork;
        public FabricTestRepository(LocalDbContext context,
            IUnitOfWork unitOfWork) : base(context)
        {
            _unitOfWork = unitOfWork;
        }

        public bool InsertFabric(FabricTest fabricTest)
        {
            _unitOfWork.GetRepository<FabricTest>().Insert(fabricTest);
            _unitOfWork.SaveChanges();
            return true;
        }

        public FabricTestSearchResult GetAll(FabricTestSearchDto model)
        {
            var result = new FabricTestSearchResult();
            var data = model.Data;
            var sortColumn = model.SortColumn;

            var query = Query(x => !x.IsDeleted)
                .Include(x => x.FabricTestResultTo)
                .ThenInclude(x => x.User)
                .Where(x => x.IsActive);

            result.TotalRecords = query.Count();
            if (!string.IsNullOrEmpty(sortColumn.ColumnName) && sortColumn.ColumnName.Equals("testResultTo"))
            {
                query = sortColumn.IsAsc ? query.OrderBy(x => string.Join(",", x.FabricTestResultTo.Where(c => !c.IsDeleted).Select(c => c.User.Name).ToList()))
                            : query.OrderByDescending(x => string.Join(",", x.FabricTestResultTo.Where(c => !c.IsDeleted).Select(c => c.User.Name).ToList()));
            }
            else
            {
                query = query.OrderByDescending(x => x.Id);
            }

            var queryResult = query.AsSplitQuery().ToList();
            result.Records = queryResult.Select(ConvertFabricResult).ToList();
            return result;
        }
        private FabricTestResultDto ConvertFabricResult(FabricTest result)
        {
            return new FabricTestResultDto
            {
                Id = result.Id,
                Name = result.Name,
            };
        }
    }
}
