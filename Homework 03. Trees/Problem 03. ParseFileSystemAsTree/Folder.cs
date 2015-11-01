namespace Problem_03.ParseFileSystemAsTree
{
    public class Folder
    {
        public Folder(string name)
        {
            this.Name = name;
        }

        public Folder(string name, File[] files, Folder[] folders)
        {
            this.Name = name;
            this.Files = files;
            this.ChildFolders = folders;
        }

        public string Name { get; private set; }

        public File[] Files { get; private set; }

        public Folder[] ChildFolders { get; private set; }

        public void AddFiles(File[] files)
        {
            this.Files = files;      
        }

        public void AddChildFolders(Folder[] folders)
        {
            this.ChildFolders = folders;
        }
    }
}
