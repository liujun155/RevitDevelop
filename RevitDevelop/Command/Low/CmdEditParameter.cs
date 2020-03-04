using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using DotNet.REVIT.External;
using RevitDevelop.Common;
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
        FamilyInstance _ins;
        private RevitStatusBar _statusBar = RevitStatusBar.Create();
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
            _ins = _doc.GetElement(refe) as FamilyInstance;
            if(_ins != null)
            {
                string len = _ins.LookupParameter("长度").AsValueString();
                string wid = _ins.LookupParameter("宽度").AsValueString();
                string hei = _ins.LookupParameter("高度").AsValueString();
                EditParamViewModel vm = new EditParamViewModel(len, wid, hei);
                vm.EditParam = SaveParam;
                EditParamView frm = new EditParamView(vm);
                frm.ShowDialog();
            }
            return Result.Succeeded;
        }

        private void SaveParam(string len,string wid,string hei)
        {
            if (_ins == null) return;
            _ins.LookupParameter("长度").SetValueString(len);
            _ins.LookupParameter("宽度").SetValueString(wid);
            _ins.LookupParameter("高度").SetValueString(hei);
            _statusBar.Set("修改成功");
        }
    }
}
