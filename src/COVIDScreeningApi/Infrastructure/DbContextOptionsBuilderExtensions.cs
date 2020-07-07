using Microsoft.EntityFrameworkCore;

namespace COVIDScreeningApi
{
    public static class DbContextOptionsBuilderExtensions
    {
        public static DbContextOptionsBuilder UseCosmos(this DbContextOptionsBuilder builder,
            string connectionString,
            string databaseName)
        {
            string[] connectionStringParts = connectionString.Split(';');
            string uri = connectionStringParts[0].Replace("AccountEndpoint=", "");
            string key = connectionStringParts[1].Replace("AccountKey=", "");
            return builder.UseCosmos(uri, key, databaseName);
        }
    }
}