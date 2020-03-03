using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using DotNet.REVIT.External;
using RevitDevelop.ViewModel;
using RevitDevelop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop.Command.Low
{
    /// <summary>
    /// 编辑参数
    /// </summary>
    [Transaction(TransactionMode.Automatic)]
    public class CmdEditParameter : RevitCommand
    {
        Document _doc;
        public override bool IsCommandAvailable(UIApplication app)
        {
            if (app.ActiveUIDocument == null) return false;
            return true;
        }

        protected override Result ExecuteCommand(ExternalCommandData data, ref string message, ElementSet elements)
        {
            _doc = data.Application.ActiveUIDocument.Document;
            Selection selection = data.Application.ActiveUIDocument.Selection;
            Reference refe = selection.PickObject(ObjectType.Element, "请选择一个实例");
            FamilyInstance fi = _doc.GetElement(refe) as FamilyInstance;
            if(fi != null)
            {
                EditParamViewModel vm = new EditParamViewModel();
                EditParamView frm = new EditParamView(vm);
                frm.ShowDialog();
            }
            return Result.Succeeded;
        }
    }
}
