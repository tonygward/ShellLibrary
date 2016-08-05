namespace ShellLibrary.Core
{
    public class LibraryFolder
    {
        public string Name;
        public string Path;

        public override string ToString()
        {
            return $"Name: {Name}, Path: {Path}";
        }
    }
}
