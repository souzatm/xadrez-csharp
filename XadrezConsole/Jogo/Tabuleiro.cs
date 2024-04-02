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

        public Peca mostraPeca(Posicao posicao)
        {
            return Pecas[posicao.Linha, posicao.Coluna];
        }

        public bool existePeca(Posicao posicao)
        {
            validarPosicao(posicao);
            return mostraPeca(posicao) != null;
        }

        public void colocarPeca(Peca p, Posicao posicao)
        {
            if (existePeca(posicao))
            {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }
            Pecas[posicao.Linha, posicao.Coluna] = p;
            p.Posicao = posicao;
        }

        public bool posicaoValida(Posicao posicao)
        {
            if (posicao.Linha <0 || posicao.Linha >= Linhas || posicao.Coluna < 0 || posicao.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void validarPosicao(Posicao posicao)
        {
            if (!posicaoValida(posicao))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}
