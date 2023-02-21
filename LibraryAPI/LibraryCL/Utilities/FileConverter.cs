using System.IO.Pipelines;

namespace LibraryCL.Utilities
{
    public static class FileConverter
    {
        public static async Task<string> GetBase64String(this PipeReader pipeReader)
        {
            await using var memoryStream = new MemoryStream();
            await pipeReader.CopyToAsync(memoryStream);
            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }
}
