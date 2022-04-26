using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_Forecast.DataAccess
{
    public static class DataBaseContextSedder
    {
        public static void Seed(DataBaseContext context)
        {
            context.Weathers.AddRange(SampleData.GetDefaultForecasts());
            context.SaveChanges();
        }
    }
}
