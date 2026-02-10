using SeedsClassificationApp.Models;

namespace SeedsClassificationApp.Classification
{
    public class DistanceManhattan : IDistance
    {
        public double Calculer(GrainBle a, GrainBle b)
        {
            return
                Math.Abs(a.Area - b.Area) +
                Math.Abs(a.Perimeter - b.Perimeter) +
                Math.Abs(a.Compactness - b.Compactness) +
                Math.Abs(a.Length - b.Length) +
                Math.Abs(a.Width - b.Width) +
                Math.Abs(a.Asymmetry - b.Asymmetry) +
                Math.Abs(a.GrooveLength - b.GrooveLength);
        }
    }
}
