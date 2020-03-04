using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using DotNet.REVIT.External;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop.Command.Low
{
    /// <summary>
    /// 过滤族实例
    /// </summary>
    [Transaction(TransactionMode.Automatic)]
    public class CmdFilterInstance : RevitCommand
    {
        Document m_doc;
        public override bool IsCommandAvailable(UIApplication app)
        {
            if (app.ActiveUIDocument == null) return false;
            return true;
        }

        protected override Result ExecuteCommand(ExternalCommandData data, ref string message, ElementSet elements)
        {
            m_doc = data.Application.ActiveUIDocument.Document;
            var elems = new FilteredElementCollector(m_doc).OfClass(typeof(FamilyInstance)).ToList();
            var categorys = elems.Select(x => x.Category).ToList();
            categorys = categorys.Where((x, i) => categorys.FindIndex(z => z.Id == x.Id) == i).ToList();
            string msg = "";
            if(categorys?.Count > 0)
            {
                foreach (var cate in categorys)
                {
                    msg += cate.Name + ":";
                    BuiltInCategory enumCategory = (BuiltInCategory)cate.Id.IntegerValue;
                    //获取族
                    var familyList = new FilteredElementCollector(m_doc).OfCategory(enumCategory).OfClass(typeof(Family)).ToList();
                    if(familyList?.Count > 0)
                    {
                        //获取类型
                        var symbolList = new FilteredElementCollector(m_doc).OfCategory(enumCategory).OfClass(typeof(FamilySymbol)).ToList();
                        foreach (var family in familyList)
                        {
                            msg += family.Name + "-->";
                            var subSymbol = symbolList.FindAll(x => (x as FamilySymbol).Family.Id == family.Id);
                            if(subSymbol?.Count > 0)
                            {
                                foreach (var symbol in subSymbol)
                                {
                                    msg += symbol.Name + "-->";
                                    var subIns = elems.FindAll(x => (x as FamilyInstance).Symbol.Id == symbol.Id);
                                    subIns.ForEach(x => msg += x.Name + ",");
                                }
                            }
                        }
                    }
                }
                TaskDialog.Show("结果", msg);
            }
            return Result.Succeeded;
        }
    }
}
