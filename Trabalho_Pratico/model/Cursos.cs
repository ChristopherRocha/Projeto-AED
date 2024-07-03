using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Pratico
{
    public class Cursos
    {
        private string nome; 
        public string Nome { get { return nome; } set { nome = value; } }

        private int codigoCurso; 
        public int CodigoCurso { get { return codigoCurso; } set { codigoCurso = value; } }

        private int quantidadeVagas;
        public int QuantidadeVagas { get { return quantidadeVagas; } set { quantidadeVagas = value; } }

        

        public Cursos(string nome, int codigoCurso, int quantidadeVagas)
        {
            this.codigoCurso = codigoCurso;
            this.nome = nome;
            this.quantidadeVagas = quantidadeVagas;
        }

        public List<Candidatos> DefinirCursando(List<Candidatos> aluno)
        {
            int countAux = 0;
            for(int i = 0; i< aluno.Count; i++)
            {
                if (aluno[i].PrimeiraOpcao == codigoCurso && countAux < quantidadeVagas)
                {
                    aluno[i].Cursando = true;
                    countAux++;
                }
            }
            return aluno;
        }
        public void MostarCurso()
        {
            Console.WriteLine("----------X----------");
            Console.WriteLine("Código Curso: " + codigoCurso);
            Console.WriteLine("Nome do curso: " + nome);
            Console.WriteLine("Quantidade de vagas: " + quantidadeVagas);
        }
    }
}
