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
                case 10:
                    IncendioInputs.CriarIncendio();
                    IncendioRegras.MostraIncendios();
                    
                    break;
                case 11:
                    IncendioInputs.AlterarHoraFimIncendio();
                    break;
                case 12:
                    IncendioInputs.RemoveIncendio();
                    break;
                case 13:
                    IncendioInputs.AdicionaOperacional();
                    break;
                case 14:
                    IncendioInputs.RemoveOperacional();
                    break;
                case 15:
                    IncendioInputs.MostraInformacoesIncendio(); //missing exception! se tentar ver quando nao ha incendios!
                    break;
                case 16:
                    IncendioRegras.MostraIncendios();
                    break;


                //tests
                case 30:
                    Console.Clear();
                    break;
                case 31:
                    Environment.Exit(0);
                    break;

                default:
                    break;
            }

            
            UserInterface();
        }

    }
}
