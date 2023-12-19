namespace Herond.Common.FileService;

public interface IFileStorageService
{
    Task UploadFileAsync(string fileName, Stream content);
    Task<Stream> GetFileAsync(string fileName);
    Task DeleteFileAsync(string fileName);
}