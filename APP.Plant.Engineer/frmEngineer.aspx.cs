using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using APP.Plant.Engineer.Helpers;

namespace APP.Plant.Engineer
{
    public partial class frmEngineer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["Id_User"].ToString() != null)
                {
                    FillDataTable();
                }
                else
                    Response.Redirect("Default");
            }
        }

        protected void FillDataTable()
        {
            try
            {
                BindData(DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd"), DateTime.Now.ToString("yyyy/MM/dd"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void BindData(string fechaIni, string fechaFin)
        {
            try
            {
                DataTable dtData = new DataTable();
                dtData = ManagerDB.GetInstance().DTExecute(Constants.DB_SEL_METRICS, fechaIni, fechaFin);
                grdMetrics.DataSource = dtData;
                grdMetrics.DataBind();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                Session["FechaInicio"] = Request.Form["txtFechaInicio"];
                Session["FechaFin"] = Request.Form["txtFechaFin"];
                BindData(Request.Form["txtFechaInicio"], Request.Form["txtFechaFin"]);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void grdMetrics_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            BindData(Session["FechaInicio"].ToString(), Session["FechaFin"].ToString());
                grdMetrics.PageIndex = e.NewPageIndex;
                grdMetrics.DataBind();
        }
    }
}