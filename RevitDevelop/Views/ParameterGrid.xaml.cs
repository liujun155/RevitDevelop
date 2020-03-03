using Autodesk.Revit.DB;
using BasicProject;
using RevitDevelop.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RevitDevelop.Views
{
    /// <summary>
    /// ParameterGrid.xaml 的交互逻辑
    /// </summary>
    public partial class ParameterGrid : Window
    {
        public ParameterGrid(ParameterSet parameter)
        {
            InitializeComponent();
            
            List<ParameterData> parameterDatas = new List<ParameterData>();
            foreach (Parameter item in parameter)
            {
                ParameterData param = new ParameterData();
                param.Name = item.Definition.Name;
                //if (item.StorageType == StorageType.String)
                //    param.Value = item.AsValueString();
                //else if (item.StorageType == StorageType.Double)
                //    param.Value = item.AsDouble().ToString();
                //else if (item.StorageType == StorageType.Integer)
                //    param.Value = item.AsInteger().ToString();
                //else if (item.StorageType == StorageType.ElementId)
                //    param.Value = item.AsElementId().IntegerValue.ToString();
                //else if (item.StorageType == StorageType.None)
                //    param.Value = item.AsString();
                param.Value = item.AsValueString();
                parameterDatas.Add(param);
            }
            this.pData.ItemsSource = parameterDatas;
        }

        private class ParameterData
        {
            public string Name { get; set; }

            public string Value { get; set; }
        }
    }
}
