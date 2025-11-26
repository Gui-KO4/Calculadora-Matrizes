public class Program{
    public static void Main(){
            Console.Clear();
            String[] Menu =
            {
                "| 1-Leitura de uma Matriz                          |",        
                "| 2-Multiplicar por uma escalar                    |",  
                "| 3-Somar Matrizes                                 |",               
                "| 4-Multiplicar Matrizes                           |",
                "| 5-Inversa de uma Matriz 2x2                      |",
                "| 6-Inversa de uma Matriz 3x3 (Laplace)            |",
                "| 7-Transposta de uma matriz                       |",
                "| 8-Verificar se uma Matriz é diagonal             |",
                "| 9-Verificar se uma Matriz é triangular superior  |"
            };

            Dictionary<string, double[,]> Matrizes = new Dictionary<string, double[,]>{};

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
                    break;
                case "5": //inversa 2x2
                        
                        //Obter a Matriz pelo nome 
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixToInve2Name = Console.ReadLine();
                        Matrizes.TryGetValue(matrixToInve2Name, out double[,] matrixToInve2);
                        
                        double [,] MatrixInve2 = CalculadoraMatrizes.Matrix_Inverse_2x2(matrixToInve2);
                        CalculadoraMatrizes.MatrixPrint(MatrixInve2);
                    break;
                case "6": //inversa 3x3
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string matrixToInve3Name = Console.ReadLine();
                        Matrizes.TryGetValue(matrixToInve3Name, out double[,] matrixToInve3);
                       
                        double [,] matrixInve3 = CalculadoraMatrizes.Inversa3x3(matrixToInve3);
                        CalculadoraMatrizes.MatrixPrint(matrixInve3);
                    break;
                case "7": //tranposta de uma matriz

                    break;
                case "8": //Matriz diagonal

                    break;
                case "9"://triangular superior

                    break;    
                case "10": //Show available matrixes

                    //just call the method and give it our dictionary with the matrixes
                    CalculadoraMatrizes.Show_Matrixes(Matrizes);

                    break;
                default:
                    break;

            }  
        }    
    }
}