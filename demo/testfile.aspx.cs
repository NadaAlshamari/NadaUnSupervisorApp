using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using unSupervisorApp.App_Code;

namespace unSupervisorApp.demo
{
    public partial class testfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnShowFile_Click(object sender, EventArgs e)
        {
                   
                gvClientFiles.DataSource = GetUploadList();  // new 
                gvClientFiles.DataBind();

            
        }

        protected IEnumerable GetUploadList()
        {
            string folder = Server.MapPath("~/Uploads");// get uploaded folder
            string[] files = Directory.GetFiles(folder); // get all files in folder 
            Array.Sort(files);
            foreach (string file in files)
                //// here I can specify the id of the file
                //if (file.Contains("_thm"))
                //{
                //    int position = file.IndexOf("_thm");
                //    yield return Path.GetFileName(file.Substring(0,position));
                //}
                //////if (file.Contains("500")) // check if files contains a value
                //////{
                //////    yield return Path.GetFileName(file);
                //////    int position = file.IndexOf("_");
                //////    yield return Path.GetFileName(file.Substring(0, position));
                //////}
                //////else
                //////{
                //////    yield return Path.GetFileName(file);
                //////}
                yield return Path.GetFileName(file);
        }
        protected void btnUploadToFileSystem_Click(object sender, EventArgs e)
        {
            ProcessMultiUploads();
        }
        protected void ProcessMultiUploads()
        {
            int rtn = 0;
            string myContactId = txtClintName.Text;
            myContactId = string.IsNullOrEmpty(myContactId) ? "000" : myContactId;
            string myPath = Path.Combine(Server.MapPath("~/Uploads"));
            int uploadIndex = 0;
            string fileName = "";
            if (FileUpload.HasFiles)
            {
                foreach (HttpPostedFile postedFile in FileUpload.PostedFiles)
                {
                    fileName = Path.Combine(Server.MapPath("~/Uploads"), myContactId + "_" + postedFile.FileName);//postedFile.FileName;
                    // uploadIndex = fileName.IndexOf("Uploads");
                    if (File.Exists(fileName))
                        File.Delete(fileName);
                    FileUpload.SaveAs(fileName);
                }
                lblOutput.Text = "Your files has been uploaded Successfully!";
            }
        }

        protected void btnUploadToDb_Click(object sender, EventArgs e)
        {
            try
            {
                //capture inserted values from the input form
                string strClient = "";
                int ddlGroupTypeId = 0;
                int intClientId = 0;
                strClient = txtClintName.Text;
                lblOutput.Text = strClient;
                // connect to the db and insert the captured vlaues
                CRUD myCrud = new CRUD();
                string mySql = @"INSERT INTO client (client )
                                VALUES  (@client)" +
                                "SELECT CAST(scope_identity() AS int)";
                Dictionary<string, object> myPara = new Dictionary<string, object>();
                myPara.Add("@client", strClient);
                intClientId = myCrud.InsertUpdateDeleteViaSqlDicRtnIdentity(mySql, myPara);
                int rtn = InsertDocuments(intClientId);
                if (rtn >= 1)
                {
                    lblOutput.Text = "You successfully uploaded " + rtn + " files ";
                }
                else
                {
                    lblOutput.Text = "Failed to upload!";
                }

            }

            catch (Exception ex)
            {
                lblOutput.Text = ex.Message.ToString();
            }
        }

        protected int InsertDocuments(int myClientId)  // upload doc to db
        {
            int intFilesUploaded = 0;
            foreach (HttpPostedFile postedFile in FileUpload.PostedFiles)
            {
                string filename = Path.GetFileName(postedFile.FileName);
                string contentType = postedFile.ContentType;
                using (Stream fs = postedFile.InputStream)
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        CRUD DocInsert = new CRUD();  // added Nov 2017 
                        string mySql = @"insert into clientDoc(clientId,DocName,ContentType,DocData)
                                    values (@clientId,@DocName,@ContentType,@DocData)";
                        Dictionary<string, Object> p = new Dictionary<string, object>();
                        //p.Add("@TaskId", "get the value ");
                        p.Add("@clientId", myClientId);  // added Nov 2017
                        p.Add("@DocName", filename);
                        p.Add("@ContentType", contentType);
                        p.Add("@DocData", bytes);
                        DocInsert.InsertUpdateDelete(mySql, p);
                        intFilesUploaded += 1;
                    }
                }
            }
            return intFilesUploaded;  // return number of files uploaded
        }
    }
    }
