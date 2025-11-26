public class Program{
    public static void Main(){
                
            CalculadoraMatrizes calc = new CalculadoraMatrizes();
            
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
                    double [,] matrixAdd = calc.Matrix_Read();
                    
                    //adicionar o nome e a matriz a um dicionario de matrizes
                    Matrizes.TryAdd(Name, matrixAdd);
                    break;
                case "2": //multiplicar a matriz por uma escalar

                        //Obter a Matriz dentro pelo nome 
                        Console.WriteLine("Qual a Matriz que pretende usar?");
                        string MatrixName = Console.ReadLine();
                        Matrizes.TryGetValue(MatrixName, out double[,] matrixScalarMult);

                        //obter a constante para multiplicar a matriz
                        Console.WriteLine("Por qual valor pretende multiplicar a Matriz");
                        double valor = Convert.ToDouble(Console.ReadLine());

                        //Multiplicar a Matriz escolhida pela constante
                        double[,] MatrixMulti = calc.Matrix_Scalar_Mult(matrixScalarMult, valor);

                        calc.MatrixPrint(MatrixMulti);
                    break;
                case "3": //Somar duas matrizes

                        //obter as matrizes para somar
                        Console.WriteLine("Quais as matrizes que pretende somar?");

                        //reading user input
                        string matrizes = Console.ReadLine();
                        string[] letrasMatrizes = matrizes.Split(" ",StringSplitOptions.None);
                        
                        //associar o inputa separado do user para cada variavel
                        string matrixAAddName = letrasMatrizes[0]; 
                        string matrixBAddNome = letrasMatrizes[1]; 

                    //procurar no dicionario as matrizes que o user inseriu 
                        Matrizes.TryGetValue(matrixAAddName, out double[,] matrixAAdd);
                        Matrizes.TryGetValue(matrixBAddNome, out double[,] matrixBAdd);

                        //fazer a soma das matrizes
                        calc.Matrix_ADD(matrixAAdd, matrixBAdd);
                    break;
                case "4": //multiplicação de matrizes

                    break;
                case "5": //inversa 2x2

                    break;
                case "6": //inversa 3x3

                    break;
                case "7": //tranposta de uma matriz

                    break;
                case "8": //Matriz triangular

                    break;
                case "9": //

                    break;
                default:
                    break;

            }  
        }    
    }
}