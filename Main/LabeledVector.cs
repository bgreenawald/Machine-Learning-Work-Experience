using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Membership_Application
{
    [Serializable]
    public class LabeledVector
    {

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //Fields
        [field: NonSerialized]
        public Corpus corpus;

        public double[][] tf_idf_matrix;
        public double[][] frequency_matrix;
        public double[][] binary_matrix; 
        public int[] labels;
        public ICollection<string> keys;
        public int vocab_size;
        public Dictionary<string, int> corpusMetrics;

        int overall_counter;
        //Dictionary to map all words to their corresponding tf-idf scores
        private IDictionary<string, double> idfScores = new Dictionary<string, double>();


        //------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //Constructors

        public LabeledVector() { }
        public LabeledVector(Corpus corp)
        {
            this.corpus = corp;
            this.keys = corp.vocabulary.Keys;
            this.vocab_size = corp.VocabularySize;
            this.tf_idf_matrix = new double[corp.DocumentCount][];
            this.frequency_matrix = new double[corp.DocumentCount][];
            this.binary_matrix = new double[corp.DocumentCount][];
            this.labels = new int[corp.DocumentCount];
            corpusMetrics = corp.getCorpusMetrics();
            //Iterate over every document and create it's tf_idf and frequency vector
            overall_counter = 0;
            getInverseDocumentFrequency(this.corpus);
            foreach(int key in corpus.getVectors().Keys)
            {
                foreach(BagOfWords bag in corpus.getVectors()[key])
                {
                    overall_counter = calculateTF_IDFforCorpus(bag, key, overall_counter);
                }
            }
        }

        //Constructors
        public LabeledVector(Corpus corp, BackgroundWorker worker)
        {
            this.corpus = corp;
            this.keys = corp.vocabulary.Keys;
            this.vocab_size = corp.VocabularySize;
            this.tf_idf_matrix = new double[corp.DocumentCount][];
            this.frequency_matrix = new double[corp.DocumentCount][];
            this.binary_matrix = new double[corp.DocumentCount][];
            this.labels = new int[corp.DocumentCount];
            //Iterate over every document and create it's tf_idf and frequency vector
            overall_counter = 0;
            getInverseDocumentFrequency(this.corpus, worker);

            worker.ReportProgress(55, "Transforming data... ");
            int progress_count = 0;
            int progress_total = corpus.getVectors()[0].Count + corpus.getVectors()[1].Count;
            foreach (int key in corpus.getVectors().Keys)
            {
                foreach (BagOfWords bag in corpus.getVectors()[key])
                {
                    overall_counter = calculateTF_IDFforCorpus(bag, key, overall_counter);
                    progress_count++;
                }
                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //Methods

        //Gets the inverse document frequency for a term within over the entire corpus
        private void getInverseDocumentFrequency(Corpus corp)
        {
            foreach (string term in corp.vocabulary.Keys)
            {
                int docCountInCorpus = corpus.DocumentCount;
                int docCountWithTerm = corpus.numberOfDocumentsInCorpusWithTerm(term);
                float ratio = (float)docCountInCorpus / docCountWithTerm;
                this.idfScores[term] = Math.Log10(ratio);
            }

        }


        //Gets the inverse document frequency for a term within over the entire corpus
        private void getInverseDocumentFrequency(Corpus corp, BackgroundWorker worker)
        {
            int counter = 0;
            int total = corp.vocabulary.Keys.Count;
            foreach (string term in corp.vocabulary.Keys)
            {
                int docCountInCorpus = corpus.DocumentCount;
                int docCountWithTerm = corpus.numberOfDocumentsInCorpusWithTerm(term);
                float ratio = (float)docCountInCorpus / docCountWithTerm;
                this.idfScores[term] = Math.Log10(ratio);

                //Update the progress
                worker.ReportProgress((int)(30 + ((double)counter / total) * 25), "Creating features... ");

                counter++;
            }

        }

        //Calculate the term frequency-inverse document frequency for a term 
        public int calculateTF_IDFforCorpus(BagOfWords bag, int label, int overall_count)
        {
            double[] tf_idf = new double[this.corpus.VocabularySize];
            double[] frequency = new double[this.corpus.VocabularySize];
            double[] binary = new double[this.corpus.VocabularySize];
            int counter = 0;

            //Loop over entire vocabulary and get freqeuncy and tf-idf information
            foreach(string word in this.corpus.vocabulary.Keys)
            {
                bool contains = bag.getFrequencyDict().Keys.Contains(word);
                int binary_contains = 0;
                int count = 0;
                double tf = 0;
                if (contains)
                {
                    count = bag.getFrequencyDict()[word];
                    tf = 1 + Math.Log10(count);
                    binary_contains = 1;
                }

                //Get the information for the frequency vector
                frequency[counter] = count;
               
                //Get the information for the tf-idf vector 
                tf_idf[counter] = tf * this.idfScores[word];

                //Now for the binary vector
                binary[counter] = binary_contains;
                counter++;
           
            }


            //Populate the feature matrices
            this.tf_idf_matrix[overall_count] = tf_idf;
            this.frequency_matrix[overall_count] = frequency;
            this.binary_matrix[overall_count] = binary;
            this.labels[overall_count] = label;
            return overall_count + 1;
        }

        //Getters and setters

        public double[][] getTF_IDFMatrix()
        {
            return this.tf_idf_matrix;
        }

        public double[][] getFrequencyMatrix()
        {
            return this.frequency_matrix;
        }

        public double[][] getBinaryMatrix()
        {
            return this.binary_matrix;
        }
        public double[] getNewTFInstance(BagOfWords bag)
        {
            double[] instance = new double[vocab_size];
            int counter = 0;

            foreach (string word in this.keys)
            {
                bool contains = bag.getFrequencyDict().Keys.Contains(word);
                int count = 0;
                if (contains)
                {
                    count = bag.getFrequencyDict()[word];
                }

                //Get the information for the tf-idf vector 
                instance[counter] = count;

                counter++;
            }

            return instance; 
        }

        public double[] getNewBinaryInstance(BagOfWords bag)
        {
            double[] instance = new double[this.vocab_size];
            int counter = 0;

            foreach (string word in this.keys)
            {
                bool contains = bag.getFrequencyDict().Keys.Contains(word);
                int count = 0;
                if (contains)
                {
                    count = 1;
                }

                //Get the information for the tf-idf vector 
                instance[counter] = count;

                counter++;
            }

            return instance;
        }

        public double[] getNewTF_IDFInstance(BagOfWords bag)
        {
            double[] instance = new double[vocab_size];
            int counter = 0;

            foreach (string word in this.keys)
            {
                bool contains = bag.getFrequencyDict().Keys.Contains(word);
                int count = 0;
                double tf = 0;
                if (contains)
                {
                    count = bag.getFrequencyDict()[word];
                    tf = 1 + Math.Log10(count);
                }

                //Get the information for the tf-idf vector 
                instance[counter] = tf * this.idfScores[word];

                counter++;
            }
            return instance;
        }

        public int[] getLabelVector()
        {
            return this.labels;
        }
    }
}
