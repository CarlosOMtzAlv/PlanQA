using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APP.Plant.Engineer.Helpers
{
    public class Constants
    {
        public static readonly string QUERY_VALIDATE_USER = "Select * From app_user ";
        public static readonly string DB_SEL_METRICS = "iaSelMetricsWPF";
        public static readonly string QUERY_GET_REPORTS = "Select Id_Reports, nam_reports From app_tab_reports order by id_reports ";
        public static readonly string SP_TABLE_GRAPHIC_OEE = "iaRptGlobalOEE";
        public static readonly string SP_TABLE_GRAPHIC_DISPONIBILIDAD = "iaRptGlobalDisponibilidad";
        public static readonly string SP_TABLE_COSTOS = "iaRptCostos";
        public static readonly string SP_TABLE_COSTOS_PERDIDA = "iaRptCostosPerdidas";
        public static readonly string SP_TABLE_COSTOS_PERDIDA_PRODUCCION = "iaRptPerdidaPorParteProducida";

        protected static readonly string QUERY_GET_LINE = "Select Id_Line, Nam_Line From CatLine order by Id_Line ";
        protected static readonly string QUERY_GET_PRODUCTFAMILY = "Select Id_ProductFamily, Desc_ProductFamily From CatProductFamily order by Id_ProductFamily ";
        protected static string QUERY_GET_MACHINE (string Id)
        {
            string strCond = "";
            if (Id != "")
                strCond = " Where Id_Line = " + Id;
            return "Select Id_Machine, Desc_Machine From CatMachine " + strCond +  " order by Id_Machine ";
        }

        protected static string QUERY_GET_PRODUCT(string Id)
        {
            string strCond = "";
            if (Id != "")
                strCond = " Where Id_ProductFamily = " + Id;
            return "Select Id_Product, Nam_Product From CatProduct " + strCond + " order by Id_Product";
        }

        public static string QUERY_CATALOG(string namCatalog, string Id)
        {
            if (namCatalog == "Line")
                return QUERY_GET_LINE;
            else if (namCatalog == "Product")
                return QUERY_GET_PRODUCT(Id);
            else if (namCatalog == "ProductFamily")
                return QUERY_GET_PRODUCTFAMILY;
            else if (namCatalog == "Machine")
                return QUERY_GET_MACHINE(Id);
            else return "";
        }
    }
}