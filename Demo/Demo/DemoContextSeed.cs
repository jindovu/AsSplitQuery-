using Demo.Entity;
using Demo.Repository;
using Demo.Repository.Repository;

namespace EzPz.EasyPeasy.Infrastructure.Data
{
    public class DemoContextSeed
    {
        public static void SeedAsync(IServiceProvider serviceProvider)
        {
            var fabricTestRepository = serviceProvider.GetRequiredService<IFabricTestRepository>();

            var fabricTest = new FabricTest()
            {
                Guid = Guid.NewGuid(),
                Name = "Test 1",
                IsActive = true,
                IsDeleted = false,
                FabricTestResultTo = new List<FabricTestResultTo>()
                {
                    new FabricTestResultTo()
                    {
                        IsActive = true,
                        IsDeleted = false,
                        User = new User()
                        {
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Test 1"
                        }
                    },
                    new FabricTestResultTo()
                    {
                        IsActive = true,
                        IsDeleted = false,
                        User = new User()
                        {
                            IsActive = true,
                            IsDeleted = false,
                            Name = "Test 2"
                        }
                    }
                }
            };

            fabricTestRepository.InsertFabric(fabricTest);
        }
    }
}
