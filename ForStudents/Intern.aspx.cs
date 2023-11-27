using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using unSupervisorApp.App_Code;

namespace unSupervisorApp.ForStudents
{
    public partial class Intern : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                populateDdlInstitution();
            }
           
        }

        protected void populateDdlInstitution()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select institutionId, institution from institution";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlinsitution.DataTextField = "institution";
            ddlinsitution.DataValueField = "institutionId";
            ddlinsitution.DataSource = dr;
            ddlinsitution.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try { 
            CRUD myCrud = new CRUD();
            string mySql = @"insert intern (fName,mName,gfName,lName,nId,cell,email,active,institutionId )
                                values( @fName,@mName ,@gfName ,@lName,@nId ,@cell, @email,@active ,@institutionId)";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            //myPara.Add("@inernId", txtinternId.Text);
            myPara.Add("@fName", txtfName.Text);
            myPara.Add("@mName", txtmName.Text);
            myPara.Add("@gfName", txtgfName.Text);
            myPara.Add("@lName", txtlName.Text);
            myPara.Add("@nId", txtNId.Text);
            myPara.Add("@cell", txtcell.Text);
            myPara.Add("@email", txtemail.Text);
            myPara.Add("@active", rblActive.SelectedItem.Value);
            myPara.Add("@institutionId", ddlinsitution.SelectedItem.Value);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Operation Successfull!";
                getintern();
            }
            else
            { lblOutput.Text = "Operation Failed!"; }
                { lblOutput.Text = "Operation Failed!"; }
            }
            catch (Exception ex)
            {
                lblOutput.Text = ex.Message.ToString();

            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        { 
               try
       
        {
            CRUD myCrud = new CRUD();
            string mySql = @"update intern set  fName=@fName,mName=@mName,gfName=@gfName,
lName=@lName,nId=@nId,institutionId=@institutionId,cell=@cell,email=@email, active=@active
                            where internId=@internId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@internId", txtinternId.Text);
                myPara.Add("@fName", txtfName.Text);
            myPara.Add("@mName", txtmName.Text);
            myPara.Add("@gfName", txtgfName.Text);
            myPara.Add("@lName", txtlName.Text);
                myPara.Add("@nId", txtNId.Text);
                myPara.Add("@institutionId", ddlinsitution.SelectedItem.Value);
                myPara.Add("@cell", txtcell.Text);
            myPara.Add("@email", txtemail.Text);
            myPara.Add("@active", rblActive.SelectedItem.Value);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Operation Successfull!";
                getintern();
            }
            else
            { lblOutput.Text = "Operation Failed!"; }
            }

            catch (Exception ex)
            {
                lblOutput.Text = ex.Message.ToString();
            }
        }

    

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try

            {
                CRUD myCrud = new CRUD();
            string mySql = @"delete intern 
                where internId = @internId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId", txtinternId.Text);
            int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
            if (rtn >= 1)
            {
                lblOutput.Text = "Operation Successfull!";
                getintern();
            }
            else
            { lblOutput.Text = "Operation Failed!"; }
            }

            catch (Exception ex)
            {
                lblOutput.Text = ex.Message.ToString();
            }
        

    }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            getintern();
        }
        protected void getintern()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"  select internId,fName,mName,gfName,lName,nId,cell,email,active,i.institution , i.institutionId
                    from intern  n inner join institution i on n.institutionId =i.institutionId ";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            gvintern.DataSource = dr;
            gvintern.DataBind();
        }
        protected void populateForm_Click(object sender, EventArgs e)
        {
            int PK = int.Parse((sender as LinkButton).CommandArgument);
            //lblOuput.Text = PK.ToString();

            string mySql = @"select internId,fName,mName,gFName,lName,nId,cell from intern 
                    where internId=@internId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internId",PK);
            CRUD myCrud = new CRUD();
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtinternId.Text = dr["internId"].ToString();
                        txtfName.Text = dr["fName"].ToString();
                        txtmName.Text = dr["mName"].ToString();
                        txtgfName.Text = dr["gFName"].ToString();
                        txtlName.Text = dr["lName"].ToString();
                       txtNId.Text=dr["nId"].ToString();
                        txtlName.Text = dr["cell"].ToString();

                    }
                }
            }
        }
    }
}

