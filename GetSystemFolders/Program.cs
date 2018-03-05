using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

using env = System.Environment;
using sf = System.Environment.SpecialFolder;

namespace GetSystemFolders
{
  class Program
  {
    static void Main(string[] args)
    {

      //assume we are going to use the app name
      string option = Process.GetCurrentProcess().ProcessName;

      //if there is an option passed in, use it instead
      if (args.Length > 0) { option = args[0]; }

      //show use if necessary
      List<string> helpOptions = new List<string>() { "/?","?","-h","--help","help" };
      if (helpOptions.Contains(option)) { ShowUse(); }
      
      sf result;

      if(Enum.TryParse<sf>(option, out result))
      {
        Console.WriteLine(env.GetFolderPath(result));
      }
        
    }

    static void ShowUse()
    {
      string allowed = String.Join(", ", Enum.GetNames(typeof(sf)));

      Console.WriteLine(Properties.Resources.ShowUseText, allowed);

      env.Exit(0);

    }
  }
}
