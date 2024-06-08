using System.IO;
using UnityEngine;

namespace CCC.Scripts.Editor
{
    public static class CsvUtilities
    {
        private const string PathToAllCsvFiles = "/CCC/CSV Sources/";

        /// <summary>
        /// Read the files from a .csv-file and return them encapsulated in an <see cref="CsvMatrix"/> object
        /// with getter functionality.
        /// </summary>
        /// <param name="csvFileName">Name of the file, without the '.csv' ending.</param>
        /// <returns>The contents of the file as <see cref="CsvMatrix"/>.</returns>
        public static CsvMatrix GetCsvAsMatrix(string csvFileName)
        {
            var allLines = GetAllCsvLines(csvFileName);
            if (allLines.Length == 0)
            {
                Debug.LogError($"Why are you trying to read the file called '{csvFileName}'" +
                               $"at '{FullPathToCsv(csvFileName)}' if it has no entries???");
            }

            string[][] result = new string[allLines.Length][];
            for (int row = 0; row < allLines.Length; row++)
                result[row] = allLines[row].Split(',');

            return new CsvMatrix(result);
        }

        /// <summary>
        /// Read all lines from a .csv file.
        /// </summary>
        /// <param name="csvFileName">Name of the file, without the '.csv' ending.</param>
        /// <returns>An array where each entry represents an entire row in the .csv file.</returns>
        private static string[] GetAllCsvLines(string csvFileName)
        {
            try
            {
                return File.ReadAllLines(FullPathToCsv(csvFileName));
            }
            catch
            {
                Debug.LogError($"Could not load .csv-file at'{FullPathToCsv(csvFileName)}'!");
                return new string[] { "FAILED" };
            }
        }

        /// <summary>
        /// Get the fully qualified path to a .csv-file inside this directory.
        /// Assumes that all .csv files are stored in the same project subfolder '/Scriptable Objects/CSV Sources/'! 
        /// </summary>
        /// <param name="csvFileName">Name of the file, without the '.csv' ending</param>
        /// <returns>Fully qualified path to the .csv file, which can be read by System.IO.File.</returns>
        private static string FullPathToCsv(string csvFileName)
        {
            return $"{Application.dataPath}{PathToAllCsvFiles}{csvFileName}.csv";
        }
        
        public static CsvMatrix GetCsvAsMatrix(string directory, string csvFileName)
        {
            var allLines = GetAllCsvLines(directory, csvFileName);
            if (allLines.Length == 0)
            {
                Debug.LogError($"Why are you trying to read the file called '{csvFileName}'" +
                               $"in directory '{directory}' if it has no entries???");
            }

            string[][] result = new string[allLines.Length][];
            for (int row = 0; row < allLines.Length; row++)
                result[row] = allLines[row].Split(',');

            return new CsvMatrix(result);
        }
        
        private static string[] GetAllCsvLines(string directory, string csvFileName)
        {
            var path = $"{directory}{csvFileName}.csv";
            try
            {
                return File.ReadAllLines(path);
            }
            catch
            {
                Debug.LogError($"Could not load .csv-file at'{path}'!");
                return new string[] { "FAILED" };
            }
        }
    }
}
