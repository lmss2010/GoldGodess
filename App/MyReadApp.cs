using App.Dom;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    public class MyReadApp
    {
        public MyRead GetMyRead(string UserID)
        {
            SqlParameter[] sp = new SqlParameter[5];
            sp[0] = new SqlParameter("@UserID", SqlDbType.VarChar);
            sp[0].Value = UserID;
            sp[1] = new SqlParameter("@fPPT", SqlDbType.Int);
            sp[1].Direction = ParameterDirection.Output;
            sp[2] = new SqlParameter("@fSet", SqlDbType.Int);
            sp[2].Direction = ParameterDirection.Output;
            sp[3] = new SqlParameter("@fSetM", SqlDbType.Int);
            sp[3].Direction = ParameterDirection.Output;
            sp[4] = new SqlParameter("@fGameM", SqlDbType.Int);
            sp[4].Direction = ParameterDirection.Output;
            SqlDataReader sqldr = SqlHelper.ExecuteReader("myRead", CommandType.StoredProcedure, sp);
            try
            {
                MyRead myRead = new MyRead()
                {
                    UserID = UserID,
                    fPPT = int.Parse(sp[1].Value.ToString()),
                    fSet = int.Parse(sp[2].Value.ToString()),
                    fSetM = int.Parse(sp[3].Value.ToString()),
                    fGameM = int.Parse(sp[4].Value.ToString()),
                };
                return myRead;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                sqldr.Close();
                sqldr.Dispose();
            }
        }
    }
}
