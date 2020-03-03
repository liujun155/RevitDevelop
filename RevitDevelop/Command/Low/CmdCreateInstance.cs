using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using DotNet.REVIT.External;
using RevitDevelop.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevitDevelop.Command.Low
{
    [Transaction(TransactionMode.Automatic)]
    public class CmdCreateInstance : RevitCommand
    {
        private RevitStatusBar _statusBar = RevitStatusBar.Create();
        public override bool IsCommandAvailable(UIApplication app)
        {
            if (app.ActiveUIDocument == null) return false;
            return true;
        }

        protected override Result ExecuteCommand(ExternalCommandData data, ref string message, ElementSet elements)
        {
            Document doc = data.Application.ActiveUIDocument.Document;
            var fams = new FilteredElementCollector(doc).OfClass(typeof(Family)).ToList();
            Family fam = null;
            if(fams?.Count > 0)
                fam = fams.FindAll(x => x.Name == "简易参变族_new")?.FirstOrDefault() as Family;
            if(fam == null)
            {
                TaskDialog.Show("提示", "请先载入族");
                return Result.Failed;
            }
            FamilySymbol fSymbol = null;
            ISet<ElementId> idSet = fam.GetFamilySymbolIds();
            if (idSet.Count > 0)
            {
                fSymbol = doc.GetElement(idSet.ElementAt<ElementId>(0)) as FamilySymbol;
                if (!fSymbol.IsActive)
                    fSymbol.Activate();
            }
            if(fSymbol != null)
            {
                doc.Create.NewFamilyInstance(new XYZ(0, 0, 0), fSymbol, StructuralType.NonStructural);
                _statusBar.Set("创建成功");
            }
            return Result.Succeeded;
        }
    }
}
