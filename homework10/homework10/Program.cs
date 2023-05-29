namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var subClass = new SubClass() { fileSize = 128};
            subClass.Read();
            subClass.Write();
            subClass.Edit();
            subClass.Delete();
        }
    }
}
