using System;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Shell;

namespace ShellLibrary.Core
{
    public class Library
    {
        public string Name;
        public string DefaultSaveLocation;
        public List<LibraryFolder> Folders;
        
        private readonly Microsoft.WindowsAPICodePack.Shell.ShellLibrary _library;

        public Library()
        {
            
        }

        public Library(ShellObject shellObject)
            : this(shellObject.Name)
        {
            
        }

        private Library(string name)
        {
            _library = Microsoft.WindowsAPICodePack.Shell.ShellLibrary.Load(name, false);

            Name = _library.Name;
            BuildDefaultSaveLocation();
            BuildFolders();
        }

        private void BuildDefaultSaveLocation()
        {
            try
            {
                if (_library.DefaultSaveFolder != null) DefaultSaveLocation = _library.DefaultSaveFolder;
            }
            catch (Exception)
            {
                // Default Save Location may be null
            }
        }

        private void BuildFolders()
        {
            Folders = new List<LibraryFolder>();
            foreach (var folder in _library)
                Folders.Add(new LibraryFolder
                 {
                     Name = folder.Name,
                     Path = folder.Path
                 });
        }

        public override string ToString()
        {
            return $"Name: {Name}, DefaultSaveLocation: {DefaultSaveLocation}, Folders: {Folders}";
        }

        public void AddFolder(string folderPath)
        {
            _library.Add(folderPath);
        }

        public void RemoveFolder(string folderPath)
        {
            _library.Remove(folderPath);
        }

        public void SetDefaultSaveFolder(string folderPath)
        {
            _library.DefaultSaveFolder = folderPath;
        }

        public static Library New(string name)
        {
            var writer = new Microsoft.WindowsAPICodePack.Shell.ShellLibrary(name, overwrite: false);
            writer.Close();

            return new Library(name);
        }

        public static void Import(Library library)
        {
            var value = New(library.Name);
            foreach (var folder in library.Folders)
                value.AddFolder(folder.Path);
            value.SetDefaultSaveFolder(library.DefaultSaveLocation);
        }
    }
}
