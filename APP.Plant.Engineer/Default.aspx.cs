using System;
using System.Data;
using APP.Plant.Engineer.Helpers;

namespace APP.Plant.Engineer
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable Result = new DataTable();
                Result = ManagerDB.GetInstance().ValidateUser(inputEmail.Value.ToString(), inputPassword.Value.ToString());
                if (Result != null)
                    if (Result.Rows.Count > 0)
                    {
                        Session["Id_User"] = Result.Rows[0][0].ToString();
                        Response.Redirect("frmReports.aspx");
                    }
                    else
                        msgError.Text = "Usuario y/o Contraseña incorrectos";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}