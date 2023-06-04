using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SloziSliku_29_2019
{
    public class DBConnection
    {
        private static SqlConnection _connection = null;
        private static readonly object Lock = new object();

        public static SqlConnection Connection
        {
            get
            {
                lock (Lock)
                {
                    if (_connection == null)
                        _connection = new SqlConnection(@"Data Source=(localdb)\server1;Initial Catalog=Igrica;Integrated Security=True");
                }
                return _connection;
            }
        }
    }
}
