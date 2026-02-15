using SeedsClassificationApp.Models;

namespace SeedsClassificationApp.Classification
{
    public class KNNClassifier : IKNNClassifier
    {
        private readonly KDTree _tree;
        private readonly int _k;
        private readonly IDistance _distance;

        public KNNClassifier(KDTree tree, int k, IDistance distance)
        {
            _tree = tree;
            _k = k;
            _distance = distance;
        }

        public TypeBle Classifier(GrainBle grain)
        {
            var voisins = _tree.RechercherKPlusProches(grain, _k, _distance);

            var compteur = new Dictionary<TypeBle, int>();

            foreach (var voisin in voisins)
            {
                if (!compteur.ContainsKey(voisin.ClasseReelle))
                    compteur[voisin.ClasseReelle] = 0;

                compteur[voisin.ClasseReelle]++;
            }

            TypeBle classePredite = compteur
                .OrderByDescending(x => x.Value)
                .First()
                .Key;

            return classePredite;
        }
    }
}
