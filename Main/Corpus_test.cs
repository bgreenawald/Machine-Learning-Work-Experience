using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deedle;
using Xunit;

namespace Membership_Application
{
    public class Corpus_tests
    {
       
        //--------------------------------------------------------------------------------------------------------------------------------//

        string filename = "C:\\Users\\bhg\\Downloads\\test_case5.csv"; 
        //First test set
        [Fact]
        public void DocumentCountTest()
        {
            Preprocessor process1 = new Preprocessor(filename);
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.DocumentCount, 8);
        }

        [Theory]
        [InlineData(-1, 4)]
        public void DocumentsInLabelTest(int label, int expected)
        {
            Preprocessor process1 = new Preprocessor(filename);
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.DocumentCountInLabel(label), expected);
        }

        [Theory]
        [InlineData(19)]
        public void CountUniqueTest(int size)
        {
            Preprocessor process1 = new Preprocessor(filename);
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.VocabularySize, size);
        }

        [Theory]
        [InlineData(19)]
        public void CountTotalTest(int size)
        {
            Preprocessor process1 = new Preprocessor(filename);
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.totalWordCount(), size);
        }


        [Theory]
        [InlineData("teaching", -1, 1)]
        public void WordCountIntLabelTest(string word, int label, int expected)
        {
            Preprocessor process1 = new Preprocessor(filename);
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.GetCountForTermInLabel(word, label), expected);
        }

        [Theory]
        [InlineData("teaching", -1, 1)]
        public void DocumentinLabelwithWordTest(string word, int label, int expected)
        {
            Preprocessor process1 = new Preprocessor(filename);
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.NumberOfDocumentsInLabelWithTerm(word, label), expected);
        }
        [Theory]
        [InlineData("teaching", 1)]
        public void DocumentwithWordTest(string word, int expected)
        {
            Preprocessor process1 = new Preprocessor(filename);
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.numberOfDocumentsInCorpusWithTerm(word), expected);
        }

        [Theory]
        [InlineData("teaching", 1)]
        public void WordCountCorpusTest(string word, int expected)
        {
            Preprocessor process1 = new Preprocessor(filename);
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.TermCountAcrossAllLabels(word), expected);
        }

        //--------------------------------------------------------------------------------------------------------------------------------//


    }
}
