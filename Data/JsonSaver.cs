using Newtonsoft.Json;
using SeedsClassificationApp.Evaluation;

namespace SeedsClassificationApp.Data
{
    public class JsonSaver
    {
        public void Sauvegarder(GlobalResult result, string cheminFichier)
        {
            var json = JsonConvert.SerializeObject(result, Formatting.Indented);

            File.WriteAllText(cheminFichier, json);
        }
    }
}
