/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

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
    /// <summary>
    /// Class responsável por escrever o menu a partir de um ficheiro
    /// Responsável também por obter a opção do user e chamar funções de "cada objeto" que interagem com o user.
    /// </summary>
    public class MenuIO
    {
        /// <summary>
        /// Escreve o menu a partir do ficheiro menu.txt
        /// </summary>
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

        /// <summary>
        /// Obtém a opção escolhida pelo user, a partir daí, chama funções front-end dos objetos respetivos.
        /// Recursiva.
        /// </summary>
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
                    OperacionalInputs.InativarOper();
                    break;
                case 11:
                    OperacionalRegras.MostraOperacionais();
                    break;

                //VIATURAS

                case 12:
                    ViaturaInputs.CriarViatura();
                    break;
                case 13:
                    ViaturaInputs.RemoveViatura();
                    break;
                case 14:
                    ViaturaInputs.AdicionarViaturaIncendio();
                    break;
                case 15:
                    ViaturaRegras.MostraViaturas();
                    break;
                //INCENDIOS

                case 16:
                    IncendioInputs.CriarIncendio();
                    //IncendioRegras.MostraIncendios();
                    
                    break;
                case 17:
                    IncendioInputs.AlterarHoraFimIncendio();
                    break;
                case 18:
                    IncendioInputs.RemoveIncendio();
                    break;
                case 19:
                    IncendioInputs.AdicionaOperacional();
                    break;
                case 20:
                    IncendioInputs.RemoveOperacional();
                    break;
                case 21:
                    IncendioInputs.MostraInformacoesIncendio(); //missing exception! se tentar ver quando nao ha incendios!
                    break;
                case 22:
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
