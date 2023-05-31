namespace ReportGenrator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var htmlGenerator = new HTMLGenerator();
            var pdfGenerator = new PdfGenerator();

            var reportGenerator1 = new ReportGenerator(htmlGenerator);
            reportGenerator1.Generate();

            var reportGenerator2 = new ReportGenerator(pdfGenerator);
            reportGenerator2.Generate();
        }
    }
}
