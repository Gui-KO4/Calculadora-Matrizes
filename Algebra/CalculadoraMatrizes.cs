
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
            
            /* por alguma razao se fizer return null o programa crasha
            portanto devolvo uma matriz som com 0*/
            if(detA == 0) 
            {
                double [,] erro = {{0}};
                Console.WriteLine("Esta matriz nao tem inversa pois o determinante é 0");
                return erro;
            }
            
        double [,] matrizTemp = new double[2,2];
        matrizTemp[0,0] = matrizA[1,1];
        matrizTemp[1,1] = matrizA[0,0];
        matrizTemp[0,1] = -matrizA[0,1];
        matrizTemp[1,0] = -matrizA[1,0];
        double[,] matrixInverse2x2 = Matrix_Scalar_Mult(matrizTemp, detA );
        return matrixInverse2x2;
        }
        return null;
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




// Todo: (Matrix_Transpose) 
// Todo: (Matrix_IsDiagonal)
// Todo: (Matrix_IsTriangular)
// Todo: (Matrix_Determinant_3x3_Sarrous)
// Todo: (Espaço gerado) se haver tempo
// Todo: (Valores proprios) se o stor deixar usar Math



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

}

