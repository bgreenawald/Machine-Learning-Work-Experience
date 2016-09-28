using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.MachineLearning;
using Accord.MachineLearning.Bayes;
using Accord.Statistics.Distributions.Univariate;
using Accord.Statistics.Distributions.Fitting;
using System.Diagnostics;
using Accord.Math;
using Accord.MachineLearning.VectorMachines;
using Accord.MachineLearning.VectorMachines.Learning;
using Accord.Statistics.Models.Regression;
using Accord.Statistics.Models.Regression.Fitting;

namespace Membership_Application
{
    public class SVM : MachineLearner
    {
        //--------------------------------------------------------------------------------------//

        //Fields
        List<int> labels = new List<int>();
        public double complexity;
        public double positiveComplexity;
        public SupportVectorMachine svm;
        double probability;


        //--------------------------------------------------------------------------------------//

        //Constructor
        public SVM(int size, double complexity, double positiveComplexity)
        {
            this.complexity = complexity;
            this.positiveComplexity = positiveComplexity;
            svm = new SupportVectorMachine(inputs: size);
        }

        //--------------------------------------------------------------------------------------//

        //Methods 

        public void Train(double[][] inputs, int[] labels)
        {
            var minimizer = new SequentialMinimalOptimization(svm, inputs: inputs, outputs: labels);
            minimizer.Complexity = complexity;
            minimizer.PositiveWeight = positiveComplexity;
            minimizer.Run();

            
        }


        public void Compute(double[] instance)
        {
            labels.Add(Math.Sign(svm.Compute(instance)));
        }

        public void calibrate(double[][] inputs, int[] labels)
        {
            // Instantiate the probabilistic learning calibration
            var calibration = new ProbabilisticOutputCalibration(this.svm, inputs, labels);
            //Console.WriteLine();
            // Run the calibration algorithm
            double loglikelihood;
            loglikelihood = calibration.Run();
        }
        public int Predict(double[] instance, int length)
        {          
            return Math.Sign(svm.Compute(instance, out this.probability));
        }

        public double getProbability()
        {
            return this.probability;
        }
        public List<int> getLabels()
        {
            return labels;
        }

        public SupportVectorMachine getModel()
        {
            return svm;
        }
    }
}
