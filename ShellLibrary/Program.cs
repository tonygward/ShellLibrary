using System;
using System.Collections.Generic;
using ShellLibrary.Core;

namespace ShellLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var reader = new LibraryBuilder();
            var libraries = reader.GetLibraries();

            // var library = Library.New("tester");

            // var json = reader.ExportToJson(libraries);

            //var val = new Library()
            //{
            //    Name = "Test",
            //    DefaultSaveLocation = @"C:\temp",
            //    Folders = new List<LibraryFolder>
            //    {
            //        new LibraryFolder()
            //        {
            //            Name = "temp",
            //            Path = @"C:\temp"
            //        }
            //    }
            //};
            //Library.Import(val);

            Console.ReadKey();
        }
    }
}
