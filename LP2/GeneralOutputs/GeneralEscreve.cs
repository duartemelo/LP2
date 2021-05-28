/**
 * Nome: Duarte Ribeiro de Melo
 * E-mail: a21149@alunos.ipca.pt
*/

using System;

namespace GeneralOutputs
{
    /// <summary>
    /// Class / Library que é responsável por outputs gerais.
    /// Feito para manter o código consistente, os outputs nos sítios onde devem estar (separados das funções).
    /// Possivelmente será obsoleta com criação de exceptions.
    /// </summary>
    public class GeneralEscreve
    {
        /// <summary>
        /// Escreve uma mensagem de erro
        /// </summary>
        /// <param name="erro">Erro a imprimir</param>
        public static void EscreveErro(string erro)
        {
            Console.WriteLine("Erro! " + erro);
        }
    }
}
