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
    public partial class internTask : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                populateDdlintern();
            }
        }

        protected void populateDdlintern()
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select internId, fName+' '+mName+' '+gfName+' '+lName AS FullName from intern";
            SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlintern.DataTextField = "FullName";
            ddlintern.DataValueField = "internId";
            ddlintern.DataSource = dr;
            ddlintern.DataBind();


        }


        protected void btnAdd_Click(object sender, EventArgs e)
        {
            {

                try { 
                CRUD myCrud = new CRUD();
                string mySql = @"insert internTask (internId,taskName,taskStartDate,taskEndDate,completed,note)
                                values(@internId, @taskName, @taskStartDate, @taskEndDate, @completed,@note)";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@internId", ddlintern.SelectedItem.Value);
                myPara.Add("@taskName", txtTaskName.Text);
                myPara.Add("@taskStartDate", txtTaskStartDate.Text);
                myPara.Add("@taskEndDate", txtTaskEndDate.Text);
                myPara.Add("@completed", rblCompleted.SelectedItem.Value);
                myPara.Add("@note", txtNote.Text);
                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                    if (rtn >= 1)
                    {
                        lblOutput.Text = "Operation Successfull!";
                        populateGvInternTask();

                    }
                    else
                    { lblOutput.Text = "Operation Failed!"; }
                }
                catch (Exception ex)
                {
                    lblOutput.Text = ex.Message.ToString();

                }
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {

            populateGvInternTask();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            {
                try {  
                CRUD myCrud = new CRUD();
                string mySql = @"delete internTask where internTaskId = @internTaskId";

                Dictionary<string, object> myPara = new Dictionary<string, object>();
                    myPara.Add("@internTaskId", txtTaskId.Text);
                    int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                    if (rtn >= 1)
                    {
                        lblOutput.Text = "Operation Successfull!";
                    }
                    else
                    { lblOutput.Text = "Operation Failed!"; }
                    }

                catch (Exception ex)
                {
                    lblOutput.Text = ex.Message.ToString(); 

                }
            }

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                CRUD myCrud = new CRUD();
                string mySql = @"update internTask set internId=@internId, taskName=@taskName,taskStartDate=@taskStartDate,
taskEndDate=@taskEndDate,completed=@completed,note=@note where internTaskId=@internTaskId ";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@internTaskId", int.Parse(txtTaskId.Text));
                myPara.Add("@internId", ddlintern.SelectedItem.Value);
                myPara.Add("@taskName", txtTaskName.Text);
                myPara.Add("@taskStartDate", txtTaskStartDate.Text);
                myPara.Add("@taskEndDate", txtTaskEndDate.Text);
                myPara.Add("@completed", rblCompleted.SelectedItem.Value);
                myPara.Add("@note", txtNote.Text);
                int rtn = myCrud.InsertUpdateDelete(mySql, myPara);
                if (rtn >= 1)
                {
                    lblOutput.Text = "Operation Successfull!";
                    populateGvInternTask();
                }
                else
                { lblOutput.Text = "Operation Failed!"; }
            }
            catch (Exception ex) { 
                lblOutput.Text = ex.Message.ToString() + "please Contact admin";
                    
                    }
        }

        protected void populateGvInternTask()
        {
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select internTaskId,it.internId,fName+ '  ' +mName+' ' +gFName+' ' +lName AS fullName,
taskName,taskStartDate,taskEndDate, completed,note from internTask it inner join intern i
on it.internId= i.internId";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
                gvInternTask.DataSource = dr;
                gvInternTask.DataBind();


            }

        }
        protected void populateForm_Click(object sender, EventArgs e)
        {
            int PK = int.Parse((sender as LinkButton).CommandArgument);
            //lblOuput.Text = PK.ToString();

            string mySql = @"select internTaskId,internId,taskName,taskStartDate,taskEndDate,completed,note 
                   from internTask where internTaskId = @internTaskId ";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@internTaskId",PK);
            CRUD myCrud = new CRUD();
            using (SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara))
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtTaskId.Text = dr["internTaskId"].ToString();
                        ddlintern.SelectedValue = dr["internId"].ToString();
                        txtTaskName.Text = dr["taskName"].ToString();
                        txtTaskStartDate.Text = dr["taskStartDate"].ToString();
                        txtTaskEndDate.Text = dr["taskEndDate"].ToString();
                        rblCompleted.SelectedValue = dr["completed"].ToString();
                        txtNote.Text = dr["note"].ToString();
                       

                    }
                }
            }
            

        }
    }
}


