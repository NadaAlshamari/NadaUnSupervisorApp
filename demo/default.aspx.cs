using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using unSupervisorApp.App_Code;

namespace unSupervisorApp.demo
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)// call the method for ONLY first time for visitor
            {
                {
                    populateDdlInstitution();
                }
            }
           
        }

        protected void populateDdlInstitution()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select institutionid, institution from institution";
          SqlDataReader dr =  myCrud.getDrPassSql(mySql);
            ddlInsitution.DataTextField = "institution";
            ddlInsitution.DataValueField = "institutionid";
            ddlInsitution.DataSource = dr;
            ddlInsitution.DataBind();
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            getSupervisorData();
        }
        protected void getSupervisorData()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select supervisorId,fName,lName,cell,email ,institution
                    from supervisor  s inner join institution i on s.institutionId =i.institutionId ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvSupervisor.DataSource = dr;
            gvSupervisor.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"insert supervisor (fName,lName,cell,email,institutionId )
                                values( @fName, @lName, @cell, @email, @institutionId)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@fName", txtFname.Text);
            myPara.Add("@lName", txtLName.Text);
            myPara.Add("@cell", txtCell.Text);
            myPara.Add("@email", txtEmail.Text);
            myPara.Add("@institutionId", ddlInsitution.SelectedItem.Value);
          int rtn =   myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Operation Successfull!";
                getSupervisorData();
            }
            else
            { lblOutput.Text = "Operation Failed!"; }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"update supervisor set fName=@fName,lName=@lName,cell=@cell,email=@email,institutionId=@institutionId
                            where supervisorId = @supervisorId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@supervisorId", txtSupervisorId.Text);
            myPara.Add("@fName", txtFname.Text);
            myPara.Add("@lName", txtLName.Text);
            myPara.Add("@cell", txtCell.Text);
            myPara.Add("@email", txtEmail.Text);
            myPara.Add("@institutionId", ddlInsitution.SelectedItem.Value);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Operation Successfull!";
                getSupervisorData();
            }
            else
            { lblOutput.Text = "Operation Failed!"; }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"delete supervisor 
                where supervisorId = @supervisorId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@supervisorId", txtSupervisorId.Text);
           int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            { lblOutput.Text = "Operation Successfull!";
                getSupervisorData();
            }
            else
            { lblOutput.Text = "Operation Failed!"; }
        }
    }// cls
}// NS