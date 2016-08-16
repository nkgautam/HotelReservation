using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services.Protocols;
using System.ServiceModel.Channels;
using System.Xml;
using System.Xml.Serialization;
using System.Data;
using System.IO;
using System.Data.SqlClient;
using System.Configuration;


    public class siteminder
    {
        public static Boolean wcf_login_check(string username,string password)
        {
            DataSet ds = new DataSet();
            StringWriter sw = new StringWriter();
            ds = mysql.executesqlgiverds("Select * from wcf_users where wcf_user='" + username + "' and wcf_password='" + password + "'");

            if (ds.Tables[0].Rows.Count > 0)
            {


                return true;
            }
            else
            {

                return  false;
            }
          
        }

    }
