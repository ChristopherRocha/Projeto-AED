using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Pratico
{
    public static class Operacoes
    {
        public static void LerArquivo(List<Candidatos> Candidato, List<Cursos> Curso, int[] cursoVagas)
        {
            string filePath = "C:\\Users\\chris\\OneDrive\\Área de Trabalho\\Trabalho_Pratico\\bin\\Debug\\net8.0\\entrada.txt";

            try
            {
                using (StreamReader lerArquivo = new StreamReader(filePath))
                {
                    string linha = lerArquivo.ReadLine();


                    while ((linha = lerArquivo.ReadLine()) != null)
                    {
                        string[] dados = linha.Split(';');

                        if (dados.Length == 2)
                        {
                            string[] curso = linha.Split(';');
                            cursoVagas[0] = int.Parse(curso[0]);
                            cursoVagas[1] = int.Parse(curso[1]);
                        }

                        else if (dados.Length == 3)
                        {
                            int codCurso = int.Parse(dados[0]);
                            string nomeCurso = dados[1];
                            int numVagas = int.Parse(dados[2]);

                            Cursos tmpCurso = new Cursos(nomeCurso, codCurso, numVagas);
                            Curso.Add(tmpCurso);


                        }

                        else if (dados.Length == 6)
                        {
                            string nomeCandidato = dados[0];
                            double notaRedacao = double.Parse(dados[1]);
                            double notaMatematica = double.Parse(dados[2]);
                            double notaLinguagens = double.Parse(dados[3]);
                            int primeiraOpcao = int.Parse(dados[4]);
                            int segundaOpcao = int.Parse(dados[5]);

                            Candidatos tmpCadidato = new Candidatos(nomeCandidato, notaRedacao, notaMatematica, notaLinguagens, primeiraOpcao, segundaOpcao);
                            Candidato.Add(tmpCadidato);
                        }
                    }
                }

                foreach (var candidato in Candidato)
                {
                    candidato.TirarMedia();
                }

            }

            catch (Exception erro)
            {
                Console.WriteLine("Ocorreu um erro: " + erro.Message);
            }
        }

        public static List<Candidatos> OrdenarCandidatos(List<Candidatos> candidatosLista)
        {
            Candidatos[] ordenarCandidatos;
            ordenarCandidatos = new Candidatos[candidatosLista.Count];


            for (int i = 0; i < candidatosLista.Count; i++)
            {
                ordenarCandidatos[i] = candidatosLista[i];
                ordenarCandidatos[i].TirarMedia();
            }


            QuickSort(ordenarCandidatos, 0, ordenarCandidatos.Length - 1);
            InsertionSort(ordenarCandidatos);

            for (int i = 0; i < candidatosLista.Count; i++)
            {
                candidatosLista[i] = ordenarCandidatos[i];
            }

            return candidatosLista;
        }


        public static void QuickSort(Candidatos[] candidatos, int esq, int dir)
        {

            double pivo = candidatos[(esq + dir) / 2].NotaRedacao;
            int i = esq, j = dir;
            while (i <= j)
            {
                while (candidatos[i].NotaRedacao < pivo)
                {
                    i++;
                }
                while (candidatos[j].NotaRedacao > pivo)
                {
                    j--;
                }
                if (i <= j)
                {
                    Swap(candidatos, i, j);
                    i++;
                    j--;
                }
            }

            if (esq < j)
            {
                QuickSort(candidatos, esq, j);
            }
            if (i < dir)
            {
                QuickSort(candidatos, i, dir);
            }

        }
        static void Swap(Candidatos[] vetor, int i, int j)
        {
            Candidatos tmp = vetor[i];
            vetor[i] = vetor[j];
            vetor[j] = tmp;
        }

        public static void InsertionSort(Candidatos[] candidatos)
        {
            int n = candidatos.Length;
            for (int i = 1; i < n; i++)
            {
                Candidatos tmp = candidatos[i];
                int j = i - 1;
                while ((j >= 0) && (candidatos[j].NotaMedia < tmp.NotaMedia))
                {
                    candidatos[j + 1] = candidatos[j];
                    j--;
                }
                candidatos[j + 1] = tmp;
            }
        }


        public static List<Candidatos> DefinirCursandos(List<Candidatos> candidatos, List<Cursos> Curso)
        {
            for (int i = 0; i < Curso.Count; i++)
            {
                candidatos = Curso[i].DefinirCursando(candidatos);
            }

            return candidatos;
        }


        public static void PopularTurma(List<Candidatos> candidatos, int i, List<Cursos> Curso, out Turmas Turma)
        {
            List<Candidatos> tmpCandidatos = new List<Candidatos>();
            Cursos tmpCurso = Curso[i];

            foreach (var candidato in candidatos)
            {
                if (candidato.PrimeiraOpcao == tmpCurso.CodigoCurso || (candidato.SegundaOpcao == tmpCurso.CodigoCurso) && (candidato.Cursando == false))
                {
                    tmpCandidatos.Add(candidato);
                }
            }

            Turma = new Turmas(tmpCandidatos, tmpCurso);
        }

        public static void EscreverSaida(Dictionary<int, Turmas> Turmas)
        {
            string filepath = "C:\\Users\\chris\\OneDrive\\Área de Trabalho\\Trabalho_Pratico\\bin\\Debug\\net8.0\\saida.txt";
            try
            {
                using (StreamWriter escreverArquivo = new StreamWriter(filepath))
                {

                    foreach (var turma in Turmas.Values)
                    {
                        escreverArquivo.WriteLine($"{turma.Curso.Nome} {turma.NotaCorte:N2}");
                        escreverArquivo.WriteLine("\nSelecionados:");


                        Candidatos[] alunosSelecionados = turma.FilaAluno.ToArray();

                        foreach (var aluno in alunosSelecionados)
                        {
                            escreverArquivo.WriteLine($"{aluno.Nome} {aluno.NotaMedia:N2}");
                        }

                        Candidatos[] alunosEspera = turma.FilaEspera.ToArray();
                        escreverArquivo.WriteLine("\nLista de Espera:");

                        foreach (var aluno in alunosEspera)
                        {
                            escreverArquivo.WriteLine($"{aluno.Nome} {aluno.NotaMedia:N2}");
                        }
                        escreverArquivo.WriteLine();
                    }
                }
            }
            catch (Exception erro)
            {
                Console.WriteLine("Ocorreu um erro: " + erro.Message);
            }

        }
    }
}
