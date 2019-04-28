using System;

namespace HelloWorld
{
    public class Individuo
    {
        private String genes = "";
        private int aptidao = 0;
        

        //gera um indivíduo aleatório
        public Individuo(int numGenes)
        {
            genes = "";
            Random r = new Random();

            String caracteres = Algoritmo.getCaracteres();

            for (int i = 0; i < numGenes; i++)
            {
                genes += caracteres[(r.Next(caracteres.Length))];
            }

            geraAptidao();
        }

        //cria um indivíduo com os genes definidos
        public Individuo(String genes)
        {
            this.genes = genes;

            Random r = new Random();
            //se for mutar, cria um gene aleatório
            if (r.NextDouble() <= Algoritmo.getTaxaDeMutacao())
            {
                String caracteres = Algoritmo.getCaracteres();
                String geneNovo = "";
                int posAleatoria = r.Next(genes.Length );
                for (int i = 0; i < genes.Length; i++)
                {
                    if (i == posAleatoria)
                    {
                        geneNovo += caracteres[(r.Next(caracteres.Length))];
                    }
                    else
                    {
                        geneNovo += genes[i];
                    }

                }
                this.genes = geneNovo;
            }
            geraAptidao();
        }

        //gera o valor de aptidão, será calculada pelo número de bits do gene iguais ao da solução
        private void geraAptidao()
        {
            String solucao = Algoritmo.getSolucao();
            for (int i = 0; i < solucao.Length; i++)
            {
                if (solucao[i] == genes[i])
                {
                    aptidao++;
                }
            }
        }

        public int getAptidao()
        {
            return aptidao;
        }

        public String getGenes()
        {
            return genes;
        }
    }
}