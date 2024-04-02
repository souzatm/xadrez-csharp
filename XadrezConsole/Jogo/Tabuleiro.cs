using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XadrezConsole.Jogo
{
    class Tabuleiro
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }

        private Peca[,] Pecas;

        public Tabuleiro(int linhas, int colunas)
        {
            Linhas = linhas;
            Colunas = colunas;
            Pecas = new Peca[Linhas, Colunas];
        }

        public Peca mostraPeca(int linha, int coluna) 
        { 
            return Pecas[linha, coluna];
        }

        public void colocarPeca(Peca p, Posicao posicao)
        {
            Pecas[posicao.Linha, posicao.Coluna] = p;
            p.Posicao = posicao;
        }
    }
}
