using CommandLine;

namespace WikiRef
{
    [Verb("default", HelpText = "Provide analysis features regarding references. '--help analyse' for more informations.")]
    public class DefaultOptions
    {
        [Option('v', "verbose", Required = false, HelpText = "Verbose console output.")]
        public bool Verbose { get; set; }

        [Option('s', "silent", Required = false, HelpText = "No console output.")]
        public bool Silent { get; set; }

        [Option('b', "color-blind", Required = false, HelpText = "Disable console coloring (compability).")]
        public bool NoColor { get; set; }

        [Option('t', "throttle", Required = false, HelpText = "Give a value in second for throttling to avoid '429 : Too Many Request' errors. Mainly for YouTube. That will slow down the speed of the too but avoid temporary banning.")]
        public int Throttle { get; set; }

        // Log and output 
        [Option('l', Default = false, Required = false, HelpText = "Write the console output in a file using the date and time as name")]
        public bool ConsoleOutputToDefaultFile { get; set; }

        [Option("log", Required = false, HelpText = "Write the console output to the given file")]
        public string ConsoleOutputToFile { get; set; }

        [Option('h', Default = false, Required = false, HelpText = "Write the console output in a file in html format using the date and time as name")]
        public bool ConsoleToDefaultHtmlFile { get; set; }

        [Option("html", Required = false, HelpText = "Write the console output in a file in html format to the given file")]
        public string ConsoleToHtmlFile { get; set; }

        [Option('4', "ipv4", Required = false, HelpText = "Default request to ipv4 (compatbilibyt)")]
        public bool IpV4Only { get; set; }

        [Option("subdir", Required = false, HelpText = "Put output files in subdirectory")]
        public bool PutInSubDirectory { get; set; }

        [Option("export-ref-text", Required = false, HelpText = "Export reference in text file - mostly for debug")]
        public bool ExportRefText { get; set; }
    }
}
