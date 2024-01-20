namespace ChartExample.Models.Chart
{
    public class Data
    {
        public Data()
        {
            datasets = new List<Dataset>();
        }
        public List<string> labels { get; set; }
        public List<Dataset> datasets { get; set; }
    }
}