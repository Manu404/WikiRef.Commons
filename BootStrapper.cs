﻿using System;

namespace WikiRef.Commons
{
    public class BootStrapper
    {
        //dependencies
        public AppConfiguration ConfigHelper { get; private set; }   
        public ConsoleHelper ConsoleHelper { get; private set; }
        public FileHelper FileHelper { get; private set; }
        public RegexHelper RegexHelper { get; private set; }
        public HtmlReportHelper HtmlReportBuilder { get; private set; }
        public NetworkHelper NetworkHelper { get; private set; }

        // Initialize dependencies and config
        public void InitializeDependencies(DefaultOptions options)
        {
            ConfigHelper = new AppConfiguration(options);
            HtmlReportBuilder = new HtmlReportHelper();
            ConsoleHelper = new ConsoleHelper(ConfigHelper, HtmlReportBuilder);
            NetworkHelper = new NetworkHelper(ConsoleHelper, ConfigHelper.Ipv4Only);
            FileHelper = new FileHelper(ConsoleHelper);
            RegexHelper = new RegexHelper();
        }

        public void SaveConsoleToLog()
        {
            if (ConfigHelper != null && (ConfigHelper.ConsoleOutputToDefaultFile || !String.IsNullOrEmpty(ConfigHelper.ConsoleOutputToFile)))
            {
                string filename = ConfigHelper.ConsoleOutputToDefaultFile ? String.Empty : ConfigHelper.ConsoleOutputToFile;
                string dirname = ConfigHelper.PutInSubDirectory ? ".log" : String.Empty;
                FileHelper.SaveConsoleOutputToFile(filename, dirname);
            }
        }

        public void SaveConsoleToHtml()
        {
            if (ConfigHelper != null && (ConfigHelper.ConsoleOutputToDefaultHtmlFile || !String.IsNullOrEmpty(ConfigHelper.ConsoleOutputToHtmlFile)))
            {
                string filename = ConfigHelper.ConsoleOutputToDefaultHtmlFile ? String.Empty : ConfigHelper.ConsoleOutputToHtmlFile;
                string dirname = ConfigHelper.PutInSubDirectory ? ".html" : String.Empty;
                FileHelper.SaveConsoleOutputToHtmlFile(HtmlReportBuilder.BuildReportContent(), filename, dirname);
            }
        }
    }
}
