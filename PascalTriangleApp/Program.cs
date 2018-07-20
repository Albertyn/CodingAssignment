using System;

namespace PascalTriangleApp
{
    /* The following pattern of numbers is called Pascal’s triangle. 

        1 
       1 1 
      1 2 1 
     1 3 3 1 
    1 4 6 4 1 
       ... 

    The numbers at the edge of the triangle are all 1, 
    and each number inside the triangle 
    is the sum of the two numbers above it. 

    Write a function that computes the elements of Pascal’s triangle by means of a recursive process. 
    Having a function pascal (column,row)  the function must evaluate the value given the parameters. 

    Example: 
    pascal(0,2) = 1 
    pascal(1,2) = 2 
    pascal(1,3) = 3 

    Rules: 
     Limit mutable variables as far as possible. 
     Write unit tests to ensure that the coverage is good. (MSTest or Nunit) 

     Recursive process must be used. 


             */
    public class Utils
    {

        public int[][] ToPascalJaggedArr(int rows)
        {
            int[][] arr = new int[rows][];
            arr[0] = new int[] { 1 };

            for (int i = 1; i < rows; i++)
            {
                arr[i] = ToPascalArr(arr[i - 1]);
            }

            return arr;
        }
        public int[] ToPascalArr(int[] input)
        {
            int[] value = new int[input.Length + 1];

            for (int i = 0; i < input.Length; i++)
            {
                value[i] = (i == 0) ? input[i] : input[i - 1] + input[i];
            }

            value[input.Length] = 1;

            return value;
        }
        public int pascalValue(ref int[][] arr, int column, int row)
        {
            return arr[row][column];
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many dimentions?");

            Int32.TryParse(Console.ReadLine(), out int D);

            Utils utils = new Utils();

            int[][] arr = utils.ToPascalJaggedArr(D);

            for (int i = 0; i < D; i++)
            {
                string _s = "";
                for (int ii = D; ii > i; ii--)
                {
                    _s += " ";
                }
                Console.WriteLine(_s + string.Join(" ", arr[i]));
            }


            // foreach (var x in arr) Console.WriteLine(string.Join(" ", x));
            // Console.WriteLine("\npascal(0,2) = 1..." + utils.pascalValue(ref arr, 0, 2).ToString());
            // Console.WriteLine("\npascal(1,2) = 2..." + utils.pascalValue(ref arr, 1, 2).ToString());
            // Console.WriteLine("\npascal(1,3) = 3..." + utils.pascalValue(ref arr, 1, 3).ToString());

            // Keep the console window open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
