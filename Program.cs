using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static JogoDaForca.RodarJogo;


// A ideia principal é de criar um jogo da forca
/* O que ele precisa fazer:
 * Ter um conjunto de palavras pre definidas
 * O usuário ter algo em torno de 6 / 7 tentativas
 * Mostrar no console algo mais ou menos assim ( A palavra sendo biscoito )
 * 
 * 3 tentativas restantes
 * b _ s _ _ _ _ _ 
 * Digite a sua tentativa:
 * 
 * Para isso eu precisaria:
 * Guardar a palavra da forca em um array
 * Mostrar na tela a quantidade de letras em underlines
 * Iterar o array da palavra e comparar com a letra que o usuário digitar
 * 
 * 
*/
namespace JogoDaForca
{
    class Program
    {
        static void Main(string[] args)
        {
            // Aqui eu crio a lista de palavras e adiciono as palavras pré-selecionadas
            var listaDePalavras = new List<Array>();
            CriaListaPalavras(listaDePalavras);
            Menu(listaDePalavras[SelecionaPalavra(listaDePalavras)]);

            // De início eu dividi em outra classe porque não tava conseguindo criar a classe aqui
            // Mas agora é mais por organização
            
            




        }
    }
}
