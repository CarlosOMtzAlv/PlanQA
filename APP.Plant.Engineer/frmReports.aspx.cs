using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;
using APP.Plant.Engineer.Helpers;
using System.Web.UI.DataVisualization.Charting;

namespace APP.Plant.Engineer
{
    public partial class frmReports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Id_User"] != null)
            {
                if (!IsPostBack)
                {
                    FillFilters();
                    DefaultRangeValues();
                }
            }
            else Response.Redirect("Default.aspx");
        }

        #region "Fill Filters"

        protected void FillFilters()
        {
            try
            {
                FillReports();
                //FillLine();
                //FillProduct("");
                //FillProductFamily();
                //FillMachine("");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void FillReports()
        {
            try
            {
                ddlReports.DataSource = ManagerDB.GetInstance().GetReports();
                ddlReports.DataTextField = "Nam_Reports";
                ddlReports.DataValueField = "Id_Reports";
                ddlReports.DataBind();
                ddlReports.Items.Insert(0, "Seleccione");
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //protected void FillLine()
        //{
        //    try
        //    {
        //        ddlLinea.DataSource = ManagerDB.GetInstance().GetCatalog("Line",""); 
        //        ddlLinea.DataTextField = "Nam_Line";
        //        ddlLinea.DataValueField = "Id_Line";
        //        ddlLinea.DataBind();
        //        ddlLinea.Items.Insert(0, "Seleccione");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void FillProduct(string Id)
        //{
        //    try
        //    {
        //        ddlProducto.Items.Clear();
        //        ddlProducto.DataSource = ManagerDB.GetInstance().GetCatalog("Product", Id);
        //        ddlProducto.DataTextField = "Nam_Product";
        //        ddlProducto.DataValueField = "Id_Product";
        //        ddlProducto.DataBind();
        //        ddlProducto.Items.Insert(0, "Seleccione");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void FillProductFamily()
        //{
        //    try
        //    {
        //        ddlFamProd.Items.Clear();
        //        ddlFamProd.DataSource = ManagerDB.GetInstance().GetCatalog("ProductFamily", "");
        //        ddlFamProd.DataTextField = "Desc_ProductFamily";
        //        ddlFamProd.DataValueField = "Id_ProductFamily";
        //        ddlFamProd.DataBind();
        //        ddlFamProd.Items.Insert(0, "Seleccione");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void FillMachine(string Id)
        //{
        //    try
        //    {
        //        ddlMaquina.Items.Clear();
        //        ddlMaquina.DataSource = ManagerDB.GetInstance().GetCatalog("Machine", Id);
        //        ddlMaquina.DataTextField = "Desc_Machine";
        //        ddlMaquina.DataValueField = "Id_Machine";
        //        ddlMaquina.DataBind();
        //        ddlMaquina.Items.Insert(0, "Seleccione");
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void ddlProducto_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        FillProduct(ddlFamProd.SelectedValue.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void ddlLinea_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        FillMachine(ddlLinea.SelectedValue.ToString());
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void ddlReports_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion

        protected void ShowPanels(string Report)
        {
            try
            {
                Session["fechaInicio"] = Convert.ToDateTime(Request["txtFechaInicio"]).ToString("dd/MM/yyyy hh:mm:ss");
                Session["fechaFin"] = Convert.ToDateTime(Request["txtFechaFin"]).ToString("dd/MM/yyyy hh:mm:ss");
                switch (Report)
                {
                    case "1":
                        pnlEficiencia.Visible = true;
                        DefaultRangeValues2();
                        lblInicioEficiencia.Text = "Fecha Inicio Reporte: " + Convert.ToDateTime(Request["txtFechaInicio"]).ToString("dd/MM/yyyy hh:mm:ss");
                        lblFinEficiencia.Text = "Fecha Fin Reporte: " + Convert.ToDateTime(Request["txtFechaFin"]).ToString("dd/MM/yyyy hh:mm:ss");
                        FillReportTableGraphic(1);
                        break;
                    case "2":
                        pnlGraficoEficiencia.Visible = true;
                        FillReportTableGraphic(2);
                        lblFechaInicio.Text = "Fecha Inicio Reporte: " + Convert.ToDateTime(Request["txtFechaInicio"]).ToString("dd/MM/yyyy hh:mm:ss");
                        lblFechaFin.Text = "Fecha Fin Reporte: " + Convert.ToDateTime(Request["txtFechaFin"]).ToString("dd/MM/yyyy hh:mm:ss");
                        break;
                    case "3":
                        pnlEficienciaCostos.Visible = true;
                        DefaultRangeValues3();
                        FillReportTableCosts();
                        lblCostoInicio.Text = "Fecha Inicio Reporte: " + Convert.ToDateTime(Request["txtFechaInicio"]).ToString("dd/MM/yyyy hh:mm:ss");
                        lblCostoFin.Text = "Fecha Fin Reporte: " + Convert.ToDateTime(Request["txtFechaFin"]).ToString("dd/MM/yyyy hh:mm:ss");
                        break;
                }
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
                ShowPanels(ddlReports.SelectedValue.ToString());               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DefaultRangeValues()
        {
            try
            {
                txtMinGreen.Text = "90";
                txtMaxGreen.Text = "100";
                txtMinYellow.Text = "80";
                txtMaxYellow.Text = "90";
                txtMaxRed.Text = "80";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void DefaultRangeValues2()
        {
            try
            {
                txtHighMin2.Text = "90";
                txtHighMax2.Text = "100";
                txtMedMin2.Text = "80";
                txtMedMax2.Text = "90";
                txtLowMax2.Text = "80";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void DefaultRangeValues3()
        {
            try
            {
                txtHighMin3.Text = "0";
                txtHighMax3.Text = "60000000";
                txtMedMin3.Text = "60000000";
                txtMedMax3.Text = "90000000";
                txtLowMax3.Text = "90000000";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region "Charts Configurations"

        protected void FillOEEChart(DataTable dtData)
        {
            try
            {
                string serieIndice = dtData.Columns[0].ColumnName;
                string serieCal = dtData.Columns[8].ColumnName;

                OEEChart.Series.Add(serieIndice);

                String[] xArray = new string[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    xArray[i] = dr[serieIndice].ToString();
                }

                Decimal[] yArray = new decimal[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    yArray[i] = Decimal.Parse(dr[serieCal].ToString());
                }
                OEEChart.Series[serieIndice].Points.DataBindXY(xArray, yArray);
                OEEChart.Series[serieIndice].Sort(PointSortOrder.Descending);
                OEEChart.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

                OEEChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

                OEEChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0.00 %}";
                OEEChart.ChartAreas[0].AxisY2.LabelStyle.Format = "{0.00 %}";

                OEEChart.ChartAreas[0].AxisX.Title = serieIndice;
                OEEChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);
                OEEChart.Series[serieIndice].ToolTip = "OEE: #PERCENT{0.00 %}";
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void FillDisponibilidadChart(DataTable dtData)
        {
            try
            {
                string serieIndice = dtData.Columns[0].ColumnName;
                string serieProd = dtData.Columns[4].ColumnName;
                string serieDisp = dtData.Columns[5].ColumnName;

                ChartDisp.Series.Add(serieIndice);
                ChartDisp.Series.Add(serieProd);

                String[] xArray = new string[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    xArray[i] = dr[serieProd].ToString();
                }

                Decimal[] yArray = new decimal[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    yArray[i] = Decimal.Parse(dr[serieDisp].ToString());
                }
                ChartDisp.Series[serieProd].Points.DataBindXY(xArray, yArray);
                ChartDisp.Series[serieProd].Sort(PointSortOrder.Descending);
                ChartDisp.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

                ChartDisp.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

                ChartDisp.ChartAreas[0].AxisY.LabelStyle.Format = "{0.00 %}";
                ChartDisp.ChartAreas[0].AxisY2.LabelStyle.Format = "{0.00 %}";

                ChartDisp.ChartAreas[0].AxisX.Title = serieProd;
                ChartDisp.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);
                ChartDisp.Series[serieProd].ToolTip = "Disponibilidad: #PERCENT{0.00 %}";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void FillCalidadChart(DataTable dtData)
        {
            try
            {
                string serieProd = dtData.Columns[4].ColumnName;
                string serieCal = dtData.Columns[6].ColumnName;

                CalidadChart.Series.Add(serieProd);

                String[] xArray = new string[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    xArray[i] = dr[serieProd].ToString();
                }

                Decimal[] yArray = new decimal[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    yArray[i] = Decimal.Parse(dr[serieCal].ToString());
                }
                CalidadChart.Series[serieProd].Points.DataBindXY(xArray, yArray);
                CalidadChart.Series[serieProd].Sort(PointSortOrder.Descending);
                CalidadChart.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

                CalidadChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

                CalidadChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0.00 %}";
                CalidadChart.ChartAreas[0].AxisY2.LabelStyle.Format = "{0.00 %}";

                CalidadChart.ChartAreas[0].AxisX.Title = serieProd;
                CalidadChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);
                CalidadChart.Series[serieProd].ToolTip = "Calidad: #PERCENT{0.00 %}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void FillDesempenoChart(DataTable dtData)
        {
            try
            {
                DataTable dt = new DataTable();

                dt.Columns.AddRange(new DataColumn[7] { new DataColumn("RHI_Freq_Class"), new DataColumn("<0"), new DataColumn("0-7"), new DataColumn("8-14"), new DataColumn("15-21"), new DataColumn("22-28"), new DataColumn(">28") });
                dt.Rows.Add("FORD", 4, 41, 11, 12, 8, 10);
                dt.Rows.Add("VW", 10, 9, 15, 1, 9, 5);
                dt.Rows.Add("GENERAL MOTORS", 17, 12, 37, 40, 16, 20);
                dt.Rows.Add("NISSAN", 17, 12, 37, 40, 16, 20);

                string[] x = new string[6] { "492586", "539164", "584276", "661765", "418002", "539164" };

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int[] y = new int[6] { Convert.ToInt32(dt.Rows[i]["<0"].ToString()), Convert.ToInt32(dt.Rows[i]["0-7"].ToString()), Convert.ToInt32(dt.Rows[i]["8-14"].ToString()), Convert.ToInt32(dt.Rows[i]["15-21"].ToString()), Convert.ToInt32(dt.Rows[i]["22-28"].ToString()), Convert.ToInt32(dt.Rows[i][">28"].ToString()) };

                    DesChart.Series.Add(dt.Rows[i]["RHI_Freq_Class"].ToString());
                    DesChart.Series[dt.Rows[i]["RHI_Freq_Class"].ToString()].Points.DataBindXY(x, y);
                    DesChart.Series[dt.Rows[i]["RHI_Freq_Class"].ToString()].ToolTip = "Desempeño: #VAL";
                }

                //string serieProd = dtData.Columns[4].ColumnName;
                //string serieCal = dtData.Columns[7].ColumnName;

                //DesChart.Series.Add(serieProd);

                //String[] xArray = new string[dtData.Rows.Count + 1];
                //for (int i = 0; i < dtData.Rows.Count; i++)
                //{
                //    DataRow dr = dtData.Rows[i];
                //    xArray[i] = dr[serieProd].ToString();
                //}

                //Decimal[] yArray = new decimal[dtData.Rows.Count + 1];
                //for (int i = 0; i < dtData.Rows.Count; i++)
                //{
                //    DataRow dr = dtData.Rows[i];
                //    yArray[i] = Decimal.Parse(dr[serieCal].ToString()) * 100;
                //}
                //DesChart.Series[serieProd].Points.DataBindXY(xArray, yArray);
                //DesChart.Series[serieProd].Sort(PointSortOrder.Descending);
                //DesChart.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

                //DesChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

                DesChart.ChartAreas[0].AxisX.Title = "Producto";
                DesChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);
                //DesChart.Series[serieProd].ToolTip = "Desempeño: #VAL";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void FillPerdidaChart(DataTable dtData)
        {
            try
            {
                string serieProd = dtData.Columns[4].ColumnName;
                string serieDisp = dtData.Columns[6].ColumnName;
                string serieCal = dtData.Columns[7].ColumnName;
                string serieDes = dtData.Columns[8].ColumnName;
                string serieOEE = dtData.Columns[9].ColumnName;
                
                chartPerdidas.Series.Add(serieDisp);
                chartPerdidas.Series.Add(serieCal);
                chartPerdidas.Series.Add(serieDes);
                chartPerdidas.Series.Add(serieOEE);

                String[] xArray = new string[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    xArray[i] = dr[serieProd].ToString();
                }

                Decimal[] yArray = new decimal[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    yArray[i] = Decimal.Parse(dr[serieCal].ToString());
                }

                Decimal[] DispArray = new decimal[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    DispArray[i] = Decimal.Parse(dr[serieDisp].ToString());
                }

                Decimal[] DesArray = new decimal[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    DesArray[i] = Decimal.Parse(dr[serieDes].ToString());
                }

                Decimal[] OEEArray = new decimal[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    OEEArray[i] = Decimal.Parse(dr[serieOEE].ToString());
                }


                chartPerdidas.Series[serieDisp].Points.DataBindXY(xArray, DispArray);
                chartPerdidas.Series[serieDisp].Sort(PointSortOrder.Descending);

                chartPerdidas.Series[serieCal].Points.DataBindXY(xArray, yArray);
                chartPerdidas.Series[serieCal].Sort(PointSortOrder.Descending);

                chartPerdidas.Series[serieDes].Points.DataBindXY(xArray, DesArray);
                chartPerdidas.Series[serieDes].Sort(PointSortOrder.Descending);

                chartPerdidas.Series[serieOEE].Points.DataBindXY(xArray, OEEArray);
                chartPerdidas.Series[serieOEE].Sort(PointSortOrder.Descending);


                chartPerdidas.ChartAreas[0].AxisY.LabelStyle.Format = "{$ 0,000}";
                chartPerdidas.ChartAreas[0].AxisY2.LabelStyle.Format = "{$ 0,000}";

                chartPerdidas.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

                chartPerdidas.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;

                chartPerdidas.ChartAreas[0].AxisX.Title = serieProd;
                chartPerdidas.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);

                chartPerdidas.Series[serieDisp].ToolTip = "Pérdida: #VAL{$ 0,000}";
                chartPerdidas.Series[serieCal].ToolTip = "Pérdida: #VAL{$ 0,000}";
                chartPerdidas.Series[serieDes].ToolTip = "Pérdida: #VAL{$ 0,000}";
                chartPerdidas.Series[serieOEE].ToolTip = "Pérdida: #VAL{$ 0,000}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void FillPerdProdChart(DataTable dtData)
        {
            try
            {
                string serieProd = dtData.Columns[4].ColumnName;
                string serieDisp = dtData.Columns[7].ColumnName;
                string serieCal = dtData.Columns[9].ColumnName;
                string serieDes = dtData.Columns[11].ColumnName;

                string titleDips = "Disponibilidad";
                string titleCal = "Calidad";
                string titleDes = "Desempeño";

                PerdProdChart.Series.Add(titleDips);
                PerdProdChart.Series.Add(titleCal);
                PerdProdChart.Series.Add(titleDes);

                String[] xArray = new string[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    xArray[i] = dr[serieProd].ToString();
                }

                Decimal[] yArray = new decimal[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    yArray[i] = Decimal.Parse(dr[serieCal].ToString());
                }

                Decimal[] DispArray = new decimal[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    DispArray[i] = Decimal.Parse(dr[serieDisp].ToString());
                }

                Decimal[] DesArray = new decimal[dtData.Rows.Count + 1];
                for (int i = 0; i < dtData.Rows.Count; i++)
                {
                    DataRow dr = dtData.Rows[i];
                    DesArray[i] = Decimal.Parse(dr[serieDes].ToString());
                }


                PerdProdChart.Series[titleDips].Points.DataBindXY(xArray, DispArray);
                PerdProdChart.Series[titleDips].Sort(PointSortOrder.Descending);

                PerdProdChart.Series[titleCal].Points.DataBindXY(xArray, yArray);
                PerdProdChart.Series[titleCal].Sort(PointSortOrder.Descending);

                PerdProdChart.Series[titleDes].Points.DataBindXY(xArray, DesArray);
                PerdProdChart.Series[titleDes].Sort(PointSortOrder.Descending);

                PerdProdChart.ChartAreas[0].AxisX.LabelStyle.Angle = 0;

                PerdProdChart.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
                PerdProdChart.ChartAreas[0].AxisY.LabelStyle.Format = "{0.00 %}";
                PerdProdChart.ChartAreas[0].AxisY2.LabelStyle.Format = "{0.00 %}";

                PerdProdChart.ChartAreas[0].AxisX.Title = serieProd;
                PerdProdChart.ChartAreas[0].AxisX.TitleFont = new System.Drawing.Font("Calibri", 12, System.Drawing.FontStyle.Bold);

                PerdProdChart.Series[titleDips].ToolTip = "Pérdida: #PERCENT{0.00 %}";
                PerdProdChart.Series[titleCal].ToolTip = "Pérdida: #PERCENT{0.00 %}";
                PerdProdChart.Series[titleDes].ToolTip = "Pérdida: #PERCENT{0.00 %}";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        protected void FillReportTableGraphic (int option)
        {
            try
            {

                DataTable dtResult = new DataTable();
                dtResult = ManagerDB.GetInstance().SelReportOEE(Convert.ToDateTime(Session["fechaInicio"]).ToString("yyyyMMdd HH:mm:ss"), Convert.ToDateTime(Session["fechaFin"]).ToString("yyyyMMdd HH:mm:ss"));
                ViewState["dtGrid"] = dtResult;
                if(option == 1)
                {
                    DataRow[] SortTop10 = dtResult.Select().OrderByDescending(c => c["OEE"]).Take(10).ToArray();
                    DataTable dtTop10 = SortTop10.CopyToDataTable();
                    grdTop10.DataSource = dtTop10;
                    grdTop10.DataBind();

                    DataRow[] SortBot10 = dtResult.Select().OrderBy(c => c["OEE"]).Take(10).ToArray();
                    DataTable dtBot10 = SortBot10.CopyToDataTable();
                    grdBottom10.DataSource = dtBot10;
                    grdBottom10.DataBind();


                    grdEficienciaGlobal.DataSource = dtResult;
                    grdEficienciaGlobal.DataBind();
                }
                else if (option == 2)
                {
                    grdTableOEE.DataSource = dtResult;
                    grdTableOEE.DataBind();
                    FillOEEChart(dtResult);
                    FillCalidadChart(dtResult);
                    FillDesempenoChart(dtResult);
                    FillDisponibilidadChart(dtResult);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void FillReportTableCosts()
        {
            try
            {

                DataTable dtResult = new DataTable();
                dtResult = ManagerDB.GetInstance().SelReportCostos(Convert.ToDateTime(Session["fechaInicio"]).ToString("yyyyMMdd HH:mm:ss"), Convert.ToDateTime(Session["fechaFin"]).ToString("yyyyMMdd HH:mm:ss"));
                grdCosts.DataSource = dtResult;
                grdCosts.DataBind();

                FillPerdidaChart(ManagerDB.GetInstance().SelReportCostosPerdida(Convert.ToDateTime(Session["fechaInicio"]).ToString("yyyyMMdd HH:mm:ss"), Convert.ToDateTime(Session["fechaFin"]).ToString("yyyyMMdd HH:mm:ss")));
                FillPerdProdChart(ManagerDB.GetInstance().SelReportCostosPerdidaPorProduccion(Convert.ToDateTime(Session["fechaInicio"]).ToString("yyyyMMdd HH:mm:ss"), Convert.ToDateTime(Session["fechaFin"]).ToString("yyyyMMdd HH:mm:ss")));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdTableOEE_RowDataBound(object sender, System.Web.UI.WebControls.GridViewRowEventArgs e)
        {
            try
            {
                if(e.Row.RowType == DataControlRowType.DataRow)
                {
                    EvaluateTableValues(e, 5);
                    EvaluateTableValues(e, 6);
                    EvaluateTableValues(e, 7);
                    EvaluateTableValues(e, 8);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void grdEficienciaGlobal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    EvalTableValuesEficiencia(e, 4);
                    EvalTableValuesEficiencia(e, 5);
                    EvalTableValuesEficiencia(e, 6);
                    EvalTableValuesEficiencia(e, 7);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void EvaluateTableValues(GridViewRowEventArgs dtRow, int rowIndex)
        {
            try
            {
                dtRow.Row.Cells[rowIndex].ForeColor = System.Drawing.Color.Black;
                dtRow.Row.Cells[rowIndex].Font.Bold = true;
                if ((Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Replace("%", "").Trim()) > Decimal.Parse(txtMinGreen.Text)) && (Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Replace("%", "").Trim()) < Decimal.Parse(txtMaxGreen.Text)))
                {
                    dtRow.Row.Cells[rowIndex].BackColor = System.Drawing.Color.Green;
                }
                if ((Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Replace("%", "").Trim()) > Decimal.Parse(txtMinYellow.Text)) && (Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Replace("%", "").Trim()) < Decimal.Parse(txtMaxYellow.Text)))
                {
                    dtRow.Row.Cells[rowIndex].BackColor = System.Drawing.Color.Yellow;
                }
                if ((Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Replace("%", "").Trim()) < Decimal.Parse(txtMaxRed.Text)))
                {
                    dtRow.Row.Cells[rowIndex].BackColor = System.Drawing.Color.Red;
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void EvalTableValuesEficiencia(GridViewRowEventArgs dtRow, int rowIndex)
        {
            try
            {
                dtRow.Row.Cells[rowIndex].ForeColor = System.Drawing.Color.Black;
                dtRow.Row.Cells[rowIndex].Font.Bold = true;
                if ((Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Replace("%", "").Trim()) > Decimal.Parse(txtHighMin2.Text)) && (Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Replace("%", "").Trim()) < Decimal.Parse(txtHighMax2.Text)))
                {
                    dtRow.Row.Cells[rowIndex].BackColor = System.Drawing.Color.Green;
                }
                if ((Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Replace("%", "").Trim()) > Decimal.Parse(txtMedMin2.Text)) && (Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Replace("%", "").Trim()) < Decimal.Parse(txtMedMax2.Text)))
                {
                    dtRow.Row.Cells[rowIndex].BackColor = System.Drawing.Color.Yellow;
                }
                if ((Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Replace("%", "").Trim()) < Decimal.Parse(txtLowMax2.Text)))
                {
                    dtRow.Row.Cells[rowIndex].BackColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void EvalTableValuesCostos(GridViewRowEventArgs dtRow, int rowIndex)
        {
            try
            {
                dtRow.Row.Cells[rowIndex].ForeColor = System.Drawing.Color.Black;
                dtRow.Row.Cells[rowIndex].Font.Bold = true;
                Decimal valor = Decimal.Parse(dtRow.Row.Cells[rowIndex].Text.Substring(0, dtRow.Row.Cells[rowIndex].Text.IndexOf(" -")).Replace("$", "").Trim());
                if ((valor >= Decimal.Parse(txtHighMin3.Text)) && (valor < Decimal.Parse(txtHighMax3.Text)))
                {
                    dtRow.Row.Cells[rowIndex].BackColor = System.Drawing.Color.Green;
                }
                if ((valor > Decimal.Parse(txtMedMin3.Text)) && (valor < Decimal.Parse(txtMedMax3.Text)))
                {
                    dtRow.Row.Cells[rowIndex].BackColor = System.Drawing.Color.Yellow;
                }
                if ((valor > Decimal.Parse(txtLowMax3.Text)))
                {
                    dtRow.Row.Cells[rowIndex].BackColor = System.Drawing.Color.Red;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtHighMin2_TextChanged(object sender, EventArgs e)
        {
            try
            {
                FillReportTableGraphic(1);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        protected void grdTableOEE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                FillReportTableGraphic(2);
                grdTableOEE.PageIndex = e.NewPageIndex;
                grdTableOEE.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdTop10Perdidas_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        string previousCellValue = "";
        int previousCellCount = 0;

        protected void grdCosts_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    EvalTableValuesCostos(e, 5);
                    EvalTableValuesCostos(e, 6);
                    EvalTableValuesCostos(e, 7);
                    EvalTableValuesCostos(e, 8);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}