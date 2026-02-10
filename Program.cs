using SeedsClassificationApp.Data;
using SeedsClassificationApp.Classification;
using SeedsClassificationApp.Evaluation;
using SeedsClassificationApp.Models;

namespace SeedsClassificationApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Seeds Classification - KNN ===");
            Console.WriteLine();

            // Charger les données
            CsvLoader loader = new CsvLoader();
            var trainingData = loader.Charger("seeds_dataset_training.csv");
            var testData = loader.Charger("seeds_dataset_test.csv");

            Console.WriteLine($"Training size : {trainingData.Count}");
            Console.WriteLine($"Test size     : {testData.Count}");
            Console.WriteLine();

            // Choix de k
            Console.Write("Entrez la valeur de k : ");
            int k = int.Parse(Console.ReadLine());

            // Choix distance
            Console.WriteLine();
            Console.WriteLine("Choisissez la distance :");
            Console.WriteLine("1 - Euclidienne");
            Console.WriteLine("2 - Manhattan");
            Console.Write("Votre choix : ");
            int choixDistance = int.Parse(Console.ReadLine());

            IDistance distance = choixDistance switch
            {
                1 => new DistanceEuclidienne(),
                2 => new DistanceManhattan(),
                _ => throw new Exception("Choix invalide")
            };

            Console.WriteLine();

            // Construction KDTree
            KDTree tree = new KDTree();
            tree.Construire(trainingData);

            IKNNClassifier classifier = new KNNClassifier(tree, k, distance);

            // Évaluation
            EvaluationResult evaluation = new EvaluationResult();
            evaluation.Calculer(testData, classifier);

            Console.WriteLine("=== Résultats ===");
            Console.WriteLine($"Accuracy : {evaluation.Accuracy:P2}");
            Console.WriteLine();

            Console.WriteLine("Matrice de confusion :");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(evaluation.ConfusionMatrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            // Sauvegarde JSON
            JsonSaver saver = new JsonSaver();

            GlobalResult global = new GlobalResult
            {
                K = k,
                DistanceType = distance.GetType().Name,
                DateExecution = DateTime.Now,
                TrainingSize = trainingData.Count,
                TestSize = testData.Count,
                Accuracy = evaluation.Accuracy,
                ConfusionMatrix = evaluation.ConfusionMatrix
            };

            saver.Sauvegarder(global, "resultats.json");

            Console.WriteLine();
            Console.WriteLine("Résultats sauvegardés dans resultats.json");
        }
    }
}
