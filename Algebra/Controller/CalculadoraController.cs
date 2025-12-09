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

        // MENU COMPLETO
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
                    case "1":
                        Console.WriteLine("Que nome pretende dar a esta Matriz?");
                        String Name = Console.ReadLine();
                        double[,] matrixRead = CalculadoraMatrizes.Matrix_Read();
                        Matrizes.TryAdd(Name, matrixRead);
                        break;

                    case "2":
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string name2 = Console.ReadLine();
                        if (Matrizes.TryGetValue(name2, out double[,] mat2))
                        {
                            Console.WriteLine("Por qual valor multiplicar?");
                            double val = Convert.ToDouble(Console.ReadLine());
                            double[,] res = CalculadoraMatrizes.Matrix_Scalar_Mult(mat2, val);
                            CalculadoraMatrizes.MatrixPrint(res);
                            SaveMatrix(res);
                        }
                        else Console.WriteLine("Matriz não encontrada.");
                        break;

                    case "3":
                        Console.WriteLine("Quais as matrizes a somar? (separe com espaço)");
                        string[] parts3 = Console.ReadLine().Split(' ');
                        if (parts3.Length >= 2 && Matrizes.TryGetValue(parts3[0], out double[,] mA) && Matrizes.TryGetValue(parts3[1], out double[,] mB))
                        {
                            double[,] res = CalculadoraMatrizes.Matrix_ADD(mA, mB);
                            if (res != null) { CalculadoraMatrizes.MatrixPrint(res); SaveMatrix(res); }
                        }
                        else Console.WriteLine("Erro ao encontrar matrizes.");
                        break;

                    case "4":
                        Console.WriteLine("Quais as matrizes a multiplicar? (separe com espaço)");
                        string[] parts4 = Console.ReadLine().Split(' ');
                        if (parts4.Length >= 2 && Matrizes.TryGetValue(parts4[0], out double[,] mAm) && Matrizes.TryGetValue(parts4[1], out double[,] mBm))
                        {
                            double[,] res = CalculadoraMatrizes.Matrix_Mult(mAm, mBm);
                            if (res != null) { CalculadoraMatrizes.MatrixPrint(res); SaveMatrix(res); }
                        }
                        else Console.WriteLine("Erro ao encontrar matrizes.");
                        break;

                    case "5":
                        Console.WriteLine("Qual a Matriz 2x2?");
                        string name5 = Console.ReadLine();
                        if (Matrizes.TryGetValue(name5, out double[,] m5))
                        {
                            double[,] res = CalculadoraMatrizes.Matrix_Inverse_2x2(m5);
                            CalculadoraMatrizes.MatrixPrint(res); SaveMatrix(res);
                        }
                        break;

                    case "6":
                        Console.WriteLine("Qual a Matriz 3x3?");
                        string name6 = Console.ReadLine();
                        if (Matrizes.TryGetValue(name6, out double[,] m6))
                        {
                            double[,] res = CalculadoraMatrizes.Matrix_Invers_3x3(m6);
                            CalculadoraMatrizes.MatrixPrint(res); SaveMatrix(res);
                        }
                        break;

                    case "7":
                        Console.WriteLine("Qual a Matriz?");
                        string name7 = Console.ReadLine();
                        if (Matrizes.TryGetValue(name7, out double[,] m7))
                        {
                            double[,] res = CalculadoraMatrizes.Matrix_Transpose(m7);
                            CalculadoraMatrizes.MatrixPrint(res); SaveMatrix(res);
                        }
                        break;

                    case "8":
                        Console.WriteLine("Qual a Matriz?");
                        string name8 = Console.ReadLine();
                        if (Matrizes.TryGetValue(name8, out double[,] m8))
                            Console.WriteLine(CalculadoraMatrizes.Matrix_IsDiagonal(m8));
                        Console.ReadLine();
                        break;

                    case "9":
                        Console.WriteLine("Qual a Matriz?");
                        string name9 = Console.ReadLine();
                        if (Matrizes.TryGetValue(name9, out double[,] m9))
                            Console.WriteLine(CalculadoraMatrizes.Matrix_IsTriangular(m9));
                        Console.ReadLine();
                        break;

                    case "10":
                        Console.WriteLine("Qual a Matriz 3x3?");
                        string name10 = Console.ReadLine();
                        if (Matrizes.TryGetValue(name10, out double[,] m10))
                        {
                            double det = CalculadoraMatrizes.Matrix_Determinant_3x3(m10);
                            Console.WriteLine($"Determinante: {det}");
                        }
                        Console.ReadLine();
                        break;

                    case "11":
                        Console.WriteLine("Nome do vetor:");
                        string nameVec = Console.ReadLine();
                        // Aqui usa a leitura padrão (sem 'q')
                        double[] vec = CalculadoraMatrizes.Vector_Read();
                        CalculadoraMatrizes.VectorPrint(vec);
                        Vetores.TryAdd(nameVec, vec);
                        Console.ReadLine();
                        break;

                    case "12":
                        // INSTANCIA O JOGO E INICIA
                        BatalhaNaval jogo = new BatalhaNaval();
                        jogo.IniciarJogo();
                        break;

                    case "LM":
                        CalculadoraMatrizes.Show_Matrixes(Matrizes);
                        Console.ReadLine();
                        break;

                    case "LV":
                        CalculadoraMatrizes.Show_Vectors(Vetores);
                        Console.ReadLine();
                        break;

                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
                Console.ReadLine();
            }
        }
    }

    public void SaveMatrix(double[,] matrix)
    {
        Console.WriteLine("Guardar matriz? (S/N)");
        string esc = Console.ReadLine();
        if (esc.ToLower() == "s")
        {
            Console.WriteLine("Nome:");
            string nome = Console.ReadLine();
            Matrizes.TryAdd(nome, matrix);
        }
    }
}