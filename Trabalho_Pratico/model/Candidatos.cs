using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Pratico
{
    public class Candidatos
    {
        private string nome;
        public string Nome { get { return nome; } set { nome = value; } }

        private double notaRedacao;
        public double NotaRedacao { get { return notaRedacao; } set { notaRedacao = value; } }

        private double notaMatematica;
        public double NotaMatematica { get { return notaMatematica; } set { notaMatematica = value; } }

        private double notaLinguagens;
        public double NotaLinguagens { get { return notaLinguagens; } set { notaLinguagens = value; } }

        private double notaMedia;
        public double NotaMedia { get { return notaMedia; } set { notaMedia = value; } }

        private int primeiraOpcao;
        public int PrimeiraOpcao { get { return primeiraOpcao; } set { primeiraOpcao = value; } }

        private int segundaOpcao;
        public int SegundaOpcao { get { return segundaOpcao; } set { segundaOpcao = value; } }

        private bool cursando = false;
        public bool Cursando { get { return cursando; } set { cursando = value; } }

        public Candidatos(string nome, double notaRedacao, double notaMatematica, double notaLinguagens, int primeiraOpcao, int segundaOpcao)
        {
            this.nome = nome;
            this.notaRedacao = notaRedacao;
            this.notaMatematica = notaMatematica;
            this.notaLinguagens = notaLinguagens;
            this.primeiraOpcao = primeiraOpcao;
            this.segundaOpcao = segundaOpcao;
        }

        public void TirarMedia()
        {
            double soma = notaMatematica + notaLinguagens + notaRedacao;
            notaMedia = soma / 3;
        }

        public void MostarCandidatos()
        {
            Console.WriteLine("----------X----------");
            Console.WriteLine("Nome: " + nome);
            Console.WriteLine("Nota redação: " + notaRedacao);
            Console.WriteLine("Nota matemática: " + notaMatematica);
            Console.WriteLine("Nota Linguagens: " + notaLinguagens);
            Console.WriteLine("Nota Média: " + notaMedia);
            Console.WriteLine("Primeira opção de curso: " + primeiraOpcao);
            Console.WriteLine("Segunda opção de curso: " + segundaOpcao);
            Console.WriteLine("Aprovado na primeira opção de curso: " + cursando);
        }
    }
}