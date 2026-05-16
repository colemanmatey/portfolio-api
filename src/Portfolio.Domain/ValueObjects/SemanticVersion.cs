namespace Portfolio.Domain.ValueObjects
{
    public class SemanticVersion
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Patch { get; set; }

        public override string ToString()
        {
            return $"{Major}.{Minor}.{Patch}";
        }
    }
}
