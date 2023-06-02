using System.IO;
using System.Reflection;

namespace Strategy
{
    internal abstract class AbstractFiler
    {
        public string filesDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Split("bin")[0];
        public abstract void workWithFile();
    }
}
