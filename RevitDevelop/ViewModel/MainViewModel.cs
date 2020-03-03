using DotNet.REVIT.External;
using RevitDevelop.Command.Low;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop.ViewModel
{
    public class MainViewModel
    {
        #region 初级
        public RevitCommand LoadFamily { get; set; }
        public RevitCommand CreateInstance { get; set; }
        public RevitCommand GetParameter { get; set; }
        public RevitCommand EditParameter { get; set; }
        public RevitCommand FilterInstance { get; set; }
        public RevitCommand CreateLine { get; set; }
        public RevitCommand MoveElem { get; set; }
        public RevitCommand RotateElem { get; set; }
        #endregion

        public MainViewModel()
        {
            LoadFamily = new CmdLoadFamily();
            CreateInstance = new CmdCreateInstance();
            GetParameter = new CmdGetParameter();
            EditParameter = new CmdEditParameter();
        }
    }
}
