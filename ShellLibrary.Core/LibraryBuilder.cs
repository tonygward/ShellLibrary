using System;
using System.Collections.Generic;
using Microsoft.WindowsAPICodePack.Shell;
using Newtonsoft.Json;

namespace ShellLibrary.Core
{
    public class LibraryBuilder
    {
        public List<Library> GetLibraries()
        {
            var libraries = KnownFolders.Libraries;
            var values = new List<Library>();

            foreach (var library in libraries)
            {
                try
                {
                    values.Add(new Library(library));
                }
                catch (Exception)
                {
                    // Ignore and Continue
                }
            }
            return values;
        }

        public string ExportToJson(List<Library> libraries)
        {
            return JsonConvert.SerializeObject(libraries);
        }

        public void Import(string json)
        {
            var libraries = JsonConvert.DeserializeObject<List<Library>>(json);
            foreach (var library in libraries)
                Library.Import(library);
        }
    }
}
