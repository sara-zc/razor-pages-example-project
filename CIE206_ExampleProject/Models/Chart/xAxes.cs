namespace ChartExample.Models.Chart
{
    public class xAxes
    {
        public xAxes() {
            ticks = new Ticks();
        }
        public string id { get; set; }
        public bool display { get; set; }
        public string type { get; set; }
        public Ticks ticks { get; set; }
    }
}