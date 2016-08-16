using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Selectors;
using System.ServiceModel;
using System.Data;
using System.IO;
namespace SiteminderWCF
{
    public class CustomUserNameValidator : UserNamePasswordValidator
    {
        public override void Validate(string userName, string password)
        {
            if (null == userName || null == password)
            {
                throw new ArgumentNullException();
            }

            DataSet ds = new DataSet();
            StringWriter sw = new StringWriter();
            ds = mysql.executesqlgiverds("Select * from wcf_users where wcf_user='" + userName + "' and wcf_password='" + password + "'");

            if (ds.Tables[0].Rows.Count <= 0)
            {
                             
                throw new FaultException("Web Service Login Problem for "+userName); 
            }

        }
    }
}