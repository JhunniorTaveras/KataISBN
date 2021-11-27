using System;

namespace KataISBN
{
    class ISBN
    {
        static void Main(string[] args)
        {
            string isbn;
            long testNumber;

            while (true)
            {
                Console.Write("Inserte el codigo ISBN: ");

                try
                {
                    isbn = Console.ReadLine();
                    testNumber = Convert.ToInt64(isbn);

                    if (isbn.Length == 10)
                    {
                        CodigoDiez(isbn);
                        break;
                    }
                    else if (isbn.Length == 13)
                    {
                        CodigoTrece(isbn);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Codigo Invalido. Porfavor Intentelo de nuevo.");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        static bool CodigoDiez(string codigo)
        {

            char[] numbers = codigo.ToCharArray();
            Array.Reverse(numbers);

            int number, sum = 0, a = 1;


            for (int i = 0; i < numbers.Length; i++)
            {
                number = (int)Char.GetNumericValue(numbers[i]) * a;
                sum += number;
                a++;
            }

            if (sum % 11 == 0)
            {
                Console.WriteLine($"{codigo} is a valid ISBN");
                return true;
            }
            else
            {
                Console.WriteLine($"{codigo} is not a valid ISBN");
                return false;
            }
        }

        static bool CodigoTrece(string codigo)
        {
            char[] numbers = codigo.ToCharArray();
            Array.Reverse(numbers);

            int number, sum = 0;


            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % 2 == 0)
                {
                    number = (int)Char.GetNumericValue(numbers[i]) * 3;
                }
                else
                {
                    number = (int)Char.GetNumericValue(numbers[i]) * 1;
                }
                sum += number;
            }

            if (sum % 10 == 0)
            {
                Console.WriteLine($"{codigo} is a valid ISBN");
                return true;
            }
            else
            {
                Console.WriteLine($"{codigo} is not a valid ISBN");
                return false;
            }
        }
    }
}
