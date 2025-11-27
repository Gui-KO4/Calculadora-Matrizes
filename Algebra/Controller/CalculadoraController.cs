public class CalculadoraController{

    string[] Menu;
    Dictionary<string, double[,]> Matrizes;
    Dictionary<string, double[]> Vetores;

        public CalculadoraController() {
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
                "| LM   -Para listar todas as matrizes.                  |",
                "| LV   -Para listar todos os vetores.                   |"                
            };

            Matrizes = new Dictionary<string, double[,]>{};
            Vetores = new Dictionary<string, double[]>{};
        }
        public void Start(){
        Console.Clear();
        while(true){
            
            Console.WriteLine("O que pretende fazer?");
            foreach( string option in Menu)
                Console.WriteLine(option);
                
            String comands = Console.ReadLine();
            switch (comands)
            {
                case "1": //ler uma matriz

                        //Obter o nome da Matriz
                        Console.WriteLine("Que nome pretende dar a esta Matriz?");
                        String Name = Console.ReadLine();
                        
                        //Usar o metodo para ler uma matriz e adiciona la a uma variavel
                        double [,] matrixRead = CalculadoraMatrizes.Matrix_Read();
                        
                        //adicionar o nome e a matriz a um dicionario de matrizes
                        Matrizes.TryAdd(Name, matrixRead);

                        Console.ReadLine();
                    break;
                case "2": //multiplicar a matriz por uma escalar

                        //Obter a Matriz pelo nome 
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixName = Console.ReadLine();
                        Matrizes.TryGetValue(matrixName, out double[,] matrixScalarMult);

                        //obter a constante para multiplicar a matriz
                        Console.WriteLine("Por qual valor pretende multiplicar a Matriz");
                        double valor = Convert.ToDouble(Console.ReadLine());

                        //Multiplicar a Matriz escolhida pela constante
                        double[,] matrixMulti = CalculadoraMatrizes.Matrix_Scalar_Mult(matrixScalarMult, valor);

                        CalculadoraMatrizes.MatrixPrint(matrixMulti);
                        SaveMatrix(matrixMulti);
                    break;
                case "3": //Somar duas matrizes

                        //obter as matrizes para somar
                        Console.WriteLine("Quais as matrizes que pretende somar?");

                        //reading user input
                        string matrizesSoma = Console.ReadLine();
                        string[] letrasMatrizes = matrizesSoma.Split(" ",StringSplitOptions.None);
                        
                        //associar o inputa separado do user para cada variavel
                        string matrixAAddName = letrasMatrizes[0]; 
                        string matrixBAddNome = letrasMatrizes[1]; 

                        //procurar no dicionario as matrizes que o user inseriu 
                        Matrizes.TryGetValue(matrixAAddName, out double[,] matrixAAdd);
                        Matrizes.TryGetValue(matrixBAddNome, out double[,] matrixBAdd);

                        //fazer a soma das matrizes
                        double[,] matrixAdd = CalculadoraMatrizes.Matrix_ADD(matrixAAdd, matrixBAdd);
                        CalculadoraMatrizes.MatrixPrint(matrixAdd);
                        SaveMatrix(matrixAdd);
                    break;
                case "4": //multiplicação de matrizes
                        //mesma coisa que a soma so criamos var novas e trocamos o metodo no fim
                        //obter as matrizes para somar
                        Console.WriteLine("Quais as matrizes que pretende Multiplicar?");

                        //reading user input
                        string matrizesMult = Console.ReadLine();
                        string[] letrasMatrizesMult = matrizesMult.Split(" ",StringSplitOptions.None);
                        
                        //associar o inputa separado do user para cada variavel
                        string matrixAMultName = letrasMatrizesMult[0]; 
                        string matrixBMultNome = letrasMatrizesMult[1]; 

                        //procurar no dicionario as matrizes que o user inseriu 
                        Matrizes.TryGetValue(matrixAMultName, out double[,] matrixAMult);
                        Matrizes.TryGetValue(matrixBMultNome, out double[,] matrixBMult);

                        //fazer a multiplicaçao das matrizes
                        double [,] matrixMult = CalculadoraMatrizes.Matrix_Mult(matrixAMult, matrixBMult);
                        CalculadoraMatrizes.MatrixPrint(matrixMult);
                        SaveMatrix(matrixMult);
                    break;
                case "5": //inversa 2x2
                        
                        //Obter a Matriz pelo nome 
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixToInve2Name = Console.ReadLine();
                        Matrizes.TryGetValue(matrixToInve2Name, out double[,] matrixToInve2);
                        
                        double [,] matrixInve2 = CalculadoraMatrizes.Matrix_Inverse_2x2(matrixToInve2);
                        CalculadoraMatrizes.MatrixPrint(matrixInve2);
                        SaveMatrix(matrixInve2);
                    break;
                case "6": //inversa 3x3
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixToInve3Name = Console.ReadLine();
                        Matrizes.TryGetValue(matrixToInve3Name, out double[,] matrixToInve3);
                       
                        double [,] matrixInve3 = CalculadoraMatrizes.Matrix_Invers_3x3(matrixToInve3);
                        CalculadoraMatrizes.MatrixPrint(matrixInve3);
                        SaveMatrix(matrixInve3);
                    break;
                case "7": //tranposta de uma matriz
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixToTransposeName = Console.ReadLine();
                        Matrizes.TryGetValue(matrixToTransposeName, out double[,] matrixToTranspose);
                       
                        double [,] matrixTranspose = CalculadoraMatrizes.Matrix_Invers_3x3(matrixToTranspose);
                        CalculadoraMatrizes.MatrixPrint(matrixTranspose);
                        SaveMatrix(matrixTranspose);
                    break;
                case "8": //Matriz diagonal
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixIsDiagonalName = Console.ReadLine();
                        Matrizes.TryGetValue(matrixIsDiagonalName, out double[,] matrixIsDiagonal);
                       
                        Console.WriteLine(CalculadoraMatrizes.Matrix_IsDiagonal(matrixIsDiagonal));
                        Console.ReadLine();
                    break;
                case "9"://triangular superior
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixIsTriangularName = Console.ReadLine();
                        Matrizes.TryGetValue(matrixIsTriangularName, out double[,] matrixIsTriangular);
                       
                        Console.WriteLine(CalculadoraMatrizes.Matrix_IsTriangular(matrixIsTriangular));
                        // Espera que o user faça algo para avançar
                        Console.ReadLine();
                    break;    
                case "10": //Det 3x3
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixToDetName = Console.ReadLine();
                        Matrizes.TryGetValue(matrixToDetName, out double[,] matrixToDet);
                       
                        double Det3x3 = CalculadoraMatrizes.Matrix_Determinant_3x3(matrixToDet);
                        Console.WriteLine($"O determinante da Matriz \"{matrixToDetName} \" é {Det3x3}");
                        Console.ReadLine();
                    break;
                case "11":
                        Console.WriteLine("Qual o nome que pretende dar a este vetor");
                        string nameVetor = Console.ReadLine();
                        double[] vector = CalculadoraMatrizes.Vector_Read();
                        CalculadoraMatrizes.VectorPrint(vector);
                        Vetores.TryAdd(nameVetor, vector);
                        Console.ReadLine();
                    break;
                case "LM": //Show available matrixes

                    //just call the method and give it our dictionary with the matrixes
                    CalculadoraMatrizes.Show_Matrixes(Matrizes);

                    break;
                case "LV":

                    CalculadoraMatrizes.Show_Vectors(Vetores);

                    break;
                default:
                    break;

            }  
        }    
    }
    public void SaveMatrix(double [,] matrix)
    {
        Console.WriteLine("Prentende guardar esta matriz? (S-sim ou N-nao)");
        string escolha = Console.ReadLine();
        if(escolha == "S" || escolha == "s")
        {
            Console.WriteLine("Que nome pretende dar a esta matriz?");
            string matrixName = Console.ReadLine();
            Matrizes.Add(matrixName, matrix);
        }
    }
}