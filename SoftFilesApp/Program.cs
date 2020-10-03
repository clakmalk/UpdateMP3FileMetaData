using Id3;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SoftFilesApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Files path?");
            string filesPath = Console.ReadLine();
            string[] files = Directory.GetFiles(filesPath, "*.mp3", SearchOption.TopDirectoryOnly);
            foreach(string file in files)
            {
                string fileName = (new FileInfo(file)).Name;
                File.Copy(file, @"D:\" + fileName);
                Console.WriteLine(fileName);
            }
            //string[] folders = Directory.GetDirectories(filesPath);
            ////string[] files = Directory.GetFiles(filesPath, "*.mp3", SearchOption.AllDirectories);
            //Array.Sort(folders, StringComparer.InvariantCulture);
            //int count = 1;
            //foreach (string folder in folders)
            //{
            //    string folderName = new DirectoryInfo(folder).Name;
            //    Console.WriteLine("Processing - " + folder);
            //    string[] files = Directory.GetFiles(folder, "*.mp3");
            //    foreach (string file in files)
            //    {
            //        Console.WriteLine(count.ToString()+" - " + file);
            //        using (var mp3 = new Mp3(file, Mp3Permissions.ReadWrite))
            //        {
            //            Id3Tag tag = mp3.GetTag(Id3TagFamily.Version2X);
            //            if (tag == null)
            //            {
            //                tag = new Id3Tag();
            //                //tag.Version = Id3Version.V23;
            //                // version is internal set, but if we use reflection to set it, the mp3.WriteTag below works.
            //                var propinfo = typeof(Id3Tag).GetProperty("Version", System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            //                propinfo.SetValue(tag, Id3Version.V23);
            //            }
            //            tag.Track.Value = count;
            //            //tag.Album.Value = count.ToString();
            //            mp3.WriteTag(tag, WriteConflictAction.Replace);
            //            string fileId = GetFileId(count);
            //            string fileName = new FileInfo(file).Name;
            //            File.Copy(file, filesPath + @"/" + fileId +"_"+folderName+ "_" + fileName);
            //        }
            //        count++;
            //    }
            //}
            

            Console.ReadLine();
        }

        private static string GetFileId(int id)
        {
            string strId = id.ToString();
            for (int i=0;i<5;i++)
            {
                if (strId.Length>=5)
                {
                    break;
                }
                strId = "0" + strId;
            }
            return strId;
        }
    }
}
