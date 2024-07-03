namespace Trabalho_Pratico
{
    public class Program
    {
        static void Main(string[] args)
        {

            //Lembre de alterar o diretório de entrada para o diretório correto no seu pc
            //Para alterar o diretório de entrada entre na classe Operacoes.cs > LerArquivo() 
            //Para alterar o diretório de saída entra na classe Operacoes.cs > EscreverSaida() 

            int[] cursoVagas = new int[2];
            List<Candidatos> candidatos = new List<Candidatos>();
            List<Cursos> curso = new List<Cursos>();
            Operacoes.LerArquivo(candidatos, curso, cursoVagas);


            candidatos = Operacoes.OrdenarCandidatos(candidatos);
            candidatos = Operacoes.DefinirCursandos(candidatos, curso);
            

            Dictionary<int, Turmas> Turmas = new Dictionary<int, Turmas>();
            for (int i = 0; i < curso.Count; i++)
            {
                Turmas tmpTurma;
                Operacoes.PopularTurma(candidatos, i, curso, out tmpTurma);
                tmpTurma.AjustarTurma();
                Turmas[i]= tmpTurma; 
            }

      
            Operacoes.EscreverSaida(Turmas);

            Console.WriteLine($"O arquivo de saída foi escrito no diretório {Directory.GetCurrentDirectory() + "\\saida.txt"}");
        }
    }
}
