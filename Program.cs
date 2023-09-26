using System;
using System.Collections.Generic;
using System.IO;


//Making an interface of DuplicateFileDeleter
interface IDuplicateFileDeleter
{
    void DeleteDuplicateFiles(string folderPath);
}

//Base class implementing the interface
class DuplicateFileDeleter : IDuplicateFileDeleter
{
    public void DeleteDuplicateFiles(string folderPath)
    {
        try
        {
            HashSet<string> uniqueFiles = new HashSet<string>();
            foreach (string filePath in Directory.GetFiles(folderPath, "*", SearchOption.AllDirectories))
            {
                string fileContent = Convert.ToBase64String(File.ReadAllBytes(filePath));
                if (!uniqueFiles.Add(fileContent))
                {
                    Console.Write("Deleting duplicate file : " + filePath);
                    File.Delete(filePath);
                    Console.WriteLine($"\n{filePath} deleted successfully!!");
                }
                else
                    uniqueFiles.Add(fileContent);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error has occurred: " + ex);
        }
    }
}


class Program
{
    static void Main(String[] args)
    {
        string folderPath = @"/Users/30111693/Desktop/DemoFolder";
        DuplicateFileDeleter fileDeleter = new DuplicateFileDeleter();
        fileDeleter.DeleteDuplicateFiles(folderPath);
    }
}
