using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program
{
    static void ReadFile(string filePath, int PasswordOrNot)
    {
        Console.Clear();
        StreamReader fr = new StreamReader(filePath);
        string line = fr.ReadLine();
        if (PasswordOrNot == 1)
        {
            line = "";
        }
        while (line != null)
        {
            Console.WriteLine(line);
            line = fr.ReadLine();
        }
        fr.Close();

        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("");
        Console.WriteLine("----------------------------------------------------------------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("File Succesfully Read");

    }

    static void OpenFile(string path) 
    {
         Console.Clear();
         Console.WriteLine("Type The Name Of The File You Wanna Open");
         Console.WriteLine("");
         Console.Write(">>");
         string file_name = Console.ReadLine();
         
         
         while (!File.Exists(path + file_name + ".txt"))
         {
             Console.BackgroundColor = ConsoleColor.Black;
             Console.Clear();
             Console.ForegroundColor = ConsoleColor.DarkRed;
             Console.WriteLine("'" + file_name + ".txt" + "'" + " Was Not Found, Check Your Spelling And Try Again");
             Console.WriteLine("");
             Console.ForegroundColor = ConsoleColor.White;
             Console.BackgroundColor = ConsoleColor.Black;
             Console.Write(">>");
             file_name = Console.ReadLine();
         }
         
         Console.Clear();
         
         StreamReader fr = new StreamReader(path + file_name + ".txt");
         string firstLine = fr.ReadLine();
         if (firstLine == null)
         {
             Console.Clear();
             Console.WriteLine("File Was Completly Empty");
             Console.WriteLine("");
             Console.WriteLine("");
             Console.WriteLine("");
             Console.WriteLine("-------------------------------------------------------------------------------------------------");
             Console.WriteLine("");
             Console.WriteLine("File Was Succesfully Opened (Not Read Because Of File Emptiness)");
             Console.ReadLine();
         }
         if (firstLine[0] == '*')
         {
             if (firstLine[1] == '*')
             {
         
                 Console.WriteLine("File Is Password Protected");
                 Console.Write("Password>> ");
                 string PasswordInput = Console.ReadLine();
         
                 if (firstLine.Remove(0, 2) == PasswordInput)
                 {
                     ReadFile(path + file_name + ".txt", 1);
                     fr.Close();
                 }
         
             }
             else { ReadFile(path + file_name + ".txt", 0);}
         
         }
         else { ReadFile(path + file_name + ".txt", 0);}
    }    

    // This Function Is Called Only When a User Wants To 
    // a File, Not When a File Will Be Created Or Opened
    // There Is Already Functions For Those Actions
    static void WriteToFile(string path, string file_name)
    { 
        // This Bit Of Code
        Console.Clear();
        Console.WriteLine("Write What You Want Line For Line");
        Console.WriteLine("");
        Console.WriteLine("And When You Are Done, Type !quit!");
        Console.WriteLine();
        try
        {
            var contentsToWrite = new List<string>();
            for (int i = 1; i < 1000; i++)
            {
                if (i < 10)
                {
                    Console.Write("line " + i + "  >>");
                }
                if (i > 9)
                {
                    Console.Write("line" + i + "  >>");
                }

                string fileInput = Console.ReadLine();
                if (fileInput == "!quit!")
                {
                    i = 1000;
                    break;
                }
                if (fileInput == "" || fileInput == " " || fileInput == null)
                {
                    contentsToWrite.Add(" ");
                }
                else
                {
                    contentsToWrite.Add(fileInput);
                }
            }

            // This Do While Will Run Until The User 
            // Is Happy With Their Text
            bool fileEdit = true;
            do
            {
                int lineNumber = 1;
                Console.Clear();
                Console.WriteLine("This Is How Your File Will Look Like");
                Console.WriteLine("");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("");
                Console.WriteLine("");
                foreach (string content in contentsToWrite)
                {

                    if (lineNumber < 10)
                    {
                        Console.Write("Line " + lineNumber++ + "  | ");
                    }
                    else
                    {
                        Console.Write("Line" + lineNumber++ + "  | ");
                    }
                    Console.WriteLine(content);
                }

                lineNumber = 1;
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Are You Satisfied With Your Text?");
                Console.WriteLine("");
                Console.Write(">>");
                string happyWithText = Console.ReadLine();

                if (happyWithText == "yes")
                {
                    StreamWriter sw = new StreamWriter(path + file_name + ".txt");
                    foreach (string line in contentsToWrite)
                    {
                        sw.WriteLine(line);
                    }
                    sw.Close();
                    fileEdit = false;
                    Main();
                }

                if (happyWithText == "no")
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    foreach (string content in contentsToWrite)
                    {

                        if (lineNumber < 10)
                        {
                            Console.Write("Line " + lineNumber++ + "  | ");
                        }
                        else
                        {
                            Console.Write("Line" + lineNumber++ + " | ");
                        }
                        Console.WriteLine(content);
                    }

                    Console.WriteLine("-------------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Write The Line Number Of The Text String You Wanna Change");
                    Console.WriteLine("");
                    Console.Write(">>");
                    string whatLineNumberToChange = Console.ReadLine();

                    bool validAnswer = false;
                    // This Loop Will Run Until The User Writes a Valid Input
                    while (!validAnswer)
                    {
                        try
                        {
                            int whatLineNumberToChangeConv = Convert.ToInt32(whatLineNumberToChange);
                            Console.Clear();
                            Console.WriteLine("Line " + whatLineNumberToChange + " | " + contentsToWrite[whatLineNumberToChangeConv]);
                            Console.WriteLine("");
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            Console.WriteLine("What You Type Below Will Completly Replace The Line You Selected");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("");
                            Console.Write(">>");
                            contentsToWrite[whatLineNumberToChangeConv] = Console.ReadLine();

                        }
                        catch (FormatException)
                        {
                            Console.Clear();
                            Console.Write("Input Must Be an ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Integer");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("!");
                            Console.WriteLine("");
                            Console.Clear();
                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            foreach (string content in contentsToWrite)
                            {

                                if (lineNumber < 10)
                                {
                                    Console.Write("Line " + lineNumber++ + "  | ");
                                }
                                else
                                {
                                    Console.Write("Line" + lineNumber++ + " | ");
                                }
                                Console.WriteLine(content);
                            }
                            lineNumber = 1;

                            Console.WriteLine("-------------------------------------------------");
                            Console.WriteLine("");
                            Console.Write("Now Please Write A ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Number");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(", And Only A ");
                            Console.ForegroundColor = ConsoleColor.DarkRed;
                            Console.Write("Number");
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine(" This Time");
                            Console.WriteLine("");
                            Console.Write(">>");
                            whatLineNumberToChange = Console.ReadLine();


                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("Something else broke");
                            Console.WriteLine("");
                            Console.WriteLine(e);
                            break;
                        }
                    }



                }
            // This Do While Runs Until The User Is Done With Their Text
            } while (fileEdit);


        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    static void CreateFile(string path)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("");
        Console.WriteLine("Here's A List Of The Currently Existing Files");
        Console.WriteLine("");
        Console.WriteLine("------------------------------------------------------");

        string[] fileList = Directory.GetFiles(path);

        
        foreach ( string file in fileList )
        {
            FileInfo fi = new FileInfo(file);
            if (fi.Extension == ".txt")
            {
                Console.Write(file);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" << Complete Path");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write(fi.Name);
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine(" << Name");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("");
            }
        }
        

        Console.WriteLine("------------------------------------------------------");
        Console.WriteLine("");
        Console.WriteLine("What Name Should Your Text File Have?");
        Console.WriteLine("");
        Console.Write(">>");

        string CreatedFileName = Console.ReadLine();
        while (File.Exists(path + CreatedFileName + ".txt"))
        {
            if (File.Exists(path + CreatedFileName + ".txt"))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("A File With That Name Already Exists");
                Console.WriteLine("");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("------------------------------------------------------");

                foreach (string file in fileList)
                {
                    FileInfo fi = new FileInfo(file);
                    if (fi.Extension == ".txt")
                    {
                        Console.Write(file);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(" << Complete Path");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(fi.Name);
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine(" << Name Of Text File");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("");
                    }
                }

                Console.WriteLine("------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("");
                Console.WriteLine("Please Choose A Name That Doesnt Match The List");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("");
                Console.Write(">>");
                CreatedFileName = Console.ReadLine();
            }
        }
        try
        {
            FileStream fs = File.Create(path + CreatedFileName + ".txt");
            Console.Clear();
            Console.WriteLine("Complete List Of Text Files In Directory");
            Console.WriteLine("");
            Console.WriteLine("Including Yours");
            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("");
            string[] fileListAfterNewFile = Directory.GetFiles(path);


            foreach (string file in fileListAfterNewFile)
            {
                FileInfo fi = new FileInfo(file);
                if (fi.Extension == ".txt")
                {
                    if (fi.Name == CreatedFileName + ".txt")
                    {
                        Console.Write(fi.Name + " ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine("<< New File");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    if (fi.Name != CreatedFileName + ".txt")
                    {
                        Console.WriteLine(fi.Name);
                    }

                }
            }

            Console.WriteLine("");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Your File '" + CreatedFileName + "' Was Succesfully Created");
            fs.Close();

            Console.WriteLine("");
            Console.WriteLine("Would You Like To Write Something To The File?");
            Console.WriteLine("");
            Console.Write(">>");
            string WriteToNewFile = Console.ReadLine();
            bool runYNloop = true;
            do
            {
                if (WriteToNewFile?.ToLower() == "yes" || WriteToNewFile?.ToLower() == "y" || WriteToNewFile?.ToLower() == "ja")
                {
                    WriteToFile(path, CreatedFileName);
                    runYNloop = false;
                }
                if (WriteToNewFile?.ToLower() == "no" || WriteToNewFile?.ToLower() == "n" || WriteToNewFile?.ToLower() == "nej")
                {
                    Main();
                    runYNloop = false;
                }
                else
                {
                    Console.Clear();
                    Console.Write("'");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(WriteToNewFile);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("' Is Neither a");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Write(" Yes ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("or a ");
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("No");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("");
                    Console.WriteLine("Answer With a Correct Answer");
                    Console.WriteLine("");
                    Console.Write(">>");
                    WriteToNewFile = Console.ReadLine();

                }
            } while (runYNloop);

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Broke :(");
            Console.WriteLine(e.Message);
        }

    }

    static void Main()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        string path = @"C:\\Users\\william.ostling1\\Documents\\textFiles\\";

        try
        {
            Console.WriteLine("Would You Like To Create A File Or Open One");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Note That Interacted Files Will Be Found In The Directory Documents");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine();
            Console.WriteLine("To Quit, Just Write Quit");
            Console.WriteLine("");
            Console.Write(">>");
            string action = Console.ReadLine();

            bool actionModeBool = false;
            while (actionModeBool != true)
            {
                switch (action)
                {
                    case "open": OpenFile(path); actionModeBool = true; break;

                    case "open file": OpenFile(path); actionModeBool = true; break;

                    case "create": CreateFile(path); actionModeBool = true; break;

                    case "create file": CreateFile(path); actionModeBool = true; break;

                    case "quit": Environment.Exit(0); break;

                    default:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("You Can Only Choose Between Either 'Open File' or 'Create File'");
                        Console.WriteLine("");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write(">>");
                        action = Console.ReadLine();
                        actionModeBool = false;
                        break;

                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}