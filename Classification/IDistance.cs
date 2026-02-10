using SeedsClassificationApp.Models;

namespace SeedsClassificationApp.Classification
{
    public interface IDistance
    {
        double Calculer(GrainBle a, GrainBle b);
    }
}
