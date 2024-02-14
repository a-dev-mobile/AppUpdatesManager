namespace AppUpdatesManager.Domain.Entities
{
    public class SoftwareVersion
    {
        public int SoftwareVersionId { get; set; }
        public int Code { get; set; }
        public required string Name { get; set; }
        public required string Checksum { get; set; }
        public long SizeInBytes { get; set; }
        public string? Description { get; set; }
    }
}
