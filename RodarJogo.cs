using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace JogoDaForca
{
    class RodarJogo
    {

        /// <summary>
        /// Inicia o jogo e faz todos os tratamentos.
        /// </summary>
        /// <param name="palavraSelecionada"></param>
        public static void RodaJogo(Array palavraSelecionada)
        {
            List<char> palavraSecreta = new List<char>();
            Console.Clear();
            var tentativas = 0;
            var escreverPalavra = 0;
            var letraEscolhida = '0';
            try
            {
                CriaArrayPalavraSecreta(palavraSelecionada, palavraSecreta);
                for (tentativas = 5; tentativas > 0; tentativas--)
                {
                    Console.Clear();
                    Console.WriteLine($"Você tem {tentativas} {(tentativas > 1 ? "tentativas" : "tentativa")} {(tentativas > 1 ? "restantes" : "restante")} ");

                    // Valido se a palavra secreta já foi criada
                    if (palavraSecreta.Count != 0)
                        PrintaPalavraSecreta(palavraSecreta);

                    Console.WriteLine("Digite a letra escolhida:");
                    letraEscolhida = Convert.ToChar(Console.ReadLine().ToUpper());
                    string palavraEmString = TransformaEmString(palavraSelecionada);
                    // Se a letra escolhida existir ele entra aqui
                    if (palavraEmString.Contains(letraEscolhida.ToString()))
                    {
                        Console.Clear();
                        AlteraPalavraSecreta(palavraEmString, palavraSecreta, letraEscolhida);
                        Console.WriteLine("Acertou a letra!");
                        PrintaPalavraSecreta(palavraSecreta);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Errou!");
                        PrintaPalavraSecreta(palavraSecreta);


                    }
                    Thread.Sleep(2500);

                    // Valido se a pessoa conseguiu completar toda a palavra enquanto ainda tem tentativas
                    if (TransformaEmString(palavraSecreta) == TransformaEmString(palavraSelecionada))
                    {
                        Console.Clear();
                        Console.WriteLine("Parabéns, você conseguiu acertar a palavra!");
                        Console.WriteLine(TransformaEmString(palavraSelecionada));
                        Thread.Sleep(3000);
                        System.Environment.Exit(0);
                    }

                    if(tentativas == 1)
                    {
                        MenuFinal(palavraSecreta, palavraSelecionada);
                    }

                }

            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("Digite apenas uma letra!");
                Thread.Sleep(3000);
                RodaJogo(palavraSelecionada, tentativas, palavraSecreta);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
        }
        // Eu criei essa sobrecarga para conseguir manter o histórico do jogo quando o usuário gerasse alguma exception
        public static void RodaJogo(Array palavraSelecionada, int tentativaAnterior, List<char> palavraSecreta)
        {
            Console.Clear();
            var tentativas = 0;
            var letraEscolhida = '0';
            try
            {
                CriaArrayPalavraSecreta(palavraSelecionada, palavraSecreta);
                for (tentativas = tentativaAnterior; tentativas > 0; tentativas--)
                {
                    Console.Clear();
                    Console.WriteLine($"Você tem {tentativas} {(tentativas > 1 ? "tentativas" : "tentativa")} {(tentativas > 1 ? "restantes" : "restante")} ");

                    // Valido se a palavra secreta já foi criada
                    if (palavraSecreta.Count != 0)
                        PrintaPalavraSecreta(palavraSecreta);

                    Console.WriteLine("Digite a letra escolhida:");
                    letraEscolhida = Convert.ToChar(Console.ReadLine().ToUpper());
                    string palavraEmString = TransformaEmString(palavraSelecionada);
                    // Se a letra escolhida existir ele entra aqui
                    if (palavraEmString.Contains(letraEscolhida.ToString()))
                    {
                        Console.Clear();
                        AlteraPalavraSecreta(palavraEmString, palavraSecreta, letraEscolhida);
                        Console.WriteLine("Acertou a letra!");
                        PrintaPalavraSecreta(palavraSecreta);
                        Thread.Sleep(2000);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Errou!");
                        PrintaPalavraSecreta(palavraSecreta);


                    }
                    Thread.Sleep(2500);

                    // Valido se a pessoa conseguiu completar toda a palavra enquanto ainda tem tentativas
                    if (TransformaEmString(palavraSecreta) == TransformaEmString(palavraSelecionada))
                    {
                        Console.Clear();
                        Console.WriteLine("Parabéns, você conseguiu acertar a palavra!");
                        Console.WriteLine(TransformaEmString(palavraSelecionada));
                        Thread.Sleep(3000);
                        System.Environment.Exit(0);
                    }

                    if (tentativas == 1)
                    {
                        MenuFinal(palavraSecreta, palavraSelecionada);
                    }

                }

            }
            catch (FormatException e)
            {
                Console.Clear();
                Console.WriteLine("Digite apenas uma letra!");
                Thread.Sleep(3000);
                RodaJogo(palavraSelecionada, tentativas, palavraSecreta);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.GetType());
            }
        }
        public static void MenuFinal(List<char> palavraSecreta, Array palavraSelecionada)
        {
            var escreverPalavra = 0;
            Console.Clear();
            Console.WriteLine("Suas tentativas acabaram!");
            PrintaPalavraSecreta(palavraSecreta);
            Console.WriteLine("1 - Eu sei a palavra!");
            Console.WriteLine("2 - Não sei a palavra");

            try
            {
                escreverPalavra = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.WriteLine("Digite o número de uma das opções!");
                Thread.Sleep(2000);
                MenuFinal(palavraSecreta, palavraSelecionada);
            }

            

            switch (escreverPalavra)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("Digite a palavra:");
                        PrintaPalavraSecreta(palavraSecreta);
                        string chutePalavra = Console.ReadLine();
                        Console.WriteLine(chutePalavra.ToUpper());
                        if (TransformaEmString(palavraSelecionada) == (chutePalavra.ToUpper()))
                        {
                            Console.Clear();
                            Console.WriteLine("Parabéns, você acertou!");
                            Console.WriteLine($"A palavra era: {TransformaEmString(palavraSelecionada)}");
                            Thread.Sleep(2000);
                            break;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Infelizmente, você não acertou");
                            Console.WriteLine($"Você escreveu {chutePalavra}, e a palavra era {TransformaEmString(palavraSelecionada)}");
                            Thread.Sleep(6000);
                            break;
                        }
                    }
                case 2:
                    {
                        Console.Clear();
                        Console.WriteLine($"A palavra era {TransformaEmString(palavraSelecionada)}");
                        Console.WriteLine("Obrigado por jogar!");
                        Thread.Sleep(2000);
                        break;
                    }
                default: Console.Clear(); Console.WriteLine("Opção de valor inválida!"); Thread.Sleep(2000); MenuFinal(palavraSecreta, palavraSelecionada); break;
            }
        }
        public static void Menu( Array palavraSelecionada)
        {
            int opcao = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Bem vindo ao jogo da forca!");
                Console.WriteLine("Digite a opção que você deseja:");
                Console.WriteLine("1 - Iniciar jogo");
                Console.WriteLine("2 - Sair do jogo");

                try
                {
                    opcao = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Console.Clear();
                    Console.WriteLine("Digite um valor válido!");
                    Thread.Sleep(2000);
                    Menu(palavraSelecionada);
                }

                switch (opcao)
                {
                    case 1: RodaJogo(palavraSelecionada); break;
                    case 2: Console.WriteLine("Saindo do sistema..."); Thread.Sleep(1000); System.Environment.Exit(0); break;
                    default: Console.Clear(); Console.WriteLine("Valor inválido. tente novamente!"); Thread.Sleep(2000); break;
                }




            } while (opcao != 2);
        }
        public static void CriaListaPalavras(List<Array> listaDePalavras)
        {
            listaDePalavras.Add("Fernandinho".ToUpper().ToCharArray());
            listaDePalavras.Add("Caneca".ToUpper().ToCharArray());
            listaDePalavras.Add("Trombeta".ToUpper().ToCharArray());
            listaDePalavras.Add("Shampoo".ToUpper().ToCharArray());
            listaDePalavras.Add("Caminhonete".ToUpper().ToCharArray());
            listaDePalavras.Add("Dinossauro".ToUpper().ToCharArray());
            listaDePalavras.Add("Prateado".ToUpper().ToCharArray());
            listaDePalavras.Add("Folheado".ToUpper().ToCharArray());
            listaDePalavras.Add("Cachaça".ToUpper().ToCharArray());
        }
        public static int SelecionaPalavra(List<Array> listaPalavras)
        {
            int indice = 0;
            Random random = new Random();

            indice = random.Next(listaPalavras.Count);

            return indice;
        }
        public static string TransformaEmString(Array palavraSelecionada)
        {
            StringBuilder palavraStB = new StringBuilder();
            for (int i = 0; i < palavraSelecionada.Length; i++)
            {
                palavraStB.Append(palavraSelecionada.GetValue(i));
            }
            return palavraStB.ToString();
        }
        public static string TransformaEmString(List<char> palavraSecreta)
        {
            StringBuilder palavraStB = new StringBuilder();
            for (int i = 0; i < palavraSecreta.Count;)
            {
                palavraStB.Append(palavraSecreta.ElementAt(i));
                i += 2;
            }
            return palavraStB.ToString();
        }
        public static void CriaArrayPalavraSecreta(Array palavraSelecionada, List<char> palavraSecreta)
        {
            // Aqui eu valido se o array da palavra secreta já foi preenchido
            if (palavraSecreta.Count() == 0)
            {
                for (int i = 0; i < palavraSelecionada.Length; i++)
                {
                    palavraSecreta.Add('_');
                    palavraSecreta.Add(' ');
                }

                palavraSecreta.RemoveAt(palavraSecreta.LastIndexOf(' '));
            }
        }
        public static void PrintaPalavraSecreta(List<char> palavraSecreta)
        {
            Console.WriteLine("");
            for (int i = 0; i < palavraSecreta.Count; i++)
            {
                Console.Write(palavraSecreta.ElementAt(i));
            }
            Console.WriteLine($" ({TransformaEmString(palavraSecreta).Replace(" ", "").Length} letras)");
            Console.WriteLine("");
        }
        public static void AlteraPalavraSecreta(string palavraSelecionada, List<char> palavraSecreta, char letraEscolhida)
        {
            int i = 0;
            for (int a = 0; a < palavraSelecionada.Length; a++)
            {

                if (palavraSelecionada[a] == letraEscolhida)
                {
                    palavraSecreta[i] = palavraSelecionada[a];
                }

                i += 2;
            }

        }
    }
}
