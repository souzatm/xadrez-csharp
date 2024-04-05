using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XadrezConsole.Jogo;

namespace XadrezConsole.Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno { get; private set; }
        public Cor jogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> Capturadas;

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            jogadorAtual = Cor.Branca;
            Terminada = false;
            Pecas = new HashSet<Peca>();
            Capturadas = new HashSet<Peca>();
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = Tabuleiro.retirarPeca(destino);
            Tabuleiro.colocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                Capturadas.Add(pecaCapturada);
            }
        }

        public void realizaJogada(Posicao origem, Posicao destino)
        {
            executaMovimento(origem,destino);
            Turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao origem)
        {
            if (Tabuleiro.mostraPeca(origem) == null)
            {
                throw new TabuleiroException("Não existe peça na posição escolhida!");
            }
            if(jogadorAtual != Tabuleiro.mostraPeca(origem).Cor)
            {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }
            if (!Tabuleiro.mostraPeca(origem).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.mostraPeca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida!");
            }
        }

        private void mudaJogador()
        {
            if(jogadorAtual == Cor.Branca)
            {
                jogadorAtual = Cor.Preta;
            }
            else
            {
                jogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.colocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }

        private void colocarPecas()
        {
            colocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));

            colocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
            colocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
            colocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
            colocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta));

        }
    }
}
