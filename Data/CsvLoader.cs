using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using SeedsClassificationApp.Models;

namespace SeedsClassificationApp.Data
{
    public class CsvLoader
    {
        public List<GrainBle> Charger(string cheminFichier)
        {
            var liste = new List<GrainBle>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";",
                HasHeaderRecord = true
            };

            using (var reader = new StreamReader(cheminFichier))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Read();
                csv.ReadHeader();

                while (csv.Read())
                {
                    string classeStr = csv.GetField<string>(0);

                    TypeBle classe = classeStr switch
                    {
                        "Kama" => TypeBle.Kama,
                        "Rosa" => TypeBle.Rosa,
                        "Canadian" => TypeBle.Canadian,
                        _ => throw new Exception($"Classe inconnue : {classeStr}")
                    };

                    double area = csv.GetField<double>(1);
                    double perimeter = csv.GetField<double>(2);
                    double compactness = csv.GetField<double>(3);
                    double length = csv.GetField<double>(4);
                    double width = csv.GetField<double>(5);
                    double asymmetry = csv.GetField<double>(6);
                    double grooveLength = csv.GetField<double>(7);

                    var grain = new GrainBle(
                        area,
                        perimeter,
                        compactness,
                        length,
                        width,
                        asymmetry,
                        grooveLength,
                        classe
                    );

                    liste.Add(grain);
                }
            }

            return liste;
        }
    }
}
