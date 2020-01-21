using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using DotNet.REVIT.External;
using DotNet.REVIT.Helper;
using RevitDevelop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop
{
    [Transaction(TransactionMode.Manual)]
    public class MainRun : RevitApp
    {
        public static MainRun ThisApp;
        public override Result OnRevitClose(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public override Result OnRevitStart(UIControlledApplication application)
        {
            ThisApp = this;
            RibbonRegisterHelper.Register(new MainView(), 0);
            return Result.Succeeded;
        }
    }
}
