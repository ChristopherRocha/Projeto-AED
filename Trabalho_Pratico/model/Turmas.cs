using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Pratico
{
    public class Turmas
    {
        
        private List<Candidatos> aluno;
        
        private Cursos curso; 
        public Cursos Curso { get { return curso; } set { curso = value; } } 

        private Fila filaAluno; 
        public Fila FilaAluno { get { return filaAluno; } set { filaAluno = value; } }

        private Fila filaEspera;
        public Fila FilaEspera { get { return filaEspera; } set { filaEspera = value; } }

        private double notaCorte;
        public double NotaCorte { get { return notaCorte; } set { notaCorte = value; } }


        public Turmas(List<Candidatos> aluno, Cursos curso)
        {
            this.aluno = aluno;
            this.curso = curso;
            filaAluno = new Fila();
            filaEspera = new Fila();
        }

        

        public void AjustarTurma()
        {
            for (int i = 0; i < aluno.Count; i++)
            {
                if(i < Curso.QuantidadeVagas)
                {
                    filaAluno.Enqueue(aluno[i]);
                    notaCorte = aluno[i].NotaMedia;
                }
                else
                {
                    filaEspera.Enqueue(aluno[i]);
                }
                
            }
        }


        
        public void MostrarTurma()
        {
            curso.MostarCurso();
            Console.WriteLine("Nota de corte "+notaCorte);
            Console.WriteLine("Fila de selecionados: ");
            filaAluno.Show();
            Console.WriteLine("\nFila de espera: ");
            filaEspera.Show();
        }
    }
}

