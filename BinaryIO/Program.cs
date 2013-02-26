using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BinaryIO
{
    class Program
    {
        const string FileName = "AppSettings.dat";

        static void Main()
        {
            WriteDefaultValues();
            DisplayValues();
        }

        public static void WriteDefaultValues()
        {
            using (var writer = new BinaryWriter(File.Open(FileName, FileMode.Create)))
            {
                writer.Write(1.250F);
                writer.Write(@"c:\Temp");
                writer.Write(10);
                writer.Write(true);
            }
        }

        public static void DisplayValues()
        {
            

            if (File.Exists(FileName))
            {
                float aspectRatio;
                string tempDirectory;
                int autoSaveTime;
                bool showStatusBar;
                using (var reader = new BinaryReader(File.Open(FileName, FileMode.Open)))
                {
                    aspectRatio = reader.ReadSingle();
                    tempDirectory = reader.ReadString();
                    autoSaveTime = reader.ReadInt32();
                    showStatusBar = reader.ReadBoolean();
                }

                Console.WriteLine("Aspect ratio set to: " + aspectRatio);
                Console.WriteLine("Temp directory is: " + tempDirectory);
                Console.WriteLine("Auto save time set to: " + autoSaveTime);
                Console.WriteLine("Show status bar: " + showStatusBar);
            }
        }
    }
}
