using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherDataAnalysis.Model.Enums;

namespace WeatherDataAnalysis.ViewModel
{
    public class ComboBoxBindings:IEnumerable<int>
    {
        public List<int> Sizes { get; set; }
        public static int ActiveSelection { get; set; }

        public ComboBoxBindings()
        {
            this.Sizes =  Enum.GetValues(typeof(HistogramBucketSize)).Cast<int>().ToList();
            ActiveSelection = 10;
        }

        public IEnumerator<int> GetEnumerator()
        {
            return ((IEnumerable<int>)Sizes).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<int>)Sizes).GetEnumerator();
        }
    }
}
