using SeedsClassificationApp.Classification;
using SeedsClassificationApp.Models;

namespace SeedsClassificationApp.Evaluation
{
    public class EvaluationResult
    {
        public double Accuracy { get; set; }
        public int[,] ConfusionMatrix { get; set; } = new int[3, 3];

        public void Calculer(List<GrainBle> testData,
                             IKNNClassifier classifier)
        {
            int correct = 0;

            foreach (var grain in testData)
            {
                var prediction = classifier.Classifier(grain);

                int realIndex = (int)grain.ClasseReelle;
                int predIndex = (int)prediction;

                ConfusionMatrix[realIndex, predIndex]++;

                if (prediction == grain.ClasseReelle)
                    correct++;
            }

            Accuracy = (double)correct / testData.Count;
        }
    }
}
