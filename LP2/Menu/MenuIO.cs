using System;
using System.IO;
using IncendioInput;
using IncendioBR;
using System.Threading;

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
                //Console.ReadLine();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public static void UserInterface()
        {
            WriteMenu();
            int opcao = int.Parse(Console.ReadLine());
            switch (opcao)
            {
                case 1:
                    IncendioInputs.CriarIncendio();
                    IncendioRegras.MostraIncendios();
                    
                    break;
                case 2:
                    IncendioInputs.AlterarHoraFimIncendio();
                    break;
                case 3:
                    IncendioInputs.RemoveIncendio();
                    break;
                    



                case 8:
                    IncendioRegras.MostraIncendios();
                    break;
                case 30:
                    Console.Clear();
                    break;

                default:
                    break;
            }

            
            UserInterface();
        }

    }
}
