using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace LearnCSharpInOneDay
{
    public class FileReader
    {
        public List<Staff> ReadFile()
        {
            List<Staff> myStaff = new List<Staff>();
            string[] result = new string[2];
            string path = "staff.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                StreamReader streamReader = new StreamReader(path);

                while (streamReader.EndOfStream != true)
                {
                    result = streamReader.ReadLine().Split(separator, StringSplitOptions.None);

                    if (result[1] == "Manager")
                    {
                        myStaff.Add(new Manager(result[0]));
                    }
                    if (result[1] == "Admin")
                    {
                        myStaff.Add(new Admin(result[0]));
                    }
                }
            }
            else
            {
                Console.WriteLine("ERROR - file doesen't exist");
            }

            return myStaff;
        }
    }
}
