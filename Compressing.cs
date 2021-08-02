using System;
using System.IO;
using System.IO.Compression;

namespace testProject
{
    internal class CompressingAndDecompressing
    {
        // Directory's path private field
        private const string DirectoryPath = @"Templates/";

        // Compressing functions //
            
            // A version without splitting by blocks of the same size during compression
            public static void Compress1(DirectoryInfo directorySelected)
            {
                // Iterate over each file in the directory
                foreach (FileInfo fileToCompress in directorySelected.GetFiles())
                {
                    // OpenRead the file and initialize it to mainFileStream
                    using (FileStream mainFileStream = fileToCompress.OpenRead())
                    {
                        // Assure the file's attributes
                        if ((File.GetAttributes(fileToCompress.FullName) & FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                        {
                            // Create the compressedFileStream
                            using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + ".gz"))
                            {
                                // streamCompression which contains the compressedFileStream and Compression arguments
                                using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                                {
                                    // Copy the stream needed to be compressed
                                    mainFileStream.CopyTo(compressionStream);
                                }
                            }
        
                            // Declare the name of the compressed file and show to the user ~ friendly message
                            FileInfo info = new FileInfo(DirectoryPath + Path.DirectorySeparatorChar + fileToCompress.FullName + ".gz");
                            Console.WriteLine($"Compressed {fileToCompress.Name} from {fileToCompress.Length.ToString()} to {info.Length.ToString()} bytes.");
                        }
                    }
                }
            }
        
            // A version splits the source file to blocks of the same size during compression (Introducing them in Bytes)
            public static void Compress2(DirectoryInfo directorySelected)
            {
                int writeStat = 0, offset = 0, counter = 0;
                
                // Traverse the files in the directory
                foreach (FileInfo fileToCompress in directorySelected.GetFiles())
                {
                    // OpenRead the file and initialize it to mainFileStream
                    using (FileStream originalFileStream = fileToCompress.OpenRead())
                    {
                        // Assure the attributes of the file
                        if ((File.GetAttributes(fileToCompress.FullName) &
                        FileAttributes.Hidden) != FileAttributes.Hidden & fileToCompress.Extension != ".gz")
                        {
                            // Declare the bytes needed to be read and the size
                            var bytesToRead = new byte[originalFileStream.Length];
                            int numBytesRead = bytesToRead.Length;
        
                            // Until it reaching the to the last stream
                            while (offset < originalFileStream.Length)
                            {                                
                                // Read upto 5 bytes
                                writeStat = originalFileStream.Read(bytesToRead, 0, 5);
        
                                // Create the compressed file stream
                                using (FileStream compressedFileStream = File.Create(fileToCompress.FullName + counter + ".gz"))
                                {
                                    // streamCompression which contains the compressedFileStream and Compression arguments
                                    using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                                    {
                                        compressionStream.Write(bytesToRead, 0, writeStat);
                                    }
                                }
                                // ITERATE
                                offset = offset + writeStat;                        
                                counter++;
                            }
                            // Declare the name of the compressed file and show to the user a friendly message
                            FileInfo info = new FileInfo(DirectoryPath + Path.DirectorySeparatorChar + fileToCompress.Name + ".gz");
                            Console.WriteLine($"Compressed {fileToCompress.Name} from {fileToCompress.Length.ToString()} to {info.Length.ToString()} bytes.");
                        }
                    }
                }
            }
        
            // Decompressing function //
            public static void Decompress(FileInfo fileSelectedToDecompress)
            {
                // OpenRead the file and initialize it to mainFileStream
                using (FileStream mainFileStream = fileSelectedToDecompress.OpenRead())
                {
                    // Declare the current file name & the new file name
                    string fileName = fileSelectedToDecompress.FullName;
                    string newFileName = fileName.Remove(fileName.Length - fileSelectedToDecompress.Extension.Length);
        
                    // create the new file and initialize it to decompressedFileStream
                    using (FileStream decompressedFileStream = File.Create(newFileName))
                    {
        
                        // Make the Decompressed GZipStream
                        using (GZipStream decompressingStream = new GZipStream(mainFileStream, CompressionMode.Decompress))
                        {
                            // Copy the decompressed stream
                            decompressingStream.CopyTo(decompressedFileStream);
                            // Show a User-Friendly Message
                            Console.WriteLine($"Decompressed: {fileSelectedToDecompress.Name}");
                        }
                    }
                }
            }
    }
}