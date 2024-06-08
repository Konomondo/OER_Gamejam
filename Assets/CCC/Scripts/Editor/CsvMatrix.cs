namespace CCC.Scripts.Editor
{
    public class CsvMatrix
    {
        private readonly string[][] _entries;
        public readonly int RowCount;
        public readonly int ColumnCount;

        public CsvMatrix(string[][] entries)
        {
            _entries = entries;
            RowCount = entries.Length;
            ColumnCount = entries[0].Length;
        }

        public string Get(int row, int col) => _entries[row][col];

        public string[] GetRow(int row) => _entries[row];

        /// <summary>
        /// Get the specified column entries, starting with the given rowIndex included.
        /// E.g. GetColumn(3,1) will get the third column and ignore the first entry in it.
        /// </summary>
        public string[] GetColumn(int col, int startingRow = 0)
        {
            string[] result = new string[RowCount - startingRow];
            for (int row = startingRow; row < RowCount; row++)
                result[row - startingRow] = _entries[row][col];
            return result;
        }
    }
}