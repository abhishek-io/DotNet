using System;

namespace PracticeProject
{
    class Program

    {
        static void Main(string[] args)

        {

            //// Searching of element in Array
            //int[] arr = new int[] { 1, 2, 3, 4, 5 };
            //string[] strArr = new string[] {"Abhishek", "Mayank", "Aditya", "Rishab", "Nishank" };
            //bool found = false;
            //int position = 0;

            ////int num = int.Parse(Console.ReadLine());
            //string str = Console.ReadLine();

            //    for (int j = 0; j < strArr.Length; j++)
            //    {
            //    position++;

            //    if (str == strArr[j])
            //        {
            //            found = true;


            //            break;
            //        }

            //    }

            //if (found)
            //{
            //    Console.WriteLine("Element found at {0}th Position",position);
            //}
            //else
            //{
            //    Console.WriteLine("element not found");
            //}




            int temp = 0;
            int[,,] arr = new int[3,3,3] { 
                { 
                    { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } 
                },
                { 
                    {1,2,3 },{4,5,6 },{7,8,9 }
                },
                {
                    {1,2,3 },{4,5,6 },{7,8,9 }
                }
            };

            for (int i = 0; i < 3; i++)
            {
                Console.Write("\n");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("\n");
                    for (int k = 0; k < 3; k++)
                    {
                        

                        Console.Write(arr[i,j,k]+" ");

                    }
                }

            }




            Console.ReadLine();
        }

       


    }


    public class PracticePrograms
    {
        public void FibonacciSeries()
        {
            int p1 = 0, p2 = 1, p3;
            Console.WriteLine("enter num");
            int count = Int32.Parse(Console.ReadLine());
            Console.WriteLine("fibonacci series for provided number is:\n" + p1 + "\n" + p2);
            for (int i = 2; i < count; i++)
            {
                p3 = p1 + p2;
                Console.WriteLine(p3);
                p1 = p2;
                p2 = p3;
            }

        }


        public void FactorialNumber()
        {
            Console.WriteLine("please provide factorial number");
            int factNumber = Int32.Parse(Console.ReadLine());
            int factResult = 1;
            for (int i = factNumber; i >= 1; i--)
            {
                factResult = factResult * i;

            }
            Console.WriteLine("{0}! is {1}", factNumber, factResult);
        }

        public void FactorialNumberRecursive()
        {

            Console.WriteLine("entr a num");
            int factNum = Int32.Parse(Console.ReadLine());

            int result = Factorial(factNum);
            Console.WriteLine("{0}! is {1}", factNum, result);
        }

            public static int fact = 1;

        private static int Factorial(int factNum)
        {
            if (factNum > 0)
            {
                fact = factNum * Factorial(factNum - 1);

            }

            return fact;
        }
    



    }//End of Class PracticeProgram

   

}




//------------------BASIC LOGICAL PROGRAMS----------------------------------------





//PracticePrograms p = new PracticePrograms();
//p.FactorialNumberRecursive();


//int index = 10;

//do
//{
//    for (int i = 0; i < index; i++)
//    {
//        Console.Write("*");

//    }
//    Console.Write("\n");

//    index--;

//} while (index>=1);


//for (int i = 0; i <5; i++)
//{
//    Console.Write("*");

//    for (int j = 0; j < i; j++)
//    {
//        Console.Write("*");

//    }
//    Console.Write("\n");

//}



//Console.WriteLine("enter a string");
//string inputString = Console.ReadLine();
//string reverseString = string.Empty;
//int lenght = inputString.Length - 1;
//while (lenght >= 0)
//{
//    reverseString = reverseString + inputString[lenght];
//    lenght--;

//}

//if (reverseString==inputString)
//{
//    Console.WriteLine("Is PAllindrome");

//}

//PracticePrograms pp = new PracticePrograms();
//pp.FibonacciSeries();





//int n, r, sum = 0, temp;
//Console.Write("Enter the Number= ");
//n = int.Parse(Console.ReadLine());
//temp = n;
//while (n > 0)
//{
//    r = n % 10;
//    sum = sum + (r * r * r);
//    n = n / 10;
//}
//if (temp == sum)
//    Console.Write("Armstrong Number.");
//else
//    Console.Write("Not Armstrong Number.");


//Bubble sort technique
//int[] arr = new int[] { 1,2,3,4,5};
//int temp;

//for (int i = 0; i < arr.Length; i++)
//{

//    for (int j = 0; j < arr.Length-1; j++)
//    {

//        if (arr[j]<arr[j+1])//   '>' for accending, '<' for decending
//        {
//            temp = arr[j];
//            arr[j] = arr[j+1];
//            arr[j + 1] = temp;

//        }

//    }
//}
//foreach (var item in arr)
//{
//    Console.WriteLine(item);
//}







//--------------recursive----------------


//---------------------------2--------------prime number------------------------------------
//int i = 0, num;
//Console.WriteLine("enter a number");
//num = Int32.Parse(Console.ReadLine());
//for ( i = 3; i < num; i++)
//{
//    if (num%i==0)
//    {
//        Console.WriteLine($"{num} is not a prime number");
//        break;
//    }
//}
//if (i==num)
//{
//    Console.WriteLine($"{num} is a prime number");
//}

//----------------------------3----------OddEven----------------------------------
//Console.WriteLine("enter a number");
//int input = Int32.Parse(Console.ReadLine());
//if (input % 2 == 0)
//{
//    Console.WriteLine($"{input} is a even number");
//}
//else
//{
//    Console.WriteLine($"{input} is a odd number");
//}

//-----------------------------4----------------reverse string---------------------------------------
//Console.WriteLine("enter a string");
//string inputString = Console.ReadLine();
//string reverseString = string.Empty;
//int lenght = inputString.Length - 1;
//while (lenght >= 0)
//{
//    reverseString = reverseString + inputString[lenght];
//    lenght--;

//}

//Console.WriteLine($"reverse is  {reverseString}");

//------------------------------5--------------fibonacci---------------------------------------------

//static int p1 = 0, p2 = 1, p3;


// inside main
//Console.WriteLine("entr a num");
//int count = Int32.Parse(Console.ReadLine());
//Console.WriteLine("fibonaci is");
//Console.WriteLine(p1+"\n"+p2);
//for (int i = 2; i < count; i++)
//{
//    p3 = p1 + p2;
//    Console.WriteLine(p3);
//    p1 = p2;
//    p2 = p3;
//}

//Fibonacci(count - 2);

//Console.WriteLine();

//-------------------recursion methd----------------------
//private static void Fibonacci(int count)
//{
//    if (count>0)
//    {
//        p3 = p1 + p2;
//        Console.WriteLine(p3);
//        p1 = p2;
//        p2 = p3;
//        Fibonacci(count - 1);

//    } 
//}



//-------------------------------5--------------number pattern-----------------------------------------------

//Console.WriteLine("enter no of rows");
//int noOfRows = Int32.Parse(Console.ReadLine());

//for (int row = 0; row <= noOfRows; row++)
//{
//    for (int column = 1; column <= row; column++)
//    {
//        Console.Write(row);
//    }
//    Console.WriteLine();
//}


