using Syncfusion.DocIO;
using Syncfusion.DocIO.DLS;
using Syncfusion.DocToPDFConverter;
using Syncfusion.OfficeChartToImageConverter;
using Syncfusion.Pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using unSupervisorApp.App_Code;


namespace unSupervisorApp.demo
{
    public partial class unTemplate : System.Web.UI.Page
    {
        string templatePath = AppDomain.CurrentDomain.BaseDirectory + "//template//cert.docx";
        string templatePathEval = AppDomain.CurrentDomain.BaseDirectory + "//template//Templatef.docx";
        
        string uploadsPathWordC = AppDomain.CurrentDomain.BaseDirectory + "//Uploads//Certs//word//";
        string uploadsPathPDFC = AppDomain.CurrentDomain.BaseDirectory + "//Uploads//Certs//pdf//";
        
        string uploadsPathWordE = AppDomain.CurrentDomain.BaseDirectory + "//Uploads//Eval//word//";
        string uploadsPathPDFE = AppDomain.CurrentDomain.BaseDirectory + "//Uploads//Eval//pdf//";



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)// call the method for ONLY first time for visitor
            {
                {
                    populateDdlInstitution();
                }
            }
        }
        // عرض ات
       protected void populateDdlInstitution()
            {
                CRUD myCrud = new CRUD();
                string mySql = @"select institutionid, institution from institution";
                SqlDataReader dr = myCrud.getDrPassSql(mySql);
            ddlInstitution.DataTextField = "institution";
            ddlInstitution.DataValueField = "institutionid";
            ddlInstitution.DataSource = dr;
            ddlInstitution.DataBind();
            }

        protected void ddlInstitution_SelectedIndexChanged(object sender, EventArgs e)
        {
            // call a method to populate the template ddl
            populateDdlTemplate();
        }

        protected void populateDdlTemplate()
        {

            CRUD myCrud = new CRUD();
         
            string mySql = @"select institutionTemplateId, template
                                from institutionTemplate
                                where institutionId = @institutionId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@institutionId", ddlInstitution.SelectedItem.Value);
            SqlDataReader dr = myCrud.getDrPassSql(mySql,myPara);
            ddlTemplate.DataTextField = "template";
            ddlTemplate.DataValueField = "institutionTemplateId";
            ddlTemplate.DataSource = dr;
            ddlTemplate.DataBind();
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            CRUD myCrud = new CRUD();
            string mySql = @"select* from studentData 
                       where institutionId = @institutionId";
            Dictionary<string, object> myPara = new Dictionary<string, object>();
            myPara.Add("@institutionId", ddlInstitution.SelectedItem.Value);
            SqlDataReader dr = myCrud.getDrPassSql(mySql, myPara);
            gvData.DataSource = dr;
            gvData.DataBind();
        }


        protected void cbAll_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chkstatus = (CheckBox)sender;
            GridViewRow row = (GridViewRow)chkstatus.NamingContainer; 

        }

        protected void cbSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cbkheader = (CheckBox)gvData.HeaderRow.FindControl("cbSelect");
            foreach (GridViewRow row in gvData.Rows) 
            {
                CheckBox chkrow = (CheckBox)row.FindControl("cbAll");
                if (cbkheader.Checked == true)
                {
                    chkrow.Checked = true;
                }
                else
                {
                    chkrow.Checked = false;

                }

               

            }
          
    }

        protected void btnSendEmail_Click(object sender, EventArgs e)
        {
            if (ddlTemplate.SelectedValue == "4")
            {
                sendCertsFiles();


            }
            else
            {
                sendEvalsFiles();

            }
          
        }

        void sendCertsFiles()
        {
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress("appdev4y@gmail.com");
                msg.Subject = "Your Subject";
                msg.Body = "<h1>Hello user</h1> Email Body content";
                msg.IsBodyHtml = true;
                #region 
                //hard code
                //  msg.To.Add(new MailAddress("aalhussein63@gmail.com"));
                //List<string> files = new List<string>();
                //// loop file system to add files into  the list
                //files.Add("~/myPdf/aalhussein@gmail.com.pdf");
                //files.Add("~/myPdf/ahameed@kfmc.med.sa.pdf");
                //files.Add("~/myPdf/aalhussein@yahoo.com.pdf");
                /// List<string> files =(List <string>)GetUploadList();
                #endregion
                /// 
                //List<string> files = GetUploadList().Cast<string>().ToList();
                for (int i = 0; i <= gvData.Rows.Count - 1; i++)
                {
                    CheckBox chkStat = gvData.Rows[i].FindControl("cbAll") as CheckBox;
                    if (chkStat.Checked)
                    {

                       
                        string email = gvData.Rows[i].Cells[8].Text;
                        //int index = file.IndexOf(".pdf");
                        //string strTo = file.Substring(0, index);
                        msg.Subject = "Email Subject :    " + email;
                        msg.To.Add(new MailAddress(email));
                        /*     msg.Attachments.Add(new Attachment(Server.MapPath("~/Uploads/Certs/pdf" + file))); */// Attach Each file
                        msg.Attachments.Add(new Attachment(Server.MapPath("~/Uploads/Certs/pdf/" + email+".pdf"))); // Attach Each file
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                        NetworkCred.UserName = msg.From.Address;
                        NetworkCred.Password = "aowhaqeyqiarghyr";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(msg);
                        msg.To.Clear();
                        msg.Attachments.Clear();


                    }

                }
                lblOutput.Text = "You have sent all selected Certificates pdf files successfully ";

            }

        }
        void sendEvalsFiles()
        {

            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress("appdev4y@gmail.com");
                msg.Subject = "Your Subject";
                msg.Body = "<h1>Hello user</h1> Email Body content";
                msg.IsBodyHtml = true;
                #region 
                //hard code
                //  msg.To.Add(new MailAddress("aalhussein63@gmail.com"));
                //List<string> files = new List<string>();
                //// loop file system to add files into  the list
                //files.Add("~/myPdf/aalhussein@gmail.com.pdf");
                //files.Add("~/myPdf/ahameed@kfmc.med.sa.pdf");
                //files.Add("~/myPdf/aalhussein@yahoo.com.pdf");
                /// List<string> files =(List <string>)GetUploadList();
                #endregion
                /// 
                //List<string> files = GetUploadList().Cast<string>().ToList();
                for (int i = 0; i <= gvData.Rows.Count - 1; i++)
                {
                    CheckBox chkStat = gvData.Rows[i].FindControl("cbAll") as CheckBox;
                    if (chkStat.Checked)
                    {


                        string email = gvData.Rows[i].Cells[8].Text;
                        //int index = file.IndexOf(".pdf");
                        //string strTo = file.Substring(0, index);
                        msg.Subject = "Email Subject :    " + email;
                        msg.To.Add(new MailAddress(email));
                        /*     msg.Attachments.Add(new Attachment(Server.MapPath("~/Uploads/Certs/pdf" + file))); */// Attach Each file
                        msg.Attachments.Add(new Attachment(Server.MapPath("~/Uploads/Eval/pdf/" + email + ".pdf"))); // Attach Each file
                        SmtpClient smtp = new SmtpClient();
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        System.Net.NetworkCredential NetworkCred = new System.Net.NetworkCredential();
                        NetworkCred.UserName = msg.From.Address;
                        NetworkCred.Password = "aowhaqeyqiarghyr";
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = NetworkCred;
                        smtp.Port = 587;
                        smtp.Send(msg);
                        msg.To.Clear();
                        msg.Attachments.Clear();


                    }

                }
                lblOutput.Text = "You have sent all selected evals pdf files successfully ";

            }

        }

        protected IEnumerable GetUploadList()
        {

            if (ddlTemplate.SelectedValue == "4")
            {


                string folder = Server.MapPath("~/Uploads/Certs/pdf/");// get uploaded folder
                string[] files = Directory.GetFiles(folder); // get all files in folder 
                Array.Sort(files);
                foreach (string file in files)
                    yield return Path.GetFileName(file);  // return individual file



            }
            else
            {
             

            string folder = Server.MapPath("~/Uploads/Eval/pdf/");// get uploaded folder
            string[] files = Directory.GetFiles(folder); // get all files in folder 
            Array.Sort(files);
            foreach (string file in files)
                yield return Path.GetFileName(file);  // return individual file

            }


        }

        protected void btnGenerateTemplateWord_Click(object sender, EventArgs e)
        {
            if (ddlTemplate.SelectedValue == "4")
            {
                wordCert();
                

            }
            else
            {
                wordEval();

            }
        }

        protected void btnGenerateTemplatePDF_Click(object sender, EventArgs e)
        {
            if (ddlTemplate.SelectedValue == "4")
            {
                pdfCert();


            }
            else
            {
                pdfEval();

            }
        }


        // methods for generating  templates

        void wordCert()
        {


            for (int i = 0; i <= gvData.Rows.Count - 1; i++)
            {
                CheckBox chkStat = gvData.Rows[i].FindControl("cbAll") as CheckBox;
                if (chkStat.Checked)
                {
                    string studentId = gvData.Rows[i].Cells[1].Text;
                    string fName = gvData.Rows[i].Cells[3].Text;
                    string lName = gvData.Rows[i].Cells[4].Text;
                    string courseStartDate = gvData.Rows[i].Cells[6].Text.ToString();
                    string courseEndDate = gvData.Rows[i].Cells[7].Text.ToString();
                    string course = gvData.Rows[i].Cells[5].Text.ToString();


                    using (WordDocument document = new WordDocument(Path.GetFullPath(templatePath), FormatType.Docx))
                    {

                        document.MailMerge.RemoveEmptyParagraphs = true;                // for removing empty cells
                        string[] fieldNames = new string[] { "studentId", "studentName", "trainingStartDate", "trainingEndDate", "courseName" };
                        string[] fieldValues = new string[] { studentId, fName + ' ' + lName, courseStartDate, courseEndDate,course };

                        document.MailMerge.Execute(fieldNames, fieldValues);            //Performs the mail merge.

                        document.Save(Server.MapPath(fName + lName + ".docx"));         //Saves the Word document.
                        document.Save(Path.GetFullPath(uploadsPathWordC + fName + "_" + lName + "_Report.docx"), FormatType.Docx);
                        document.Close();
                    }
                }
                //pass message to user notifying of successfull opreation
                lblOutput.Text = " Template output generated successfully ";


            }
        }


        void pdfCert()
        {
            wordCert();
            for (int i = 0; i <= gvData.Rows.Count - 1; i++)
            {
                CheckBox chkStat = gvData.Rows[i].FindControl("cbAll") as CheckBox;
                if (chkStat.Checked)
                {

                    string fName = gvData.Rows[i].Cells[3].Text;
                    string lName = gvData.Rows[i].Cells[4].Text;
                    string email = gvData.Rows[i].Cells[8].Text;



                    //Loads an existing Word document
                    using (WordDocument document = new WordDocument(Path.GetFullPath(uploadsPathWordC + fName + "_" + lName + "_Report.docx"), FormatType.Docx))

                    {


                        document.ChartToImageConverter = new ChartToImageConverter();


                        document.ChartToImageConverter.ScalingMode = Syncfusion.OfficeChart.ScalingMode.Normal;

                        //Creates an instance of the DocToPDFConverter - responsible for Word to PDF conversion
                        DocToPDFConverter converter = new DocToPDFConverter();


                        //Sets true to embed TrueType fonts
                        converter.Settings.EmbedFonts = true;           // clerfiying pdfs output 

                        //Sets true to enable the fast rendering using direct PDF conversion.
                        converter.Settings.EnableFastRendering = true;

                        //Converts Word document into PDF document
                        PdfDocument pdfDocument = converter.ConvertToPDF(document);

                        ////pdfDocument.Save(Server.MapPath(@"C:\projects\supervisorProject\unSupervisorApp\Data\PdfOutput" + internId + "_" + fName + " " + lName + ".pdf"));

                        //Saves the PDF files
                        pdfDocument.Save(Path.GetFullPath(uploadsPathPDFC + email + ".pdf"));

                        //Closes the instance of document objects
                        pdfDocument.Close(true);
                        pdfDocument.Close();
                    }
                }
            }

            lblOutput.Text = " Pdfs output generated successfully ";
        }


        void wordEval()
        {


            for (int i = 0; i <= gvData.Rows.Count - 1; i++)
            {
                CheckBox chkStat = gvData.Rows[i].FindControl("cbAll") as CheckBox;
                if (chkStat.Checked)
                {
                    string studentId = gvData.Rows[i].Cells[1].Text;
                    string fName = gvData.Rows[i].Cells[3].Text;
                    string lName = gvData.Rows[i].Cells[4].Text;
                    string courseStartDate = gvData.Rows[i].Cells[6].Text.ToString();
                    string courseEndDate = gvData.Rows[i].Cells[7].Text.ToString();

                    string email = gvData.Rows[i].Cells[8].Text;
                    string course = gvData.Rows[i].Cells[5].Text;
                    string institutionId = gvData.Rows[i].Cells[2].Text;
                    string supervisorEmail = gvData.Rows[i].Cells[9].Text;

                    string problemSolving = "80";
                    string abilityToLearn = "90";
                    string punctuality = "60";
                    string grandTotal = "88";


                    using (WordDocument document = new WordDocument(Path.GetFullPath(templatePathEval), FormatType.Docx))
                    {

                        document.MailMerge.RemoveEmptyParagraphs = true;                // for removing empty cells
                        string[] fieldNames = new string[] {
                            "studentId", "fName", "lName", "course","courseStartDate","courseEndDate",
           "email" ,"problemSolving", "abilityToLearn",
           "punctuality", "grandTotal",
           "institutionId","supervisorEmail"

                        };
                        string[] fieldValues = new string[] {studentId, fName, lName,course, courseStartDate,courseEndDate,
           email ,problemSolving,abilityToLearn,
           punctuality, grandTotal,
           institutionId,supervisorEmail,

                        };

                        document.MailMerge.Execute(fieldNames, fieldValues);            //Performs the mail merge.

                        document.Save(Server.MapPath(fName + lName + ".docx"));         //Saves the Word document.
                        document.Save(Path.GetFullPath(uploadsPathWordE + fName + "_" + lName + "_Report.docx"), FormatType.Docx);
                        document.Close();
                    }
                }
                //pass message to user notifying of successfull opreation
                lblOutput.Text = " Template output generated successfully ";


            }
        }


        void pdfEval()
        {
            wordCert();
            for (int i = 0; i <= gvData.Rows.Count - 1; i++)
            {
                CheckBox chkStat = gvData.Rows[i].FindControl("cbAll") as CheckBox;
                if (chkStat.Checked)
                {

                    string fName = gvData.Rows[i].Cells[3].Text;
                    string lName = gvData.Rows[i].Cells[4].Text;
                    string email = gvData.Rows[i].Cells[8].Text;



                    //Loads an existing Word document
                    using (WordDocument document = new WordDocument(Path.GetFullPath(uploadsPathWordE + fName + "_" + lName + "_Report.docx"), FormatType.Docx))

                    {


                        document.ChartToImageConverter = new ChartToImageConverter();


                        document.ChartToImageConverter.ScalingMode = Syncfusion.OfficeChart.ScalingMode.Normal;

                        //Creates an instance of the DocToPDFConverter - responsible for Word to PDF conversion
                        DocToPDFConverter converter = new DocToPDFConverter();


                        //Sets true to embed TrueType fonts
                        converter.Settings.EmbedFonts = true;           // clerfiying pdfs output 

                        //Sets true to enable the fast rendering using direct PDF conversion.
                        converter.Settings.EnableFastRendering = true;

                        //Converts Word document into PDF document
                        PdfDocument pdfDocument = converter.ConvertToPDF(document);


                        //Saves the PDF files
                        pdfDocument.Save(Path.GetFullPath(uploadsPathPDFE + email + ".pdf"));

                        //Closes the instance of document objects
                        pdfDocument.Close(true);
                        pdfDocument.Close();
                    }
                }
            }

            lblOutput.Text = " Pdfs output generated successfully ";
        }


    } //cs

} //ns
 