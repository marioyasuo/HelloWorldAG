using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define a solução
            Algoritmo.setSolucao("Hello World");
            //Define os caracteres existentes
            Algoritmo.setCaracteres("!,.:;?áÁãÃâÂõÕôÔóÓéêÉÊíQWERTYUIOPASDFGHJKLÇZXCVBNMqwertyuiopasdfghjklçzxcvbnm1234567890 ");
            //taxa de crossover de 60%
            Algoritmo.setTaxaDeCrossover(0.9);
            //taxa de mutação de 3%
            Algoritmo.setTaxaDeMutacao(0.3);
            //elitismo
            bool eltismo = true;
            //tamanho da população
            int tamPop = 500;
            //numero máximo de gerações
            int numMaxGeracoes = 10000;

            //define o número de genes do indivíduo baseado na solução
            int numGenes = Algoritmo.getSolucao().Length;

            //cria a primeira população aleatérioa
            Populacao populacao = new Populacao(numGenes, tamPop);

            bool temSolucao = false;
            int geracao = 0;

            System.Console.WriteLine("Iniciando... Aptidão da solução: " + (Algoritmo.getSolucao().Length));

            //loop até o critério de parada
            while (!temSolucao && geracao < numMaxGeracoes)
            {
                geracao++;

                //cria nova populacao
                populacao = Algoritmo.novaGeracao(populacao, eltismo);

                System.Console.WriteLine("Geração " + geracao + " | Aptidão: " + populacao.getIndivduo(0).getAptidao() + " | Melhor: " + populacao.getIndivduo(0).getGenes());

                //verifica se tem a solucao
                temSolucao = populacao.temSolocao(Algoritmo.getSolucao());
            }

            if (geracao == numMaxGeracoes)
            {
                System.Console.WriteLine("Número Maximo de Gerações | " + populacao.getIndivduo(0).getGenes() + " " + populacao.getIndivduo(0).getAptidao());
            }

            if (temSolucao)
            {
                System.Console.WriteLine("Encontrado resultado na geração " + geracao + " | " + populacao.getIndivduo(0).getGenes() + " (Aptidão: " + populacao.getIndivduo(0).getAptidao() + ")");
            }
        }
    }
}
