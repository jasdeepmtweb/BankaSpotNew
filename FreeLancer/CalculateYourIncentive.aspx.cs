using BankaSpotNew.App_Code;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace BankaSpotNew.FreeLancer
{
    public partial class CalculateYourIncentive : System.Web.UI.Page
    {
        static List<Product_Add> ProList = new List<Product_Add>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["frl"] == null)
            {
                Response.Redirect("../FreeLancerLogin.aspx");
            }
            if (!IsPostBack)
            {
                GetData();
            }
        }
        private void GetData()
        {
            ProList.Clear();
            DataAccess oDataAccess = new DataAccess();
            var result = oDataAccess.QuerySPDynamic<Product_Add>("sp_getallproducts");
            ddlProduct.DataSource = result;
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "Id";
            ddlProduct.DataBind();
            ProList = result.ToList();
        }
        protected void BtnSubmit_Click(object sender, EventArgs e)
        {
            double Amount = Convert.ToDouble(txtAmount.Text);
            Product_Add oProduct_Add = ProList.FirstOrDefault(p => p.Id == Convert.ToInt32(ddlProduct.SelectedValue));
            double EmpPayout = Math.Round(Amount * (oProduct_Add.FreelancerCom / 100), 2);

            txtIncentive.Text = EmpPayout.ToString();
        }
    }
}