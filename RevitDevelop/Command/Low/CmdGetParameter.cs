using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using DotNet.REVIT.External;
using RevitDevelop.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop.Command.Low
{
    [Transaction(TransactionMode.Automatic)]
    public class CmdGetParameter : RevitCommand
    {
        private Document _doc;
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
            if (fi == null)
            {
                TaskDialog.Show("提示", "您未选择任何实例");
                return Result.Failed;
            }
            //参数获取
            // 方法一：利用LookupParameter,参数为参数名称，如果选择元素找不到参数就会报错; 
            //Parameter p = fi.LookupParameter("面积");
            //string ps = p.AsValueString(); //此方法会输出公制单位
            //string ps = p.AsDouble().ToString(); 此方法会输出英制单位。

            // 方法二：利用get_Parameter,参数为定义参数，如果选择元素找不到参数就会报错; 
            //Parameter p1 = fi.get_Parameter(BuiltInParameter.HOST_AREA_COMPUTED);
            //string p1s = p1.AsValueString();

            //方法三：获取所有参数
            ParameterSet parameter = fi.Parameters;
            if (parameter != null)
            {
                ParameterGrid frm = new ParameterGrid(parameter);
                frm.ShowDialog();
            }
            return Result.Succeeded;
        }
    }
}
