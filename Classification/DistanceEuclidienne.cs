using SeedsClassificationApp.Models;

namespace SeedsClassificationApp.Classification
{
    public class DistanceEuclidienne : IDistance
    {
        public double Calculer(GrainBle a, GrainBle b)
        {
            double somme =
                Math.Pow(a.Area - b.Area, 2) +
                Math.Pow(a.Perimeter - b.Perimeter, 2) +
                Math.Pow(a.Compactness - b.Compactness, 2) +
                Math.Pow(a.Length - b.Length, 2) +
                Math.Pow(a.Width - b.Width, 2) +
                Math.Pow(a.Asymmetry - b.Asymmetry, 2) +
                Math.Pow(a.GrooveLength - b.GrooveLength, 2);

            return Math.Sqrt(somme);
        }
    }
}
