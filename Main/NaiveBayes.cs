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
    public class NaiveBayes: MachineLearner 
    {

        //--------------------------------------------------------------------------------------//

        //Fields
        List<int> labels = new List<int>();
        NaiveBayes<NormalDistribution> NB;
        
        //--------------------------------------------------------------------------------------//

        //Constructor
        public NaiveBayes(int classes, int size)
        {
            NB = new NaiveBayes<NormalDistribution>(classes: classes, inputs: size, initial: NormalDistribution.Standard);
        }

        //--------------------------------------------------------------------------------------//

        //Methods 

        public void Train(double[][] inputs, int[] labels)
        {
            var error = this.NB.Estimate(inputs: inputs, outputs: labels, options: new NormalOptions()
            {
                Regularization = 1e-5 // avoid zero variance issues
            });
        }


        public void Compute(double[] instance)
        {
            labels.Add(this.NB.Compute(instance));
        }


        public int Predict(double[] instance)
        {
            return NB.Compute(instance);
        }

        public List<int> getLabels()
        {
            return labels;
        }
    }
}
