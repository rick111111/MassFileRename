using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MassFileRename
{
    class Program
    {
        static void Main(string[] args)
        {
            Rename(@"C:\Users\faxue\Desktop\2241_Fangliang_MatchSnappointIconsColorToSyntaxHighlight_ToClient");
        }

        static void Rename(string path)
        {
            foreach (var f in Directory.GetFiles(path))
            {
                string fileName = Path.GetFileName(f);
                if (fileName.Contains("ProductionSnapshotPointAdvanced"))
                    fileName = fileName.Replace("ProductionSnapshotPointAdvanced", "AdvancedProductionBreakpoint");
                else if (fileName.Contains("ProductionSnapshotPoint"))
                    fileName = fileName.Replace("ProductionSnapshotPoint", "ProductionBreakpoint");
                else if (fileName.Contains("ProductionTracePointAdvanced"))
                    fileName = fileName.Replace("ProductionTracePointAdvanced", "AdvancedProductionTracepoint");
                else if (fileName.Contains("ProductionTracePoint"))
                    fileName = fileName.Replace("ProductionTracePoint", "ProductionTracepoint");

                if (fileName.Contains("Hidden"))
                    fileName = fileName.Replace("Hidden", "Dashed");
                if (fileName.Contains("OffWarning"))
                    fileName = fileName.Replace("OffWarning", "Warning");
                if (fileName.Contains("OffError"))
                    fileName = fileName.Replace("OffError", "Error");

                if (fileName.Contains("_16x.png"))
                    fileName = fileName.Replace("_16x.png", ".16.16.png");
                else if (fileName.Contains("_16x.xaml"))
                    fileName = fileName.Replace("_16x.xaml", ".xaml");

                File.Move(f, Path.Combine(path, fileName));

                if (fileName.EndsWith(".svg") || fileName.Contains("Disabled"))
                    File.Delete(f);
            }
        }
    }
}
