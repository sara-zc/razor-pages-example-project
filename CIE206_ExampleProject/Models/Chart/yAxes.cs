namespace ChartExample.Models.Chart
{
    public class yAxes
    {
        public yAxes()
        {
            ticks = new Ticks();    
        }
        public string id { get; set; }
        public bool display { get; set; }
        public string type { get; set; }
        public Ticks ticks { get; set; }
    }
}