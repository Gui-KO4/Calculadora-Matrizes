using System;
using System.Threading; 

public class BatalhaNaval
{
    private double[,] TabuleiroOculto;
    private double[,] TabuleiroVisivel;
    private int Tamanho = 5;
    private int NaviosRestantes = 3;

    public void IniciarJogo()
    {
        TabuleiroOculto = new double[Tamanho, Tamanho];
        TabuleiroVisivel = new double[Tamanho, Tamanho];

        PosicionarNaviosAleatorios();

        bool jogoRodando = true;

        while (jogoRodando)
        {
            Console.Clear(); 
            Console.WriteLine("=== BATALHA NAVAL MATRICIAL ===");
            Console.WriteLine("Legenda: 0=Mar | 8=ACERTO | -1=ÁGUA");
            Console.WriteLine($"Navios restantes: {NaviosRestantes}");

            Console.WriteLine("\n--- RADAR ATUAL ---");
            CalculadoraMatrizes.MatrixPrint(TabuleiroVisivel);

            // --- AQUI O JOGO VAI LER O TIRO ---
            double[] coordenadas = LerTiroControlado();

            // Se for null, significa que escreveste 'q' em algum momento
            if (coordenadas == null)
            {
                Console.WriteLine("\nA abandonar a missão... Volte sempre!");
                Thread.Sleep(1500);
                return; // Sai do método IniciarJogo e volta ao Menu Principal
            }

            // Validação de tamanho (caso o user tenha posto tamanho errado mas não 'q')
            if (coordenadas.Length < 2)
            {
                Console.WriteLine("Erro: O vetor tem de ter tamanho 2 (Linha, Coluna).");
                Thread.Sleep(2000);
                continue;
            }

            int linha = (int)coordenadas[0];
            int coluna = (int)coordenadas[1];

            // Validação de limites
            if (linha < 0 || linha >= Tamanho || coluna < 0 || coluna >= Tamanho)
            {
                Console.WriteLine($"Coordenada inválida! Use valores entre 0 e {Tamanho - 1}.");
                Thread.Sleep(2000);
                continue;
            }

            ProcessarTiro(linha, coluna);

            // Verifica vitória
            if (NaviosRestantes == 0)
            {
                Console.WriteLine("\nPARABÉNS! TODOS OS ALVOS FORAM ABATIDOS!");
                Console.WriteLine("Pressione Enter para voltar ao menu.");
                Console.ReadLine();
                jogoRodando = false;
            }
            else
            {
                Console.WriteLine("\nA atualizar radar em 5 segundos...");
                Thread.Sleep(5000); 
            }
        }
    }

    // === MÉTODO ATUALIZADO PARA SAIR A QUALQUER MOMENTO ===
    private double[] LerTiroControlado()
    {
        Console.WriteLine("\nLance o míssil! (Escreva 'q' a qualquer momento para sair)");
        
        // 1. Pergunta o Tamanho
        Console.WriteLine("Defina o tamanho do vetor (Digite 2):");
        string inputSize = Console.ReadLine();

        // Verifica saída no tamanho
        if (IsExitCommand(inputSize)) return null;

        int size;
        if (!int.TryParse(inputSize, out size))
        {
            size = 2; // Se escreveres algo errado que não seja 'q', assume 2
        }

        double[] vetor = new double[size];
        
        // 2. Pergunta as Coordenadas (Linha e Coluna)
        for (int i = 0; i < size; i++)
        {
            string tipo = (i == 0) ? "Linha" : "Coluna";
            Console.WriteLine($"Digite o valor para {tipo} (Posição {i}): ");
            
            string inputValor = Console.ReadLine();

            // Verifica saída nas coordenadas
            if (IsExitCommand(inputValor)) return null;

            try
            {
                vetor[i] = Convert.ToDouble(inputValor);
            }
            catch
            {
                Console.WriteLine("Valor inválido, assumindo 0.");
                vetor[i] = 0;
            }
        }
        return vetor;
    }

    // Função auxiliar pequena para verificar o "q"
    private bool IsExitCommand(string input)
    {
        return !string.IsNullOrEmpty(input) && input.Trim().ToLower() == "q";
    }

    private void PosicionarNaviosAleatorios()
    {
        Random rnd = new Random();
        int naviosColocados = 0;
        
        while (naviosColocados < NaviosRestantes)
        {
            int l = rnd.Next(0, Tamanho);
            int c = rnd.Next(0, Tamanho);

            if (TabuleiroOculto[l, c] == 0)
            {
                TabuleiroOculto[l, c] = 1;
                naviosColocados++;
            }
        }
    }

    private void ProcessarTiro(int l, int c)
    {
        if (TabuleiroVisivel[l, c] != 0)
        {
            Console.WriteLine($"\n>>> ALERTA: Já atiraste em ({l},{c})! <<<");
            return;
        }

        if (TabuleiroOculto[l, c] == 1)
        {
            Console.WriteLine($"\n>>> KABUM! ACERTO NA POSIÇÃO ({l},{c})! <<<");
            TabuleiroVisivel[l, c] = 8;
            NaviosRestantes--;
        }
        else
        {
            Console.WriteLine($"\n>>> SPLASH! Tiro na água em ({l},{c}). <<<");
            TabuleiroVisivel[l, c] = -1;
        }
    }
}