using unSupervisorApp.admin;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace unSupervisorApp.App_Code
{

    public static class common
    {


         






        //.. public static string   constr = WebConfigurationManager.ConnectionStrings["conStrtaskDb"].ConnectionString;
        public static bool InputIsEmpty(string s)
        {
            return (s == null || s == String.Empty || string.IsNullOrWhiteSpace(s)) ? true : false;
        }
        static void ValidateNullOrEmpty(string myObject)
        {
            if (string.IsNullOrWhiteSpace(myObject))
            {
                throw new ArgumentException("Your Object is null or empty", myObject);
            }
        }
        public static string msg = "";
        // added on 3/16/2014 
        public static string validateInput(string myValue)
        {
            string rtnMsg = (!string.IsNullOrEmpty(myValue) ? myValue : "-1");
            return rtnMsg;
        }
        public static string SafeGetString(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return reader.GetString(colIndex).ToString();
            return string.Empty;
        }
        public static int SafeGetStringInt(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return Convert.ToInt32(reader.GetValue(colIndex).ToString());
            return 0;
        }
        public static DateTime SafeGetStringDate(this SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
                return Convert.ToDateTime(reader.GetValue(colIndex).ToString());  //Convert.ToDateTime(dr.SafeGetString(3)).ToString("dd/MM/yyyy"));
            return DateTime.Now;
        }
        public static bool IsNullOrEmpty(this ICollection collection)
        {
            return collection == null || collection.Count == 0;
        }
        public static bool IsNullOrEmpty(int myNum)
        {
            return myNum == 0;
        }
        public static bool IsNullOrEmpty(string myString)
        {
            // ali added july5,2019 better 
            return string.IsNullOrEmpty(myString) || string.IsNullOrWhiteSpace(myString) || myString == string.Empty;
        }
        public static bool IsNullOrEmpty(TextBox myObject, Label myLabel) // use this better
        {
            bool fieldIsEmpty = false;
            if (string.IsNullOrEmpty(myObject.Text) || string.IsNullOrWhiteSpace(myObject.Text) || myObject.Text == string.Empty)
            {
                myObject.Focus();
                myLabel.ForeColor = System.Drawing.Color.Red;
                myLabel.Text = " Please fill  " + (myObject.ID).Substring(3, myObject.ID.Length - 3) + " !"; // to get max length  myObject.ID.Length
                fieldIsEmpty = true;
            }
            return fieldIsEmpty;
        }
        public static void IsNullOrEmpty(TextBox myObject, Label myLabel, string myMsg)
        {
            if (string.IsNullOrEmpty(myObject.Text) || string.IsNullOrWhiteSpace(myObject.Text) || myObject.Text == string.Empty)
            {
                myObject.Focus();
                myLabel.ForeColor = System.Drawing.Color.Red;
                myLabel.Text = " Please fill.... " + myMsg + " !";
                return;
            }
        }
        public static void IsNullOrEmpty(DropDownList myObject, Label myLabel, string myMsg)
        {
            if (string.IsNullOrEmpty(myObject.SelectedValue) || string.IsNullOrWhiteSpace(myObject.SelectedValue) || myObject.SelectedValue == string.Empty)
            {
                myObject.Focus();
                myLabel.ForeColor = System.Drawing.Color.Red;
                myLabel.Text = " Please fill.... " + myMsg + " !";
                return;
            }
        }
        public static bool IsNullOrEmptyControlObj(object myObject, Label myLabel, string myMsg)
        {  // new created in April 2020  improve using  switch 
            bool rtn = false;
            if (myObject.GetType() == typeof(DropDownList))
            {
                DropDownList ddlMyObj = (DropDownList)myObject;
                if (string.IsNullOrEmpty(ddlMyObj.SelectedValue) || string.IsNullOrWhiteSpace(ddlMyObj.SelectedValue) || ddlMyObj.SelectedValue == string.Empty || ddlMyObj.SelectedValue == "1")
                {
                    ddlMyObj.Focus();
                    myLabel.ForeColor = System.Drawing.Color.Red;
                    myLabel.BackColor = Color.Yellow;
                    myLabel.Text = myMsg;
                    rtn = true;
                }
            }

            if (myObject.GetType() == typeof(TextBox))
            {
                TextBox txtMyObj = (TextBox)myObject;
                if (string.IsNullOrEmpty(txtMyObj.Text) || string.IsNullOrWhiteSpace(txtMyObj.Text) || txtMyObj.Text == string.Empty)
                {
                    txtMyObj.Focus();
                    //  txtMyObj.BorderWidth = 2;
                    //  txtMyObj.BorderColor = System.Drawing.Color.Green;
                    myLabel.ForeColor = System.Drawing.Color.Red;
                    myLabel.BackColor = Color.Yellow;
                    myLabel.Text = myMsg;
                    myLabel.ToolTip = "Please enter a value!";
                    rtn = true;
                }
            }
            if (myObject.GetType() == typeof(RadioButton))
            {
                RadioButton rbnMyObj = (RadioButton)myObject;
                if (string.IsNullOrEmpty(rbnMyObj.Text) || string.IsNullOrWhiteSpace(rbnMyObj.Text) || rbnMyObj.Text == string.Empty)
                {
                    rbnMyObj.Focus();
                    myLabel.ForeColor = System.Drawing.Color.Red;
                    myLabel.BackColor = Color.Yellow;
                    myLabel.Text = myMsg;
                    rtn = true;
                }
            }

            if (myObject.GetType() == typeof(CheckBox))
            {
                CheckBox cbxMyObj = (CheckBox)myObject;
                if (string.IsNullOrEmpty(cbxMyObj.Text) || string.IsNullOrWhiteSpace(cbxMyObj.Text) || cbxMyObj.Text == string.Empty)
                {
                    cbxMyObj.Focus();
                    myLabel.ForeColor = System.Drawing.Color.Red;
                    myLabel.BackColor = Color.Yellow;
                    myLabel.Text = myMsg;
                    rtn = true;
                }
            }
            return rtn;
        }
        public static string TrimMyString(string myString)
        {
            // ali added july5,2019  
            return myString.Trim();
        }
        public static bool IsDecimalOrIntOrEmpty(string myString)
        {
            // this method applies for both int and decimal.
            decimal output;
            bool result = decimal.TryParse(myString, out output);
            return result;
        }
        #region msg auto
        public static void clearLblOutputContent(Label myLblOutput)
        {
            myLblOutput.Text = "";
        }
        public static void PostMsg(Label myLblOutput, string myMsg)
        {
            myLblOutput.Text = myMsg;
            //myLblOutput.ForeColor = System.Drawing.Color.Red;
            //myLblOutput.BackColor = System.Drawing.Color.Yellow;
        }
        public static bool PostMsg(Label myLblOutput, string myMsg, string myColor)
        { // myColor either green or red
            bool rtn = false;
            switch (myColor)
            {
                case "green":
                    myLblOutput.Text = myMsg;
                    myLblOutput.ForeColor = System.Drawing.Color.Green;
                    myLblOutput.BackColor = System.Drawing.Color.Yellow;
                    rtn = true;
                    break;
                case "red":
                    myLblOutput.Text = myMsg;
                    myLblOutput.ForeColor = System.Drawing.Color.Red;
                    myLblOutput.BackColor = System.Drawing.Color.Yellow;
                    rtn = false;
                    break;
                default:
                    rtn = false;
                    break;
            }
            return rtn;
        }
        public static void PostMsg(Label myLblOutput, int rtn)
        {
            if (rtn >= 1)
            {
                myLblOutput.Text = "Success!";
                myLblOutput.ForeColor = System.Drawing.Color.Black;
                myLblOutput.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                myLblOutput.Text = "Failed!";
                myLblOutput.ForeColor = System.Drawing.Color.Red;
                myLblOutput.BackColor = System.Drawing.Color.Yellow;
                return;
            }
        }
        public static void PostMsg(Label myLblOutput, int rtn, string myMsg)
        {

            if (rtn >= 1)
            {
                myLblOutput.Text = myMsg;
                myLblOutput.ForeColor = System.Drawing.Color.Black;
                myLblOutput.BackColor = System.Drawing.Color.Yellow;
            }
            else
            {
                myLblOutput.Text = myMsg;
                myLblOutput.ForeColor = System.Drawing.Color.Red;
                myLblOutput.BackColor = System.Drawing.Color.Yellow;
            }
        }
        public static void grantPermission(Button myBtn)
        {
            if (Roles.IsUserInRole("admin") || Roles.IsUserInRole("supervisor"))
            {
                myBtn.Visible = true;
            }

        }
        #endregion
        public static void goToNextPage(string nextPage)
        {
            //   Server.Transfer("~/"+nextPage); // important point, server.Transfer keeps old url address and does not go to the new one ? why
            //  Response.Redirect("~/" + nextPage);
            HttpContext.Current.Response.Redirect("~/" + nextPage);

        }
        public static void showHideControl(object myObject, bool intShowHIdeCode)
        {
            if (myObject.GetType() == typeof(Button))
            {
                Button btnMyObj = (Button)myObject;
                btnMyObj.Visible = intShowHIdeCode;
            }

            if (myObject.GetType() == typeof(TextBox))
            {
                TextBox btnMyObj = (TextBox)myObject;
                btnMyObj.Visible = intShowHIdeCode;
            }
            if (myObject.GetType() == typeof(DropDownList))
            {
                DropDownList btnMyObj = (DropDownList)myObject;
                btnMyObj.Visible = intShowHIdeCode;
            }

            if (myObject.GetType() == typeof(RadioButton))
            {
                RadioButton btnMyObj = (RadioButton)myObject;
                btnMyObj.Visible = intShowHIdeCode;
            }

            if (myObject.GetType() == typeof(CheckBox))
            {
                CheckBox btnMyObj = (CheckBox)myObject;
                btnMyObj.Visible = intShowHIdeCode;
            }

            if (myObject.GetType() == typeof(GridView))
            {
                GridView btnMyObj = (GridView)myObject;
                btnMyObj.Visible = intShowHIdeCode;
            }
        }
        public static void showHideGvColumn(GridView myGv, int intColNo)
        {
            ////foreach (GridViewRow row in myGv.Rows)  // hide gv button
            ////{
            ////    ((Button)row.FindControl("btnDelete")).Visible = true;
            ////    ((Button)row.FindControl("btnEdit")).Visible = true;
            ////}
            // hide the GV column . Gv is zero index
            myGv.Columns[intColNo].Visible = true;
        }
        public static void clearControl(object myObject)
        {
            if (myObject.GetType() == typeof(Label))
            {
                Label btnMyObj = (Label)myObject;
                btnMyObj.Text = "";
            }

            if (myObject.GetType() == typeof(TextBox))
            {
                TextBox btnMyObj = (TextBox)myObject;
                btnMyObj.Text = "";
            }
            if (myObject.GetType() == typeof(DropDownList))
            {
                DropDownList btnMyObj = (DropDownList)myObject;
                btnMyObj.SelectedIndex = 0; // reset it to zero index 
            }
            if (myObject.GetType() == typeof(CheckBox))
            {
                CheckBox btnMyObj = (CheckBox)myObject;
                btnMyObj.Checked = false;
            }
            if (myObject.GetType() == typeof(GridView))
            {
                GridView btnMyObj = (GridView)myObject;
                btnMyObj.DataSource = null;
                btnMyObj.DataBind();
            }
        }
        public static int gvRowCount(GridView myGv)
        {
            int intRowCount = 0;
            intRowCount = myGv.Rows.Count;
            return intRowCount;
        }
    }//cls
}// ns
