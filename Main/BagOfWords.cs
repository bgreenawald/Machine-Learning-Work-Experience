using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using java.io;
using java.util;
using edu.stanford.nlp.pipeline;
using System.IO;
using Console = System.Console;
using edu.stanford.nlp.process;
using StringReader = java.io.StringReader;
using edu.stanford.nlp.parser.lexparser;
using edu.stanford.nlp.trees;
using System.Collections;

namespace Membership_Application
{
    [Serializable]
    public class BagOfWords
    {

//------------------------------------------------------------------------------------------------------------------------------------------------------------------//
        
        //Methods

        //Keeps track of words and their frequencies
        Dictionary<string, int> frequency_dict;
        IEnumerable<string> raw_words;


//------------------------------------------------------------------------------------------------------------------------------------------------------------------//

        //Constructors

        public BagOfWords() { }

        public BagOfWords(string data_raw)
        {
            this.raw_words = tokenize(data_raw);

            //Set up the frequency dictionary
            var distinctWords = this.raw_words.Distinct();

            this.frequency_dict = distinctWords.Select(a => new
            {
                Word = a,
                Count = this.raw_words.Count(b => b.Equals(a, StringComparison.OrdinalIgnoreCase))
            }).ToDictionary(a => a.Word, a => a.Count);

        }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------//


        //Methods

        //Returns a tokenized version of a string, all lowercase, without numbers or stop words.
        public IEnumerable<string> tokenize(string raw_input)
        {
            List<string> tokens = new List<string>();

            //First, use the Stanford NLTK to tokenize the strings
            var tokenizerFactory = PTBTokenizer.factory(new CoreLabelTokenFactory(), "untokenizable=noneDelete");
            var sent2Reader = new StringReader(raw_input);
            var stanford_token = tokenizerFactory.getTokenizer(sent2Reader).tokenize().AsEnumerable();
            sent2Reader.close();

            //Now make all elements lower case
            var lower_token = toLower(stanford_token);

            //Now split on the slash
            var without_Slash = splitOnSlash(lower_token);

            //Finally, filter out the stop words (also filters out numbers)
            StopWords stop_words = new StopWords();
            var finalized_tokens = stop_words.Filter(without_Slash);

            return finalized_tokens;

        }

        //Make all elements in a collection of strings lower case
        public IEnumerable<string> toLower(IEnumerable<string> upper)
        {
            List<string> lowers = new List<string>();
            foreach(string word in upper)
            {
                lowers.Add(word.ToLower());
            }
            return (IEnumerable<string>) lowers;
        }

        public Dictionary<string, int> getFrequencyDict()
        {
            return frequency_dict;
        }

        //Tokenizer has problems with words deliminated by a '/', perform this manually
        public IEnumerable<string> splitOnSlash(IEnumerable<string> withSlash)
        {
            IEnumerable<string> withoutSlash = new List<string>();

            foreach(string s in withSlash)
            {
                if (s.Contains("/"))
                {
                    withoutSlash = withoutSlash.Concat(s.Split('/'));
                }else
                {
                    withoutSlash = withoutSlash.Concat(s.Split(' '));
                }
            }

            return withoutSlash;

        }

        //Returns the number of words in the bag of words as a whole
        public int Size()
        {
            int sum = 0;
            foreach(string s in frequency_dict.Keys)
            {
                sum += frequency_dict[s];
            }

            return sum;
        }

        //Return the numbers of UNIQUE words
        public int UniqueWordCount()
        {
            return frequency_dict.Keys.Count;
        }

        public IEnumerable<string> Words
        {
            get
            {
                return this.frequency_dict.Select(a => a.Key);
            }
        }

        public static void deleteFile(string filepath)
        {
            // Delete a file by using File class static method...
            if (System.IO.File.Exists(filepath))
            {
                // Use a try block to catch IOExceptions, to
                // handle the case of the file already being
                // opened by another process.
                try
                {
                    System.IO.File.Delete(filepath);
                }
                catch (System.IO.IOException e)
                {
                    Console.WriteLine(e.Message);
                    return;
                }
            }
        }
    }

//------------------------------------------------------------------------------------------------------------------------------------------------------------------//

    //Extensions
    [Serializable]
    internal static class JavaExtensions
    {
        public static IEnumerable<string> AsEnumerable(this List javaList)
        {
            var items = new List<string>();
            var it = javaList.iterator();

            while (it.hasNext())
            {
                items.Add(it.next().ToString());
            }

            return items;
        }
    }
}
