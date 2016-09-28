using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning;

namespace MLWE_UI
{
    public partial class MLWE_UI2 : Form
    {
        Membership_Application.LabeledVector tf;
        Membership_Application.SVM svm_TFIDF;
        Membership_Application.SVM svm_B;
        Membership_Application.kNN kNearest_TFIDF;
        Membership_Application.kNN kNearest_B;
 
        public MLWE_UI2() {
            InitializeComponent();
        }


        public void SetMLWE_UI2(Membership_Application.LabeledVector tf, Membership_Application.SVM svm1, Membership_Application.SVM svm2, Membership_Application.kNN knn1, Membership_Application.kNN knn2)
        {
            this.tf = tf;
            this.svm_TFIDF = svm1;
            this.svm_B = svm2;
            this.kNearest_TFIDF = knn1;
            this.kNearest_B = knn2;

        }


        private void Fscore_label_TF_Click(object sender, EventArgs e)
        {

        }

        private void MLWE_UI2_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void run_job_description_Click(object sender, EventArgs e)
        {
            var instanceBag = new Membership_Application.BagOfWords(job_Description_text_box.Text);
            var insta_tfidf = tf.getNewTF_IDFInstance(instanceBag);
            var insta_binary = tf.getNewBinaryInstance(instanceBag);
            int size = instanceBag.Size();
            int unique = instanceBag.UniqueWordCount();

            int sizeThreshHold = tf.corpusMetrics["Average Word Count"] - tf.corpusMetrics["SD Word Count"];
            int uniqueThreshHold = tf.corpusMetrics["Average Unique Word Count"] - tf.corpusMetrics["SD Unique Word Count"];
            if(size < sizeThreshHold || unique < uniqueThreshHold)
            {
                this.svm_TFIDF_Pred.Text = "";
                this.svm_Binary_Pred.Text = "";
                this.kNN_TFIDF_Pred.Text = "";
                this.kNN_Binary_Pred.Text = "Push for review";
                return;

            }
            var svmpredtfidf = svm_TFIDF.Predict(insta_tfidf, size);
            string svm_tfidf_predict = (svmpredtfidf == 0 || svmpredtfidf == -1) ? "Rejected" : "Accepted";
            if (svm_tfidf_predict == "Rejected")
            {
                this.svm_TFIDF_Pred.Text = "SVM with TF-IDF predicts " + svm_tfidf_predict.ToLower() + " with " + (1 - svm_TFIDF.getProbability()) + " certainty.";
            }
            else
            {
                this.svm_TFIDF_Pred.Text = "SVM with TF-IDF predicts " + svm_tfidf_predict.ToLower() + " with " + svm_TFIDF.getProbability() + " certainty.";
            }


            var svmpredb = svm_B.Predict(insta_tfidf, size);
            string svm_b_predict = (svmpredb == 0 || svmpredb == -1) ? "Rejected" : "Accepted";

            if (svm_b_predict == "Rejected")
            {
                this.svm_Binary_Pred.Text = "SVM with Binary predicts " + svm_b_predict.ToLower() + " with " + (1 - svm_B.getProbability()) + " certainty.";
            }
            else
            {
                this.svm_Binary_Pred.Text = "SVM with Binary predicts " + svm_b_predict.ToLower() + " with " + svm_B.getProbability() + " certainty.";
            }


            var knnpredtfidf = kNearest_TFIDF.Predict(insta_binary, size);
            string knn_tfidf_predict = (knnpredtfidf == 0 || knnpredtfidf == -1) ? "Rejected" : "Accepted";
            this.kNN_TFIDF_Pred.Text = "kNN with TF-IDF predicts " + knn_tfidf_predict.ToLower() + " with " + kNearest_TFIDF.getProbability() + " certainty.";

            var knnpredb = kNearest_B.Predict(insta_binary, size);
            string knn_b_predict = (knnpredb == 0 || knnpredb == -1) ? "Rejected" : "Accepted";

            this.kNN_Binary_Pred.Text = "kNN with Binary predicts " + knn_b_predict.ToLower() + " with " + kNearest_B.getProbability() + " certainty.";
        }

        private void svm_TFIDF_Pred_Click(object sender, EventArgs e)
        {

        }

    }
}
