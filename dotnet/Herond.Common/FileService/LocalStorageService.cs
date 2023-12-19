namespace Herond.Common.FileService;

public class LocalStorageService : IFileStorageService
{
    private readonly string _basePath;

    public LocalStorageService(string basePath)
    {
        _basePath = basePath;
    }

    public async Task UploadFileAsync(string fileName, Stream content)
    {
        var filePath = Path.Combine(_basePath, fileName);

        await using var fileStream = File.Create(filePath);
        await content.CopyToAsync(fileStream);
    }

    public async Task<Stream> GetFileAsync(string fileName)
    {
        var filePath = Path.Combine(_basePath, fileName);

        if (File.Exists(filePath))
            return File.OpenRead(filePath);

        return null!;
    }

    public async Task DeleteFileAsync(string fileName)
    {
        var filePath = Path.Combine(_basePath, fileName);

        if (File.Exists(filePath))
            File.Delete(filePath);
    }
}