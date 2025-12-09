using System;
using System.Collections.Generic;

public class CalculadoraController
{
    string[] Menu;
    Dictionary<string, double[,]> Matrizes;
    Dictionary<string, double[]> Vetores;

    public CalculadoraController()
    {
        Matrizes = new Dictionary<string, double[,]>();
        Vetores = new Dictionary<string, double[]>();

        // MENU UNIFICADO (Todas as opções juntas)
        Menu = new string[]
        {
            "| 1    -Leitura de uma Matriz.                          |",
            "| 2    -Multiplicar por uma escalar.                    |",
            "| 3    -Somar Matrizes.                                 |",
            "| 4    -Multiplicar Matrizes.                           |",
            "| 5    -Inversa de uma Matriz 2x2.                      |",
            "| 6    -Inversa de uma Matriz 3x3 (Laplace).            |",
            "| 7    -Transposta de uma matriz.                       |",
            "| 8    -Verificar se uma Matriz é diagonal.             |",
            "| 9    -Verificar se uma Matriz é triangular superior.  |",
            "| 10   -Determinante de uma Matriz 3x3.                 |",
            "| 11   -Leitura de um vetor.                            |",
            "| 12   -JOGAR BATALHA NAVAL (Matricial).                |",
            "| LM   -Para listar todas as matrizes.                  |",
            "| LV   -Para listar todos os vetores.                   |"
        };
    }

    public void Start()
    {
        Console.Clear();
        while (true)
        {
            Console.WriteLine("\nO que pretende fazer?");
            foreach (string option in Menu)
                Console.WriteLine(option);

            String comands = Console.ReadLine();
            try
            {
                switch (comands)
                {
                    case "1": //ler uma matriz
                        Console.WriteLine("Que nome pretende dar a esta Matriz?");
                        String Name = Console.ReadLine();
                        double[,] matrixRead = CalculadoraMatrizes.Matrix_Read();
                        Matrizes.TryAdd(Name, matrixRead);
                        break;

                    case "2": //multiplicar a matriz por uma escalar
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixName = Console.ReadLine();
                        if (Matrizes.TryGetValue(matrixName, out double[,] matrixScalarMult))
                        {
                            Console.WriteLine("Por qual valor pretende multiplicar a Matriz");
                            double valor = Convert.ToDouble(Console.ReadLine());
                            double[,] matrixMulti = CalculadoraMatrizes.Matrix_Scalar_Mult(matrixScalarMult, valor);
                            CalculadoraMatrizes.MatrixPrint(matrixMulti);
                            SaveMatrix(matrixMulti);
                        }
                        else Console.WriteLine("Matriz não encontrada.");
                        break;

                    case "3": //Somar duas matrizes
                        Console.WriteLine("Quais as matrizes que pretende somar? (separe com espaço)");
                        string matrizesSoma = Console.ReadLine();
                        string[] letrasMatrizes = matrizesSoma.Split(" ", StringSplitOptions.None);

                        if (letrasMatrizes.Length >= 2 &&
                            Matrizes.TryGetValue(letrasMatrizes[0], out double[,] matrixAAdd) &&
                            Matrizes.TryGetValue(letrasMatrizes[1], out double[,] matrixBAdd))
                        {
                            double[,] matrixAdd = CalculadoraMatrizes.Matrix_ADD(matrixAAdd, matrixBAdd);
                            if (matrixAdd != null)
                            {
                                CalculadoraMatrizes.MatrixPrint(matrixAdd);
                                SaveMatrix(matrixAdd);
                            }
                        }
                        else Console.WriteLine("Matrizes não encontradas.");
                        break;

                    case "4": //multiplicação de matrizes
                        Console.WriteLine("Quais as matrizes que pretende Multiplicar? (separe com espaço)");
                        string matrizesMult = Console.ReadLine();
                        string[] letrasMatrizesMult = matrizesMult.Split(" ", StringSplitOptions.None);

                        if (letrasMatrizesMult.Length >= 2 &&
                            Matrizes.TryGetValue(letrasMatrizesMult[0], out double[,] matrixAMult) &&
                            Matrizes.TryGetValue(letrasMatrizesMult[1], out double[,] matrixBMult))
                        {
                            double[,] matrixResultMult = CalculadoraMatrizes.Matrix_Mult(matrixAMult, matrixBMult);
                            if (matrixResultMult != null)
                            {
                                CalculadoraMatrizes.MatrixPrint(matrixResultMult);
                                SaveMatrix(matrixResultMult);
                            }
                        }
                        else Console.WriteLine("Matrizes não encontradas.");
                        break;

                    case "5": //inversa 2x2
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixToInve2Name = Console.ReadLine();
                        if (Matrizes.TryGetValue(matrixToInve2Name, out double[,] matrixToInve2))
                        {
                            double[,] matrixInve2 = CalculadoraMatrizes.Matrix_Inverse_2x2(matrixToInve2);
                            CalculadoraMatrizes.MatrixPrint(matrixInve2);
                            SaveMatrix(matrixInve2);
                        }
                        break;

                    case "6": //inversa 3x3
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixToInve3Name = Console.ReadLine();
                        if (Matrizes.TryGetValue(matrixToInve3Name, out double[,] matrixToInve3))
                        {
                            double[,] matrixInve3 = CalculadoraMatrizes.Matrix_Invers_3x3(matrixToInve3);
                            CalculadoraMatrizes.MatrixPrint(matrixInve3);
                            SaveMatrix(matrixInve3);
                        }
                        break;

                    case "7": //transposta
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixToTransposeName = Console.ReadLine();
                        if (Matrizes.TryGetValue(matrixToTransposeName, out double[,] matrixToTranspose))
                        {
                            double[,] matrixTranspose = CalculadoraMatrizes.Matrix_Transpose(matrixToTranspose);
                            CalculadoraMatrizes.MatrixPrint(matrixTranspose);
                            SaveMatrix(matrixTranspose);
                        }
                        break;

                    case "8": //Matriz diagonal
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixIsDiagonalName = Console.ReadLine();
                        if (Matrizes.TryGetValue(matrixIsDiagonalName, out double[,] matrixIsDiagonal))
                        {
                            Console.WriteLine(CalculadoraMatrizes.Matrix_IsDiagonal(matrixIsDiagonal));
                        }
                        Console.ReadLine();
                        break;

                    case "9": //triangular superior
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixIsTriangularName = Console.ReadLine();
                        if (Matrizes.TryGetValue(matrixIsTriangularName, out double[,] matrixIsTriangular))
                        {
                            Console.WriteLine(CalculadoraMatrizes.Matrix_IsTriangular(matrixIsTriangular));
                        }
                        Console.ReadLine();
                        break;

                    case "10": //Det 3x3
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixToDetName = Console.ReadLine();
                        if (Matrizes.TryGetValue(matrixToDetName, out double[,] matrixToDet))
                        {
                            double Det3x3 = CalculadoraMatrizes.Matrix_Determinant_3x3(matrixToDet);
                            Console.WriteLine($"O determinante da Matriz \"{matrixToDetName}\" é {Det3x3}");
                        }
                        Console.ReadLine();
                        break;

                    case "11": // Ler vetor
                        Console.WriteLine("Qual o nome que pretende dar a este vetor");
                        string nameVetor = Console.ReadLine();
                        double[] vector = CalculadoraMatrizes.Vector_Read();

                        // Só guarda se não for null (se user não digitou 'q')
                        if (vector != null)
                        {
                            CalculadoraMatrizes.VectorPrint(vector);
                            Vetores.TryAdd(nameVetor, vector);
                        }
                        else
                        {
                            Console.WriteLine("Operação cancelada.");
                        }
                        Console.ReadLine();
                        break;

                    case "LM": // Listar Matrizes
                        CalculadoraMatrizes.Show_Matrixes(Matrizes);
                        Console.ReadLine();
                        break;

                    case "LV": // Listar Vetores
                        CalculadoraMatrizes.Show_Vectors(Vetores);
                        Console.ReadLine();
                        break;

                    case "12": // JOGAR BATALHA NAVAL
                        BatalhaNaval jogo = new BatalhaNaval();
                        jogo.IniciarJogo();
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ocorreu um erro: " + e.Message);
                Console.ReadLine();
            }
        }
    }

    public void SaveMatrix(double[,] matrix)
    {
        Console.WriteLine("Pretende guardar esta matriz? (S-sim ou N-nao)");
        string escolha = Console.ReadLine();
        if (escolha == "S" || escolha == "s")
        {
            Console.WriteLine("Que nome pretende dar a esta matriz?");
            string matrixName = Console.ReadLine();
            Matrizes.TryAdd(matrixName, matrix);
        }
    }
}