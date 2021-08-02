# GZipTest

A program that Compress and Decompress using GZipStream Class

-- Objectives:
Implement a command line tool using C# for block-by-block compressing and decompressing of files using class System.IO.Compression.GzipStream.
During compression source file should be split by blocks of the same size, for example, block of 1MB.
Each block then should be compressed and written to the output file independently of others blocks.
Application should effectively parallel and synchronize blocks processing in multicore environment and should be able to process files
that are larger than available RAM size.
Program code must be safe and robust in terms of exceptions. In case of exceptional situations
user should be informed by user friendly message, that allows user to fix occurred issue, for example, in case of OS limitations.
Source code should satisfy OOP and OOD principles (readability, classes separation and so on).

-- Dealing with the program:
Use the following command line arguments:
 compressing: GZipTest.exe compress [original file name] [archive file name]
 decompressing: GZipTest.exe decompress [archive file name] [decompressing filename]
On success program should return 0, otherwise 1.
Note: format of the archive is up to solution author, and does not affects final score, for example
there is no requirement for archive file to be compatible with GZIP file format.
Please send us solution source files and Visual Studio project. Briefly describe architecture and
algorithms used.

---
OS: Manjaro I3
IDE: Rider/vim

Program is able to read from the command line:-
compress [Directory contains files needed to be compressed]
decompress [Archive file name that is needed to be decompressed]

Source file is split by blocks of 5B size each of which is compressed and written to the output file.

-

2 Main Problems needed to be fixed ASAP:-

Problem 1 <in Compress method>: The user is not able to pass me the "archive file name" as a second command line argument.
The only way found to resolve that issue; Creating a local function (In main method) that will compress files
then modify it to be able write the name of the compressed file (the output file) exactly as same as the 2nd command line argument
that the user is going to pass.

DEFECTS of that resolution: Break of the Object Oriented Design of the program which will lead the program to be more fragile,
Decrease the flexibility & reduce the property of scaling (If the program needs to be scalled or upgraded).

Problem 2 <in Decompress method>: Almost the same as the first problem, Can not find how to modify the method to be able to
read the name of the output file to match the 2nd command line argument that the user is going to enter.


