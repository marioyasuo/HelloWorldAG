using System;


namespace HelloWorld
{
    public static class Algoritmo
    {
        private static String solucao;
        private static double taxaDeCrossover;
        private static double taxaDeMutacao;
        private static String caracteres;

        public static Populacao novaGeracao(Populacao populacao, bool elitismo)
        {
            Random r = new Random();
            //nova população do mesmo tamanho da antiga
            Populacao novaPopulacao = new Populacao(populacao.getTamPopulacao());

            //se tiver elitismo, mantém o melhor indivíduo da geração atual
            if (elitismo)
            {
                novaPopulacao.setIndividuo(populacao.getIndivduo(0));
            }

            //insere novos indivíduos na nova população, até atingir o tamanho máximo
            while (novaPopulacao.getNumIndividuos() < novaPopulacao.getTamPopulacao())
            {
                //seleciona os 2 pais por torneio
                Individuo[] pais = selecaoTorneio(populacao);

                Individuo[] filhos = new Individuo[2];

                //verifica a taxa de crossover, se sim realiza o crossover, se não, mantém os pais selecionados para a próxima geração
                if (r.NextDouble() <= taxaDeCrossover)
                {
                    filhos = crossover(pais[1], pais[0]);
                }
                else
                {
                    filhos[0] = new Individuo(pais[0].getGenes());
                    filhos[1] = new Individuo(pais[1].getGenes());
                }

                //adiciona os filhos na nova geração
                novaPopulacao.setIndividuo(filhos[0]);
                novaPopulacao.setIndividuo(filhos[1]);
            }

            //ordena a nova população
            novaPopulacao.ordenaPopulacao();
            return novaPopulacao;
        }

        public static Individuo[] crossover(Individuo individuo1, Individuo individuo2)
        {
            Random r = new Random();

            //sorteia o ponto de corte
            int pontoCorte1 = r.Next(((individuo1.getGenes().Length -1) / 2) - 2) + 1;
            int pontoCorte2 = r.Next(((individuo1.getGenes().Length -1) / 2) - 2) + (individuo1.getGenes().Length - 1) / 2;

            Individuo[] filhos = new Individuo[2];

            //pega os genes dos pais
            String genePai1 = individuo1.getGenes();
            String genePai2 = individuo2.getGenes();

            String geneFilho1;
            String geneFilho2;

            //realiza o corte, 
            geneFilho1 = genePai1.Substring(0, pontoCorte1);
            geneFilho1 += genePai2.Substring(pontoCorte1, pontoCorte2 - pontoCorte1);
            geneFilho1 += genePai1.Substring(pontoCorte2, genePai1.Length - pontoCorte2);

            geneFilho2 = genePai2.Substring(0, pontoCorte1);
            geneFilho2 += genePai1.Substring(pontoCorte1, pontoCorte2 - pontoCorte1);
            geneFilho2 += genePai2.Substring(pontoCorte2, (genePai2.Length- pontoCorte2));

            //cria o novo indivíduo com os genes dos pais
            filhos[0] = new Individuo(geneFilho1);
            filhos[1] = new Individuo(geneFilho2);

            return filhos;
        }

        public static Individuo[] selecaoTorneio(Populacao populacao)
        {
            Random r = new Random();
            Populacao populacaoIntermediaria = new Populacao(3);

            //seleciona 3 indivíduos aleatóriamente na população
            populacaoIntermediaria.setIndividuo(populacao.getIndivduo(r.Next(populacao.getTamPopulacao())));
            populacaoIntermediaria.setIndividuo(populacao.getIndivduo(r.Next(populacao.getTamPopulacao())));
            populacaoIntermediaria.setIndividuo(populacao.getIndivduo(r.Next(populacao.getTamPopulacao())));

            //ordena a população
            populacaoIntermediaria.ordenaPopulacao();

            Individuo[] pais = new Individuo[2];

            //seleciona os 2 melhores deste população
            pais[0] = populacaoIntermediaria.getIndivduo(0);
            pais[1] = populacaoIntermediaria.getIndivduo(1);

            return pais;
        }

        public static String getSolucao()
        {
            return solucao;
        }

        public static void setSolucao(String pSolucao)
        {
            solucao = pSolucao;
        }

        public static double getTaxaDeCrossover()
        {
            return taxaDeCrossover;
        }

        public static void setTaxaDeCrossover(double pTaxaDeCrossover)
        {
            taxaDeCrossover = pTaxaDeCrossover;
        }

        public static double getTaxaDeMutacao()
        {
            return taxaDeMutacao;
        }

        public static void setTaxaDeMutacao(double pTaxaDeMutacao)
        {
            taxaDeMutacao = pTaxaDeMutacao;
        }

        public static String getCaracteres()
        {
            return caracteres;
        }

        public static void setCaracteres(String pCaracteres)
        {
            caracteres = pCaracteres;
        }
    }   
    
}  