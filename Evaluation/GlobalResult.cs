using SeedsClassificationApp.Models;

namespace SeedsClassificationApp.Evaluation
{
    public class GlobalResult
    {
        public int K { get; set; }
        public string DistanceType { get; set; }
        public DateTime DateExecution { get; set; }

        public int TrainingSize { get; set; }
        public int TestSize { get; set; }

        public double Accuracy { get; set; }
        public int[,] ConfusionMatrix { get; set; }
    }
}
