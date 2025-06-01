using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TINHTOANVANKHUONDAM.View;

namespace TINHTOANVANKHUONDAM
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.Manual)]
    public class MoForm : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Document doc = uiDoc.Document;

            // Mở form và lấy thông số từ người dùng
            ViewTrangChu wpfForm = new ViewTrangChu(doc,uiDoc);
            // Hiển thị form và lấy kết quả từ người dùng
            wpfForm.ShowDialog();
            bool? dialogResult = wpfForm.dialogResult;

            // Xử lý kết quả từ form
            if (dialogResult == true) // Người dùng nhấn "OK"
            {
                // Bạn có thể xử lý dữ liệu từ wpfForm tại đây
                return Result.Succeeded;
            }
            else // Người dùng nhấn "Cancel" hoặc đóng form
            {
                return Result.Cancelled;
            }

        }
    }
}
