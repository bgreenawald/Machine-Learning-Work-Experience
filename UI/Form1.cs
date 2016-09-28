using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using Deedle;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Distributions.Fitting;
using System.Diagnostics;
//using Accord.Math;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Models.Regression;
using Accord.Statistics.Models.Regression.Fitting;
using Accord.Statistics.Analysis;
using System.Threading;
using Accord.Controls;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace MLWE_UI
{
    public partial class Form1 : Form
    {
        MLWE_UI2 form_MLWE_UI = new MLWE_UI2();
        public Form1()
        {
            InitializeComponent();
            form_MLWE_UI.Visible = false;
            Thread.Sleep(1500);
            backgroundWorker1.WorkerReportsProgress = true;
        //    this.new_Case_Button.
        }


        private void open_file_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.CurrentDirectory;
            openFileDialog1.Multiselect = false;
            openFileDialog1.Filter = "Excel files (*.xls, *.xlsx)|*.xls;*.xlsx";

            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                Search_text.Text = openFileDialog1.FileName;
            }
        }


        private void run_test_Click(object sender, EventArgs e)
        {
            if(backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void SVM_Fscore_TextChanged(object sender, EventArgs e)
        {

        }

     
        private void backgroundWorker1_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            var results = (Dictionary<ConfusionMatrix, double>) e.Result;
            var res = results.Keys;

            if(res.ElementAt(0) != null)
            {
                var svm_stats = res.ElementAt(0);
                SVM_Fscore_IDF.Text = (svm_stats.FScore.ToString("N2"));
                SVM_Specificity_IDF.Text = (svm_stats.Specificity.ToString("N2"));
                SVM_Precision_IDF.Text = (svm_stats.Precision.ToString("N2"));
                SVM_Recall_IDF.Text = (svm_stats.Recall.ToString("N2"));
            }

            if(res.ElementAt(1) != null)
            {
                var knn_stats = res.ElementAt(1);
                KNN_Fscore_IDF.Text = (knn_stats.FScore.ToString("N2"));
                KNN_Specificity_IDF.Text = (knn_stats.Specificity.ToString("N2"));
                KNN_Precision_IDF.Text = (knn_stats.Precision.ToString("N2"));
                KNN_Recall_IDF.Text = (knn_stats.Recall.ToString("N2"));
            }

            if (res.ElementAt(2) != null)
            {
                var svm_b = res.ElementAt(2);
                SVM_Fscore_B.Text = (svm_b.FScore.ToString("N2"));
                SVM_Specificity_B.Text = (svm_b.Specificity.ToString("N2"));
                SVM_Precision_B.Text = (svm_b.Precision.ToString("N2"));
                SVM_Recall_B.Text = (svm_b.Recall.ToString("N2"));
            }

            if (res.ElementAt(3) != null)
            {
                var knn_b = res.ElementAt(3);
                KNN_Fscore_B.Text = (knn_b.FScore.ToString("N2"));
                KNN_Specificity_B.Text = (knn_b.Specificity.ToString("N2"));
                KNN_Precision_B.Text = (knn_b.Precision.ToString("N2"));
                KNN_Recall_B.Text = (knn_b.Recall.ToString("N2"));
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            progressLabel.Text = (string) (e.UserState + e.ProgressPercentage.ToString() + '%');
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Background worker to free up the main UI
            BackgroundWorker worked = sender as BackgroundWorker;
            var processer = new Membership_Application.Preprocessor(@"C:/Users/bhg/My Documents/workExperienceDataFullMARIA.csv");

            IFormatter formatter = new BinaryFormatter();
            var keys = (Tuple<List<int>, List<int>>)formatter.Deserialize(new FileStream("C:\\Users\\bhg\\Documents\\keys", FileMode.Open, FileAccess.Read, FileShare.None));

            //Make the files
            string path = @"C:\\Users\\bhg\\Documents\\membership_results.txt";
            generateFile(path);

            //Test instance variables

            int trainsize = keys.Item1.Count();
            int testsize = keys.Item2.Count();

            double complexity = 1;
 
            worked.ReportProgress(5, "Preprocessing Data... ");
            var data = processer.getDataFiltered();

           
            worked.ReportProgress(15, "Generating Corpus... ");
            var corpus = new Membership_Application.Corpus(data.Rows[keys.Item1.Take(trainsize)]);

            int actualNegativeCount = corpus.labeledDocuments[0].Count;
            int actualPositiveCount = corpus.labeledDocuments[1].Count;

            worked.ReportProgress(30, "Creating features... ");
            var tf = (Membership_Application.LabeledVector) formatter.Deserialize(new FileStream(@"C:\\Users\\bhg\\Documents\\LabeledVectors.bin", FileMode.Open));

            double[][] matrix = tf.getTF_IDFMatrix();
            double[][] freq_matrix = tf.getFrequencyMatrix();
            double[][] binary_matrix = tf.getBinaryMatrix();
            int[] labels = tf.getLabelVector();

            int[] svmlabels = transformLabels(labels);

            worked.ReportProgress(65, "Making models... ");

            //Models TF_IDF
            int pre_k = (int)Math.Sqrt(testsize);
            int k = pre_k % 2 == 0 ? pre_k + 1 : pre_k;
            //Make the models
            var svm_TFIDF = new Membership_Application.SVM(size: corpus.VocabularySize, complexity: complexity, positiveComplexity: .5);
            svm_TFIDF.svm = SupportVectorMachine.Load(new FileStream(@"C:\\Users\\bhg\\Documents\\svm_TFIDF", FileMode.Open));
            var kNearest_TFIDF = new Membership_Application.kNN(k: k);
           
            var svm_B = new Membership_Application.SVM(size: corpus.VocabularySize, complexity: complexity, positiveComplexity: .5);
            svm_B.svm = SupportVectorMachine.Load(new FileStream(@"C:\\Users\\bhg\\Documents\\svm_B", FileMode.Open));
            var kNearest_B = new Membership_Application.kNN(k: k);

            worked.ReportProgress(70, "Training models... ");
            //TF-ID
            if (this.KNN_IDF.Checked == true) { kNearest_TFIDF.Train(inputs: matrix, labels: labels); }

            worked.ReportProgress(73, "Training models... ");

            worked.ReportProgress(77, "Training models... ");

            //Binary 
            if (this.KNN_B.Checked == true) { kNearest_B.Train(inputs: binary_matrix, labels: labels); }


            //Finally the Binary term freqeuncy
            var true_labels = new List<int>();


            worked.ReportProgress(80, "Running tests... ");

            int counter = 0;
            foreach (int key in keys.Item2.Take(testsize))
            {
                var instance = data.Rows[key].GetAs<string>("JOB_DESCRIPTION");
                var instanceBag = new Membership_Application.BagOfWords(instance);

                var insta_tfidf = tf.getNewTF_IDFInstance(instanceBag);
                var insta_binary = tf.getNewBinaryInstance(instanceBag);

                //Perform the prediction and add the labels
                if (this.KNN_IDF.Checked == true) { kNearest_TFIDF.Compute(insta_tfidf); }

                //Binary
                if (this.KNN_B.Checked == true) { kNearest_B.Compute(insta_binary); }

                true_labels.Add(corpus.getLabel(data.Rows[key].GetAs<string>("APPROVAL_STATUS").Trim()));

                //Keep track of the progress
                Console.WriteLine(counter);
                counter++;
                worked.ReportProgress((int)(80 + ((double)counter / testsize) * 20), "Running tests... ");
            }

            //Generate our return list of confusion matrices to return to the main thread
            //Add in nulls so we know exactly what order everything is
            var matrices = new List<ConfusionMatrix>();

            var results = new Dictionary<ConfusionMatrix, double>();
            
            if (this.SVM_IDF.Checked == true)
            {
                var svm_stats = (ConfusionMatrix)formatter.Deserialize(new FileStream("C:\\Users\\bhg\\Documents\\SVM TFIDF Confustion", FileMode.Open));
                // var roc1 = new ReceiverOperatingCharacteristic(svm_TFIDF.getLabels().ToArray<int>(), true_labels.Select(Convert.ToDouble).ToArray());
                results[svm_stats] = 0;//roc1.Area;
            } else { matrices.Add(null); }


            if (this.KNN_IDF.Checked == true)
            {
                var knn_stats = new ConfusionMatrix(kNearest_TFIDF.getLabels().ToArray<int>(), true_labels.ToArray<int>(), positiveValue: 1);
                var roc2 = new ReceiverOperatingCharacteristic(kNearest_TFIDF.getLabels().ToArray<int>(), true_labels.Select(Convert.ToDouble).ToArray());
                results[knn_stats] = roc2.Area;
            }
            else {  matrices.Add(null);  }


            if (this.SVM_B.Checked == true)
            {
                var svm_b = (ConfusionMatrix)formatter.Deserialize(new FileStream("C:\\Users\\bhg\\Documents\\SVM B Confustion", FileMode.Open));
              //  var roc3 = new ReceiverOperatingCharacteristic(svm_B.getLabels().ToArray<int>(), true_labels.Select(Convert.ToDouble).ToArray());
                results[svm_b] = 0;
            }
            else { matrices.Add(null); }


            if (this.KNN_B.Checked == true)
            {
                var knn_b = new ConfusionMatrix(kNearest_B.getLabels().ToArray<int>(), true_labels.ToArray<int>(), positiveValue: 1);
                var roc4 = new ReceiverOperatingCharacteristic(kNearest_B.getLabels().ToArray<int>(), true_labels.Select(Convert.ToDouble).ToArray());
                results[knn_b] = roc4.Area;
            }
            else { matrices.Add(null); }

            
            worked.ReportProgress(100, "Done...");
            Console.Beep();
            form_MLWE_UI.SetMLWE_UI2(tf, svm_TFIDF, svm_B, kNearest_TFIDF, kNearest_B);
            e.Result = results;
        }
        
        //Transform the labels for the SVM Classifier
        public static int[] transformLabels(int[] prevLabels)
        {
            int[] new_labels = new int[prevLabels.Count()];
            for (int i = 0; i < prevLabels.Length; i++)
            {
                if (prevLabels[i] == 0)
                {
                    new_labels[i] = -1;
                }
                else
                {
                    new_labels[i] = 1;
                }
            }

            return new_labels;
        }

        public static int[] backTransformLabels(List<int> labels, int size)
        {
            int[] return_labels = new int[size];

            for (int i = 0; i < labels.Count; i++)
            {
                if (labels.ElementAt(i) == -1)
                {
                    return_labels[i] = 0;
                }
                else
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

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void new_Case_Button_Click(object sender, EventArgs e)
        {
            form_MLWE_UI.ShowDialog(this);
        }
    }
}
