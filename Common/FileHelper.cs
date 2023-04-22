using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace WikiRef.Commons
{
    public class FileHelper
    {
        private ConsoleHelper _consoleHelper;

        public FileHelper(ConsoleHelper consoleHelper)
        {
            _consoleHelper = consoleHelper;
        }

        public void SaveConsoleOutputToFile(string filename, string subfolder)
        {
            filename = GenerateOutputFilePath(filename, subfolder, ".log");

            try
            {
                CreateDirecotoryIfNotExist(subfolder);
                File.WriteAllText(filename, _consoleHelper.Builder.ToString());
            }
            catch (Exception e)
            {
                _consoleHelper.WriteLineInRed(String.Format("An error occured while saving console output to file {0}", filename));
                _consoleHelper.WriteLineInRed(e.Message);
            }
        }

        public void SaveTextTofile(string text, string filename, string subfolder, string extension = "")
        {
            filename = GenerateOutputFilePath(filename, subfolder, extension);

            try
            {
                CreateDirecotoryIfNotExist(subfolder);

                File.WriteAllText(filename, text);
            }
            catch (Exception e)
            {
                _consoleHelper.WriteLineInRed(String.Format("An error occured while saving console output to file {0}", filename));
                _consoleHelper.WriteLineInRed(e.Message);
            }
        }

        public void SaveConsoleOutputToHtmlFile(string text, string filename, string subfolder)
        {
            try
            {
                SaveTextTofile(text, filename, subfolder, ".html");
            }
            catch (Exception e)
            {
                _consoleHelper.WriteLineInRed(String.Format("An error occured while saving console output to file {0}", filename));
                _consoleHelper.WriteLineInRed(e.Message);
            }
        }

        public void CreateDirecotoryIfNotExist(string subfolder)
        {
            if (String.IsNullOrEmpty(subfolder))
                return;

            if (!Directory.Exists(subfolder))
                Directory.CreateDirectory(subfolder);
        }

        public string GenerateOutputFilePath(string filename, string subfolder, string extension)
        {
            if (String.IsNullOrEmpty(filename))
                filename = String.IsNullOrEmpty(subfolder) ? GenerateUniqueFileName(extension) : Path.Combine(subfolder, GenerateUniqueFileName(extension));
            return filename;
        }

        public string GenerateUniqueFileName(string extension)
        {
            string filenameWithtoutExtension = String.Format("output_{0}", DateTime.Now.ToString("yyyyMMddTHH-mm-ss"));
            string filenameWithExtension = String.Format("{0}{1}", filenameWithtoutExtension, extension);

            // add '_' until find unique file name, barely possible, but possible.
            while (File.Exists(filenameWithExtension))
            {
                filenameWithtoutExtension += "_";
                filenameWithExtension = String.Format("{0}{1}", filenameWithtoutExtension, extension);
            }

            return filenameWithExtension;
        }
    }
}
