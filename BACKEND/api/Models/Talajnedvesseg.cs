namespace api.Models
{
    public class Talajnedvesseg
    {
        public List<List<string>> MatrixA { get; set; }
        public List<List<double>> MatrixB { get; set; }
        public List<List<double>> MatrixC { get; set; }

        public List<List<double>> MatrixAErtekek => TipusbolErtek(MatrixA);
        public List<List<double>> NormalizaltC => MatrixNormalizalas(MatrixC);

        private static readonly Dictionary<string, double> TalajTipusok = new Dictionary<string, double>
        {
            { "Agyagos", 0.319 },
            { "Tőzeges", 0.380 },
            { "Szerves", 0.391 },
            { "Sós", 0.563 },
            { "Lúgos", 0.669 },
            { "Vályogos", 0.727 },
            { "Homokos", 0.785 }
        };

        public static List<List<double>> TipusbolErtek(List<List<string>> matrix)
        {
            List<List<double>> ertekMatrix = new List<List<double>>();
            for (int i = 0; i < matrix.Count; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    if (TalajTipusok.TryGetValue(matrix[i][j], out double ertek))
                        row.Add(ertek);
                    else
                        row.Add(0);
                }
                ertekMatrix.Add(row);
            }
            return ertekMatrix;
        }

        public static List<List<double>> MatrixNormalizalas(List<List<double>> matrix)
        {
            double min = matrix.Min(row => row.Min());
            double max = matrix.Max(row => row.Max());

            List<List<double>> normalizaltMatrix = new List<List<double>>();
            for (int i = 0; i < matrix.Count; i++)
            {
                List<double> row = new List<double>();
                for (int j = 0; j < matrix[i].Count; j++)
                {
                    double normalizedValue = (matrix[i][j] - min) / (max - min);
                    row.Add(normalizedValue);
                }
                normalizaltMatrix.Add(row);
            }
            return normalizaltMatrix;
        }
    }
}
