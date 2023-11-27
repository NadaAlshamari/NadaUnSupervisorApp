using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using unSupervisorApp.App_Code;

namespace unSupervisorApp.ForStudents
{
    public partial class exportintern : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            populategvexport();
        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Confirms that an HtmlForm control is rendered for the specified ASP.NET
               server control at run time. */
        }


     
            protected void populategvexport()
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select fName +'  '+ mName +'  '+ gFName +'  '+ lName As tranineeFullName ,nId,i.institution 
                    from intern  n inner join institution i on n.institutionId =i.institutionId";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvIntern.DataSource = dr;
            gvIntern.DataBind();
            }

            protected void btnExpot_Click(object sender, EventArgs e)
        {
            ExportGridToExcel(gvIntern);
        }
        public void ExportGridToExcel(GridView grd)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=GridViewExport.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grd.AllowPaging = false;
            populategvexport();
            grd.RenderControl(hw);
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }

       
    }
}
