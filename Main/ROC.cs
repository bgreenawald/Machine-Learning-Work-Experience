using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accord.Statistics.Analysis;
using Accord.Controls;

namespace Membership_Application
{
    class ROC
    {

        public void displayROCCurve(Int32[] outputs, int[] predicted)
        {

            var pred = predicted.Select(x => (double)x).ToArray();
            // Create a new ROC curve to assess the performance of the model
            var roc = new ReceiverOperatingCharacteristic(outputs, pred);
            roc.Compute(100); // Compute a ROC curve with 100 cut-off points

            // Generate a connected scatter plot for the ROC curve and show it on-screen
            ScatterplotBox.Show(roc.GetScatterplot(includeRandom: true))
                .SetSymbolSize(0) // do not display data points
                .SetLinesVisible(true) // show lines connecting points
                .SetScaleTight(true)   // tighten the scale to points
                .WaitForClose();

            
        }
    }
}
