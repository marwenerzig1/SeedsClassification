namespace SeedsClassificationApp.Models
{
    public class GrainBle
    {
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public double Compactness { get; set; }
        public double Length { get; set; }
        public double Width { get; set; }
        public double Asymmetry { get; set; }
        public double GrooveLength { get; set; }

        public TypeBle ClasseReelle { get; set; }

        public GrainBle() { }

        public GrainBle(
            double area,
            double perimeter,
            double compactness,
            double length,
            double width,
            double asymmetry,
            double grooveLength,
            TypeBle classe)
        {
            Area = area;
            Perimeter = perimeter;
            Compactness = compactness;
            Length = length;
            Width = width;
            Asymmetry = asymmetry;
            GrooveLength = grooveLength;
            ClasseReelle = classe;
        }
    }
}
