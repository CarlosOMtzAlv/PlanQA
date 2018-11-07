<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmReports.aspx.cs" Inherits="APP.Plant.Engineer.frmReports" EnableEventValidation="false" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reporteador</title>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/datepicker.css" rel="stylesheet" />
    <link href="css/menuFlotante.css" rel="stylesheet" />
</head>
<body style="background-image: url('Images/Fondo.jpg'); background-repeat: no-repeat; background-attachment: fixed;">
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server"></asp:ScriptManager>
        <asp:UpdatePanel runat="server" ID="pnlPag" UpdateMode="Conditional">
            <ContentTemplate>
                <header>
                    <section class="wrapper">
                        <asp:Image runat="server" ID="Logo" ImageUrl="~/Images/Logo 4.png" Width="255" Height="99"/>
                    </section>
                </header>
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <br /><br /><br /><br />
                            <asp:Label CssClass="h1" runat="server" Text="Reporteador"></asp:Label>
                        </div>
                        <br />
                        <br />
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="card mb-3">
                                <div class="card-header">
                                    <i class="fa fa-briefcase"></i>
                                    <a>Filtros de Busqueda</a>
                                </div>
                                <div class="card-body">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-lg-12">
                                                <label for="ddlReporte">Reporte:</label>
                                                <asp:DropDownList runat="server" ID="ddlReports" CssClass="form-control" OnSelectedIndexChanged="ddlReports_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="form-row">
                                            <div class="col-lg-6">
                                                <label for="txtFechaInicio">Fecha Inicio:</label>
                                                <input type="datetime-local" name="txtFechaInicio" min="1000-01-01" max="3000-12-31" class="form-control" id="txtFechaInicio"/>
                                                <%-- required="required" />--%>
                                            </div>
                                            <div class="col-lg-6">
                                                <label for="txtFechaFin">Fecha Fin:</label>
                                                <input type="datetime-local" name="txtFechaFin" min="1000-01-01" max="3000-12-31" class="form-control" id="txtFechaFin" />
                                                <%--required="required" />--%>
                                            </div>
                                        </div>
                                        <%--                                    <div class="form-row">
                                        <div class="col-lg-3">
                                            <label for="ddlLinea">Linea:</label>
                                            <asp:DropDownList runat="server" ID="ddlLinea" CssClass="form-control" OnSelectedIndexChanged="ddlLinea_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <label for="ddlFamProd">Familia Producto:</label>
                                            <asp:DropDownList runat="server" ID="ddlFamProd" CssClass="form-control" OnSelectedIndexChanged="ddlProducto_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <label for="ddlProducto">Producto:</label>
                                            <asp:DropDownList runat="server" ID="ddlProducto" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <label for="ddlMaquina">Maquina:</label>
                                            <asp:DropDownList runat="server" ID="ddlMaquina" CssClass="form-control"></asp:DropDownList>
                                        </div>
                                    </div>--%>
                                        <div class="form-row">
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
                            </div>
                        </div>
                    </div>
                    
                    <!-- REPORTE GRÁFICO EFICIENCIA -->
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:Panel runat="server" ID="pnlGraficoEficiencia" Visible="false">
                                <div class="card mb-3">
                                    <div class="card-header" style="text-align: center;">
                                        <asp:Label CssClass="h1" runat="server" Text="Reporte Gráfico de Eficiencia"></asp:Label>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-group">
                                            <div class="form-row">
                                                <div class="col-lg-8">
                                                    <br />
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" ID="lblFechaInicio"></asp:Label>
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" ID="lblFechaFin"></asp:Label>
                                                </div>
                                                <%--                                                <div class="col-lg-4">
                                                </div>--%>
                                                <div class="col-lg-4">
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Código de Color:"></asp:Label><br />
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Alto: " ForeColor="Green"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtMinGreen" Width="40px"></asp:TextBox>
                                                    <asp:Label CssClass="h3" runat="server" Text="% ≤ x ≤ " ForeColor="Green"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtMaxGreen" Width="40px"></asp:TextBox>
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Medio: " ForeColor="#f4f400"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtMinYellow" Width="40px"></asp:TextBox>
                                                    <asp:Label CssClass="h3" runat="server" Text="% ≤ x ≤ " ForeColor="#f4f400"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtMaxYellow" Width="40px"></asp:TextBox>
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Bajo x < " ForeColor="Red"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtMaxRed" Width="40px"></asp:TextBox>
                                                    <asp:Label CssClass="h3" runat="server" Text="%" ForeColor="Red"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="form-row">
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="table-responsive">
                                                        <asp:Label CssClass="h2" runat="server" Text="Reporte Global"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <asp:GridView runat="server" ID="grdTableOEE" CssClass="table table-bordered bs-table" AutoGenerateColumns="false" OnRowDataBound="grdTableOEE_RowDataBound" 
                                                            OnPageIndexChanging="grdTableOEE_PageIndexChanging" AllowPaging="true" PageSize="10">
                                                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#AAE4FF" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                            <AlternatingRowStyle BackColor="#E6E6E6" />
                                                            <EmptyDataTemplate>
                                                                No hay datos para mostrar.
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:BoundField DataField="Indice" HeaderText="Index" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Linea" HeaderText="Linea" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Maquina" HeaderText="Maquina" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Familia Producto" HeaderText="Familia Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Producto" HeaderText="Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Disponibilidad" HeaderText="Disponibilidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="Calidad" HeaderText="Calidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="Desempeño" HeaderText="Desempeño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="OEE" HeaderText="OEE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                            </Columns>
                                                            <PagerSettings Mode="NumericFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last"/>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="form-row">
                                                <div class="col-lg-12">
                                                    <asp:Chart ID="CalidadChart" runat="server" Width="1000px" Height="350px">
                                                        <Titles>
                                                            <asp:Title Font="Calibri, 20pt, style=Bold" Name="Title1" Text="Calidad"></asp:Title>
                                                        </Titles>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="ChartArea1">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                    </asp:Chart>
                                                    <asp:Chart ID="ChartDisp" runat="server" Width="1000px" Height="350px">
                                                        <Titles>
                                                            <asp:Title Font="Calibri, 20pt, style=Bold" Name="Title1" Text="Disponibilidad"></asp:Title>
                                                        </Titles>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="ChartArea1">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                    </asp:Chart>
                                                    <asp:Chart ID="DesChart" runat="server" Width="1000px" Height="350px">
                                                        <Titles>
                                                            <asp:Title Font="Calibri, 20pt, style=Bold" Name="Title1" Text="Desempeño"></asp:Title>
                                                        </Titles>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="ChartArea1">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                        <Legends>
                                                            <asp:Legend Name="Legend1">
                                                            </asp:Legend>
                                                        </Legends>
                                                    </asp:Chart>
                                                    <asp:Chart ID="OEEChart" runat="server" Width="1000px" Height="350px">
                                                        <Titles>
                                                            <asp:Title Font="Calibri, 20pt, style=Bold" Name="Title1" Text="OEE"></asp:Title>
                                                        </Titles>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="ChartArea1">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                    </asp:Chart>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="form-row">
                                                <div class="col-lg-4">
                                                </div>
                                                <div class="col-lg-4">
                                                    <asp:Chart ID="Chart4" runat="server" Width="500px" Height="500px">
                                                        <Titles>
                                                            <asp:Title Font="Calibri, 20pt, style=Bold" Name="Title1" Text="Distribución Global"></asp:Title>
                                                        </Titles>
                                                        <Series>
                                                            <asp:Series Name="Testing" YValueType="Int32" ChartType="Pie">

                                                                <Points>
                                                                    <asp:DataPoint AxisLabel="OEE" YValues="35" Label="OEE: #PERCENT{0.00 %}" />
                                                                    <asp:DataPoint AxisLabel="Calidad" YValues="60" Label="Calidad: #PERCENT{0.00 %}" />
                                                                    <asp:DataPoint AxisLabel="Desempeño" YValues="90" Label="Desempeño: #PERCENT{0.00 %}" />
                                                                    <asp:DataPoint AxisLabel="Disponibilidad" YValues="40" Label="Disponibilidad: #PERCENT{0.00 %}" />

                                                                </Points>
                                                            </asp:Series>
                                                        </Series>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                        <%--                                                        <Legends>
                                                            <asp:Legend Name="Legend1">
                                                            </asp:Legend>
                                                        </Legends>--%>
                                                    </asp:Chart>
                                                </div>
                                                <div class="col-lg-4">
                                                </div>
                                            </div>
                                            <div class="form-row">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-footer">
                                    </div>
                            </asp:Panel>
                        </div>
                    </div>

                    <!-- REPORTE EFICIENCIA -->
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:Panel runat="server" ID="pnlEficiencia" Visible="false">
                                <div class="card mb-3">
                                    <div class="card-header" style="text-align: center;">
                                        <asp:Label CssClass="h1" runat="server" Text="Reporte de Eficiencia"></asp:Label>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-group">
                                            <div class="form-row">
                                                <div class="col-lg-8">
                                                    <br />
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" ID="lblInicioEficiencia"></asp:Label>
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" ID="lblFinEficiencia"></asp:Label>
                                                </div>
                                                <%--                                                <div class="col-lg-4">
                                                </div>--%>
                                                <div class="col-lg-4">
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Código de Color:"></asp:Label><br />
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Alto: " ForeColor="Green"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtHighMin2" Width="40px" OnTextChanged="txtHighMin2_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    <asp:Label CssClass="h3" runat="server" Text="% ≤ x ≤ " ForeColor="Green"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtHighMax2" Width="40px"></asp:TextBox>
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Medio: " ForeColor="#f4f400"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtMedMin2" Width="40px" OnTextChanged="txtHighMin2_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    <asp:Label CssClass="h3" runat="server" Text="% ≤ x ≤ " ForeColor="#f4f400"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtMedMax2" Width="40px"></asp:TextBox>
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Bajo x < " ForeColor="Red"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtLowMax2" Width="40px" OnTextChanged="txtHighMin2_TextChanged" AutoPostBack="true"></asp:TextBox>
                                                    <asp:Label CssClass="h3" runat="server" Text="%" ForeColor="Red"></asp:Label>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="form-row">
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="table-responsive">
                                                        <asp:Label CssClass="h2" runat="server" Text="Reporte Global"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <asp:GridView runat="server" ID="grdEficienciaGlobal" CssClass="table table-bordered bs-table" AutoGenerateColumns="false" OnRowDataBound="grdEficienciaGlobal_RowDataBound">
                                                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#AAE4FF" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                            <AlternatingRowStyle BackColor="#E6E6E6" />
                                                            <EmptyDataTemplate>
                                                                No hay datos para mostrar.
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:BoundField DataField="Linea" HeaderText="Linea" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Maquina" HeaderText="Maquina" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Familia Producto" HeaderText="Familia Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Producto" HeaderText="Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Disponibilidad" HeaderText="Disponibilidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="Calidad" HeaderText="Calidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="Desempeño" HeaderText="Desempeño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="OEE" HeaderText="OEE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="form-row">
                                                <div class="col-lg-12">
                                                    <div class="table-responsive">
                                                        <asp:Label CssClass="h2" runat="server" Text="Reporte de los 10 más Altos"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <asp:GridView runat="server" ID="grdTop10" CssClass="table table-bordered bs-table" AutoGenerateColumns="false" OnRowDataBound="grdEficienciaGlobal_RowDataBound">
                                                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#AAE4FF" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                            <AlternatingRowStyle BackColor="#E6E6E6" />
                                                            <EmptyDataTemplate>
                                                                No hay datos para mostrar.
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:BoundField DataField="Linea" HeaderText="Linea" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Maquina" HeaderText="Maquina" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Familia Producto" HeaderText="Familia Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Producto" HeaderText="Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Disponibilidad" HeaderText="Disponibilidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="Calidad" HeaderText="Calidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="Desempeño" HeaderText="Desempeño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="OEE" HeaderText="OEE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="form-row">
                                                <div class="col-lg-12">
                                                    <div class="table-responsive">
                                                        <asp:Label CssClass="h2" runat="server" Text="Reporte de los 10 más Bajos"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <asp:GridView runat="server" ID="grdBottom10" CssClass="table table-bordered bs-table" AutoGenerateColumns="false" OnRowDataBound="grdEficienciaGlobal_RowDataBound">
                                                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#AAE4FF" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                            <AlternatingRowStyle BackColor="#E6E6E6" />
                                                            <EmptyDataTemplate>
                                                                No hay datos para mostrar.
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:BoundField DataField="Linea" HeaderText="Linea" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Maquina" HeaderText="Maquina" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Familia Producto" HeaderText="Familia Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Producto" HeaderText="Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Disponibilidad" HeaderText="Disponibilidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="Calidad" HeaderText="Calidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="Desempeño" HeaderText="Desempeño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                                <asp:BoundField DataField="OEE" HeaderText="OEE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:p}" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="form-row">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-footer">
                                    </div>
                            </asp:Panel>
                        </div>
                    </div>

                    <!-- REPORTE EFICIENCIA Y COSTOS -->
                    <div class="row">
                        <div class="col-lg-12">
                            <asp:Panel runat="server" ID="pnlEficienciaCostos" Visible="false">
                                <div class="card mb-3">
                                    <div class="card-header" style="text-align: center;">
                                        <asp:Label CssClass="h1" runat="server" Text="Reporte de Eficiencia Y Costos"></asp:Label>
                                    </div>
                                    <div class="card-body">
                                        <div class="form-group">
                                            <div class="form-row">
                                                <div class="col-lg-8">
                                                    <br />
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" ID="lblCostoInicio"></asp:Label>
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" ID="lblCostoFin"></asp:Label>
                                                </div>
                                                <%--                                                <div class="col-lg-4">
                                                </div>--%>
                                                <div class="col-lg-4">
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Código de Color:"></asp:Label><br />
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Alto: $" ForeColor="Green"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtHighMin3" Width="40px"></asp:TextBox>
                                                    <asp:Label CssClass="h3" runat="server" Text=" > x ≤ $" ForeColor="Green"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtHighMax3" Width="40px"></asp:TextBox>
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Medio: $" ForeColor="#f4f400"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtMedMin3" Width="40px"></asp:TextBox>
                                                    <asp:Label CssClass="h3" runat="server" Text=" > x ≤ $" ForeColor="#f4f400"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtMedMax3" Width="40px"></asp:TextBox>
                                                    <br />
                                                    <asp:Label CssClass="h3" runat="server" Text="Bajo x > $" ForeColor="Red"></asp:Label>
                                                    <asp:TextBox runat="server" ID="txtLowMax3" Width="40px"></asp:TextBox>
                                                    <br />
                                                </div>
                                            </div>
                                            <div class="form-row">
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="table-responsive">
                                                        <asp:Label CssClass="h2" runat="server" Text="Reporte Global"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <asp:GridView runat="server" ID="grdCosts" CssClass="table table-bordered bs-table" AutoGenerateColumns="false" OnRowDataBound="grdCosts_RowDataBound" Font-Size="Small">
                                                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#AAE4FF" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                            <AlternatingRowStyle BackColor="#E6E6E6" />
                                                            <EmptyDataTemplate>
                                                                No hay datos para mostrar.
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:BoundField DataField="Indice" HeaderText="Index" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Linea" HeaderText="Linea" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Maquina" HeaderText="Maquina" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Familia Producto" HeaderText="Fam. Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Producto" HeaderText="Prod." HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Disponibilidad" HeaderText="Disponibilidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>
                                                                <asp:BoundField DataField="Calidad" HeaderText="Calidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"/>
                                                                <asp:BoundField DataField="Desempeño" HeaderText="Desempeño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="OEE" HeaderText="OEE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="table-responsive">
                                                        <asp:Label CssClass="h2" runat="server" Text="Reporte Top 10 con mayores Pérdidas"></asp:Label>
                                                        <br />
                                                        <br />
                                                        <br />
                                                        <asp:GridView runat="server" ID="grdTop10Perdidas" CssClass="table table-bordered bs-table" AutoGenerateColumns="false" OnRowDataBound="grdTableOEE_RowDataBound">
                                                            <HeaderStyle BackColor="#337ab7" Font-Bold="True" ForeColor="White" />
                                                            <EditRowStyle BackColor="#AAE4FF" />
                                                            <EmptyDataRowStyle ForeColor="Red" CssClass="table table-bordered" />
                                                            <AlternatingRowStyle BackColor="#E6E6E6" />
                                                            <EmptyDataTemplate>
                                                                No hay datos para mostrar.
                                                            </EmptyDataTemplate>
                                                            <Columns>
                                                                <asp:BoundField DataField="Indice" HeaderText="Index" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Linea" HeaderText="Linea" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Maquina" HeaderText="Maquina" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Familia Producto" HeaderText="Familia Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Producto" HeaderText="Producto" HeaderStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Disponibilidad" HeaderText="Disponibilidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="Calidad" HeaderText="Calidad" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center"  />
                                                                <asp:BoundField DataField="Desempeño" HeaderText="Desempeño" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                                <asp:BoundField DataField="OEE" HeaderText="OEE" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="form-row">
                                                <div class="col-lg-12">
                                                    <asp:Chart ID="chartPerdidas" runat="server" Width="1000px" Height="350px">
                                                        <Titles>
                                                            <asp:Title Font="Calibri, 20pt, style=Bold" Name="Title1" Text="Perdidas Totales"></asp:Title>
                                                        </Titles>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="ChartArea1">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                        <Legends>
                                                            <asp:Legend Name="Legend1">
                                                            </asp:Legend>
                                                        </Legends>
                                                    </asp:Chart>
                                                    <asp:Chart ID="PerdProdChart" runat="server" Width="1000px" Height="350px">
                                                        <Titles>
                                                            <asp:Title Font="Calibri, 20pt, style=Bold" Name="Title1" Text="Ración de pérdida por parte producida"></asp:Title>
                                                        </Titles>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="ChartArea1">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                        <Legends>
                                                            <asp:Legend Name="Legend1">
                                                            </asp:Legend>
                                                        </Legends>
                                                    </asp:Chart>
                                                </div>

                                            </div>
                                        </div>
                                        <div class="form-group">
                                            <div class="form-row">
                                                <div class="col-lg-4">
                                                </div>
                                                <div class="col-lg-4">
                                                    <asp:Chart ID="Chart11" runat="server" Width="500px" Height="500px">
                                                        <Titles>
                                                            <asp:Title Font="Calibri, 20pt, style=Bold" Name="Title1" Text="Distribución Global de Pérdidas"></asp:Title>
                                                        </Titles>
                                                        <Series>
                                                            <asp:Series Name="Testing" YValueType="Int32" ChartType="Pie">

                                                                <Points>
                                                                    <asp:DataPoint AxisLabel="Calidad" YValues="30" Label="Calidad: #PERCENT{0.00 %}" />
                                                                    <asp:DataPoint AxisLabel="Desempeño" YValues="15" Label="Desempeño: #PERCENT{0.00 %}" />
                                                                    <asp:DataPoint AxisLabel="Disponibilidad" YValues="10" Label="Disponibilidad: #PERCENT{0.00 %}" />

                                                                </Points>
                                                            </asp:Series>
                                                        </Series>
                                                        <ChartAreas>
                                                            <asp:ChartArea Name="ChartArea1" Area3DStyle-Enable3D="true">
                                                            </asp:ChartArea>
                                                        </ChartAreas>
                                                        <%--                                                        <Legends>
                                                            <asp:Legend Name="Legend1">
                                                            </asp:Legend>
                                                        </Legends>--%>
                                                    </asp:Chart>
                                                </div>
                                                <div class="col-lg-4">
                                                </div>
                                            </div>
                                            <div class="form-row">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-footer">
                                    </div>
                            </asp:Panel>
                        </div>
                    </div>

                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
