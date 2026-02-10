using SeedsClassificationApp.Models;

namespace SeedsClassificationApp.Classification
{
    public interface IKNNClassifier
    {
        TypeBle Classifier(GrainBle grain);
    }
}
