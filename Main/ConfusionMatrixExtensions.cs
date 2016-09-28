using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Analysis;
using Accord.Controls;

namespace Membership_Application
{
    public static class ConfusionMatrixExtensions
    {
        public static void printStats(this ConfusionMatrix matrix, string title, string path)
        {
            Console.WriteLine(title);
            Console.WriteLine("F-score: " + matrix.FScore);
            Console.WriteLine("Precision: " + matrix.Precision);
            Console.WriteLine("Recall: " + matrix.Recall);
            Console.WriteLine("Specificity: " + matrix.Specificity);
            Console.WriteLine();

            writeStats(matrix, title, path);
        }

        public static void writeStats(this ConfusionMatrix matrix, string title, string path)
        {
            File.AppendAllText(path, title + Environment.NewLine);
            File.AppendAllText(path, "F-score: " + matrix.FScore + Environment.NewLine);
            File.AppendAllText(path, "Precision: " + matrix.Precision + Environment.NewLine);
            File.AppendAllText(path, "Recall: " + matrix.Recall + Environment.NewLine);
            File.AppendAllText(path, "Specificity: " + matrix.Specificity + Environment.NewLine);
            File.AppendAllText(path, "" + Environment.NewLine);
        }

        
    }
}
