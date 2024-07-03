using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Pratico
{
    public class Fila 
    {
        private Celula primeiro;
        public Celula Primeiro { get { return primeiro; } set { primeiro = value; } }

        private Celula ultimo;
        public Celula Ultimo { get { return ultimo; } set { ultimo = value; } }

        public Fila()
        {
            primeiro = null;
            ultimo = null;
        }

        public void Enqueue(Candidatos elemento)
        {
            if(primeiro == null)
            {
                primeiro= new Celula(elemento);
                ultimo = primeiro;
            }
            else
            {
                Celula tmp = new Celula(elemento);
                ultimo.Prox = tmp;
                ultimo = tmp;
            }
        }

        public Candidatos Dequeue()
        {
            if( primeiro == null )
            {
                throw new Exception("Erro!");
            }
            else
            {
                Candidatos tmp = primeiro.Elemento;
                primeiro = primeiro.Prox;
                return tmp;
            }
            
        }

        public int Count()
        {
            int count = 0;
            for( Celula i = primeiro; i != null; i = i.Prox)
            {
                count++;
            }
            return count;
        }

        
        public void Show()
        {
            for (Celula i = primeiro; i != null; i = i.Prox)
            {
                i.Elemento.MostarCandidatos();
            }
        }

        public Candidatos[] ToArray()
        {
            int count = Count();
            Candidatos[] elementos = new Candidatos[count];
            int countAux = 0;

            for (Celula i = primeiro; i != null; i = i.Prox)
            {
                elementos[countAux] = i.Elemento;
                countAux++;
            }

            return elementos;
        }
    }
}
