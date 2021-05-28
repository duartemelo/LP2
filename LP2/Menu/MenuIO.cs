using System;
using System.IO;

namespace Menu
{
    public class MenuIO
    {
        public static void WriteMenu()
        {
            try
            {
                //read from file
                StreamReader sr = new StreamReader("menu.txt");
                string line = sr.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
