using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.IO;
using System.IO.Compression;
using System.Threading.Channels;
using Microsoft.VisualBasic;

namespace testProject
{
    // Inherit Program from CompressingAndDecompressing class
    internal class GZipTest : CompressingAndDecompressing
    {
        public static void Main(string[] args)
        {
            // A user-friendly message is shown if the he/she did not cooperate //
            try
            { 
                // Check the command-line argument
                if (args[0] == "compress") Compress2(new DirectoryInfo(args[1]));
                if (args[0] == "decompress") Decompress(new FileInfo(args[1]));
                else
                {
                    Console.WriteLine("ERROR!"); 
                    Console.WriteLine("Compressing: GZipTest.exe compress [original file name]"); 
                    Console.WriteLine("Decompressing: GZipTest.exe decompress [archive file name]");
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("type 'compress' for compressing OR 'decompress' for decompressing");
            }

            Console.ReadKey();
        }
    }
}