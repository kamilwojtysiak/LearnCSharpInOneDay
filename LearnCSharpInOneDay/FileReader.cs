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
                

                streamReader.Close();
            }

        }
    }
}
