using PriceCompare.Backend.Accessors.Import.Contracts;
using PriceCompare.Backend.Accessors.Import.Contracts.DataContracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PriceCompare.Backend.Accessors.Import
{
    public class DownloadAccessor : IDownloadAccessor
    {
        public void DownloadFileFromSite(string FilePathOnSite, ChainItem ChainToDownload)
        {
            string path = @"c:\temp";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var destinationDirectory = path + @"\" + FilePathOnSite;
            var RemoteFtpPath = ChainToDownload.ChainWebSiteLink + @"/" + FilePathOnSite;
            FtpWebRequest Request = (FtpWebRequest)WebRequest.Create(RemoteFtpPath);
            Request.Method = WebRequestMethods.Ftp.DownloadFile;
            Request.Credentials = new NetworkCredential(ChainToDownload.ChainUserName, ChainToDownload.ChainPassword);
            Request.KeepAlive = true;
            Request.UsePassive = false;
            Request.UseBinary = true;

            FtpWebResponse Response = (FtpWebResponse)Request.GetResponse();

            Stream ResponseStream = Response.GetResponseStream();
            StreamReader Reader = new StreamReader(ResponseStream);

            using (FileStream writer = new FileStream(destinationDirectory, FileMode.Create))
            {

                long length = Response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[2048];

                readCount = ResponseStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    writer.Write(buffer, 0, readCount);
                    readCount = ResponseStream.Read(buffer, 0, bufferSize);
                }
            }
        }

        public List<string> GetAllFilesNamesInChainFromSite(ChainItem ChainToDownload)
        {
            List<string> filesnames = new List<string>();
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ChainToDownload.ChainWebSiteLink);
            request.Method = WebRequestMethods.Ftp.ListDirectory;
            request.Credentials = new NetworkCredential(ChainToDownload.ChainUserName, ChainToDownload.ChainPassword);
            request.KeepAlive = true;
            request.UsePassive = false;

            FtpWebResponse response = (FtpWebResponse)request.GetResponse();

            Stream responseStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(responseStream);

            while (!reader.EndOfStream)
            {
                String filename = reader.ReadLine();
                filesnames.Add(filename);
                Console.WriteLine(filename);
            }
            List<string> fullpriceList = new List<string>();
            foreach (var item in filesnames)
            {
                if (item.Contains("PriceFull"))
                {
                    fullpriceList.Add(item);
                }
            }

            return fullpriceList;
        }

        public void UnZipFiles()
        {
            string directoryPath = @"c:\temp";

            DirectoryInfo directorySelected = new DirectoryInfo(directoryPath);

            foreach (FileInfo fileToDecompress in directorySelected.GetFiles("*.gz"))
            {
                using (FileStream originalFileStream = fileToDecompress.OpenRead())
                {
                    string currentFileName = fileToDecompress.FullName;
                    string newFileName = currentFileName.Remove(currentFileName.Length - fileToDecompress.Extension.Length);
                    newFileName = newFileName + ".xml";
                    using (FileStream decompressedFileStream = File.Create(newFileName))
                    {
                        using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(decompressedFileStream);
                        }
                    }
                }
            }
        }
    }
}
