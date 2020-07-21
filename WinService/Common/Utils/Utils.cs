using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Common.Utils
{
   public class Utils
    {
        public static void RegisterStartupScript(Page Page, string Key, string script)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), Key, script, true);
        }

        public static void ShowMessage(Page Page, string Message)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "Alert", "alert(\"" + Message + "\");", true);
        }

        public static string RemoveLastString(string text, string character)
        {
            if (text.Length < 1) return text;
            return text.Remove(text.ToString().LastIndexOf(character), character.Length);
        }
        //public static List<Month> GetMonthList()
        //{
        //    List<Month> listMonth = new List<Month>();
        //    for(int i=1; i<12; i++)
        //    {
        //        listMonth.Add(new Month
        //        {
        //            MonthValue = i,
        //            MonthName = GetMonthName(i)
        //        }); 
        //    }
        //    return listMonth;
        //}

        public static string GetMonthName(int month)
        {
            DateTime date = new DateTime(DateTime.Now.Year, month, 1);
            return date.ToString("MMM");

        }

        

        public static void LoadYear(DropDownList dd)
        {
            //using (DBHelper db = new DBHelper())
            //{
            //    using (Rep_ms_calendar rep = new Rep_ms_calendar(db))
            //    {
            //        dd.DataSource = rep.GetYearCollection(DateTime.Now.Year);
            //        dd.DataBind();
            //        dd.SelectedValue = DateTime.Now.Year.ToString();
            //    }
            //}
        }


        //public static void LoadMonth (DropDownList dd)
        //{
        //    dd.DataSource = GetMonthList();
        //    dd.DataValueField = "MonthValue";
        //    dd.DataTextField = "MonthName";
        //    dd.DataBind();
        //    dd.SelectedValue = DateTime.Now.Month.ToString();
        //}

        public static bool IsFileIsReady(string filePath)
        {
            try
            {
                using (var file = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    return true;
                }
            }
            catch (IOException ex)
            {
                return false;
            }
        }
        public static void LoadWindow(Repeater rpt, int month, int year)
        {
            //using (DBHelper db = new DBHelper())
            //{
            //    using (Rep_ms_calendar rep = new Rep_ms_calendar(db))
            //    {
            //        DataTable dt = rep.GetWindowsCollection(month, year);
            //        rpt.DataSource = dt;
            //        rpt.DataBind();
            //    }
            //}
        }
    }
}
