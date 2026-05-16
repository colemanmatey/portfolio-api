namespace Portfolio.Application.Features.Projects
{
    public record ProjectDto(int id, string title, string? description, string? category, string? status);
}
