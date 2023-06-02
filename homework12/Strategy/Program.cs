namespace Strategy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* var zipFiler = new ZipFiler();
             zipFiler.workWithFile();*/

            /*var txtFiler = new TxtFiler();
            txtFiler.workWithFile();*/

            var jsonFiler = new JsonFiler();
            jsonFiler.workWithFile();
        }
    }
}
