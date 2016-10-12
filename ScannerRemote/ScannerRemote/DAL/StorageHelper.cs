using PCLStorage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerRemote.Helpers
{
    
    internal class StorageHelper
    {
        internal const string docFolder = "Documents";
        internal static async Task WriteFileToStorage(string fileName, byte[] content)
        {
            IFolder rootFolder = FileSystem.Current.LocalStorage;
            IFolder folder = await rootFolder.CreateFolderAsync(docFolder,
                CreationCollisionOption.OpenIfExists);
            IFile file = await folder.CreateFileAsync(fileName,CreationCollisionOption.ReplaceExisting);
            using (var filehandler = await file.OpenAsync(FileAccess.ReadAndWrite))
            {
                await filehandler.WriteAsync(content, 0, content.Length);
            }
        }
    }
   
}
