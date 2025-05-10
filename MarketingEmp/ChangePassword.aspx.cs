using BankaSpotNew.App_Code;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BankaSpotNew.MarketingEmp
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["memp"] == null)
            {
                Response.Redirect("../MarketingEmpLogin.aspx");
            }
            if (!IsPostBack)
            {
                Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;
                cmpOldPassword.ValueToCompare = oMarketing_Employee_Add.EmpPassword;
            }
        }

        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Marketing_Employee_Add oMarketing_Employee_Add = Session["memp"] as Marketing_Employee_Add;
                var parameters = new DynamicParameters();
                parameters.Add("p_EmpPassword", txtConfirmNewPassword.Text.Trim());
                parameters.Add("p_Id", oMarketing_Employee_Add.Id);

                DataAccess oDataAccess = new DataAccess();
                oDataAccess.ExecuteSPDynamic("sp_changepwd_marketingemp", parameters);

                ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('Password Changed.Please Login Again');window.location.href='../MarketingEmpLogin.aspx';", true);
            }
        }
    }
}