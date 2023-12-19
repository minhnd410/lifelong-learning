using System.Data;
using ExcelDataReader;

namespace Herond.Common.Utils;

public delegate (bool considerEqual, bool considerSmaller) CompareHandler(int middleIndex);

public static class ExcelUtils
{
    public static DataSet ReadDataSet(string path, ExcelDataSetConfiguration? config = null)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        using var stream = File.Open(path, FileMode.Open, FileAccess.Read);

        // Auto-detect format, supports:
        //  - Binary Excel files (2.0-2003 format; *.xls)
        //  - OpenXml Excel files (2007 format; *.xlsx, *.xlsb)
        using var reader = ExcelReaderFactory.CreateReader(stream);
        
        // Use the AsDataSet extension method
        var dataSet = reader.AsDataSet(config);

        // The result of each spreadsheet is in result.Tables
        return dataSet;
    }

    public static int SearchColumn(int length, CompareHandler handler)
    {
        int left = 0;
        int right = length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;

            var(considerEqual, considerSmaller) = handler.Invoke(mid);
            if (considerEqual)
            {
                return mid; // Target found at index 'mid'
            }
            else if (considerSmaller)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return -1;
    }
}