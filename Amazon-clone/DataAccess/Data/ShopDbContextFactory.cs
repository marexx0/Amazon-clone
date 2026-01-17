using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Amazon_clone.DataAccess.Data
{
        public class ShopDbContextFactory : IDesignTimeDbContextFactory<ShopDbContext>
        {
            public ShopDbContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<ShopDbContext>();

                optionsBuilder.UseSqlServer(
                    "workstation id=AlloraDb.mssql.somee.com;packet size=4096;user id=marexx000_SQLLogin_1;pwd=pt5bdwainv;data source=AlloraDb.mssql.somee.com;persist security info=False;initial catalog=AlloraDb;TrustServerCertificate=True"
                );

                return new ShopDbContext(optionsBuilder.Options);
            }
        }
}
