using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficha_3
{
    class Program
    {
        static void Main(string[] args)
        {
            string equacao = "1 + (5 + 3 - (8 - 5) * 4 - ((3 + 7) * (3 - 1)))";
            string texto = "Uma atividade livre, conscientemente tomada como 'não-séria' e exterior à vida habitual, mas ao mesmo tempo capaz de absorver o jogador de maneira intensa e total. É uma atividade desligada de todo e qualquer interesse material, com a qual não se pode obter qualquer lucro, praticada dentro de limites espaciais e temporais próprios, segundo uma certa ordem e certas regras. Promove a formação de grupos sociais com tendência a rodearem-se de segredo e a sublinharem sua diferença em relação ao resto do mundo por meio de disfarces ou outros meios semelhantes.";

            string[] separado = texto.ToLower().Split(new string[] { ",", ".", "'", " " }, StringSplitOptions.RemoveEmptyEntries);
            char[] expressao = equacao.ToCharArray();

            List<string> lista = Contagem(separado);
            Console.WriteLine(lista.Count);
            Console.ReadKey();
            ContagemRepeticao(separado, lista);
            Console.ReadKey();
            Console.WriteLine("A estrutura de pilha pode ser usada para validar estruturas de expressões numéricas");
            VerificarParenteses(expressao);
            Console.ReadKey();

        }

        public static List<string> Contagem(string[] separado)
        {
            bool Diferente = true;
            string Comparar;
            int Contador = 1;
            List<string> Palavras = new List<string>();

            for (int i = 0; i < separado.Length; i++)
            {
                if (Contador == 1)
                {
                    Palavras.Add(separado[i]);
                }
                else
                {
                    Comparar = separado[i];

                    for (int j = 0; j < Contador - 1; j++) 
                    {
                        if (Comparar == separado[j])
                        {
                            Diferente = false;
                        }
                    }
                    if (Diferente) 
                    {
                        Palavras.Add(Comparar);
                    }
                    Diferente = true;
                }
                Contador++;
            }
            return Palavras;

        }
        public static void ContagemRepeticao(string[] separado, List<string> Palavras)
        {
            int repete = 0; 

            for (int i = 0; i < Palavras.Count; i++)     
            {
                for (int j = 0; j < separado.Length; j++)
                {
                    if (Palavras[i] == separado[j])
                    {
                        repete++;
                    }
                }

                Console.WriteLine(Palavras[i] + " " + repete);
                repete = 0;
            }
        }
        public static void VerificarParenteses(char[] expressao)
        {
            Stack<char> pilha = new Stack<char>();

            for (int i = 0; i < expressao.Length; i++)
            {
                if (pilha.Count == 0 && expressao[i] == '(')
                {
                    pilha.Push(expressao[i]);
                    Console.Write(expressao[i]);
                }
                else if (pilha.Count == 0 && expressao[i] == ')')
                {
                    Console.WriteLine("Os parênteses estão incorretos!!!");
                }
                else if (expressao[i] == '(' || expressao[i] == ')')
                {
                    if (pilha.Peek() == '(' && expressao[i] == ')')
                    {
                        pilha.Pop();
                        Console.Write(expressao[i]);
                    }
                    else if (pilha.Peek() == '(' && expressao[i] == '(')
                    {
                        pilha.Push(expressao[i]);
                        Console.Write(expressao[i]);
                    }
                }
            }

            if (pilha.Count == 0)
            {
                Console.WriteLine();
                Console.WriteLine("Os parênteses estão corretos!!!");
            }
        }
    }
}
