using PriceCompare.Backend.Accessors.Import.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using PriceCompare.Backend.Accessors.Import.Contracts.DataContracts;
using System.Reflection;

namespace PriceCompare.Backend.Accessors.Import
{
    public class ImportAccessor : IImportAccessor
    {
        private const string directoryPath = @"c:\temp";

        public void DeleteAllFiles()
        {
            Array.ForEach(Directory.GetFiles(directoryPath, "*.Xml"), File.Delete);
            Array.ForEach(Directory.GetFiles(directoryPath, "*.gz"), File.Delete);
        }

        public string[] GetAllXmlFiles()
        {
            string[] filePaths = Directory.GetFiles(directoryPath, "*.Xml");
            return filePaths;
        }

        public XDocument ReadXmlFile(string Path)
        {
            XDocument doc = XDocument.Load(Path);
            return doc;
        }

    }
}
