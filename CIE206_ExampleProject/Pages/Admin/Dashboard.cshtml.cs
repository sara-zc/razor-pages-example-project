using ChartExample.Models.Chart;
using CIE206_ExampleProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;  // for converting Chart into ChartJson
using System.Data;

namespace CIE206_ExampleProject.Pages.Admin
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public string username { get; set; }
        public DB db { get; set; }
        public ChartJs PieChart { get; set; }
        public ChartJs BarChart { get; set; }
        public string ChartJsonProjectWorkers { get; set; }
        public string ChartJsonProjectHours { get; set; }
        public IndexModel(ILogger<IndexModel> logger, DB db)
        {
            _logger = logger;
            PieChart = new ChartJs();
            BarChart = new ChartJs();
            this.db = db;
        }

        public IActionResult OnGet()
        {
            username = HttpContext.Session.GetString("username");
            if (username == null)
            {
                return RedirectToPage("/SignIn");
            }

            Dictionary<string, int> whoWorksOnWhat = db.getProjectWithWorkers();
            Dictionary<string, double> projectHours = db.getProjectHours();

            setUpPieChart(whoWorksOnWhat);
            setUpLineChart(projectHours);

            return Page();
        }
        public IActionResult OnPost()
        {
            return RedirectToPage("/Error");
        }
        private void setUpPieChart(Dictionary<string,int> dataToDisplay)
        {
            try
            {
                // 1. set up chart options
                PieChart.type = "pie";
                PieChart.options.responsive = true;

                // 2. separate the received Dictionary data into labels and data arrays
                var labelsArray = new List<string>();
                var dataArray = new List<double>();

                foreach (var data in dataToDisplay)
                {
                    labelsArray.Add(data.Key);
                    dataArray.Add(data.Value);
                }

                PieChart.data.labels = labelsArray;

                // 3. set up a dataset
                var firsDataset = new Dataset();
                firsDataset.label = "Number of employees";
                firsDataset.data = dataArray.ToArray();

                PieChart.data.datasets.Add(firsDataset);

                // 4. finally, convert the object to json to be able to inject in HTML code
                ChartJsonProjectWorkers = JsonConvert.SerializeObject(PieChart, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error initialising the chart inside Index.cshtml.cs");
                throw e;
            }
        }

        private void setUpLineChart(Dictionary<string,double> dataToDisplay)
        {
            try
            {
                // 1. set up chart options
                BarChart.type = "bar";
                BarChart.options.responsive = true;

                // 2. separate the received Dictionary data into labels and data arrays
                var labelsArray = new List<string>();
                var dataArray = new List<double>();

                foreach (var data in dataToDisplay)
                {
                    labelsArray.Add(data.Key);
                    dataArray.Add(data.Value);
                }

                BarChart.data.labels = labelsArray;

                // 3. set up a dataset
                var firsDataset = new Dataset();
                firsDataset.label = "Project Hours";
                firsDataset.data = dataArray.ToArray();

                BarChart.data.datasets.Add(firsDataset);

                // 4. finally, convert the object to json to be able to inject in HTML code
                ChartJsonProjectHours = JsonConvert.SerializeObject(BarChart, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                });
            }
            catch (Exception e)
            {
                Console.WriteLine("Error initialising the chart inside Index.cshtml.cs");
                throw e;
            }

        }


    }
}
