using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
//using Accord.Math;
using Accord.Statistics.Analysis;
using Accord.Controls;
using Accord.MachineLearning;
using System.Threading;
using Accord.MachineLearning.VectorMachines;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using Accord.MachineLearning.VectorMachines.Learning;

namespace Membership_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Reading in the data...");
            Preprocessor processer = new Preprocessor(@"C:/Users/bhg/My Documents/workExperienceDataFullMARIA.csv");
            
            //Make the files
            string path = @"C:\\Users\\bhg\\Documents\\membership_results.txt";
            generateFile(path);
            //Test instance variables

            bool oversample = true;
            double split = .8;

            System.
            Console.WriteLine("Preprocessing the data...");
            var data = processer.getDataFiltered();

            SplitArray splitter = new SplitArray();
            var keys = splitter.Split(data.Rows.Keys, split);

            int trainsize = 1000;// keys.Item1.Count();
            int testsize = 1000;// keys.Item2.Count();


            Console.WriteLine("Creating corpus, this may take some time.");
            Corpus corpus = new Corpus(data.Rows[keys.Item1.Take(trainsize)].Merge(processer.getDataExtra()));

            int actualNegativeCount = corpus.labeledDocuments[0].Count;
            int actualPositiveCount = corpus.labeledDocuments[1].Count;

            Console.WriteLine("Extracting the features..");
            var tf = new LabeledVector(corpus);
            double[][] matrix = tf.getTF_IDFMatrix();

            double[][] binary_matrix = tf.getBinaryMatrix();
            int[] labels = tf.getLabelVector();

            int[] svmlabels = transformLabels(labels);

            Console.WriteLine("Making the models...");

            //Making the models
            //Models TF_IDF
            int pre_k = (int)Math.Sqrt(testsize);
            int k = pre_k % 2 == 0 ? pre_k + 1 : pre_k;
            var kNearest_TFIDF = new kNN(k: k);
            kNearest_TFIDF.Train(inputs: matrix, labels: labels);

            Console.WriteLine("kNN 1 Done...");

            // var svm_TFIDF = new SVM(size: corpus.VocabularySize, complexity: 1, positiveComplexity: .5);
            //  svm_TFIDF.Train(inputs: matrix, labels: svmlabels);

            var svm_TFIDF = new SVM(corpus.VocabularySize, 1, .5);

            Task TrainSVM = new Task(() => svm_TFIDF.Train(inputs: matrix, labels: svmlabels));
            TrainSVM.Start();

            Console.WriteLine("SVM 1 Done...");

            //Models Frequency Matrix
            var kNearest_B = new kNN(k: k);
            kNearest_B.Train(inputs: binary_matrix, labels: labels);

            Console.WriteLine("kNN 3 Done...");

            var svm_B = new SVM(size: corpus.VocabularySize, complexity: 1, positiveComplexity: .5);
            svm_B.Train(inputs: binary_matrix, labels: svmlabels);

            Console.WriteLine("SVM 3 Done...");

            Task.WaitAll(TrainSVM);
            TrainSVM.Dispose();

            //Finally the Binary term freqeuncy
            var true_labels = new List<int>();

            //Write the train and test keys to memory
            //Write the labeled vectors to a file to load later
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("C:\\Users\\bhg\\Documents\\keys", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, keys);
            stream.Close();

            Task testB = new Task(() =>
            {
                foreach (int key in keys.Item2.Take(testsize))
                {
                    var instance = data.Rows[key].GetAs<string>("JOB_DESCRIPTION");
                    var instanceBag = new BagOfWords(instance);

                    var insta_binary = tf.getNewBinaryInstance(instanceBag);

                    //Binary
                    kNearest_B.Compute(insta_binary);
                    svm_B.Compute(insta_binary);
                }

            });

            testB.Start();

            int counter = 0;
            foreach(int key in keys.Item2.Take(testsize))
            {
                var instance = data.Rows[key].GetAs<string>("JOB_DESCRIPTION");
                var instanceBag = new BagOfWords(instance);

                var insta_tfidf = tf.getNewTF_IDFInstance(instanceBag);

                //Perform the prediction and add the labels
                kNearest_TFIDF.Compute(insta_tfidf);
                svm_TFIDF.Compute(insta_tfidf);

                true_labels.Add(corpus.getLabel(data.Rows[key].GetAs<string>("APPROVAL_STATUS").Trim()));

                //Keep track of the progress
                Console.WriteLine(counter);
                counter++;

             }

            Task.WaitAll(testB);
            testB.Dispose();

            var svm_stats = new ConfusionMatrix(backTransformLabels(svm_TFIDF.getLabels(), svm_TFIDF.getLabels().Count()), true_labels.ToArray<int>(), positiveValue: 1);
            var knn_stats = new ConfusionMatrix(kNearest_TFIDF.getLabels().ToArray<int>(), true_labels.ToArray<int>(), positiveValue: 1);

            var svm_b = new ConfusionMatrix(backTransformLabels(svm_B.getLabels(), svm_B.getLabels().Count), true_labels.ToArray<int>(), positiveValue: 1);
            var knn_b = new ConfusionMatrix(kNearest_B.getLabels().ToArray<int>(), true_labels.ToArray<int>(), positiveValue: 1);

            Console.WriteLine(svm_stats.ToGeneralMatrix().ToString());
        //    displayROCCurve(backTransformLabels(svm_TFIDF.getLabels(), svm_TFIDF.getLabels().Count()), true_labels.ToArray<int>());
           // displayROCCurve(kNearest_TFIDF.getLabels().ToArray<int>(), true_labels.ToArray<int>());
            //displayROCCurve(backTransformLabels(svm_B.getLabels(), svm_B.getLabels().Count), true_labels.ToArray<int>());
            //displayROCCurve(kNearest_B.getLabels().ToArray<int>(), true_labels.ToArray<int>());

            //Serialize the confusion matrices
            Stream confusion_svm1 = new FileStream("C:\\Users\\bhg\\Documents\\SVM TFIDF Confustion", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(confusion_svm1, svm_stats);

            Stream confusion_svm2 = new FileStream("C:\\Users\\bhg\\Documents\\SVM B Confustion", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(confusion_svm2, svm_b);

            confusion_svm1.Close();
            confusion_svm2.Close();

            //Write the labeled vectors to a file to load later
            Stream stream1 = new FileStream("C:\\Users\\bhg\\Documents\\LabeledVectors.bin", FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream1, tf);
            stream1.Close();

            //Write some basic performance measures
            if (File.Exists(path))
            {
                File.AppendAllText(path, ("Training Size: " + trainsize + Environment.NewLine));
                File.AppendAllText(path, ("Test Size: " + testsize + Environment.NewLine));
                File.AppendAllText(path, "Actual number of negative instances used: " + actualNegativeCount + Environment.NewLine);
                File.AppendAllText(path, "Actual number of positive instances used: " + actualPositiveCount + Environment.NewLine);
                File.AppendAllText(path, ("Oversample: " + oversample + Environment.NewLine));
                File.AppendAllText(path, ("Split: " + split + ":" + (1 - split) + Environment.NewLine));
                File.AppendAllText(path, "k: " + 13 + Environment.NewLine);
                File.AppendAllText(path, "Distance: Euclidean" + Environment.NewLine);
                File.AppendAllText(path, "" + Environment.NewLine);
            }

            svm_stats.printStats("SVM with TF-IDf", path);
            knn_stats.printStats("kNN with TF-IDF", path);

            svm_b.printStats("SVM with TF with Binary Term Matrix", path);
            knn_b.printStats("kNN with TF with Binary Term Matrix", path);

            //Calibrate the prob models
            Task CalibrateTFIDF = new Task(() => svm_TFIDF.calibrate(matrix, svmlabels));
            CalibrateTFIDF.Start();
            svm_B.calibrate(matrix, svmlabels);
            Task.WaitAll(CalibrateTFIDF);

            FileStream fs_svm = File.Create(@"C:\\Users\\bhg\\Documents\\svm_TFIDF");
            Task WriteSVMTFIDF = new Task(() => svm_TFIDF.getModel().Save(fs_svm));
            WriteSVMTFIDF.Start();

            FileStream fs_svm_b = File.Create(@"C:\\Users\\bhg\\Documents\\svm_B");
            svm_B.getModel().Save(fs_svm_b);
            Task.WaitAll(WriteSVMTFIDF);

            fs_svm.Close();   
            fs_svm_b.Close();

            Console.WriteLine();
            Console.Read();
            
        }

        //Transform the labels for the SVM Classifier
        public static int[] transformLabels(int[] prevLabels)
        {
            int[] new_labels = new int[prevLabels.Count()];
            for(int i = 0; i < prevLabels.Length; i++)
            {
                if(prevLabels[i] == 0)
                {
                    new_labels[i] = -1;
                }else
                {
                    new_labels[i] = 1;
                }
            }

            return new_labels;
        }
        
        public static int[] backTransformLabels(List<int> labels, int size)
        {
            int[] return_labels = new int[size];

            for(int i = 0; i < labels.Count; i++)
            {
                if (labels.ElementAt(i) == -1)
                {
                    return_labels[i] = 0;
                }else
                {
                    return_labels[i] = 1;
                }
            }

            return return_labels;
        }
   
        public static void generateFile(string filepath)
        {
            deleteFile(filepath);
            File.Create(filepath);
        }

        public static void deleteFile(string filepath)
        {
            // Delete a file by using File class static method...
            if (File.Exists(filepath))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    File.Delete(filepath);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }


        public static void displayROCCurve(Int32[] outputs, int[] predicted)
        {

            var pred = predicted.Select(x => (double)x).ToArray();
            // Create a new ROC curve to assess the performance of the model
            var roc = new ReceiverOperatingCharacteristic(outputs, pred);
            roc.Compute(100); // Compute a ROC curve with 100 cut-off points

            // Generate a connected scatter plot for the ROC curve and show it on-screen
            ScatterplotBox.Show(roc.GetScatterplot(includeRandom: true))
                .SetSymbolSize(0) // do not display data points
                .SetLinesVisible(true) // show lines connecting points
                .SetScaleTight(true)   // tighten the scale to points
                .WaitForClose();

            Console.WriteLine(roc.Area);
        }


    }
}

 