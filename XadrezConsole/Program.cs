using XadrezConsole.Jogo;
using XadrezConsole.Xadrez;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Tabuleiro tabuleiro = new Tabuleiro(8, 8);

                tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0,0));
                tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 5));
                tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(0, 2));

                tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(5, 3));
                tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new Posicao(2, 7));
                tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Branca), new Posicao(4, 5));

                Tela.imprimirTabuleiro(tabuleiro);
            }
            catch (TabuleiroException ex) 
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }
    }
}