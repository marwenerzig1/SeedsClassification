using SeedsClassificationApp.Models;

namespace SeedsClassificationApp.Classification
{
    public class KDTree
    {
        public KDNode Root { get; private set; }

        public void Construire(List<GrainBle> data)
        {
            Root = ConstruireRecursif(data, 0);
        }

        private KDNode ConstruireRecursif(List<GrainBle> points, int profondeur)
        {
            if (points == null || points.Count == 0)
                return null;

            int axe = profondeur % 7;

            // Trier selon l'axe choisi
            points = TrierSelonAxe(points, axe);

            int medianIndex = points.Count / 2;

            KDNode node = new KDNode(points[medianIndex]);

            node.Left = ConstruireRecursif(points.Take(medianIndex).ToList(), profondeur + 1);
            node.Right = ConstruireRecursif(points.Skip(medianIndex + 1).ToList(), profondeur + 1);

            return node;
        }

        private List<GrainBle> TrierSelonAxe(List<GrainBle> liste, int axe)
        {
            for (int i = 1; i < liste.Count; i++)
            {
                GrainBle cle = liste[i];
                double valeurCle = GetValeurSelonAxe(cle, axe);

                int j = i - 1;

                while (j >= 0 && GetValeurSelonAxe(liste[j], axe) > valeurCle)
                {
                    liste[j + 1] = liste[j];
                    j--;
                }

                liste[j + 1] = cle;
            }

            return liste;
        }

        private double GetValeurSelonAxe(GrainBle g, int axe)
        {
            return axe switch
            {
                0 => g.Area,
                1 => g.Perimeter,
                2 => g.Compactness,
                3 => g.Length,
                4 => g.Width,
                5 => g.Asymmetry,
                6 => g.GrooveLength,
                _ => throw new ArgumentException("Axe invalide")
            };
        }

        private void ParcoursArbre(KDNode node, GrainBle cible, IDistance distance,
                           List<(GrainBle grain, double dist)> liste)
        {
            if (node == null)
                return;

            double d = distance.Calculer(cible, node.Data);
            liste.Add((node.Data, d));

            ParcoursArbre(node.Left, cible, distance, liste);
            ParcoursArbre(node.Right, cible, distance, liste);
        }


        public List<GrainBle> RechercherKPlusProches(GrainBle cible, int k, IDistance distance)
        {
            var liste = new List<(GrainBle grain, double dist)>();

            ParcoursArbre(Root, cible, distance, liste);

            // Trier par distance (tri insertion maison)
            for (int i = 1; i < liste.Count; i++)
            {
                var cle = liste[i];
                int j = i - 1;

                while (j >= 0 && liste[j].dist > cle.dist)
                {
                    liste[j + 1] = liste[j];
                    j--;
                }

                liste[j + 1] = cle;
            }

            return liste.Take(k).Select(x => x.grain).ToList();
        }

    }
}

