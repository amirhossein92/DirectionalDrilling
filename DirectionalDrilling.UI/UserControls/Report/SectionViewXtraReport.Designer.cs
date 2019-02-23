namespace DirectionalDrilling.UI.UserControls.Report
{
    partial class SectionViewXtraReport
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.ScatterLineSeriesView scatterLineSeriesView1 = new DevExpress.XtraCharts.ScatterLineSeriesView();
            this.objectDataSource1 = new DevExpress.DataAccess.ObjectBinding.ObjectDataSource(this.components);
            this.ddLabel1 = new DirectionalDrilling.UI.Base.Report.DDLabel();
            this.ddLabel2 = new DirectionalDrilling.UI.Base.Report.DDLabel();
            this.ddLabel5 = new DirectionalDrilling.UI.Base.Report.DDLabel();
            this.ddLabel6 = new DirectionalDrilling.UI.Base.Report.DDLabel();
            this.ddLabelValue1 = new DirectionalDrilling.UI.Base.Report.DDLabelValue();
            this.ddLabelValue3 = new DirectionalDrilling.UI.Base.Report.DDLabelValue();
            this.ddLabelValue4 = new DirectionalDrilling.UI.Base.Report.DDLabelValue();
            this.ddLabelValue2 = new DirectionalDrilling.UI.Base.Report.DDLabelValue();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.ddLabel3 = new DirectionalDrilling.UI.Base.Report.DDLabel();
            this.paramPaymentDate = new DevExpress.XtraReports.Parameters.Parameter();
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(scatterLineSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.ddLabel3,
            this.xrChart1,
            this.ddLabelValue1,
            this.ddLabel1,
            this.ddLabel2,
            this.ddLabel5,
            this.ddLabel6,
            this.ddLabelValue2,
            this.ddLabelValue3,
            this.ddLabelValue4});
            this.Detail.HeightF = 646.875F;
            // 
            // objectDataSource1
            // 
            this.objectDataSource1.DataSource = typeof(DirectionalDrilling.DataAccess.Report.Models.SectionView.SectionViewReportModel);
            this.objectDataSource1.Name = "objectDataSource1";
            // 
            // ddLabel1
            // 
            this.ddLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ddLabel1.LocationFloat = new DevExpress.Utils.PointFloat(47.91667F, 30.24998F);
            this.ddLabel1.Multiline = true;
            this.ddLabel1.Name = "ddLabel1";
            this.ddLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddLabel1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.ddLabel1.StylePriority.UseForeColor = false;
            this.ddLabel1.StylePriority.UseTextAlignment = false;
            this.ddLabel1.Text = "Platform:";
            this.ddLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ddLabel2
            // 
            this.ddLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ddLabel2.LocationFloat = new DevExpress.Utils.PointFloat(47.91668F, 53.24996F);
            this.ddLabel2.Multiline = true;
            this.ddLabel2.Name = "ddLabel2";
            this.ddLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddLabel2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.ddLabel2.StylePriority.UseForeColor = false;
            this.ddLabel2.StylePriority.UseTextAlignment = false;
            this.ddLabel2.Text = "Well:";
            this.ddLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ddLabel5
            // 
            this.ddLabel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ddLabel5.LocationFloat = new DevExpress.Utils.PointFloat(281.25F, 53.24996F);
            this.ddLabel5.Multiline = true;
            this.ddLabel5.Name = "ddLabel5";
            this.ddLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddLabel5.SizeF = new System.Drawing.SizeF(166.6667F, 23F);
            this.ddLabel5.StylePriority.UseForeColor = false;
            this.ddLabel5.StylePriority.UseTextAlignment = false;
            this.ddLabel5.Text = "Vertical Section Direction:";
            this.ddLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ddLabel6
            // 
            this.ddLabel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ddLabel6.LocationFloat = new DevExpress.Utils.PointFloat(281.25F, 30.24998F);
            this.ddLabel6.Multiline = true;
            this.ddLabel6.Name = "ddLabel6";
            this.ddLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddLabel6.SizeF = new System.Drawing.SizeF(166.6667F, 23F);
            this.ddLabel6.StylePriority.UseForeColor = false;
            this.ddLabel6.StylePriority.UseTextAlignment = false;
            this.ddLabel6.Text = "Wellbore:";
            this.ddLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // ddLabelValue1
            // 
            this.ddLabelValue1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PlatformName]")});
            this.ddLabelValue1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.ddLabelValue1.LocationFloat = new DevExpress.Utils.PointFloat(158.3333F, 30.24998F);
            this.ddLabelValue1.Multiline = true;
            this.ddLabelValue1.Name = "ddLabelValue1";
            this.ddLabelValue1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddLabelValue1.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.ddLabelValue1.StylePriority.UseBackColor = false;
            this.ddLabelValue1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ddLabelValue3
            // 
            this.ddLabelValue3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[WellboreName]")});
            this.ddLabelValue3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.ddLabelValue3.LocationFloat = new DevExpress.Utils.PointFloat(462.5F, 30.24998F);
            this.ddLabelValue3.Multiline = true;
            this.ddLabelValue3.Name = "ddLabelValue3";
            this.ddLabelValue3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddLabelValue3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.ddLabelValue3.StylePriority.UseBackColor = false;
            this.ddLabelValue3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ddLabelValue4
            // 
            this.ddLabelValue4.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[VerticalSectionDirection]")});
            this.ddLabelValue4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.ddLabelValue4.LocationFloat = new DevExpress.Utils.PointFloat(462.5F, 53.24996F);
            this.ddLabelValue4.Multiline = true;
            this.ddLabelValue4.Name = "ddLabelValue4";
            this.ddLabelValue4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddLabelValue4.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.ddLabelValue4.StylePriority.UseBackColor = false;
            this.ddLabelValue4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // ddLabelValue2
            // 
            this.ddLabelValue2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[WellName]")});
            this.ddLabelValue2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.ddLabelValue2.LocationFloat = new DevExpress.Utils.PointFloat(158.3333F, 53.24996F);
            this.ddLabelValue2.Multiline = true;
            this.ddLabelValue2.Name = "ddLabelValue2";
            this.ddLabelValue2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.ddLabelValue2.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.ddLabelValue2.StylePriority.UseBackColor = false;
            this.ddLabelValue2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrChart1
            // 
            this.xrChart1.BorderColor = System.Drawing.Color.Black;
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            xyDiagram1.AxisX.Title.Text = "Vertical Section";
            xyDiagram1.AxisX.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.Reverse = true;
            xyDiagram1.AxisY.Title.Text = "True Vertical Depth";
            xyDiagram1.AxisY.Title.Visibility = DevExpress.Utils.DefaultBoolean.True;
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart1.Diagram = xyDiagram1;
            this.xrChart1.Legend.Name = "Default Legend";
            this.xrChart1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 87.5F);
            this.xrChart1.Name = "xrChart1";
            series1.ArgumentDataMember = "SectionViewReportModelCharts.VeritcalSection";
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.Name = "Series 1";
            series1.ValueDataMembersSerializable = "SectionViewReportModelCharts.TrueVerticalDepth";
            series1.View = scatterLineSeriesView1;
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.xrChart1.SizeF = new System.Drawing.SizeF(650F, 559.375F);
            // 
            // ddLabel3
            // 
            this.ddLabel3.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "\'Report Date: \' + [Parameters].[paramPaymentDate]")});
            this.ddLabel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ddLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.ddLabel3.Name = "ddLabel3";
            this.ddLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
            this.ddLabel3.SizeF = new System.Drawing.SizeF(650F, 23F);
            this.ddLabel3.StylePriority.UseTextAlignment = false;
            this.ddLabel3.Text = "Report for [?paramPaymentDate]";
            this.ddLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.ddLabel3.TextFormatString = "{0:MMMM yyyy}";
            // 
            // paramPaymentDate
            // 
            this.paramPaymentDate.Description = "Parameter 1 Payment Date";
            this.paramPaymentDate.Name = "paramPaymentDate";
            this.paramPaymentDate.Type = typeof(System.DateTime);
            this.paramPaymentDate.Visible = false;
            // 
            // SectionViewXtraReport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.objectDataSource1});
            this.DataSource = this.objectDataSource1;
            this.Parameters.AddRange(new DevExpress.XtraReports.Parameters.Parameter[] {
            this.paramPaymentDate});
            this.Version = "18.1";
            ((System.ComponentModel.ISupportInitialize)(this.objectDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(scatterLineSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }


        #endregion

        private DevExpress.DataAccess.ObjectBinding.ObjectDataSource objectDataSource1;
        private Base.Report.DDLabel ddLabel1;
        private Base.Report.DDLabel ddLabel2;
        private Base.Report.DDLabel ddLabel5;
        private Base.Report.DDLabel ddLabel6;
        private Base.Report.DDLabelValue ddLabelValue1;
        private Base.Report.DDLabelValue ddLabelValue2;
        private Base.Report.DDLabelValue ddLabelValue3;
        private Base.Report.DDLabelValue ddLabelValue4;
        private DevExpress.XtraReports.UI.XRChart xrChart1;
        private Base.Report.DDLabel ddLabel3;
        private DevExpress.XtraReports.Parameters.Parameter paramPaymentDate;
    }
}
