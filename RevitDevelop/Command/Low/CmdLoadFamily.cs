using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DotNet.REVIT.External;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop.Command.Low
{
    [Transaction(TransactionMode.Automatic)]
    public class CmdLoadFamily : RevitCommand
    {
        public Document _doc;
        public override bool IsCommandAvailable(UIApplication app)
        {
            if (app.ActiveUIDocument == null) return false;
            return true;
        }

        protected override Result ExecuteCommand(ExternalCommandData data, ref string message, ElementSet elements)
        {
            _doc = data.Application.ActiveUIDocument.Document;
            try
            {
                string path = @"E:\Revit二次开发\简易参变族_new.rfa";
                if (!File.Exists(path))
                {
                    TaskDialog.Show("提示", "未找到族文件");
                    return Result.Failed;
                }
                //删除已有
                var fams = new FilteredElementCollector(_doc).OfClass(typeof(Family)).ToList();
                if (fams?.Count > 0)
                {
                    var repeatFam = fams.Find(x => x.Name == "简易参变族_new");
                    if (repeatFam != null)
                        _doc.Delete(repeatFam.Id);
                }
                //载入族
                Family fam = null;
                _doc.LoadFamily(path, out fam);
                TaskDialog.Show("提示", "载入成功");
            }
            catch (Exception ex)
            {
                TaskDialog.Show("警告", "载入失败");
            }
            return Result.Succeeded;
        }
    }
}
