using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPFStackingBarChart
{
    public class ViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Model> collection;
        public ObservableCollection<Model> Collection
        {
            get { return collection; }
            set
            {
                collection = value;
                NotifyPropertyChanged();
            }
        }

        public ViewModel()
        {
            Collection = new ObservableCollection<Model>(ReadCSV("WPFStackingBarChart.teenwithsocialmedia.csv"));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public IEnumerable<Model> ReadCSV(string fileName)
        {
            Assembly executingAssembly = typeof(App).GetTypeInfo().Assembly;
            Stream inputStream = executingAssembly.GetManifestResourceStream(fileName);
            List<string> lines = new List<string>();
            List<Model> collection = new List<Model>();
            if (inputStream != null)
            {
                string line;
                StreamReader reader = new StreamReader(inputStream);
                while ((line = reader.ReadLine()) != null)
                {
                    lines.Add(line);
                }
                lines.RemoveAt(0);

                foreach (var dataPoint in lines)
                {
                    string[] data = dataPoint.Split(',');
                  
                    collection.Add(new Model(data[0], Convert.ToDouble(data[1])*100, Convert.ToDouble(data[2])*100,Convert.ToDouble(data[3]) * 100, 
                        Convert.ToDouble(data[4]) * 100, Convert.ToDouble(data[5]) * 100, Convert.ToDouble(data[6]) * 100));
                }

            }
            
            return collection;
        }
    }
}
