using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership_Application
{
    public class ArraySplitter
    {
        public ArraySplitter() {}
        public Tuple<IEnumerable<int>, IEnumerable<int>> Split(IEnumerable<int> allDocuments, double split)
        {
            var needed = (int)(allDocuments.Count() * split);

            var ar = allDocuments.ToArray();

            Shuffle(ar);

            var training = ar.Take(needed);
            var test = ar.Skip(needed);

            return Tuple.Create(training, test);
        }

        public static void Shuffle<T>(T[] array)
        {
            var random = new Random();
            int n = array.Length;
            for (int i = 0; i < n; i++)
            {
                // NextDouble returns a random number between 0 and 1.
                // ... It is equivalent to Math.random() in Java.
                int r = i + (int)(random.NextDouble() * (n - i));
                T t = array[r];
                array[r] = array[i];
                array[i] = t;
            }
        }


    }

}
