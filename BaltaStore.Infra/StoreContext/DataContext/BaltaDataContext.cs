using System;
using System.Data.SqlClient;

namespace BaltaStore.Infra.StoreContext.DataContext
{
    public class BaltaDataContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public BaltaDataContext()
        {
            Connection = new SqlConnection(BaltaStore.Shared.Settings.ConnectionString);
            Connection.Open();
        }
        public void Dispose()
        {
            if(Connection.State != System.Data.ConnectionState.Closed)
            {
                Connection.Close();
            }
        }
    }
}
