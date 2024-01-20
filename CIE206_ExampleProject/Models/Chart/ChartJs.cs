namespace ChartExample.Models.Chart
{
    public class ChartJs
    {
        public ChartJs() { 
            options = new Options();
            data = new Data();
            title = new Title();
        }
        public string type { get; set; }
        public int duration { get; set; }
        public string easing { get; set; }
        public Title title { get; set; }
        public bool lazy { get; set; }
        public Data data { get; set; }
        public Options options { get; set; }
    }
}