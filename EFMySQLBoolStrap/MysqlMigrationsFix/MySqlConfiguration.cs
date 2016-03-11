using System.Data.Entity;

namespace EFMySQLBoolStrap.MysqlMigrationsFix
{
  public class MySqlConfiguration : DbConfiguration
  {
    public MySqlConfiguration()
    {
      SetHistoryContext(
      "MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema));
    }
  }
}