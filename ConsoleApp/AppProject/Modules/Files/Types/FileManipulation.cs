using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.IO;

namespace AppProject.Modules.Files.Types
{
    public class FileManipulation : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        private string appPath = AppDomain.CurrentDomain.BaseDirectory;
        private const string file = @"Modules\\Files\\Resources\\File1.txt";
        private string fileFullPath = string.Empty;
        private string copyDirectoryName = "CopyDirectory";
        private string copyDirectoryFullPath = string.Empty;
        private string moveDirectoryName = "MoveDirectory";
        private string moveDirectoryFullPath = string.Empty;
        public FileManipulation() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
            fileFullPath = Path.Combine(appPath + file);
            copyDirectoryFullPath = Path.Combine(appPath + copyDirectoryName);
            moveDirectoryFullPath = Path.Combine(appPath + moveDirectoryName);
        }

        public void Init()
        {
            CheckFileExistence();
            ShowParentDirectories();
            CheckDirectoryAndCreate();
            CopyFileToAnotherDirectory();
            MoveFileToAnotherDirectory();
            GetFileNameAndExtension();
            ChangeFileExtension();
            GetAllFiles();
            DeleteDirectories();
        }

        private void CheckFileExistence()
        {
            if (File.Exists(fileFullPath))
            {
                _printer.Print("The file exists");
            }
            else
            {
                _printer.Print("The file doesn't exists");
            }
        }

        private void ShowParentDirectories()
        {
            string rootParentDirectory = new DirectoryInfo(fileFullPath).Parent.FullName;
            string rootParentParentDirectory = new DirectoryInfo(fileFullPath).Parent.Parent.FullName;

            _printer.Print("Parent: " + rootParentDirectory);
            _printer.Print("Parent Parent: " + rootParentParentDirectory);
        }

        private void CheckDirectoryAndCreate()
        {
            if (!Directory.Exists(copyDirectoryFullPath))
            {
                _printer.Print($"Creating {copyDirectoryFullPath}");
                Directory.CreateDirectory(copyDirectoryFullPath);
            }
        }

        private void CopyFileToAnotherDirectory()
        {
            string fileName = Path.GetFileName(fileFullPath);
            string fullPathNewDirectory = Path.Combine(copyDirectoryFullPath, fileName);
            File.Copy(fileFullPath, fullPathNewDirectory, true);
            _printer.Print($"Copying file to {fullPathNewDirectory}");
        }

        private void MoveFileToAnotherDirectory()
        {
            string fileName = Path.GetFileName(fileFullPath);
            string fullPathCopyDirectory = Path.Combine(copyDirectoryFullPath, fileName);
            string fullPathMoveDirectory = Path.Combine(moveDirectoryFullPath, fileName);
            Directory.CreateDirectory(moveDirectoryFullPath);
            if (!File.Exists(fullPathMoveDirectory))
            {
                File.Move(fullPathCopyDirectory, fullPathMoveDirectory);
            }
        }

        private void GetFileNameAndExtension()
        {
            string fileName = Path.GetFileNameWithoutExtension(fileFullPath);
            string extension = Path.GetExtension(fileFullPath);
            _printer.Print($"file name: {fileName} | file extension: {extension}");
        }

        private void ChangeFileExtension()
        {
            string newFile = Path.ChangeExtension(fileFullPath, ".dat");
            _printer.Print(newFile);
        }

        private void DeleteDirectories()
        {
            Directory.Delete(copyDirectoryFullPath, true);
            Directory.Delete(moveDirectoryFullPath, true);
        }

        private void GetAllFiles()
        {
            string[] allFiles = Directory.GetFiles(appPath);
            foreach (var fileName in allFiles)
            {
                _printer.Print(fileName);
            }
        }
    }
}
