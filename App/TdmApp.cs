using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class TdmApp
    {
        public int GetSecond()
        {
            int second = 0;
            SqlDataReader sqldr = SqlHelper.ExecuteReader("SELECT TOP 1  t.f_dm FROM T_dm t");
            while(sqldr.Read())
            {
                second = Convert.ToInt32(sqldr[0]);
            }
            return second;
        }
    }
}
