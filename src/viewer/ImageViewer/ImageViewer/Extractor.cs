using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Compression;

namespace ImageViewer
{
    /// <summary>
    /// This class deals with the extraction of .zip files and creating/destroying temporary directories.
    /// </summary> 
    class Extractor
    {
        private string _TempFolderName = "";

        public string TempFolderName 
        {
            get {  return _TempFolderName; }
            set { TempFolderName = _TempFolderName; }
        }
        
        /// <summary>
        /// default constructor.
        /// </summary>
        public Extractor()
        {
            _TempFolderName = GenerateTempFolderName();          
        }       

        /// <summary>
        /// takes a file path and extracts its contents to temporary folder.
        /// </summary>
        /// <param name="ResourceFilePath"> string file path to the .zip</param>
        public void Extract(string ResourceFilePath)
        {
            CreateTempFolder(_TempFolderName);           
            ZipFile.ExtractToDirectory(ResourceFilePath, _TempFolderName);

        }
        
        /// <summary>
        /// call this method when the application is closing because we want to delete the temporary folder.
        /// </summary>
        public void Dispose()
        {
            DeleteTempFolder(_TempFolderName);
        }

        /// <summary>
        /// creates a folder that temporary holds the contents of the extracted file.
        /// </summary>
        /// <param name="FolderName">name of the folder were creating</param>
        private void CreateTempFolder(string FolderName)
        {
            Directory.CreateDirectory(FolderName);
        }

        /// <summary>
        /// delete the temporary folder.
        /// </summary>
        /// <param name="FolderName">the name of the folder were deleting.</param>
        private void DeleteTempFolder(string FolderName)
        {
            Directory.Delete(FolderName);
        }

        /// <summary>
        /// Move a file to a specified location
        /// </summary>
        /// <param name="FilePath"> the file thats being moved.</param>
        /// <param name="DestinationPath">the place were moving the file.</param>
        private void MoveFile(string FilePath , string DestinationPath)
        {

        }

        /// <summary>
        /// generates a temporary folder name.
        /// </summary>
        /// <returns></returns>
        private string GenerateTempFolderName()
        {           
            Random RandGen = new Random();            
            string Name = "";

            // generate 5 random numbers from 64 to 90.
            // then convert the new numbers into chars and append it to the Name string
            for (int i = 0; i < 5; i++)
            {
                int rand = RandGen.Next(64, 90);
                char c = Convert.ToChar(rand);
                Name += c;
            }
                
            return Name;
        }

    }
}
