using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using unSupervisorApp.App_Code;

namespace unSupervisorApp.demo
{
    public partial class students : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) {
             ;
 
                 getAllInstitution();
                onAddStudent();
            }
               

        }

       
  
        protected void opration_SelectedIndexChanged(object sender, EventArgs e)
        {


            switch (opration.SelectedItem.Text)
            {
                case "Add New Student":
                    {
                        onAddStudent();


                        break;
                    }
                case "Join To Course":
                    {
                        onJoinToCourse();

                        break;
                    }
                case "Update Student": {
                        onUpdateStudent();
                        break;
                    }
                default:
                    {
                        reactive();
                        break;
                    }


            }
        }


        private void getAllInstitution()
        {

            string query = @"SELECT institutionId,institution as 'institution name' FROM institution ;";
            CRUD myCrud = new CRUD();
            SqlDataReader dr = myCrud.getDrPassSql(query);
            institute.DataTextField = "institution name";
            institute.DataValueField = "institutionId";
            institute.DataSource = dr;
            institute.DataBind();
            dr.Close();

        }
        void onAddStudent()
        {
            course.Visible = false;
            student.Visible = false;
            start_date.Visible= false;
            end_date.Visible=false; 
           

            student_first_name.Enabled = true;
            student_last_name.Enabled = true;
            email.Enabled = true;
            btnupdate.Visible = false;
            btnAdd.Visible = true;


        }

        void onJoinToCourse() {

            course.Visible = true;
            student.Visible = true;
            start_date.Visible = true;
            end_date.Visible = true;

            student_first_name.Enabled = false;
            student_last_name.Enabled = false;
            email.Enabled = false;
            btnupdate.Visible = false;
            btnAdd.Visible = true;

        }

        void onUpdateStudent()
        {

            course.Visible = false;
            student.Visible = true;
            start_date.Visible = false;
            end_date.Visible = false;

            student_first_name.Enabled = true;
            student_last_name.Enabled = true;
            email.Enabled = true;
            btnAdd.Visible = false;
            btnupdate.Visible = true;

        }
        void reactive()
        {
            course.Visible = true;
            student.Visible = true;
          
        }
        bool addStudent()
        {

            string Institute= institute.SelectedValue.ToString().Trim();  
           // string Supervisor= supervisor.SelectedValue.ToString();
            string Student_First_Name = student_first_name.Text.ToString().Trim();
            string Student_Last_Name = student_last_name.Text.ToString().Trim();
            string Email = email.Text.ToString().Trim();

            string query = @"INSERT INTO studentData (institutionId,fName,lName,email) VALUES(@Institute,@Student_First_Name,@Student_Last_Name,@Email)";

            CRUD myCrud = new CRUD();
            Dictionary<string, object> myPara = new Dictionary<string, object>();

            myPara.Add("@Institute", Institute);
            myPara.Add("@Student_First_Name", Student_First_Name);
            myPara.Add("@Student_Last_Name", Student_Last_Name);
            myPara.Add("@Email", Email);
            int status=  myCrud.InsertUpdateDelete(query, myPara);
            
            if (status == 0)
            {
                return false;
            }else
            {
                return true;
            }
           
        }
       bool joinToCourse()
        {

            string Institute = institute.SelectedValue.ToString().Trim();
            // string Supervisor= supervisor.SelectedValue.ToString();
            string  Course=course.SelectedValue.ToString().Trim();
            string Supervisor=supervisor.SelectedValue.ToString().Trim();
            string Student_id = student_id2.Text.ToString();
            string Start_date = start_date.SelectedDate.ToString("yyyy/MM/dd");
            string End_date = end_date.SelectedDate.ToString("yyyy/MM/dd");    
           
            string query = @"INSERT INTO student_course
 

VALUES(@Student_id,@Supervisor,@Institute,@Course,@Start_date,@End_date) ;";

            CRUD myCrud = new CRUD();
            Dictionary<string, object> myPara = new Dictionary<string, object>();

            myPara.Add("@Student_id", Student_id);
            myPara.Add("@Supervisor", Supervisor);
            myPara.Add("@Institute", Institute);
            myPara.Add("@Course", Course);
            myPara.Add("@Start_date", Start_date);
            myPara.Add("@End_date", End_date);

            int status = myCrud.InsertUpdateDelete(query, myPara);

            if (status == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        protected void institute_SelectedIndexChanged(object sender, EventArgs e)
        {

            switch (opration.SelectedItem.Text)
            {
                case "Add New Student":
                    {
                        string query = @"SELECT id , name FROM supervisor_course WHERE institution_id = @institutionId ;";
                        CRUD myCrud = new CRUD();
                        Dictionary<string, object> myPara = new Dictionary<string, object>();

                        myPara.Add("@institutionId", institute.SelectedItem.Value);

                        SqlDataReader dr = myCrud.getDrPassSql(query, myPara);

                        supervisor.DataTextField = "name";
                        supervisor.DataValueField = "id";
                        supervisor.DataSource = dr;
                        supervisor.DataBind();
                        dr.Close();

                        break;
                    }
                case "Join To Course":
                    {
                        string query = @"SELECT id , name FROM supervisor_course WHERE institution_id = @institutionId ;";
                        CRUD myCrud = new CRUD();
                        Dictionary<string, object> myPara = new Dictionary<string, object>();

                        myPara.Add("@institutionId", institute.SelectedItem.Value);

                        SqlDataReader dr = myCrud.getDrPassSql(query, myPara);

                        supervisor.DataTextField = "name";
                        supervisor.DataValueField = "id";
                        supervisor.DataSource = dr;
                        supervisor.DataBind();
                      



                        query = @"	SELECT c.id,c.course_name
	                        FROM course c
	                        LEFT JOIN institution institution
			                        ON c.institution_id =institution.institutionId
                            WHERE c.institution_id=@institutionId;

";
                        
                        myPara = new Dictionary<string, object>();

                        myPara.Add("@institutionId", institute.SelectedItem.Value);
                        myCrud = new CRUD();

                        dr = myCrud.getDrPassSql(query, myPara);

                        course.DataTextField = "course_name";
                        course.DataValueField = "id";
                        course.DataSource = dr;
                        course.DataBind();
                        

                        query = @"	SELECT institution.institutionId,s.studentId,s.fName,s.lName,s.email
	FROM studentData s
	LEFT JOIN institution institution
			ON s.institutionId =institution.institutionId

                            WHERE s.institutionId=@institutionId;

";

                        myPara = new Dictionary<string, object>();

                        myPara.Add("@institutionId", institute.SelectedItem.Value);
                        myCrud = new CRUD();
                        SqlDataReader dr2 = myCrud.getDrPassSql(query, myPara);

                        student.DataTextField = "email";
                        student.DataValueField = "studentId";
                        student.DataSource = dr2;
                        student.DataBind();
                       
                       
                        break;
                    }
                case "Update Student":
                    {


                       string query = @"	SELECT institution.institutionId,s.studentId,s.fName,s.lName,s.email
	FROM studentData s
	LEFT JOIN institution institution
			ON s.institutionId =institution.institutionId

                            WHERE s.institutionId=@institutionId;

";

                        Dictionary<string, object> myPara = new Dictionary<string, object>();

                        myPara.Add("@institutionId", institute.SelectedItem.Value);
                        CRUD myCrud = new CRUD();
                        SqlDataReader dr2 = myCrud.getDrPassSql(query, myPara);

                        student.DataTextField = "email";
                        student.DataValueField = "studentId";
                        student.DataSource = dr2;
                        student.DataBind();
                        
                        break;
                    }



            }


  
        }
        bool UpdateStudent()
        {
          
            // string Supervisor= supervisor.SelectedValue.ToString();
            string FNme = student_first_name.Text.ToString().Trim();
            string Lname = student_last_name.Text.ToString().Trim();
            string Student_id = student_id2.Text.ToString();
            string Email = email.Text.ToString().Trim();

            string query = @"
   UPDATE studentData SET fName=@FNme ,lName=@Lname , email=@Email where studentId=@Student_id
;";

            CRUD myCrud = new CRUD();
            Dictionary<string, object> myPara = new Dictionary<string, object>();

            myPara.Add("@Student_id", Student_id);
            myPara.Add("@FNme", FNme);
            myPara.Add("@Lname", Lname);
            myPara.Add("@Email", Email);
         

            int status = myCrud.InsertUpdateDelete(query, myPara);

            if (status == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            switch (opration.SelectedItem.Text)
            {
                case "Add New Student":
                    {
                        bool add = addStudent();
                        if (add == true)
                        {
                            string massage = "Added";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + massage + "');", true);
                        }
                        else
                        {
                            string massage = "Not Added";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + massage + "');", true);

                        }


                        break;
                    }
                case "Join To Course":
                    {
                       
                        bool add = joinToCourse();
                        if (add == true)
                        {
                            string massage = "Added";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + massage + "');", true);
                        }
                        else
                        {
                            string massage = "Not Added";
                            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + massage + "');", true);

                        }
                        break;
                    }
               


            }
        
        }

        protected void course_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void student_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = @"SELECT studentId,fName,lName,email FROM studentData WHERE studentId = @studentId ;";
            CRUD myCrud = new CRUD();
            Dictionary<string, object> myPara = new Dictionary<string, object>();

            myPara.Add("@studentId", student.SelectedItem.Value);

            SqlDataReader dr = myCrud.getDrPassSql(query, myPara);

            while (dr.Read())
            {
                var id = dr.GetInt32(0).ToString(); //The 0 stands for "the 0'th column", so the first column of the result.
                                          // Do somthing with this rows string, for example to put them in to a list
                var fname = dr.GetString(1);
                var lname = dr.GetString(2);
                var emailv = dr.GetString(3);
                student_id2.Text = id;
                student_first_name.Text = fname;
                student_last_name.Text = lname;
                email.Text = emailv;    



            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            bool add = UpdateStudent();
            if (add == true)
            {
                string massage = "Added";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + massage + "');", true);
            }
            else
            {
                string massage = "Not Added";
                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + massage + "');", true);

            }
        }
    }
}