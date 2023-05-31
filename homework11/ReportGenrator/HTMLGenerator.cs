using System;

namespace ReportGenrator
{
    internal class HTMLGenerator : AbstractGenerator
    {
        public override void GenerateHeader()
        {
            Console.WriteLine("<header> MY Header <header/>");
        }

        public override void GenerateBody()
        {
            Console.WriteLine("<body>");
            Console.WriteLine("Video provides a powerful way to help you prove your point. When you click\r\nOnline Video, you can paste in the embed code for the video you want to add.");
            Console.WriteLine("<body/>");
        }

        public override void GenerateFooter()
        {
            Console.WriteLine("<footer> My Footer <footer/>");
        }
    }
}
