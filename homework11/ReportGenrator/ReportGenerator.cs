namespace ReportGenrator
{
    internal class ReportGenerator
    {
        private AbstractGenerator generator { get; set; }

        public ReportGenerator(AbstractGenerator generator)
        {
            this.generator = generator;
        }

        public void Generate()
        {
            generator.GenerateHeader();
            generator.GenerateBody();
            generator.GenerateFooter();
        }
    }
}
