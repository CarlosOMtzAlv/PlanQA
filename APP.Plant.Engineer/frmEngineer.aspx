<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmEngineer.aspx.cs" Inherits="APP.Plant.Engineer.frmEngineer" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ingeniería</title>
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/datepicker.css" rel="stylesheet">
    <!-- Custom styles for this template -->
    <link href="signin.css" rel="stylesheet">

</head>
<body>

    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="pnlPag" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                        <asp:Label CssClass="h1" runat="server" Text="Pantalla de Ingeniería"></asp:Label>
                            </div>
                        <br /><br /><br />
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card mb-3">
                                <div class="card-header"><i class="fa fa-briefcase"></i></div>
                                <div class="card-body">
                                    <div class="form-group">
                                        <div class="form-row">
                                            <div class="col-lg-6">
                                                <label for="txtFechaInicio">Fecha Inicio:</label>
                                                <input type="date" name="txtFechaInicio" min="1000-01-01" max="3000-12-31" class="form-control" />
                                            </div>
                                            <div class="col-lg-6">
                                                <label for="txtFechaFin">Fecha Fin:</label>
                                                <input type="date" name="txtFechaFin" min="1000-01-01" max="3000-12-31" class="form-control"  />
                                            </div>
                                            <div class="col-lg-12">
                                                <br />
                                                <asp:Button runat="server" ID="btnBuscar" Text="Buscar" CssClass="btn btn-sm btn-primary btn-block" OnClick="btnBuscar_Click" />
                                            </div>

                                        </div>
                                    </div>
                                </div>
                                <div class="card-footer">
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-12">
                            <div class="table-responsive">
                                <asp:GridView runat="server" ID="grdMetrics" CssClass="table table-striped" EmptyDataText="No hay valores como resultado de la busqueda" AllowPaging="true" PageSize="10" 
                                    OnPageIndexChanging="grdMetrics_PageIndexChanging" >
                                    <HeaderStyle CssClass="success" />
                                    <PagerStyle CssClass=""/>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
