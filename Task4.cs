using System;

namespace TestSpace
{
    class Program
    {
        static void Main()
        {
            // 1.
            string test = "Fallout";

            ForString instanceString = new ForString(test);
            Console.WriteLine(instanceString.ShavString(5));
            Console.WriteLine(instanceString.ShavString(3,5));
            Console.WriteLine(instanceString.Concating("New", "Vegas", "Is", "Best", "3D", "Fallot", "Ever"));
            Console.WriteLine(instanceString.ToSomthing('U'));
            Console.WriteLine(instanceString.ToSomthing('L'));

            // 2.
            int someNum = 1377;
            Console.WriteLine("Byte Array: " + string.Join(" ", ToByteArray(someNum)));

            // 3.
            Vector First = new Vector(4, 8, 16);
            Vector Second = new Vector(2, 4, 8);
            Vector Third = Vector.MathVector(First, Second, '+');
            Console.WriteLine($"New Vector : x={Third.x}, y={Third.y}, z={Third.z}");

            // 4.
            Console.WriteLine("Type: " + Typing(First));
            Console.WriteLine("Type: " + Typing(test));

            // 5.

            Library limb = new Library(4);

            Book orwell = new Book("1984");

            limb.AddBook(orwell);
            limb.AddBook("It's me - Edichka");

            limb.ShowBooks();

            Console.WriteLine("Book found status: " + limb.IsBookExist(orwell));
            Console.WriteLine("Book found status: " + limb.IsBookExist("The Catcher in the Rye"));

            limb.RemoveBook("It's me - Edichka");

            limb.AddBook("Tractatus Logico-Philosophicus");
            limb.AddBook("Critique of Pure Reason");
            limb.AddBook("Critique of Practical Reason");
            limb.ShowBooks();

            limb.RemoveBook(orwell);
            limb.RemoveBook("Critique of Practical Reason");

            Book hegel = new Book("Wissenschaft der Logik");
            limb.RemoveBook(hegel);

            limb.ShowBooks();

            //6.

            long big = long.MaxValue;
            float small = 23.84F;
            int gig = 1024;
            int _gig_ = 1_000_380;
            int gigchec = 1_000_000;

            Console.WriteLine(big.Abb());
            Console.WriteLine(small.Abb());
            Console.WriteLine(gig.Abb());
            Console.WriteLine(_gig_.Abb());
            Console.WriteLine(gigchec.Abb());


            Console.Read();
        }

        /******************** 4 ******************/

        static string Typing(object source)
        {
            string myType = source.GetType().ToString();

            return myType.Remove(0, myType.IndexOf('.')+1);
        }

        /******************** 2 ******************/

        static byte[] ToByteArray(int source)
        {
            string converValue = source.ToString();
            byte[] value = new byte[converValue.Length];
            
            for(var i = 0; i < converValue.Length; i++)
            {
                value[i] = (byte) converValue[i];
            }

            return value;
        }

    }

    /******************** 1 ******************/
    class ForString
    {
        public string inputString;

        public ForString(string source)
        {
            this.inputString = source;
        }

        public string ShavString(int end, int start = 0)
        {
            int[] checkArray = { end, start };
            bool verifictionFlag = true;

            foreach (var index in checkArray)
            {
                if(index >= this.inputString.Length || index < 0)
                {
                    verifictionFlag = false;
                    break;
                }
            }

            if (verifictionFlag)
            {
                if (start != 0)
                {
                    int temp = end;
                    end = start;
                    start = temp;
                    end -= start;
                }

                return this.inputString.Substring(start, end);
            }
            else
            {
                return "Your indexes for trim not in string length";
            }

        }

        public string Concating (params string[] array)
        {
            string text = this.inputString;

            foreach(var str in array)
            {
                text += str;
            }

            return text;
        }

        public string ToSomthing(char mode)
        {
            if (mode == 'U')
            {
                return this.inputString.ToUpper();
            }
            else if (mode == 'L')
            {
                return this.inputString.ToLower();
            }
            else
            {
                return this.inputString;
            }
        }

    }

    /******************** 3 ******************/
    struct Vector
    {
        public int x;
        public int y;
        public int z;

        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector MathVector(Vector a, Vector b, char mode = '-')
        {

            if(mode == '+')
            {
                return new Vector(a.x + b.x, a.y + b.y, a.z + b.z);

            }
            else
            {
                return new Vector(a.x - b.x, a.y - b.y, a.z - b.z);
 
            }

        }
    }

    /******************** 5 ******************/
    struct Book
    {
        public string name;

        public Book(string name)
        {
            this.name = name; 
        }
    }

    class Library
    {
        private Book[] list;

        private int counter = 0;

        public Library(uint size)
        {
            this.list = new Book[size+1];
        }

        public void AddBook(string bookName)
        {   
            if(counter == list.Length - 1)
            {
                Console.WriteLine("The library is full.");
                return;
            }

            list[counter] = new Book(bookName);
            counter++;
        }

        public void AddBook(Book book)
        {
            list[counter] = book;
            counter++;
        }

        public void ShowBooks()
        {
            Console.WriteLine("--------------------");
            for (var i = 0; i < counter; i++)
            {
                Console.WriteLine(list[i].name);
            }
            Console.WriteLine("--------------------");
        }

        public bool IsBookExist(string bookName)
        {
            foreach(var book in list)
            {
                if(bookName == book.name)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsBookExist(Book book)
        {
            return IsBookExist(book.name);
        }

        public void RemoveBook(string bookName)
        {
            if (IsBookExist(bookName) == false)
            {
                return;
            }

            bool flag = false;

            for (var i = 0; i < counter; i++)
            {
                if(bookName == list[i].name)
                {
                    flag = true;
                }

                if (flag == true)
                {
                    list[i] = list[i + 1];
                }
            }

            --counter;
        }

        public void RemoveBook(Book book)
        {
            RemoveBook(book.name);
        }
    }

    /******************** 6 ******************/
    static class AbbNumber
    {
        public static string Abb(this float sorce)
        {

            double x;
            string z = "";
            string toInput;

            if (sorce / Math.Pow(10, 12) >= 1)
            {
                x = sorce / Math.Pow(10, 12);
                z = "T";
            }
            else if(sorce / Math.Pow(10, 9) >= 1)
            {
                x = sorce / Math.Pow(10, 9);
                z = "B";
            }
            else if(sorce / Math.Pow(10, 6) >= 1)
            {
                x = sorce / Math.Pow(10, 6);
                z = "M";
            }
            else if(sorce / Math.Pow(10, 3) >= 1)
            {
                x = sorce / Math.Pow(10, 3);
                z = "K";
            }
            else
            {
                x = sorce;
            }

            toInput = x.ToString();

            if (x == (int)x)
            {
                return ((int)x).ToString() + z;
            }
            else if (double.Parse(toInput.Substring(0, 4)) == (int) x)
            {
                return ((int)x).ToString() + z;
            }
            else
            {
                return toInput.Substring(0, 4) + z;
            }

        }

        public static string Abb(this long sorce)
        {
            return Abb((float)sorce);
        }

        public static string Abb(this int sorce)
        {
            return Abb((float)sorce);
        }
    }

}


