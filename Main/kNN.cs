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
    public class kNN : MachineLearner
    {
        //--------------------------------------------------------------------------------------//

        //Fields
        List<int> labels = new List<int>();
        public int k;
        KNearestNeighbors<double[]> kNearest;
        double probability;

        //--------------------------------------------------------------------------------------//

        //Constructor
        public kNN(int k)
        {
            this.k = k;

          
        }

        //--------------------------------------------------------------------------------------//

        //Methods 

        public void Train(double[][] inputs, int[] labels)
        {
            kNearest = new KNearestNeighbors<double[]>(k: k, inputs: inputs, outputs: labels, distance: Distance.SquareEuclidean);
        }


        public void Compute(double[] instance)
        {
            labels.Add(kNearest.Compute(instance));
        }


        public int Predict(double[] instance, int length)
        {
            int pred;
            int[] nearestLabels;
            kNearest.GetNearestNeighbors(instance, out nearestLabels);
            pred = kNearest.Compute(instance);
            int size = nearestLabels.Where(elem => elem == pred).Count();
            probability = (double)(size + 1) / (k + 2);
            
            return pred;
        }

        public List<int> getLabels()
        {
            return labels;
        }

        public double getProbability()
        {
            return this.probability;
        }

        public KNearestNeighbors<double[]> getModel()
        {
            return this.kNearest;
        }

    }
}
