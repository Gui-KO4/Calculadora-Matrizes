
public class CalculadoraMatrizes
{
    public static double[,] Matrix_Read()
    {
        do{
        Console.WriteLine("Qual o tamanho da sua matriz? (Ex: 2x2)");

            string size = Console.ReadLine();
            string[] parts = size.Split('x',StringSplitOptions.None);
        
        if(parts.Length <= 2){
            int Columns = int.Parse(parts[0]);
            int Rows = int.Parse(parts[1]);
            double [,] MatrixRead = new double[Columns,Rows];
                for(int i=0; i< Columns; i++)
                    {
                        for(int f=0; f< Rows; f++)
                            {
                                Console.WriteLine($"Qual o numero na posiçao {i}{f}?");
                                double num = Convert.ToDouble(Console.ReadLine());
                                MatrixRead[i,f] = num;
                            }      
                    }
            return MatrixRead;
        }
        }while(true);       
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

        public static void Show_Matrixes(Dictionary<string, double[,] > matrixes)
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
            double[,] Matrix_Scalar_Mult = matriz;
            for (int i = 0; i < matriz.GetLength(0); i++)
            {
                for (int j = 0; j < matriz.GetLength(1); j++)
                {
                    Matrix_Scalar_Mult[i, j] *= constante;
                }
            }

            return Matrix_Scalar_Mult;
        }



    public static double[,] Matrix_ADD(double[,] MatrizA , double [,] MatrizB)
    {
        do{
            if(MatrizA.GetLength(0) == MatrizB.GetLength(0) && MatrizA.GetLength(1) == MatrizB.GetLength(1))
            {
                int cols = MatrizA.GetLength(0);
                int rows = MatrizA.GetLength(1);
                double [,] MatrixADD = new double[cols, rows];
                for(int i = 0; i < cols; i++) 
                {
                    for(int f = 0; f < rows; f++)
                    {
                        MatrixADD[i,f] = MatrizA[i,f] + MatrizB[i,f];
                    }
                }
                return MatrixADD;
            }
             
        }while(true); 
    }




    
    public static double[,] Matrix_Mult(double[,] MatrizA, double[,] MatrizB)
    {
        double[,] MatrizMult = null; // declaração fora do if/else

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
        if(matrizA.GetLength(0) == 2 && matrizA.GetLength(0) == 2)
        {
        double diagonalPrincipal = matrizA[0,0] * matrizA[1,1];
        double diagonalSecundaria = matrizA[0,1] * matrizA[1,0];
        double detA = diagonalPrincipal - diagonalSecundaria;
            
        double [,] matrizTemp = new double[2,2];
        matrizTemp[0,0] = matrizA[1,1];
        matrizTemp[1,1] = matrizA[0,0];
        matrizTemp[0,1] = -matrizA[0,1];
        matrizTemp[1,0] = -matrizA[1,0];
        double[,] matrixInverse2x2 = Matrix_Scalar_Mult(matrizTemp, detA );
        return matrixInverse2x2;
        }
        else
        {
            Console.WriteLine("A matriz nao é 2x2");
            return Matrix_Error();
        }
        
    }

    public static double Matrix_Determinant_3x3(double[,] m)
    {
        double det = m[0,0]*(m[1,1]*m[2,2] - m[1,2]*m[2,1])
               - m[0,1]*(m[1,0]*m[2,2] - m[1,2]*m[2,0])
               + m[0,2]*(m[1,0]*m[2,1] - m[1,1]*m[2,0]);
               
            return det;
    }




    public static double[,] Matrix_Invers_3x3(double[,] m)
    {
        // Calcula determinante
        double det = m[0,0]*(m[1,1]*m[2,2] - m[1,2]*m[2,1])
                - m[0,1]*(m[1,0]*m[2,2] - m[1,2]*m[2,0])
                + m[0,2]*(m[1,0]*m[2,1] - m[1,1]*m[2,0]);

        if (det == 0) return null; // não invertível

        // Calcula matriz de cofatores
        double[,] cofatores = new double[3, 3];
        cofatores[0, 0] =  (m[1,1]*m[2,2] - m[1,2]*m[2,1]);
        cofatores[0, 1] = -(m[1,0]*m[2,2] - m[1,2]*m[2,0]);
        cofatores[0, 2] =  (m[1,0]*m[2,1] - m[1,1]*m[2,0]);

        cofatores[1, 0] = -(m[0,1]*m[2,2] - m[0,2]*m[2,1]);
        cofatores[1, 1] =  (m[0,0]*m[2,2] - m[0,2]*m[2,0]);
        cofatores[1, 2] = -(m[0,0]*m[2,1] - m[0,1]*m[2,0]);

        cofatores[2, 0] =  (m[0,1]*m[1,2] - m[0,2]*m[1,1]);
        cofatores[2, 1] = -(m[0,0]*m[1,2] - m[0,2]*m[1,0]);
        cofatores[2, 2] =  (m[0,0]*m[1,1] - m[0,1]*m[1,0]);

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
        for (int i = 0; i <= cols; i++)
        {
            for (int j = 0; j <= rows; j++)
            {
                matrixTranspose[i, j] = matrix[j, i];
            }
        }
        return matrixTranspose;
    }

    public static string  Matrix_IsDiagonal(double[,] m)
    {
        int rows = m.GetLength(0);
        int cols = m.GetLength(1);

        // Só faz sentido verificar se for quadrada
        if (rows != cols)
            return "A matriz não é quadrada, logo não pode ser diagonal.";

        // Verifica se elementos fora da diagonal são zero
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (i != j && m[i, j] != 0)
                     return "A matriz não é diagonal.";
            }
        }
        return "A matriz é diagonal.";
        
    }
    public static string Matrix_IsTriangular(double[,] m)
    {
        int rows = m.GetLength(0);
        int cols = m.GetLength(1);

        if (rows != cols)
            return "A matriz não é quadrada, logo não pode ser triangular.";
        bool superior = true;
         for (int i = 1; i < rows; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (m[i, j] != 0)
                    superior = false;
            }
        }
        if (superior)
            return "A matriz é triangular superior.";
        return "A matriz não é triangular.";
    }
    public static double[] Vector_Read()
    {
        Console.WriteLine("Qual o tamanho do seu vetor?");
        int size = int.Parse(Console.ReadLine());
        double[] vector = new double[size];

        for (int i = 0; i < size; i++)
        {
            Console.WriteLine($"Qual o numero na posição {i}?");
            vector[i] = Convert.ToDouble(Console.ReadLine());
        }

        return vector;
    }

    //  Mostrar um vetor
    public static void VectorPrint(double[] vector)
    {
        Console.Write("(");
        foreach (var v in vector)
        {
            Console.Write($"{v} ");
        }
        Console.WriteLine(")");
    }

    //  Mostrar vários vetores
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
public static List<double[]> Generate_Space(Dictionary<string, double[]> vectors)
{
    // Copia os vetores para uma lista para manipulação
    List<double[]> vectorList = vectors.Values.ToList();
    int n = vectorList[0].Length;
    int m = vectorList.Count;

    // Lista para armazenar a base
    List<double[]> basis = new List<double[]>();

    // Matriz para eliminação
    double[,] matrix = new double[m, n];

    for (int i = 0; i < m; i++)
        for (int j = 0; j < n; j++)
            matrix[i, j] = vectorList[i][j];

    // Eliminação de Gauss simples
    int rank = 0;
    for (int col = 0; col < n; col++)
    {
        // Encontrar pivot
        int pivotRow = -1;
        for (int row = rank; row < m; row++)
        {
            if (matrix[row, col] != 0)
            {
                pivotRow = row;
                break;
            }
        }

        if (pivotRow == -1) continue; // Nenhum pivot nessa coluna

        // Trocar linhas
        if (pivotRow != rank)
        {
            for (int c = 0; c < n; c++)
            {
                double temp = matrix[rank, c];
                matrix[rank, c] = matrix[pivotRow, c];
                matrix[pivotRow, c] = temp;
            }
        }

        // Normalizar pivot
        double pivot = matrix[rank, col];
        for (int c = 0; c < n; c++)
            matrix[rank, c] /= pivot;

        // Eliminar abaixo
        for (int row = rank + 1; row < m; row++)
        {
            double factor = matrix[row, col];
            for (int c = 0; c < n; c++)
                matrix[row, c] -= factor * matrix[rank, c];
        }

        rank++;
    }

    // Os vetores correspondentes às linhas não nulas formam a base
    for (int i = 0; i < rank; i++)
    {
        double[] vec = new double[n];
        for (int j = 0; j < n; j++)
            vec[j] = matrix[i, j];
        basis.Add(vec);
    }

    return basis;
}





// Todo: (Espaço gerado) se haver tempo
// Todo: (Valores proprios) se o stor deixar usar Math


    // Error Helper Fix
    public static double[,] Matrix_Error()
    {
        return new double[,] { { 0 } };
    }
       

}