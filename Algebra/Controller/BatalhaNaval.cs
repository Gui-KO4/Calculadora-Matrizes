using System;
using System.Threading; // Necessário para o Sleep

public class BatalhaNaval
{
    private double[,] TabuleiroOculto; // Onde estão os navios
    private double[,] TabuleiroVisivel; // O que o jogador vê
    private int Tamanho = 5; // Tabuleiro 5x5
    private int NaviosRestantes = 3;

    public void IniciarJogo()
    {
        // Inicializar tabuleiros
        TabuleiroOculto = new double[Tamanho, Tamanho];
        TabuleiroVisivel = new double[Tamanho, Tamanho];

        // Colocar navios aleatoriamente
        PosicionarNaviosAleatorios();

        bool jogoRodando = true;

        while (jogoRodando)
        {
            Console.Clear(); // Limpa o ecrã a cada novo turno
            Console.WriteLine("=== BATALHA NAVAL MATRICIAL ===");
            Console.WriteLine("Legenda: 0=Mar | 8=ACERTO | -1=ÁGUA");
            
            Console.WriteLine("\n--- RADAR ATUAL ---");
            CalculadoraMatrizes.MatrixPrint(TabuleiroVisivel);

            Console.WriteLine($"\nNavios restantes: {NaviosRestantes}");
            Console.WriteLine("Lance as coordenadas do míssil! (Escreva 'q' no tamanho para sair)");
            
            // Lê as coordenadas
            double[] coordenadas = CalculadoraMatrizes.Vector_Read();

            // === VERIFICAÇÃO PARA SAIR ===
            if (coordenadas == null)
            {
                Console.WriteLine("A sair da Batalha Naval...");
                return; 
            }

            // Validação de tamanho do vetor
            if (coordenadas.Length < 2)
            {
                Console.WriteLine("Erro: O vetor precisa ter tamanho 2. A reiniciar turno...");
                System.Threading.Thread.Sleep(2000);
                continue;
            }

            int linha = (int)coordenadas[0];
            int coluna = (int)coordenadas[1];

            // Verificar se está dentro do tabuleiro
            if (linha < 0 || linha >= Tamanho || coluna < 0 || coluna >= Tamanho)
            {
                Console.WriteLine("Coordenada fora do radar! Tente entre 0 e 4.");
                System.Threading.Thread.Sleep(2000);
                continue;
            }

            // --- AQUI ESTÁ A LÓGICA DO TIRO E A PAUSA ---
            ProcessarTiro(linha, coluna);

            // Verificar Vitória antes de pausar
            if (NaviosRestantes == 0)
            {
                Console.WriteLine("\nPARABÉNS! TODOS OS ALVOS FORAM NEUTRALIZADOS.");
                Console.WriteLine("Pressione Enter para voltar ao menu.");
                Console.ReadLine();
                jogoRodando = false;
            }
            else
            {
                // SE O JOGO CONTINUA:
                Console.WriteLine("\n-------------------------------------------");
                Console.WriteLine("A atualizar radar em 5 segundos...");
                // O PROGRAMA ESPERA AQUI 5 SEGUNDOS
                System.Threading.Thread.Sleep(5000); 
            }
        }
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
        // Se já atirou ali
        if (TabuleiroVisivel[l, c] != 0)
        {
            Console.WriteLine($"\n>>> ALERTA: Você já atirou na coordenada ({l},{c})! <<<");
            return;
        }

        // Verifica se acertou
        if (TabuleiroOculto[l, c] == 1)
        {
            Console.WriteLine($"\n>>> FOGO NA POSIÇÃO ({l},{c})! ACERTOU UM NAVIO! <<<");
            TabuleiroVisivel[l, c] = 8; // Marca Acerto
            NaviosRestantes--;
        }
        else
        {
            Console.WriteLine($"\n>>> SPLASH! Tiro na água na posição ({l},{c}). <<<");
            TabuleiroVisivel[l, c] = -1; // Marca Erro
        }
    }
}