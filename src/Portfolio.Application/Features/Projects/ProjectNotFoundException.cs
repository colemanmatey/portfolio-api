namespace Portfolio.Application.Features.Projects
{
    public class ProjectNotFoundException : Exception
    {
        public ProjectNotFoundException(int id) : base($"Project with ID {id} was not found.") 
        {
        }
    }
}
