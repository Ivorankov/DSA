namespace Problem_03.ParseFileSystemAsTree
{
    public class File
    {
        public File(string name, long fileSize)
        {
            this.Name = name;
            this.FileSize = fileSize;
        }

        public string Name { get; private set; }

        public long FileSize { get; private set; }
    }
}
