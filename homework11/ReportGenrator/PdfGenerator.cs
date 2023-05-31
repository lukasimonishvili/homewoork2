using System;

namespace ReportGenrator
{
    internal class PdfGenerator : AbstractGenerator
    {
        public override void GenerateHeader()
        {
            Console.WriteLine("Header : I’m using Facade Pattern");
        }

        public override void GenerateBody()
        {
            Console.WriteLine("Body :");
            Console.WriteLine("Video provides a powerful way to help you prove your point. When you click\r\nOnline Video, you can paste in the embed code for the video you want to add.\r\nYou can also type a keyword to search online for the video that best fits your\r\ndocument. To make your document look professionally produced, Word provides");
        }

        public override void GenerateFooter()
        {
            Console.WriteLine("Footer: Page 1");
        }
    }
}
