using Azure.Storage.Blobs;

namespace Herond.Common.FileService;

public class AzureBlobStorageService : IFileStorageService
{
    private readonly BlobContainerClient _client;

    public AzureBlobStorageService(string connectionString, string containerName)
    {
        var blobServiceClient = new BlobServiceClient(connectionString);
        _client = blobServiceClient.GetBlobContainerClient(containerName);
    }

    public async Task UploadFileAsync(string blobName, Stream content)
    {
        var blobClient = _client.GetBlobClient(blobName);
        await blobClient.UploadAsync(content, true);
    }

    public Task<Stream> GetFileAsync(string blobName)
    {
        var blobClient = _client.GetBlobClient(blobName);
        return blobClient.OpenReadAsync();
    }

    public async Task DeleteFileAsync(string blobName)
    {
        var blobClient = _client.GetBlobClient(blobName);
        await blobClient.DeleteIfExistsAsync();
    }
}