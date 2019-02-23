using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Printing;
using DevExpress.XtraPrinting;
using DirectionalDrilling.DataAccess.Report;
using DirectionalDrilling.DataAccess.Survey;
using DirectionalDrilling.UI.UserControls.Graph.ViewModel;
using DirectionalDrilling.UI.UserControls.Report;

namespace DirectionalDrilling.UI.UserControls.Graph.View
{
    /// <summary>
    /// Interaction logic for SectionView.xaml
    /// </summary>
    public partial class SectionView : UserControl
    {

        public SectionView()
        {
            InitializeComponent();
        }

        private void ExportedPdf_OnClick(object sender, RoutedEventArgs e)
        {
            string PdfFilePath = "Output.pdf";
            PrintSizeMode sizeMode = PrintSizeMode.Stretch;
            PdfExportOptions exportOptions = new PdfExportOptions();
            exportOptions.ImageQuality = PdfJpegImageQuality.Highest;
            ChartControl.ExportToPdf(PdfFilePath, exportOptions, sizeMode);
            Process.Start(PdfFilePath);
        }

        private void Print_OnClick(object sender, RoutedEventArgs e)
        {
            //PrintSizeMode sizeMode = PrintSizeMode.Stretch;
            //ChartControl.Print(sizeMode);

            //var sectionViewXtraReport = new SectionViewXtraReport();

            //ISectionViewReportService myReportService = new SectionViewReportService();

            //sectionViewXtraReport.DataSource = myReportService.GetSectionViewReportModels(1);
            //PrintHelper.ShowRibbonPrintPreview(this, sectionViewXtraReport);

        }

        private void PrintPreview_OnClick(object sender, RoutedEventArgs e)
        {
            ChartControl.ShowPrintPreview(this, "SectionView", "Title - Section View", PrintSizeMode.Stretch);
        }
    }
}
