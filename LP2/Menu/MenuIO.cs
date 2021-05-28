using IncendioBR;
using IncendioInput;
using System;
using System.IO;
using CorporacaoBR;
using CorporacaoInput;
using OperacionalBR;
using OperacionalInput;
using ViaturaBR;
using ViaturaInput;

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

                //CORPORAÇOES
                case 1:
                    CorporacaoInputs.CriarCorporacao();
                    //CorporacaoRegras.MostraCorporacoes();
                    break;
                case 2:
                    CorporacaoInputs.RemoveCorporacao();
                    break;
                case 3:
                    CorporacaoRegras.MostraCorporacoes();
                    break;

               //OPERACIONAIS

                case 4:
                    OperacionalInputs.CriarOperacional();
                    break;
                case 5:
                    OperacionalInputs.RemoveOperacional();
                    break;
                case 6:
                    OperacionalInputs.AdicionarOperacionalACorp();
                    break;
                case 7:
                    OperacionalInputs.AlterarCargoOper();
                    break;
                case 8:
                    OperacionalInputs.AlterarSalarioOper();
                    break;
                case 9:
                    OperacionalInputs.RemoveOperacionalDeCorp();
                    break;
                case 10:
                    OperacionalRegras.MostraOperacionais();
                    break;

                //VIATURAS

                case 11:
                    ViaturaInputs.CriarViatura();
                    break;
                case 12:
                    ViaturaInputs.RemoveViatura();
                    break;
                case 13:
                    //to do 
                    break;
                case 14:
                    ViaturaRegras.MostraViaturas();
                    break;
                //INCENDIOS

                case 15:
                    IncendioInputs.CriarIncendio();
                    //IncendioRegras.MostraIncendios();
                    
                    break;
                case 16:
                    IncendioInputs.AlterarHoraFimIncendio();
                    break;
                case 17:
                    IncendioInputs.RemoveIncendio();
                    break;
                case 18:
                    IncendioInputs.AdicionaOperacional();
                    break;
                case 19:
                    IncendioInputs.RemoveOperacional();
                    break;
                case 20:
                    IncendioInputs.MostraInformacoesIncendio(); //missing exception! se tentar ver quando nao ha incendios!
                    break;
                case 21:
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
