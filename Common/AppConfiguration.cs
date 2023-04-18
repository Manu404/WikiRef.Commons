using WikiRef.Commons.Data;

namespace WikiRef.Commons
{
    public class AppConfiguration
    {
        public Action Action { get; set; }

        public AppConfiguration(DefaultOptions options)
        {
            Action = Action.Undefined;
            InitalizeOptions(options);
        }

        // default options
        public bool Silent { get; private set; }
        public bool Verbose { get; private set; }
        public bool NoColor { get; private set; }
        public int Throttle { get; private set; }
        public bool Ipv4Only { get; private set; }
        public bool PutInSubDirectory { get; private set; } 
        public bool ExportRefText { get; private set; } 

        public bool ConsoleOutputToDefaultFile { get; private set; }
        public bool ConsoleOutputToDefaultHtmlFile { get; private set; }
        public string ConsoleOutputToFile { get; private set; }
        public string ConsoleOutputToHtmlFile { get; private set; }

        public void InitalizeOptions(DefaultOptions options)
        {
            Verbose = options.Verbose;
            Silent = options.Silent;
            NoColor = options.NoColor;
            Throttle = options.Throttle;
            Ipv4Only = options.IpV4Only;
            PutInSubDirectory = options.PutInSubDirectory;
            ExportRefText = options.ExportRefText;

            ConsoleOutputToDefaultFile = options.ConsoleOutputToDefaultFile;
            ConsoleOutputToDefaultHtmlFile = options.ConsoleToDefaultHtmlFile;
            ConsoleOutputToFile = options.ConsoleOutputToFile;
            ConsoleOutputToHtmlFile = options.ConsoleToHtmlFile;

        }
    }
}
