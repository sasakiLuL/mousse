using Microsoft.AspNetCore.Http;

namespace mousse.Application.Abstractions.Storage;

public interface IStorageService
{
    Task<Guid> UploadFileAsync(IFormFile file, CancellationToken token = default);

    Task<FileResponse> DownloadAsync(Guid fileId, CancellationToken token = default);

    Task DeleteAsync(Guid fileId, CancellationToken token = default);
}
