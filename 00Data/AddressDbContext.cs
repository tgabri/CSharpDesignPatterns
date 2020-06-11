using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00Data
{
    public class AddressDbContext : DbContext
    {
        public DbSet<MyAddress> MyAddresses { get; set; }
    }

    /// <summary>
    /// EF megkeresi, hogy a DbContext mellett van-e AddresContext
    /// </summary>
    public class MyConfig : DbConfiguration
    {
        public MyConfig()
        {
            Console.WriteLine("MyConfig");
            SetExecutionStrategy("System.Data.SqlClient", () => new MyStrategy(5, TimeSpan.FromSeconds(30)));
        }
    }

    public class MyStrategy : SqlAzureExecutionStrategy
    {
        public MyStrategy(int maxRetryCount, TimeSpan maxDelay) : base(maxRetryCount, maxDelay)
        {
            Console.WriteLine("MyStrategy");
        }

        protected override TimeSpan? GetNextDelay(Exception lastException)
        {
            var result = base.GetNextDelay(lastException);
            Console.WriteLine("GetNextDelay - Exception: {0},GetNextDelay - Result: {1}", lastException.Message, result);
            return result;
        }

        protected override bool ShouldRetryOn(Exception exception)
        {
            var errorToRetry = new int[] { -1, 109, 233 };
            var isRetrying = false;
            var result = base.ShouldRetryOn(exception);

            var sqlException = exception as SqlException;

            if (sqlException != null)
            {
                foreach (SqlError error in sqlException.Errors)
                {
                    Console.WriteLine("ShouldRetryOn - Error Number: {0},ShouldRetryOn - Result: {1}", error.Number, result);
                    if (errorToRetry.Contains(error.Number))
                    {
                        isRetrying = true;
                    }
                }
            }
            Console.WriteLine("ShouldRetryOn - Exception: {0},ShouldRetryOn - Result: {1}, isRetrying: {2}", exception.Message, result, isRetrying);
            //return result;
            return true;
        }
    }
}
