namespace Core.Application.Extensions
{
    public static class LINQExtensions
    {
        //double[] numbers1 = { 0.9, 5, 2, 9.3, 2.6, 7, 3.3, 4 };
        // var query = numbers1.Median();
        //Console.WriteLine("double: Median = " + query1);
        //Kullanımıda yukarıdaki gibi.

        public static double Median(this IEnumerable<double>? source)
        {
            if (!(source?.Any() ?? false)) throw new InvalidOperationException("A null or empty set cannot be used to compute the median..");

            var sortedList = (from numberX in source
                              orderby numberX
                              select numberX).ToList();

            int itemIndex = sortedList.Count / 2;
            if (sortedList.Count % 2 == 0)
            {
                return (sortedList[itemIndex] + sortedList[itemIndex - 1]) / 2;
            }
            else
            {
                return sortedList[itemIndex];
            }
        }
        public static double Median<T>(this IEnumerable<T> numbersY,
                       Func<T, double> selector) =>
    (from num in numbersY select selector(num)).Median();

        //Aşagıdaki kullanıma sahip olur.
        //        int[] numbers4 = { 14, 16, 15, 13, 11, 10, 9 };

        //        /*
        //           In this case, the compiler will implicitly convert num=>num's value to double when you pass it as a parameter to the Median method.
        //           Otherwise, the compiler will give the user an error message.
        //        */
        //        var query4 = numbers4.Median(num => num);

        //        Console.WriteLine("int: Median = " + query3);

        //string[] numbers5 = { "fourteen", "sixteen", "fifteen", "thirteen", "eleven", "ten", "nine" };

        //        A number of object properties are available with the generic overload.

        //       var query5 = numbers5.Median(str => str.Length);

        //        Console.WriteLine("String: Median = " + query5);
    }
}
