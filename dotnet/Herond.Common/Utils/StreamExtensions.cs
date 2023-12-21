namespace Herond.Common.Utils;

public static class StreamExtensions
{
    public static void SaveAsFile(
        this Stream inputStream, 
        string filePath, 
        FileMode fileMode = FileMode.OpenOrCreate)
    {
        using FileStream outputFileStream = new FileStream(filePath, fileMode);
        inputStream.CopyTo(outputFileStream);
    }
}