namespace Proyecto3.Settings
{
    public class UploadSettings
    {
        public string UploadDirectory { get; set; } = string.Empty;
        public string AllowedExtensions { get; set; } = string.Empty;
        public int MaxFileSizeInMb { get; set; }
    }
}


