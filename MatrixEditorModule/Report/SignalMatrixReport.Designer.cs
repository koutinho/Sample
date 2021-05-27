namespace SignalMatrixEditor.Report
{
    partial class SignalMatrixReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.OutputRelayPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.DigitalInputPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.DiscreteInputPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.ParameterTypeLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.DesignationLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.NameLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.ReportHeaderLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportHeaderLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.OutputRelayHeaderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.OutputRelayHeaderLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.DigitalInputHeaderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.DigitalInputHeaderLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.DiscrteInputHeaderPanel = new DevExpress.XtraReports.UI.XRPanel();
            this.DiscreteInputHeaderLabel = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.OddRowStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.CrossCellStyle = new DevExpress.XtraReports.UI.XRControlStyle();
            this.ObjectPath = new DevExpress.XtraReports.Parameters.Parameter();
            this.SerialNumber = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 50F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Font = new System.Drawing.Font("Arial", 10F);
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.StylePriority.UseFont = false;
            // 
            // Detail
            // 
            this.Detail.BackColor = System.Drawing.Color.Empty;
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.OutputRelayPanel,
            this.DigitalInputPanel,
            this.DiscreteInputPanel,
            this.ParameterTypeLabel,
            this.DesignationLabel,
            this.NameLabel});
            this.Detail.HeightF = 23.00002F;
            this.Detail.HierarchyPrintOptions.ChildListFieldName = "Nodes";
            this.Detail.Name = "Detail";
            this.Detail.OddStyleName = "OddRowStyle";
            // 
            // OutputRelayPanel
            // 
            this.OutputRelayPanel.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.OutputRelayPanel.LocationFloat = new DevExpress.Utils.PointFloat(753.8464F, 3.178914E-05F);
            this.OutputRelayPanel.Name = "OutputRelayPanel";
            this.OutputRelayPanel.SizeF = new System.Drawing.SizeF(179.07F, 22.99999F);
            // 
            // DigitalInputPanel
            // 
            this.DigitalInputPanel.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.DigitalInputPanel.LocationFloat = new DevExpress.Utils.PointFloat(574.7764F, 3.178914E-05F);
            this.DigitalInputPanel.Name = "DigitalInputPanel";
            this.DigitalInputPanel.SizeF = new System.Drawing.SizeF(179.07F, 22.99999F);
            // 
            // DiscreteInputPanel
            // 
            this.DiscreteInputPanel.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.DiscreteInputPanel.LocationFloat = new DevExpress.Utils.PointFloat(395.7063F, 0F);
            this.DiscreteInputPanel.Name = "DiscreteInputPanel";
            this.DiscreteInputPanel.SizeF = new System.Drawing.SizeF(179.07F, 22.99999F);
            // 
            // ParameterTypeLabel
            // 
            this.ParameterTypeLabel.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.ParameterTypeLabel.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "Iif([ParameterType]==0, \'Вход\', Iif([ParameterType]==1, \'Выход\', Iif([ParameterTy" +
                    "pe]==2, \'Вход/Выход\', \'\')))")});
            this.ParameterTypeLabel.Font = new System.Drawing.Font("Arial", 10F);
            this.ParameterTypeLabel.LocationFloat = new DevExpress.Utils.PointFloat(301.0243F, 0F);
            this.ParameterTypeLabel.Multiline = true;
            this.ParameterTypeLabel.Name = "ParameterTypeLabel";
            this.ParameterTypeLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ParameterTypeLabel.SizeF = new System.Drawing.SizeF(94.68222F, 23F);
            this.ParameterTypeLabel.StylePriority.UseFont = false;
            this.ParameterTypeLabel.Text = "ParameterTypeLabel";
            // 
            // DesignationLabel
            // 
            this.DesignationLabel.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.DesignationLabel.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Designation]")});
            this.DesignationLabel.Font = new System.Drawing.Font("Arial", 10F);
            this.DesignationLabel.LocationFloat = new DevExpress.Utils.PointFloat(155.5121F, 0F);
            this.DesignationLabel.Multiline = true;
            this.DesignationLabel.Name = "DesignationLabel";
            this.DesignationLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DesignationLabel.SizeF = new System.Drawing.SizeF(145.5122F, 23F);
            this.DesignationLabel.StylePriority.UseFont = false;
            this.DesignationLabel.Text = "DesignationLabel";
            // 
            // NameLabel
            // 
            this.NameLabel.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.NameLabel.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Name]")});
            this.NameLabel.Font = new System.Drawing.Font("Arial", 10F);
            this.NameLabel.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 0F);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NameLabel.SizeF = new System.Drawing.SizeF(145.5121F, 23F);
            this.NameLabel.StylePriority.UseFont = false;
            this.NameLabel.Text = "NameLabel";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ReportHeaderLabel4,
            this.xrLabel5,
            this.ReportHeaderLabel3,
            this.xrLabel6,
            this.xrLabel7,
            this.xrLabel8,
            this.xrPageInfo1});
            this.ReportHeader.HeightF = 122.0416F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // ReportHeaderLabel4
            // 
            this.ReportHeaderLabel4.BackColor = System.Drawing.Color.Gainsboro;
            this.ReportHeaderLabel4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?SerialNumber")});
            this.ReportHeaderLabel4.Font = new System.Drawing.Font("Arial", 12F);
            this.ReportHeaderLabel4.LocationFloat = new DevExpress.Utils.PointFloat(185.7607F, 72.99998F);
            this.ReportHeaderLabel4.Multiline = true;
            this.ReportHeaderLabel4.Name = "ReportHeaderLabel4";
            this.ReportHeaderLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ReportHeaderLabel4.SizeF = new System.Drawing.SizeF(818.8746F, 23F);
            this.ReportHeaderLabel4.StylePriority.UseBackColor = false;
            this.ReportHeaderLabel4.StylePriority.UseFont = false;
            this.ReportHeaderLabel4.StylePriority.UseTextAlignment = false;
            this.ReportHeaderLabel4.Text = "ReportHeaderLabel4";
            this.ReportHeaderLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Arial", 12F);
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 23.00001F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(175F, 27F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Дата и время отчета:";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // ReportHeaderLabel3
            // 
            this.ReportHeaderLabel3.BackColor = System.Drawing.Color.Gainsboro;
            this.ReportHeaderLabel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "?ObjectPath")});
            this.ReportHeaderLabel3.Font = new System.Drawing.Font("Arial", 12F);
            this.ReportHeaderLabel3.LocationFloat = new DevExpress.Utils.PointFloat(185.7607F, 50F);
            this.ReportHeaderLabel3.Multiline = true;
            this.ReportHeaderLabel3.Name = "ReportHeaderLabel3";
            this.ReportHeaderLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ReportHeaderLabel3.SizeF = new System.Drawing.SizeF(818.8749F, 23F);
            this.ReportHeaderLabel3.StylePriority.UseBackColor = false;
            this.ReportHeaderLabel3.StylePriority.UseFont = false;
            this.ReportHeaderLabel3.StylePriority.UseTextAlignment = false;
            this.ReportHeaderLabel3.Text = "ReportHeaderLabel3";
            this.ReportHeaderLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Arial", 12F);
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 50F);
            this.xrLabel6.Multiline = true;
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(175F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Объект:";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Arial", 12F);
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 72.99998F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(175F, 23F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Серийный номер:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // xrLabel8
            // 
            this.xrLabel8.BackColor = System.Drawing.Color.Transparent;
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.Font = new System.Drawing.Font("Arial", 12F);
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(185.7607F, 0F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(818.8746F, 23F);
            this.xrLabel8.StylePriority.UseBackColor = false;
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Матрица сигналов";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.BackColor = System.Drawing.Color.LightGray;
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial", 12F);
            this.xrPageInfo1.LocationFloat = new DevExpress.Utils.PointFloat(185.7607F, 23F);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.PageInfo = DevExpress.XtraPrinting.PageInfo.DateTime;
            this.xrPageInfo1.SizeF = new System.Drawing.SizeF(818.8746F, 27F);
            this.xrPageInfo1.StylePriority.UseBackColor = false;
            this.xrPageInfo1.StylePriority.UseFont = false;
            this.xrPageInfo1.TextFormatString = "{0:dd.MM.yyyy HH:mm}";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.OutputRelayHeaderPanel,
            this.OutputRelayHeaderLabel,
            this.DigitalInputHeaderPanel,
            this.DigitalInputHeaderLabel,
            this.DiscrteInputHeaderPanel,
            this.DiscreteInputHeaderLabel,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2,
            this.xrLabel1});
            this.PageHeader.HeightF = 57.10004F;
            this.PageHeader.Name = "PageHeader";
            // 
            // OutputRelayHeaderPanel
            // 
            this.OutputRelayHeaderPanel.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.OutputRelayHeaderPanel.LocationFloat = new DevExpress.Utils.PointFloat(753.8464F, 28.55002F);
            this.OutputRelayHeaderPanel.Name = "OutputRelayHeaderPanel";
            this.OutputRelayHeaderPanel.SizeF = new System.Drawing.SizeF(179.07F, 28.54999F);
            // 
            // OutputRelayHeaderLabel
            // 
            this.OutputRelayHeaderLabel.BackColor = System.Drawing.Color.LightGray;
            this.OutputRelayHeaderLabel.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.OutputRelayHeaderLabel.Font = new System.Drawing.Font("Arial", 10F);
            this.OutputRelayHeaderLabel.LocationFloat = new DevExpress.Utils.PointFloat(753.8464F, 0F);
            this.OutputRelayHeaderLabel.Multiline = true;
            this.OutputRelayHeaderLabel.Name = "OutputRelayHeaderLabel";
            this.OutputRelayHeaderLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.OutputRelayHeaderLabel.SizeF = new System.Drawing.SizeF(179.07F, 28.55002F);
            this.OutputRelayHeaderLabel.StylePriority.UseBackColor = false;
            this.OutputRelayHeaderLabel.StylePriority.UseBorders = false;
            this.OutputRelayHeaderLabel.StylePriority.UseFont = false;
            this.OutputRelayHeaderLabel.Text = "Выходные реле";
            // 
            // DigitalInputHeaderPanel
            // 
            this.DigitalInputHeaderPanel.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.DigitalInputHeaderPanel.LocationFloat = new DevExpress.Utils.PointFloat(574.7764F, 28.55002F);
            this.DigitalInputHeaderPanel.Name = "DigitalInputHeaderPanel";
            this.DigitalInputHeaderPanel.SizeF = new System.Drawing.SizeF(179.07F, 28.54999F);
            // 
            // DigitalInputHeaderLabel
            // 
            this.DigitalInputHeaderLabel.BackColor = System.Drawing.Color.LightGray;
            this.DigitalInputHeaderLabel.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.DigitalInputHeaderLabel.Font = new System.Drawing.Font("Arial", 10F);
            this.DigitalInputHeaderLabel.LocationFloat = new DevExpress.Utils.PointFloat(574.7765F, 0F);
            this.DigitalInputHeaderLabel.Multiline = true;
            this.DigitalInputHeaderLabel.Name = "DigitalInputHeaderLabel";
            this.DigitalInputHeaderLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DigitalInputHeaderLabel.SizeF = new System.Drawing.SizeF(179.07F, 28.55002F);
            this.DigitalInputHeaderLabel.StylePriority.UseBackColor = false;
            this.DigitalInputHeaderLabel.StylePriority.UseBorders = false;
            this.DigitalInputHeaderLabel.StylePriority.UseFont = false;
            this.DigitalInputHeaderLabel.Text = "Цифровые входы";
            // 
            // DiscrteInputHeaderPanel
            // 
            this.DiscrteInputHeaderPanel.AnchorHorizontal = DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right;
            this.DiscrteInputHeaderPanel.LocationFloat = new DevExpress.Utils.PointFloat(395.7064F, 28.55005F);
            this.DiscrteInputHeaderPanel.Name = "DiscrteInputHeaderPanel";
            this.DiscrteInputHeaderPanel.SizeF = new System.Drawing.SizeF(179.07F, 28.54999F);
            // 
            // DiscreteInputHeaderLabel
            // 
            this.DiscreteInputHeaderLabel.BackColor = System.Drawing.Color.LightGray;
            this.DiscreteInputHeaderLabel.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.DiscreteInputHeaderLabel.Font = new System.Drawing.Font("Arial", 10F);
            this.DiscreteInputHeaderLabel.LocationFloat = new DevExpress.Utils.PointFloat(395.7065F, 0F);
            this.DiscreteInputHeaderLabel.Multiline = true;
            this.DiscreteInputHeaderLabel.Name = "DiscreteInputHeaderLabel";
            this.DiscreteInputHeaderLabel.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DiscreteInputHeaderLabel.SizeF = new System.Drawing.SizeF(179.07F, 28.55002F);
            this.DiscreteInputHeaderLabel.StylePriority.UseBackColor = false;
            this.DiscreteInputHeaderLabel.StylePriority.UseBorders = false;
            this.DiscreteInputHeaderLabel.StylePriority.UseFont = false;
            this.DiscreteInputHeaderLabel.Text = "Дискретные входы";
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(301.0244F, 28.55002F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(94.68198F, 28.54999F);
            this.xrLabel4.StylePriority.UseBackColor = false;
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Тип";
            // 
            // xrLabel3
            // 
            this.xrLabel3.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(155.5121F, 28.55002F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(145.5123F, 28.54999F);
            this.xrLabel3.StylePriority.UseBackColor = false;
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.Text = "Обозначение";
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(9.999998F, 28.54999F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(145.5121F, 28.55002F);
            this.xrLabel2.StylePriority.UseBackColor = false;
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "Наименование";
            // 
            // xrLabel1
            // 
            this.xrLabel1.BackColor = System.Drawing.Color.LightGray;
            this.xrLabel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel1.Font = new System.Drawing.Font("Arial", 10F);
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(9.999927F, 0F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(385.7066F, 28.54999F);
            this.xrLabel1.StylePriority.UseBackColor = false;
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Параметр";
            // 
            // OddRowStyle
            // 
            this.OddRowStyle.BackColor = System.Drawing.Color.LightGray;
            this.OddRowStyle.Name = "OddRowStyle";
            // 
            // CrossCellStyle
            // 
            this.CrossCellStyle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.CrossCellStyle.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.CrossCellStyle.Name = "CrossCellStyle";
            this.CrossCellStyle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ObjectPath
            // 
            this.ObjectPath.AllowNull = true;
            this.ObjectPath.Description = "Path for object";
            this.ObjectPath.Name = "ObjectPath";
            // 
            // SerialNumber
            // 
            this.SerialNumber.AllowNull = true;
            this.SerialNumber.Description = "Object\'s serial number";
            this.SerialNumber.Name = "SerialNumber";
            // 
            // SignalMatrixReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader,
            this.PageHeader});
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(27, 35, 50, 100);
            this.PageHeight = 827;
            this.PageWidth = 1169;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4Rotated;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.ObjectPath,
            this.SerialNumber});
            this.StyleSheet.AddRange(new DevExpress.XtraReports.UI.XRControlStyle[] {
            this.OddRowStyle,
            this.CrossCellStyle});
            this.Version = "20.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.SignalMatrixReport_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel NameLabel;
        private DevExpress.XtraReports.UI.XRLabel DesignationLabel;
        private DevExpress.XtraReports.UI.XRLabel ParameterTypeLabel;
        private DevExpress.XtraReports.UI.XRPanel DiscreteInputPanel;
        private DevExpress.XtraReports.UI.XRPanel DigitalInputPanel;
        private DevExpress.XtraReports.UI.XRPanel OutputRelayPanel;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRPanel DiscrteInputHeaderPanel;
        private DevExpress.XtraReports.UI.XRLabel DiscreteInputHeaderLabel;
        private DevExpress.XtraReports.UI.XRLabel DigitalInputHeaderLabel;
        private DevExpress.XtraReports.UI.XRPanel DigitalInputHeaderPanel;
        private DevExpress.XtraReports.UI.XRPanel OutputRelayHeaderPanel;
        private DevExpress.XtraReports.UI.XRLabel OutputRelayHeaderLabel;
        private DevExpress.XtraReports.UI.XRControlStyle OddRowStyle;
        private DevExpress.XtraReports.UI.XRControlStyle CrossCellStyle;
        private DevExpress.XtraReports.UI.XRLabel ReportHeaderLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel ReportHeaderLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel7;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;
        private DevExpress.XtraReports.Parameters.Parameter ObjectPath;
        private DevExpress.XtraReports.Parameters.Parameter SerialNumber;
    }
}
