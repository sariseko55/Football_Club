using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Football_Club
{
    class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection(@"Data Source=.;Initial Catalog=Futbol_Bilgi;Integrated Security=True; Connection timeout=0");
            baglan.Open();
            return baglan;
        }
    }
}
