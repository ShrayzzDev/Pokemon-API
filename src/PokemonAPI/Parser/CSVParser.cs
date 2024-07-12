namespace Parser
{
    /// <summary>
    /// Very simple CSV Parser
    /// This parser suppose that the first line
    /// of the CSV correspond to the columns names.
    /// This should not be used if there is no columns.
    /// </summary>
    public class CSVParser
    {
        private IEnumerable<string[]> _data;

        private Dictionary<string, int> _columnPositions = new Dictionary<string, int>();

        /// <summary>
        /// Used to setup the data in the parser
        /// </summary>
        /// <param name="filePath">Path relative to the program one (contains file name)</param>
        /// <exception cref="FileNotFoundException">Thrown when the path is not found.</exception>
        public CSVParser(string filePath)
        {
            if (!filePath.EndsWith(".csv"))
            {
                throw new ArgumentException("File provided does not end with .csv");
            }
            string? currentLine;
            string[] splited;
            List<string[]> allLines = new List<string[]>();
            int i;
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"File at location {filePath} could not be found.");
            }
            using (var file = new StreamReader(filePath))
            {
                i = 0;
                while ((currentLine = file.ReadLine()) != null)
                {
                    splited = currentLine.Split(',');
                    allLines.Add(new string[splited.Length]);
                    for (int j = 0; j < splited.Length; j++)
                    {
                        allLines.ElementAt(i)[j] = splited[j];
                    }
                    i++;
                }
            }
            _data = allLines;

            string[] cols = allLines.First();
            for (i = 0; i < cols.Length; ++i)
            {
                _columnPositions[cols[i]] = i;
            }
        }

        /// <summary>
        /// Get the data from the name of the column
        /// NOTE : This is 1-index (0 is the column names)
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="lineNumber"></param>
        /// <returns></returns>
        public string GetDataFromColumn(string columnName, int lineNumber)
        {
            return _data.ElementAt(lineNumber)[_columnPositions[columnName]];
        }

        /// <summary>
        /// Retrieves the first value found where
        /// the values match the ones passed.
        /// </summary>
        /// <param name="columnName">Value to retrieve</param>
        /// <param name="conditions">List of tuples. First element is the column name, the second the value it has to respect.</param>
        /// <returns>Value if found. If not, empty string.</returns>
        public string GetFirstValueWhere(string columnName, IEnumerable<Tuple<string,string>> conditions)
        {
            bool areConditionsMet;
            for (int i = 1; i < GetNumberOfLines(); ++i)
            {
                areConditionsMet = true;
                foreach (var condition in conditions)
                {
                    areConditionsMet &= GetDataFromColumn(condition.Item1, i) == condition.Item2;
                }
                if (areConditionsMet)
                {
                    return GetDataFromColumn(columnName, i);
                }
            }
            return "";
        }

        /// <summary>
        /// Returns the first index where it finds a
        /// specific value.
        /// </summary>
        /// <param name="columnName">Name of the column to check</param>
        /// <param name="value">Value to find</param>
        /// <returns>Index, -1 if not found</returns>
        public int GetFirstIndexWhere(string columnName, string value)
        {
            for (int i = 1; i < GetNumberOfLines() - 1; ++i)
            {
                if (GetDataFromColumn(columnName, i) == value)
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns the number of lines
        /// </summary>
        /// <returns>The number of lines</returns>
        public int GetNumberOfLines()
        {
            // -1 because we should not count the columns
            return _data.Count();
        }
    }
}
