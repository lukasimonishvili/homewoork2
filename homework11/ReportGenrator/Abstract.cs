namespace ReportGenrator
{
    internal abstract class AbstractGenerator
    {
        public abstract void GenerateHeader();
        public abstract void GenerateBody();
        public abstract void GenerateFooter();
    }
}
