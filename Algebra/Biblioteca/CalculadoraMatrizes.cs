using System;
using System.Collections.Generic;

public class CalculadoraMatrizes
{
    public static double[,] Matrix_Read()
    {
        do
        {
            Console.WriteLine("Qual o tamanho da sua matriz? (Ex: 2x2)");

            string size = Console.ReadLine();
            string[] parts = size.Split('x', StringSplitOptions.None);

            if (parts.Length <= 2)
            {
                // Proteção simples contra erros de parse
                if (!int.TryParse(parts[0], out int Columns) || !int.TryParse(parts[1], out int Rows))
                {
                    Console.WriteLine("Formato inválido. Tente novamente (Ex: 2x2).");
                    continue;
                }

                double[,] MatrixRead = new double[Columns, Rows];
                for (int i = 0; i < Columns; i++)
                {
                    for (int f = 0; f < Rows; f++)
                    {
                        Console.WriteLine($"Qual o numero na posiçao {i}{f}?");
                        try
                        {
                            double num = Convert.ToDouble(Console.ReadLine());
                            MatrixRead[i, f] = num;
                        }
                        catch
                        {
                            MatrixRead[i, f] = 0; // Assume 0 se der erro
                        }
                    }
                }
                return MatrixRead;
            }
        } while (true);
    }

    public static void MatrixPrint(double[,] matrix)
    {
        int linhas = matrix.GetLength(0);
        int colunas = matrix.GetLength(1);

        Console.WriteLine();
        for (int i = 0; i < linhas; i++)
        {
            Console.Write("|");
            for (int j = 0; j < colunas; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine("|");
        }
    }

    public static void Show_Matrixes(Dictionary<string, double[,]> matrixes)
    {
        foreach (KeyValuePair<string, double[,]> matrix in matrixes)
        {
            Console.WriteLine("_______________");
            Console.WriteLine(matrix.Key);
            MatrixPrint(matrix.Value);
            Console.WriteLine("_______________");
        }
    }

    public static double[,] Matrix_Scalar_Mult(double[,] matriz, double constante)
    {
        double[,] Matrix_Scalar_Mult = (double[,])matriz.Clone(); // Clone para não alterar a original se não quiseres
        for (int i = 0; i < matriz.GetLength(0); i++)
        {
            for (int j = 0; j < matriz.GetLength(1); j++)
            {
                Matrix_Scalar_Mult[i, j] *= constante;
            }
        }

        return Matrix_Scalar_Mult;
    }

    public static double[,] Matrix_ADD(double[,] MatrizA, double[,] MatrizB)
    {
        if (MatrizA.GetLength(0) == MatrizB.GetLength(0) && MatrizA.GetLength(1) == MatrizB.GetLength(1))
        {
            int cols = MatrizA.GetLength(0);
            int rows = MatrizA.GetLength(1);
            double[,] MatrixADD = new double[cols, rows];
            for (int i = 0; i < cols; i++)
            {
                for (int f = 0; f < rows; f++)
                {
                    MatrixADD[i, f] = MatrizA[i, f] + MatrizB[i, f];
                }
            }
            return MatrixADD;
        }
        else
        {
            Console.WriteLine("Erro: Matrizes de tamanhos diferentes não podem ser somadas.");
            return null;
        }
    }

    public static double[,] Matrix_Mult(double[,] MatrizA, double[,] MatrizB)
    {
        double[,] MatrizMult = null;

        if (MatrizA.GetLength(1) != MatrizB.GetLength(0))
        {
            Console.WriteLine("As matrizes não são compatíveis para multiplicação.");
        }
        else
        {
            int linhas = MatrizA.GetLength(0);
            int colunas = MatrizB.GetLength(1);
            int comum = MatrizA.GetLength(1);

            MatrizMult = new double[linhas, colunas];

            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    for (int k = 0; k < comum; k++)
                    {
                        MatrizMult[i, j] += MatrizA[i, k] * MatrizB[k, j];
                    }
                }
            }
        }

        return MatrizMult;
    }

    public static double[,] Matrix_Inverse_2x2(double[,] matrizA)
    {
        EnsureMatrixSize(matrizA, 2, 2, nameof(matrizA));

        double diagonalPrincipal = matrizA[0, 0] * matrizA[1, 1];
        double diagonalSecundaria = matrizA[0, 1] * matrizA[1, 0];
        double detA = diagonalPrincipal - diagonalSecundaria;

        if (detA == 0)
        {
            throw new InvalidOperationException("A matriz não é invertível (determinante é zero).");
        }

        double[,] matrizTemp = new double[2, 2];
        matrizTemp[0, 0] = matrizA[1, 1];
        matrizTemp[1, 1] = matrizA[0, 0];
        matrizTemp[0, 1] = -matrizA[0, 1];
        matrizTemp[1, 0] = -matrizA[1, 0];
        
        // Multiplicar por 1/detA
        double[,] matrixInverse2x2 = Matrix_Scalar_Mult(matrizTemp, 1.0 / detA);
        return matrixInverse2x2;
    }

    public static double Matrix_Determinant_3x3(double[,] matrizA)
    {
        double det = matrizA[0, 0] * (matrizA[1, 1] * matrizA[2, 2] - matrizA[1, 2] * matrizA[2, 1])
           - matrizA[0, 1] * (matrizA[1, 0] * matrizA[2, 2] - matrizA[1, 2] * matrizA[2, 0])
           + matrizA[0, 2] * (matrizA[1, 0] * matrizA[2, 1] - matrizA[1, 1] * matrizA[2, 0]);

        return det;
    }

    public static double[,] Matrix_Invers_3x3(double[,] matrizA)
    {
        EnsureMatrixSize(matrizA, 3, 3, nameof(matrizA));

        // Calcula determinante
        double det = Matrix_Determinant_3x3(matrizA);

        if (det == 0)
        {
            throw new InvalidOperationException("O determinante é zero, a matriz não é invertível.");
        }

        // Calcula matriz de cofatores
        double[,] cofatores = new double[3, 3];
        cofatores[0, 0] = (matrizA[1, 1] * matrizA[2, 2] - matrizA[1, 2] * matrizA[2, 1]);
        cofatores[0, 1] = -(matrizA[1, 0] * matrizA[2, 2] - matrizA[1, 2] * matrizA[2, 0]);
        cofatores[0, 2] = (matrizA[1, 0] * matrizA[2, 1] - matrizA[1, 1] * matrizA[2, 0]);

        cofatores[1, 0] = -(matrizA[0, 1] * matrizA[2, 2] - matrizA[0, 2] * matrizA[2, 1]);
        cofatores[1, 1] = (matrizA[0, 0] * matrizA[2, 2] - matrizA[0, 2] * matrizA[2, 0]);
        cofatores[1, 2] = -(matrizA[0, 0] * matrizA[2, 1] - matrizA[0, 1] * matrizA[2, 0]);

        cofatores[2, 0] = (matrizA[0, 1] * matrizA[1, 2] - matrizA[0, 2] * matrizA[1, 1]);
        cofatores[2, 1] = -(matrizA[0, 0] * matrizA[1, 2] - matrizA[0, 2] * matrizA[1, 0]);
        cofatores[2, 2] = (matrizA[0, 0] * matrizA[1, 1] - matrizA[0, 1] * matrizA[1, 0]);

        // Transposta da matriz de cofatores - adjunta
        double[,] adjunta = new double[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                adjunta[i, j] = cofatores[j, i];
            }
        }

        // Divide cada elemento pelo determinante
        double[,] inversa = new double[3, 3];
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                inversa[i, j] = adjunta[i, j] / det;
            }
        }

        return inversa;
    }

    public static double[,] Matrix_Transpose(double[,] matrix)
    {
        int cols = matrix.GetLength(0);
        int rows = matrix.GetLength(1);
        double[,] matrixTranspose = new double[rows, cols];
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                matrixTranspose[j, i] = matrix[i, j];
            }
        }
        return matrixTranspose;
    }

    public static string Matrix_IsDiagonal(double[,] matrizA)
    {
        int rows = matrizA.GetLength(0);
        int cols = matrizA.GetLength(1);

        if (rows != cols)
            return "A matriz não é quadrada, logo não pode ser diagonal.";

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i != j && matrizA[i, j] != 0)
                    return "A matriz não é diagonal.";
            }
        }
        return "A matriz é diagonal.";
    }

    public static string Matrix_IsTriangular(double[,] matrizA)
    {
        int rows = matrizA.GetLength(0);
        int cols = matrizA.GetLength(1);

        if (rows != cols)
            return "A matriz não é quadrada, logo não pode ser triangular.";
        bool superior = true;
        for (int i = 1; i < rows; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (matrizA[i, j] != 0)
                    superior = false;
            }
        }
        if (superior)
            return "A matriz é triangular superior.";
        return "A matriz não é triangular.";
    }

    // --- AQUI ESTÁ A ALTERAÇÃO PARA O 'q' ---
    public static double[] Vector_Read()
    {
        Console.WriteLine("Qual o tamanho do seu vetor? (Ou digite 'q' para voltar)");
        string input = Console.ReadLine();

        // Verifica se quer sair
        if (input.ToLower() == "q")
        {
            return null;
        }

        if (!int.TryParse(input, out int size))
        {
            Console.WriteLine("Valor inválido. A assumir tamanho 2.");
            size = 2;
        }

        double[] vector = new double[size];

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Qual o numero na posição {i}?");
            try
            {
                vector[i] = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                vector[i] = 0;
            }
        }

        return vector;
    }

    public static void VectorPrint(double[] vector)
    {
        if (vector == null) return;
        Console.Write("(");
        foreach (var v in vector)
        {
            Console.Write($"{v} ");
        }
        Console.WriteLine(")");
    }

    public static void Show_Vectors(Dictionary<string, double[]> vectors)
    {
        foreach (KeyValuePair<string, double[]> entry in vectors)
        {
            Console.WriteLine("_______________");
            Console.WriteLine(entry.Key);
            VectorPrint(entry.Value);
            Console.WriteLine("_______________");
        }
    }

    private static void EnsureMatrixSize(double[,] matrix, int expectedRows, int expectedCols, string argumentName)
    {
        if (matrix == null)
            throw new ArgumentNullException(argumentName);

        if (matrix.GetLength(0) != expectedRows || matrix.GetLength(1) != expectedCols)
            throw new ArgumentException($"A matriz deve ter dimensão {expectedRows}x{expectedCols}.", argumentName);
    }
}