using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;



public class mysql
{


    public static int executesql(String sql)
    {
        try
        {
            int msg = 0;
            string connectString = ConfigurationManager.AppSettings["myConnectionString"];
            using (SqlConnection conn = new SqlConnection(connectString))
            using (SqlCommand cmd = conn.CreateCommand())
            
            {
                conn.Open();
                cmd.CommandText = sql;
                msg=cmd.ExecuteNonQuery();

            }
            return msg;
        }
        catch { return 0; }

    }

    public static String getmyfieldstring(String sql, String field)
    {


        SqlDataReader rdr = null; //SQL Data Reader Baglantisi
        string connectString = ConfigurationManager.AppSettings["myConnectionString"]; using (SqlConnection conn = new SqlConnection(connectString))
        using (SqlCommand cmd = conn.CreateCommand())
        {


            try
            {
                conn.Open();
                string x = "";

                cmd.CommandText = sql;
                cmd.Connection = conn;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                    x = (rdr[field].ToString());

                rdr.Close();
                return x;


            }
            catch { return ""; }

        }
    }
    public static Int64 getmyfieldint(String sql, String field)
    {


        SqlDataReader rdr = null; //SQL Data Reader Baglantisi
        string connectString = ConfigurationManager.AppSettings["myConnectionString"]; using (SqlConnection conn = new SqlConnection(connectString))
        using (SqlCommand cmd = conn.CreateCommand())
        {


            try
            {
                conn.Open();
                Int64 x = 0;

                cmd.CommandText = sql;
                cmd.Connection = conn;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                    x = Convert.ToInt64((rdr[field].ToString()));

                rdr.Close();
                return x;


            }
            catch { return 0; }


        }
    }
    public static Int64 executesqlid(String sql)
    {
        try
        {

            string connectString = ConfigurationManager.AppSettings["myConnectionString"];
            using (SqlConnection conn = new SqlConnection(connectString))
            using (SqlCommand cmd = conn.CreateCommand())
            {

                int key;
                sql = "SET NOCOUNT ON " + sql + " SELECT CAST(scope_identity() AS int)";
                conn.Open();
                cmd.CommandText = sql;

                key = (Int32)cmd.ExecuteScalar();


                return key;
            }
        }
        catch { return 0; }
    }




    public static SqlDataReader executesqlgiverdr(String sql)
    {
        SqlDataReader rdr = null; //SQL Data Reader Baglantisi
        string connectString = ConfigurationManager.AppSettings["myConnectionString"];
        SqlConnection conn = new SqlConnection(connectString);
        SqlCommand cmd = conn.CreateCommand();

        try
        {

            conn.Open();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            // Execute the query
            rdr = cmd.ExecuteReader();


            return rdr;


        }
        catch { return null; }



    }

    public static DataSet executesqlgiverds(String sql)
    {

        string connectString = ConfigurationManager.AppSettings["myConnectionString"];
        using (SqlConnection conn = new SqlConnection(connectString))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);



                return ds;

            }
            catch { return null; }

        }

    }



    public static void callSP(string spname)
    {
        string connectString = ConfigurationManager.AppSettings["myConnectionString"];
        using (SqlConnection conn = new SqlConnection(connectString))
        {

            try
            {

                conn.Open();
                SqlCommand cmdSP = new SqlCommand(spname, conn);
                cmdSP.CommandType = CommandType.StoredProcedure;
                SqlParameter paramLastName = cmdSP.Parameters.Add("@ln", SqlDbType.NVarChar, 50);
                SqlParameter paramBirthDay = cmdSP.Parameters.Add("@bd", SqlDbType.DateTime);
                SqlParameter paramJob = cmdSP.Parameters.Add("@j", SqlDbType.NVarChar, 50);
                paramLastName.Value = 1;//txtLastName.Text;
                paramBirthDay.Value = 2;//dtBirthDay.Text;
                paramJob.Value = 3;//txtJob.Text;
                // Böylece ilgili paremetrelere degerleri geçirilmis oldu. simdi komutu çalistiralim.
                cmdSP.ExecuteNonQuery();
                cmdSP.Dispose();
            }
            catch { }
        }
    }


    public static DataSet callSPgetDS(string spname)
    {
        String connectString = ConfigurationManager.AppSettings["myConnectionString"];
        DataSet ds = new DataSet();
        using (SqlConnection conn = new SqlConnection(connectString))
        using (SqlCommand cmd = conn.CreateCommand())
        {




            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSP = new SqlCommand(spname, conn);
                cmdSP.CommandType = CommandType.StoredProcedure;

                da.SelectCommand = cmdSP;
                da.Fill(ds);
                //DataTable dt = ds.Tables[dsname];
            }
            catch { }





        }
        return ds;
    }

    public static SqlDataReader callSPgetRdr(string spname)
    {
        SqlDataReader rdr = null; //SQL Data Reader Baglantisi
        string connectString = ConfigurationManager.AppSettings["myConnectionString"];
        using (SqlConnection conn = new SqlConnection(connectString))
        using (SqlCommand cmd = conn.CreateCommand())
        {
            try
            {

                string ConnectionString;
                ConnectionString = ConfigurationManager.AppSettings["myConnectionString"];

                conn.Open();
                SqlCommand cmdSP = new SqlCommand(spname, conn);
                cmdSP.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdSP;
                rdr = cmdSP.ExecuteReader(CommandBehavior.CloseConnection);

            }
            catch { }


        }
        return rdr;
    }

    public static SqlDataReader callSPgetRdrwithParam(string spname, int paramvalue, string paramname)
    {

        SqlDataReader rdr = null; //SQL Data Reader Baglantisi
        string connectString = ConfigurationManager.AppSettings["myConnectionString"];
        SqlConnection conn = new SqlConnection(connectString);
        SqlCommand cmd = conn.CreateCommand();
        {
            try
            {

                conn.Open();
                SqlCommand cmdSP = new SqlCommand(spname, conn);
                cmdSP.CommandType = CommandType.StoredProcedure;
                SqlParameter paramCountry = cmdSP.Parameters.Add("@" + paramname, SqlDbType.Int);
                paramCountry.Value = paramvalue;
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmdSP;


                rdr = cmdSP.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch { }


        }

        return rdr;

    }

    public static DataSet callSPgetDSwithParam(string spname, int paramvalue, string paramname)
    {
        DataSet ds = new DataSet();
        string connectString = ConfigurationManager.AppSettings["myConnectionString"];
        using (SqlConnection conn = new SqlConnection(connectString))
        using (SqlCommand cmd = conn.CreateCommand())
        {

            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmdSP = new SqlCommand(spname, conn);
                cmdSP.CommandType = CommandType.StoredProcedure;

                SqlParameter paramCountry = cmdSP.Parameters.Add("@" + paramname, SqlDbType.Int);
                paramCountry.Value = paramvalue;
                da.SelectCommand = cmdSP;
                da.Fill(ds);
                //DataTable dt = ds.Tables[dsname];



            }
            catch { }
        }
        return ds;

    }

    public static void callSPwithParamString(string spname, string paramname, string p1v)
    {
        string connectString = ConfigurationManager.AppSettings["myConnectionString"];
        using (SqlConnection conn = new SqlConnection(connectString))
        {
            try
            {
                conn.Open();
                SqlCommand cmdSP = new SqlCommand(spname, conn);
                cmdSP.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = cmdSP.Parameters.Add("@" + paramname, SqlDbType.NVarChar, 50);
                //SqlParameter p2 = cmdSP.Parameters.Add("@bd", SqlDbType.DateTime);
                //SqlParameter paramJob = cmdSP.Parameters.Add("@j", SqlDbType.NVarChar, 50);
                //paramLastName.Value = 1;//txtLastName.Text;
                //paramBirthDay.Value = 2;//dtBirthDay.Text;
                p1.Value = p1v;
                cmdSP.ExecuteNonQuery();
                cmdSP.Dispose();
            }
            catch { }
        }
    }
    public static void callSPwithParamInt(string spname, string paramname, Int64 p1v)
    {
        string connectString = ConfigurationManager.AppSettings["myConnectionString"];
        using (SqlConnection conn = new SqlConnection(connectString))
        {
            try
            {
                conn.Open();
                SqlCommand cmdSP = new SqlCommand(spname, conn);
                cmdSP.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = cmdSP.Parameters.Add("@" + paramname, SqlDbType.Int);
                p1.Value = p1v;
                cmdSP.ExecuteNonQuery();
                cmdSP.Dispose();
            }
            catch { }
        }
    }
    public static void callSPaddDates(int range_id, string date_begin, string date_end)
    {
        string connectString = ConfigurationManager.AppSettings["myConnectionString"];
        using (SqlConnection conn = new SqlConnection(connectString))
        {
            try
            {

                conn.Open();
                SqlCommand cmdSP = new SqlCommand("add_location_price_dates", conn);
                cmdSP.CommandType = CommandType.StoredProcedure;
                SqlParameter p1 = cmdSP.Parameters.Add("@range_id", SqlDbType.Int);
                SqlParameter p2 = cmdSP.Parameters.Add("@date_begin", SqlDbType.DateTime);
                SqlParameter p3 = cmdSP.Parameters.Add("@date_end", SqlDbType.DateTime);

                p1.Value = range_id;
                p2.Value = myformat.sqldateshort(date_begin);
                p3.Value = myformat.sqldateshort(date_end);


                
                cmdSP.ExecuteNonQuery();
                cmdSP.Dispose();

            }
            catch (Exception ex)
            {

            }
        }
    }

}




