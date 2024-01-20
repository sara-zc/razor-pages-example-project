namespace ChartExample.Models.Chart
{
    public class Options
    {
        public Options() {
            scales = new Scales();
        }
        public Scales scales { get; set; }
        public bool responsive { get; set; }
    }
}