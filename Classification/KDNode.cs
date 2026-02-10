using SeedsClassificationApp.Models;

namespace SeedsClassificationApp.Classification
{
    public class KDNode
    {
        public GrainBle Data { get; set; }
        public KDNode Left { get; set; }
        public KDNode Right { get; set; }

        public KDNode(GrainBle data)
        {
            Data = data;
        }
    }
}
