using System;
using System.IO;

class Program
{
    public static void Main(string[] args)
    {
        double precoTotal = 0.00;
        string continuar;

        do
        {
            Console.WriteLine("Qual o tipo de joia? (anel, colar, brinco, pulseira, outros)");
            string tipoJoia = Console.ReadLine();

            Console.WriteLine("Qual o material da joia? (ouro, prata, bronze, outros)");
            string material = Console.ReadLine();

            Console.WriteLine("Qual o tamanho da joia? (pequeno, médio, grande)");
            string tamanho = Console.ReadLine();

            Console.WriteLine("Deseja gravação na joia? (sim ou não)");
            bool gravacao = ConfirmarOpcao();

            Console.WriteLine("Deseja adicionar pedras preciosas? (sim ou não)");
            bool pedras = ConfirmarOpcao();

            Console.WriteLine("Deseja acabamento especial? (sim ou não)");
            bool acabamentoEspecial = ConfirmarOpcao();

            double precoItem = CalcularPreco(tipoJoia, material, tamanho, gravacao, pedras, acabamentoEspecial);
            precoTotal += precoItem;

            Console.WriteLine($"O preço deste item é: R${precoItem:F2}");
            Console.WriteLine("Deseja adicionar mais um item? (sim ou não)");
            continuar = Console.ReadLine().ToLower().Trim();

        } while (continuar == "sim" || continuar == "s");

        // Aplicar desconto se o preço total for maior que 500
        if (precoTotal > 500.00)
        {
            precoTotal *= 0.90; // Desconto de 10%
            Console.WriteLine("Parabéns! Você ganhou um desconto de 10%.");
        }

        Console.WriteLine($"O preço total para todos os itens é: R${precoTotal:F2}");

        // Salvar orçamento em um arquivo
        SalvarOrcamento(precoTotal);

        Console.WriteLine("Orçamento salvo com sucesso!");
    }

    public static bool ConfirmarOpcao()
    {
        while (true)
        {
            string resposta = Console.ReadLine().ToLower().Trim();

            if (resposta == "sim" || resposta == "s")
            {
                return true;
            }
            else if (resposta == "não" || resposta == "nao" || resposta == "n")
            {
                return false;
            }
            else
            {
                Console.WriteLine("Entrada inválida. Digite 'sim' ou 'não'.");
            }
        }
    }

    public static double CalcularPreco(string tipoJoia, string material, string tamanho, bool gravacao, bool pedras, bool acabamentoEspecial)
    {
        // Preço base da joia
        double precoBase = 50.00;
        double custoMaterial = 0.00;
        double custoTamanho = 0.00;
        double custoGravacao = 0.00;
        double custoPedras = 0.00;
        double custoAcabamento = 0.00;

        // Calcular custo baseado no tipo de joia
        switch (tipoJoia.ToLower())
        {
            case "anel":
                precoBase += 30.00;
                break;
            case "colar":
                precoBase += 50.00;
                break;
            case "brinco":
                precoBase += 40.00;
                break;
            case "pulseira":
                precoBase += 35.00;
                break;
            default:
                precoBase += 20.00; // Padrão para outros tipos
                break;
        }

        // Calcular custo baseado no material
        switch (material.ToLower())
        {
            case "ouro":
                custoMaterial = 100.00;
                break;
            case "prata":
                custoMaterial = 50.00;
                break;
            case "bronze":
                custoMaterial = 20.00;
                break;
            default:
                custoMaterial = 10.00; // Padrão para outros materiais
                break;
        }

        // Calcular custo baseado no tamanho
        switch (tamanho.ToLower())
        {
            case "pequeno":
                custoTamanho = 10.00;
                break;
            case "médio":
                custoTamanho = 20.00;
                break;
            case "grande":
                custoTamanho = 30.00;
                break;
            default:
                custoTamanho = 15.00; // Padrão para outros tamanhos
                break;
        }

        // Calcular custo da gravação
        if (gravacao)
        {
            custoGravacao = 25.00;
        }

        // Calcular custo das pedras preciosas
        if (pedras)
        {
            custoPedras = 50.00;
        }

        // Calcular custo do acabamento especial
        if (acabamentoEspecial)
        {
            custoAcabamento = 30.00;
        }

        // Calcular preço final
        double precoFinal = precoBase + custoMaterial + custoTamanho + custoGravacao + custoPedras + custoAcabamento;
        return precoFinal;
    }

    public static void SalvarOrcamento(double precoTotal)
    {
        string caminhoArquivo = "orcamentos.txt";
        string conteudo = $"Orçamento realizado em {DateTime.Now}: R${precoTotal:F2}\n";

        // Salvar no arquivo
        File.AppendAllText(caminhoArquivo, conteudo);
    }
}
