using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deedle;

namespace Membership_Application
{
    [Serializable]
    public class Corpus
    {

//------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //Fields

        // For each term, the number of times the term has been seen across all documents.
        public IDictionary<string, int> vocabulary { get; set; } = new Dictionary<string, int>();

        // Documents within the corpus grouped by their associated label.
        public IDictionary<int, List<BagOfWords>> labeledDocuments = new Dictionary<int, List<BagOfWords>>();

        // The alpha for applying Lidstone or Laplace smoothing (Laplace == 1).  
        private double smoothingAlpha = 1.0;
        public int base_progress = 1;
        public int max_progress;
        //------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //Constructors

        public Corpus() { }
        //Constructor using deedle series
        public Corpus(Frame<int, string> data)
        {
            max_progress = data.Rows.Keys.Count();
            //Add each document to the list of labeledDocs
            foreach (int key in data.Rows.Keys)
            {
                string job_description = data.Rows[key].GetAs<string>("JOB_DESCRIPTION");
                Random rand = new Random();
                
                string status = data.Rows[key].GetAs<string>("APPROVAL_STATUS").Trim();
                int label = getLabel(status);

                if(status == "Rejected") {
                    for (int i = 0; i < 2; i++)
                    {
                        BagOfWords bag = new BagOfWords(job_description);
                        Dictionary<string, int> dict = bag.getFrequencyDict();

                        if (!this.labeledDocuments.ContainsKey(label))
                        {
                            this.labeledDocuments.Add(label, new List<BagOfWords>());
                        }

                        this.labeledDocuments[label].Add(bag);

                        addToVocabulary(bag.getFrequencyDict());
                    }
                }else
                {
                    if (rand.Next(0, 100) < 101)
                    {
                        BagOfWords bag = new BagOfWords(job_description);
                        Dictionary<string, int> dict = bag.getFrequencyDict();

                        if (!this.labeledDocuments.ContainsKey(label))
                        {
                            this.labeledDocuments.Add(label, new List<BagOfWords>());
                        }

                        this.labeledDocuments[label].Add(bag);

                        addToVocabulary(bag.getFrequencyDict());
                    }
                }

                
            }
        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //Methods

        //Given a frequency dictionary, add the corresponding counts to the overall corpus
        public void addToVocabulary(IDictionary<string, int> dict)
        {
            foreach(string s in dict.Keys)
            {
                if (!vocabulary.Keys.Contains(s))
                {
                    vocabulary.Add(s, dict[s]);
                }else
                {
                    vocabulary[s] += dict[s];
                }
            }
        }

        // Returns the number of documents that comprise the Corpus across all labels.
        public int DocumentCount
        {
            get
            {
                return this.labeledDocuments.Select(a => a.Value.Count).Sum();
            }
        }

        //Returns the number of labels in the document corpus (should be 2 in this instance)
        public int labelCount(int label)
        {
            return this.labeledDocuments.Keys.Count;
        }

        // Returns the number of documents with the provided label.  Returns 0 if there are no documents
        // with that label. 
        public int DocumentCountInLabel(int label)
        {
            if (!this.labeledDocuments.ContainsKey(label))
            {
                return 0;
            }

            return this.labeledDocuments[label].Count;
        }



        // Returns the number of words that appear in all documents within the provided label.  This is all words, not 
        // distinct words, so it's the sum of term counts of all documents in label.  
        public int WordCountInLabel(int label)
        {
            var documents = this.labeledDocuments[label];

            return documents.Select(a => a.Size()).Sum();
        }

        //Returns the average word count in label
        public int AverageWordCountInLabel(int label)
        {
            var documents = this.labeledDocuments[label];
            
            return (int)documents.Select(a => a.Size()).Average();
        }
        
        public int DeviationOfWordCountInLabel(int label)
        {
            var documents = this.labeledDocuments[label];

            return (int) CalculateStdDev(documents.Select(a => a.Size()));
        }

        public int AverageUniqueWordCountInLabel(int label)
        {
            var documents = this.labeledDocuments[label];

            return (int)documents.Select(a => a.UniqueWordCount()).Average();
        }

        public int DeviationOfUniqueWordCountInLabel(int label)
        {
            var documents = this.labeledDocuments[label];

            return (int)CalculateStdDev(documents.Select(a => a.UniqueWordCount()));
        }

        // Finds the number of times term is used in all documents with provided label.  
        public int GetCountForTermInLabel(string term, int label)
        {
            int total = 0;
            foreach(BagOfWords bag in this.labeledDocuments[label])
            {
                if (bag.getFrequencyDict().Keys.Contains(term))
                {
                    total += bag.getFrequencyDict()[term];
                }
            }

            return total;

            //return this.labeledDocuments[label].Sum(a => a.getFrequencyDict()[term] if() ;
        }

        public int totalWordCount()
        {
            int total = 0;
            foreach(int key in this.labeledDocuments.Keys)
            {
                foreach(BagOfWords bag in this.labeledDocuments[key])
                {
                    total += bag.Size();
                }
            }

            return total;
        }
        // Returns the number of unique words within the Vocabulary.  
        public int VocabularySize
        {
            get
            {
                return this.vocabulary.Count;
            }
        }

        //Gets the number of documents in a given label that contain the given term
        public int NumberOfDocumentsInLabelWithTerm(string term, int label)
        {
            int count = 0;
            foreach (BagOfWords b in this.labeledDocuments[label])
            {
                if (b.Words.Contains(term))
                {
                    count++;
                }
            }

            return count;
        }

        //Gets the number of documents in a corpus with a given term
        public int numberOfDocumentsInCorpusWithTerm(string term)
        {
            int count = 0;
            //Iterate over all labels
            foreach (int i in this.labeledDocuments.Keys)
            {
                //Iterate over all documents within the label
                foreach (BagOfWords bag in labeledDocuments[i])
                {
                    if (bag.Words.Contains(term))
                    {
                        count++;
                    }
                }
            }

            return count;

        }

        // Returns the number of times term appears in the Vocabulary in all documents across all labels.
        public int TermCountAcrossAllLabels(string term)
        {
            int count = this.vocabulary.ContainsKey(term) ? this.vocabulary[term] : 0;

            return count;
        }

        public int getLabel(string status)
        {
            int label;

            if (status == "Approved")
            {
                label = 1;
            }
            else if (status == "Rejected")
            {
                label = 0;
            }
            else
            {
                label = 0;
            }

            return label;
        }

        
        public Dictionary<string, int> getCorpusMetrics()
        {
            var return_Dict = new Dictionary<string, int>();
            return_Dict["Average Word Count"] = AverageWordCountInLabel(1);
            return_Dict["SD Word Count"] = DeviationOfWordCountInLabel(1);
            return_Dict["Average Unique Word Count"] = AverageUniqueWordCountInLabel(1);
            return_Dict["SD Unique Word Count"] = DeviationOfUniqueWordCountInLabel(1);
            return return_Dict;
        }
        //Getters and setters
        public IDictionary<int, List<BagOfWords>> getVectors()
        {
            return this.labeledDocuments;
        }

        //Taken from http://stackoverflow.com/questions/3141692/standard-deviation-of-generic-list
        private double CalculateStdDev(IEnumerable<int> values)
        {
            double ret = 0;
            if (values.Count() > 0)
            {
                //Compute the Average      
                double avg = values.Average();
                //Perform the Sum of (value-avg)_2_2      
                double sum = values.Sum(d => Math.Pow(d - avg, 2));
                //Put it all together      
                ret = Math.Sqrt((sum) / (values.Count() - 1));
            }
            return ret;
        }
    }
}
