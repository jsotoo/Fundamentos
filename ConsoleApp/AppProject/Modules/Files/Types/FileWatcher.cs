using AppProject.Core.Module;
using AppProject.Core.Print;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Threading;

namespace AppProject.Modules.Files.Types
{
    public class FileWatcher : ModuleBase, IModule
    {
        private readonly IPrint _printer;
        private string appPath = AppDomain.CurrentDomain.BaseDirectory;
        private const string file = @"Modules\\Files\\Resources\\File1.txt";
        private string fileFullPath = string.Empty;
        private string watchDirectoryName = "WatchDirectory";
        private string watchDirectoryFullPath = string.Empty;
        private static ConcurrentDictionary<string, string> FilesToProcess =
            new ConcurrentDictionary<string, string>();

        public FileWatcher() : base(new ConsolePrinter())
        {
            _printer = new ConsolePrinter();
            fileFullPath = Path.Combine(appPath + file);
            watchDirectoryFullPath = Path.Combine(appPath + watchDirectoryName);
        }

        // NotifyFilters enum: 
        // Attributes: File/directory attributes
        // CreationTime: File/directory created time
        // DirectoryName: The name of the directory
        // FileName: The name of the file
        // LastAccess: File/directory last opened date
        // LastWrite: Last date file/directory written to
        // Security: File/directory security settings
        // Size: File/directory size

        public void Init()
        {
            ConfigureDirectoryWatcher();
        }

        public void ConfigureDirectoryWatcher()
        {
            Directory.CreateDirectory(watchDirectoryFullPath);

            using (var inputFileWatcher = new FileSystemWatcher(watchDirectoryFullPath))
            using (var time = new Timer(ProcessFiles, null, 0, 1000))
            {
                _printer.Print($"Watching directory: {watchDirectoryFullPath}");
                inputFileWatcher.IncludeSubdirectories = false;
                inputFileWatcher.InternalBufferSize = 32768; // 32 KB
                //inputFileWatcher.Filter = "*.*";
                //inputFileWatcher.NotifyFilter = NotifyFilters.LastWrite;
                //inputFileWatcher.NotifyFilter = NotifyFilters.FileName;
                inputFileWatcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite;

                inputFileWatcher.Created += FileCreated;
                inputFileWatcher.Changed += FileChanged;
                inputFileWatcher.Deleted += FileDeleted;
                inputFileWatcher.Renamed += FileRenamed;
                inputFileWatcher.Error += FileError;

                inputFileWatcher.EnableRaisingEvents = true;

                Console.WriteLine("Press enter");
                Console.ReadLine();
            }
        }

        private void FileCreated(object sender, FileSystemEventArgs e)
        {
            _printer.Print($"* File created: {e.Name} - type: {e.ChangeType}");
            FilesToProcess.TryAdd(e.FullPath, e.FullPath);
            //ProcessFile();
        }

        private void FileChanged(object sender, FileSystemEventArgs e)
        {
            _printer.Print($"* File changed: {e.Name} - type: {e.ChangeType}");
            FilesToProcess.TryAdd(e.FullPath, e.FullPath);
            //ProcessFile();
        }

        private void FileDeleted(object sender, FileSystemEventArgs e)
        {
            _printer.Print($"* File deleted: {e.Name} - type: {e.ChangeType}");
        }

        private void FileRenamed(object sender, RenamedEventArgs e)
        {
            _printer.Print($"* File renamed: {e.OldName} to {e.Name} - type: {e.ChangeType}");
            FilesToProcess.TryAdd(e.FullPath, e.FullPath);
            //ProcessFile();
        }

        private void FileError(object sender, ErrorEventArgs e)
        {
            _printer.Print($"ERROR: file system watching may no longer be active: {e.GetException()}");
        }

        private static void ProcessFiles(Object stateInfo)
        {
            foreach (var fileName in FilesToProcess.Keys)
            {
                if(FilesToProcess.TryRemove(fileName, out _))
                {
                    Console.WriteLine($"Processing file: {fileName}");
                }
            }
        }

        private void ProcessFile()
        {
            Console.WriteLine("Processing file");
        }
    }
}
