using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerRemote.Helpers
{
    static class Constants
    {
        internal static List<int> scanResolution = new List<int>()
        {
            150,300,600,1200 
        };
        internal static List<string> picformats = new List<string>
        {
            "JPG","PNG","BMP"
        };

        internal const string SERVERADDRESS = "ServerAddress";
        internal const string SERVERPORT = "ServerPort";
        internal const string PREPROCESS = "PreProcess";
        internal const string MERGE = "Merge";
        internal const string RESOLUTION = "Resolution";
        internal const string SCANFORMAT = "ScanFormat";
        internal const string CREATEPDFFROMPIC = "CreatePDFFROMPIC";
        internal const string KEYWORDS = "KEYWORDS";
        internal const string FILTERNONTAGGED = "FILTERNONTAGGED";
    }
}
