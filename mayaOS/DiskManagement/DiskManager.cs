using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.System.FileSystem;

namespace mayaOS.DiskManagement
{
    public class DiskManager
    {
        public static CosmosVFS vfs = new CosmosVFS();

        public static void RegisterFileSystem()
        {
            Cosmos.System.FileSystem.VFS.VFSManager.RegisterVFS(vfs);
        }

        public static void Format(string driveID)
        {
            vfs.Format(driveID, "FAT32", true);
        }

        public static void MakeDirectory(string name, string path)
        {
            vfs.CreateDirectory(path + "/" + name);
        }

        public static void CreateFile(string fileName, string content)
        {
            vfs.CreateFile("0:" + fileName);
            try
            {
                var file = Cosmos.System.FileSystem.VFS.VFSManager.GetFile("0:" + fileName);
                var fileStream = file.GetFileStream();

                if (fileStream.CanWrite)
                {
                    byte[] text_to_write = Encoding.ASCII.GetBytes(content);
                    fileStream.Write(text_to_write, 0, text_to_write.Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void DeleteDirectory(string path)
        {
            //TODO: Implement rmdir
        }

        public static void DeleteFile(string path)
        {
            //TODO: Implement rm
        }

        public static void ListFiles(string driveID, string path)
        {
            var directoryList = Cosmos.System.FileSystem.VFS.VFSManager.GetDirectoryListing(driveID + ":" + path);

            foreach(var dirEntry in directoryList)
            {
                Console.WriteLine(dirEntry.mName + $"\tS:{dirEntry.mSize}");
            }
        }

        public static string ReadFile(string filePath)
        {
            string result = "";
            try
            {
                var file = Cosmos.System.FileSystem.VFS.VFSManager.GetFile("0:" + filePath);
                var fileStream = file.GetFileStream();

                if (fileStream.CanRead)
                {
                    byte[] text_to_read = new byte[fileStream.Length];
                    fileStream.Read(text_to_read, 0, (int)fileStream.Length);
                    result = Encoding.Default.GetString(text_to_read);
                }
            }
            catch (Exception e)
            {
                return "Error: " + e.Message;
            }
            return result;
        }
    }
}
