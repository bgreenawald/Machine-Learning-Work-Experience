using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Deedle;
using Xunit;

namespace Membership_Application.Models.Tests
{
    public class Corpus_tests
    {
/*
        static Preprocessor process2 = new Preprocessor("C:\\Users\\bhg\\Downloads\\test_case2.csv");
        static Frame<int, string> data2 = process2.getDataFiltered();
        Corpus test2 = new Corpus(data2);
        */
        //--------------------------------------------------------------------------------------------------------------------------------//

        //First test set
        [Fact]
        public void DocumentCountTest()
        {
            Preprocessor process1 = new Preprocessor("C:\\Users\\bhg\\Downloads\\test_case1.csv");
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.DocumentCount, 4);
        }

        [Theory]
        [InlineData(1, 3)]
        public void DocumentsInLabelTest(int label, int expected)
        {
            Preprocessor process1 = new Preprocessor("C:\\Users\\bhg\\Downloads\\test_case1.csv");
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.DocumentCountInLabel(label), expected);
        }

        [Theory]
        [InlineData(11)]
        public void CountWordTest(int size)
        {
            Preprocessor process1 = new Preprocessor("C:\\Users\\bhg\\Downloads\\test_case1.csv");
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.VocabularySize, size);
        }

        [Theory]
        [InlineData("analysis", 1, 3)]
        public void WordCountIntLabelTest(string word, int label, int expected)
        {
            Preprocessor process1 = new Preprocessor("C:\\Users\\bhg\\Downloads\\test_case1.csv");
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.GetCountForTermInLabel(word, label), expected);
        }

        [Theory]
        [InlineData("analysis", 1, 3)]
        public void DocumentinLabelwithWordTest(string word, int label, int expected)
        {
            Preprocessor process1 = new Preprocessor("C:\\Users\\bhg\\Downloads\\test_case1.csv");
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.GetCountForTermInLabel(word, label), expected);
        }
        [Theory]
        [InlineData("analysis", 3)]
        public void DocumentwithWordTest(string word, int expected)
        {
            Preprocessor process1 = new Preprocessor("C:\\Users\\bhg\\Downloads\\test_case1.csv");
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.numberOfDocumentsInCorpusWithTerm(word), expected);
        }

        [Theory]
        [InlineData("analysis", 3)]
        public void WordCountCorpusTest(string word, int expected)
        {
            Preprocessor process1 = new Preprocessor("C:\\Users\\bhg\\Downloads\\test_case1.csv");
            Frame<int, string> data1 = process1.getDataFiltered();
            Corpus test1 = new Corpus(data1);

            Assert.Equal(test1.TermCountAcrossAllLabels(word), expected);
        }

        //--------------------------------------------------------------------------------------------------------------------------------//
    }
}
