using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework;
using System.Reflection;
using System.IO;

namespace Application
{
    class Application
    {
        static void Main(string[] args)
        {
            String dir = "C:\\Users\\all\\Documents\\Visual Studio 2015\\Projects\\Week6\\Plugins\\";
            List<IPlugin> plugins = new List<IPlugin>();
            DirectoryInfo dirInfo = new DirectoryInfo(dir);
            foreach (FileInfo file in dirInfo.GetFiles("*.dll"))
            {
                Assembly assembly = Assembly.LoadFrom(file.FullName);
                foreach (var type in assembly.GetTypes())
                    if (type.GetInterface("IPlugin") != null)
                        plugins.Add(Activator.CreateInstance(type) as IPlugin);
            }
            foreach (IPlugin plugin in plugins)
                Console.WriteLine(plugin.Name);
            Console.ReadKey();
        }
    }
}
