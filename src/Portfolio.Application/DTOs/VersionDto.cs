namespace Portfolio.Application.DTOs
{
    public record VersionDto(string name, List<string> versions);
    public record VersionCreateDto(int major, int minor, int patch);
}
