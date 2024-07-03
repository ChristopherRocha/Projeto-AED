using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabalho_Pratico
{
    public class Celula
    {

        private Candidatos? elemento;
        public Candidatos? Elemento { get {  return elemento; } set {  elemento = value; } }

        private Celula? prox;
        public Celula? Prox { get { return prox; } set {  prox = value; } }

        public Celula()
        {
            elemento = null;
            prox = null;
        }

        public Celula(Candidatos elemento)
        {
            this.elemento = elemento;
            prox = null;
        }
    }
}
