using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


  public class myformat
    {
        public static string Left(string param, int length)
        {
            string result = "";
            if (param.Length >= length)
                result = param.Substring(0, length);
            return result;
        }
        public static string Right(string param, int length)
        {
            string result = "";
            if (param.Length >= length)
                result = param.Substring(param.Length - length);
            return result;

        }
        public static string Mid(string param, int startIndex, int length)
        {
            string result = "";
            if (param.Length >= length + startIndex)
                result = param.Substring(startIndex, length);
            return result;

        }
        public static string Mid(string param, int startIndex)
        {
            string result = param.Substring(startIndex);
            return result;
        }


        public static string sqldate(DateTime dt)
        {
            try
            {


                string dd, mm, yyyy;

                dd = dt.Day.ToString("D2");
                mm = dt.Month.ToString("D2");
                yyyy = dt.Year.ToString("D4");



                return yyyy + mm + dd;

            }
            catch 
            {
                return "";
            }
        }

        public static string sqldateshort(string dt)
        {
            try
            {
                DateTime a;
                a = Convert.ToDateTime(dt);



                string x = String.Format("{0:MM/dd/yyyy}", a);

                x = x.Replace(".", "/");

                return x;
            }
            catch 
            {
                return "";
            }
        }
        public static string sqldateshortfromdate(DateTime  a)
        {
            try
            {
                


                string x = String.Format("{0:MM/dd/yyyy}", a);

                x = x.Replace(".", "/");

                return x;
            }
            catch 
            {
                return "";
            }
        }
        public static string sqldateveryshort(string dt)
        {
            try
            {
                DateTime a;
                a = Convert.ToDateTime(dt);



                string x = String.Format("{0:MM/dd/yy}", a);

                x = x.Replace(".", "/");

                return x;
            }
            catch 
            {
                return "";
            }
        }

        public static string xconvertdateustr(string dt)
        {
            try
            {

                string d, m, y;
                m=myformat.Left(dt,2);
                d =  myformat.Mid(dt, 3,2);
                y = myformat.Mid(dt, 6, 4);



                return d + "/" + m + "/" + y; 
            }
            catch 
            {
                return "";
            }
        }
        public static string xcleantrdt(string dt)
        {
            try
            {

                string d, m, y;
                d = myformat.Left(dt, 2);
                m = myformat.Mid(dt, 3, 2);
                y = myformat.Mid(dt,6, 4);



                return d + "/" + m + "/" + y;
            }
            catch 
            {
                return "";
            }
        }

        public static string xsqldatelong1(string dt)
        {
            DateTime a;
            a = Convert.ToDateTime(dt);

            string x = String.Format("{0:MM/dd/yyyy HH:mm:ss}", a);
            x = x.Replace(".", "/");
            return x;
        }


        public static string generatenewpassword(int size)
        {
            char[] cr = "0123456789abcdefghijkmnopqrstuvwxyz".ToCharArray();
            string result = string.Empty;
            Random r = new Random();
            for (int i = 0; i < size; i++)
            {
                result += cr[r.Next(0, cr.Length - 1)].ToString();
            }
            return result;
        }


        public static int datediff(DateTime starttime, DateTime endtime, int type)
        {

            try
            {
                DateTime tstarttime = starttime;
                DateTime tendtime =endtime;

                TimeSpan span = tendtime.Subtract(tstarttime);

                switch (type)
                {
                    case 1:
                        return span.Seconds;
                    case 2:
                        return span.Minutes;
                    case 3:
                        return span.Hours;
                    case 4:
                        return span.Days;
                    default:
                        return span.Days;

                }

            }
            catch { return 0; }

        }

        public static string adddate(DateTime mydate, int number)
        {

            try
            {
                DateTime tmydate = mydate;



                return myformat.sqldateshort(tmydate.AddDays(number).ToString());
            }

            catch{return "";}

            
            

        }


 public static string getweekday(string dt)
        {
      
     int myday;
     myday=(int)(Convert.ToDateTime(dt)).DayOfWeek+2; 
     string WKG="";
     switch (myday)
     {

         case 2:
             WKG = "Saturday"; break;
         case 3:
            WKG = "Sunday";break;
         case 4:
            WKG = "Monday";break;
         case 5:
            WKG = "Tuesday";break;
         case 6:
            WKG = "Wednesday";break;
         case 7:
            WKG = "Thursday";break;
         case 8:
            WKG = "Friday";break;
         
     }
           return WKG ;
        }

 public static int getweekdayn(string dt)
 {

     int myday;
     myday = (int)(Convert.ToDateTime(dt)).DayOfWeek ;
     
     return myday;
 }




    }


    