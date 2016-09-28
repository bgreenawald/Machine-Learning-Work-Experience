using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Membership_Application
{
    interface MachineLearner
    {

        //Method to train the algorithm
        void Train(double[][] input, int[] labels);

        //Gets a new instance of the model
        void Compute(double[] instance);
    }
}
