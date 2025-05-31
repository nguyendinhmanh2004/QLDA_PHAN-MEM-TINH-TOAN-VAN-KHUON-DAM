using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TINHTOANVANKHUONDAM.ViewModels;
using TINHTOANVANKHUONDAM.Class;
using System.Windows.Input;
using TINHTOANVANKHUONDAM.View;
using Autodesk.Revit.DB;
using System.Windows.Controls;
using Autodesk.Revit.UI;
using System.Linq.Expressions;
using TinhToanCotThep.Class;
using System.Windows;
using System.Windows.Media;

namespace TINHTOANVANKHUONDAM.ViewModels
{
    public class BeamVM : BaseViewModel
    {
        public ICommand NhapTuRevit { get; set; }
        public ICommand cmTinhToan { get; set; }
        public ICommand cmLuu { get; set; }
        


        Document Doc;
        UIDocument UIDoc;
        public BeamVM(Document doc, UIDocument uiDoc)
        {
            Doc = doc;
            UIDoc = uiDoc;
            NhapTuRevit = new RelayCommand<ViewTrangChu>((p) => true, (p) => LayDuLieuDam(p));
            cmTinhToan = new RelayCommand<ViewTrangChu>((p) => true, (p) => TinhToanVanKhuon(p));
            cmLuu = new RelayCommand<ViewTrangChu>((p) => true, (p) => LuuVatLieu(p));

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void LayDuLieuDam(ViewTrangChu viewTrangChu)
        {
            // Yêu cầu người dùng chọn dầm
            ICollection<ElementId> selectElements = UIDoc.Selection.GetElementIds();

            foreach (ElementId elementId in selectElements)
            {
                Element element = Doc.GetElement(elementId);
                FamilyInstance beam = element as FamilyInstance;

                if (beam != null)
                {
                    double b = 0, h = 0, length = 0;

                    // Lấy thông số từ Symbol (kiểu dầm)
                    Parameter paramB = beam.Symbol.LookupParameter("b");
                    Parameter paramH = beam.Symbol.LookupParameter("h");
                    Parameter paramLength = beam.LookupParameter("Length");

                    if (paramB != null && paramB.HasValue)
                        b = paramB.AsDouble() * 304.8;

                    if (paramH != null && paramH.HasValue)
                        h = paramH.AsDouble() * 304.8;

                    if (paramLength != null && paramLength.HasValue)
                        length = paramLength.AsDouble() * 304.8;

                    // Lấy ID và Name
                    string id = beam.Id.IntegerValue.ToString();
                    string name = beam.Name;

                    // Tạo đối tượng dầm và thêm vào danh sách
                    clsDam dam = new clsDam(id, name, length, b, h);
                    clsBienToanCuc.Beams.Add(dam);
                }
                List<string> nameDam = new List<string>();
                foreach (clsDam Dam in clsBienToanCuc.Beams)
                {
                    nameDam.Add(Dam.Name);
                }
                viewTrangChu.cbbDam.ItemsSource = nameDam;
                viewTrangChu.cbbDam.SelectedIndex = 0;
            }
        }

        public void TinhToanVanKhuon(ViewTrangChu viewTrangChu)
        {
            VanKhuon vanKhuon = null;
            clsDam Dam = null;
            foreach (VanKhuon vk in clsBienToanCuc.ListVK)
            {
                if (viewTrangChu.cboMaterial.Text == vk.Name)
                {
                    vanKhuon = vk;
                }
            }
            foreach (clsDam dam in clsBienToanCuc.Beams)
            {
                if (viewTrangChu.cbbDam.Text == dam.Name)
                {
                    Dam = dam;
                }
            }
            double hsvt = Convert.ToDouble(viewTrangChu.txtHSVT.Text);
            double gamaBT = Convert.ToDouble(viewTrangChu.txtGamaBT.Text);
            double Width = Dam.Width / 1000;
            double Height = Dam.Height / 1000;
            (double Gtc1, double Gtt1) = clsChuongTrinhConVanDay.TrongLuongBTKetCau(hsvt, Width, Height, gamaBT);
            (double Gtc2, double Gtt2) = clsChuongTrinhConVanDay.TrongLuongBTVanDay(hsvt, Width, Height, vanKhuon.GaMaVK);
            (double Ptc1, double Ptt1) = clsChuongTrinhConVanDay.HTDamRung(Width, hsvt);
            (double Ptc2, double Ptt2) = clsChuongTrinhConVanDay.HTDoBeTong(Width, hsvt);
            (double Qtc, double Qtt) = clsChuongTrinhConVanDay.ToHopTaiTrong(Gtc1, Gtt1, Gtc2, Gtt2, Ptt1, Ptt2);
            double KCCC = clsChuongTrinhConVanDay.TTKCTheoDKBen(Qtt, Width, vanKhuon.DayVanDay, vanKhuon.CuongDoGo);
            double SoCC = clsChuongTrinhConVanDay.BoTriCotChong(Dam.Length/1000, Width, KCCC);

            if (clsChuongTrinhConVanDay.KTKCCotChongTheoDKBienDang(Qtc, Dam.Length/1000, Width, vanKhuon.DayVanDay))
            {
                viewTrangChu.lblKCCC.Text = Math.Round(KCCC, 2) + "(m) {Thỏa mãn}";
                viewTrangChu.lblSoKCCC.Text = Math.Round(SoCC, 2) + "(cái)";

                viewTrangChu.lblKCCC.Foreground = Brushes.Green;
            }
            else
            {
                viewTrangChu.lblKCCC.Text = Math.Round(KCCC, 2) + "{Không thỏa mãn}";
                viewTrangChu.lblKCCC.Foreground = Brushes.Red;
            }


            (double Ptc1Thanh, double Ptt1Thanh, double Ptc2Thanh, double Ptt2Thanh, double Ptc3Thanh, double Ptt3Thanh) = ChuongTrinhConVanThanh.TaiTrongTDPNgangVanThanh
                (gamaBT,KCCC,Height,0.1,hsvt);

            (double QtcVT, double QttVT) = ChuongTrinhConVanThanh.ToHopTaiTrong
                (Ptc1Thanh, Ptt1Thanh, Ptt2Thanh, Ptt3Thanh);

            double KCND = ChuongTrinhConVanThanh.TinhToanKhoangCachNepDung
               (QtcVT, Height, vanKhuon.DayVanThanh, 0.1,vanKhuon.CuongDoGo);

            double SoND = ChuongTrinhConVanThanh.BoTriNepDung(Dam.Length / 1000, Width, KCND);

            if (ChuongTrinhConVanThanh.KiemTraKCNepDungTheoDKBienDang(QttVT, KCND, Height, vanKhuon.DayVanThanh, 0.1))
            {
                viewTrangChu.lblKCND.Text = Math.Round(KCND, 2) + "(m) {Thỏa mãn}";
                viewTrangChu.lblSoNepDung.Text = Math.Round(SoND, 2) + "(cái)";
                viewTrangChu.lblKCND.Foreground = Brushes.Green;
            }
            else
            {
                viewTrangChu.lblKCND.Text = Math.Round(KCND, 2) + "{Không thỏa mãn}";
                viewTrangChu.lblKCND.Foreground = Brushes.Red;
            }



        }
        public void LuuVatLieu(ViewTrangChu viewTrangChu)
        {
            double dayday = Convert.ToDouble(viewTrangChu.txtDayVanDay.Text);
            double daythanh = Convert.ToDouble(viewTrangChu.txtDayVanThanh.Text);
            double gamago = Convert.ToDouble(viewTrangChu.txtGamaVK.Text);
            double ccg = Convert.ToDouble(viewTrangChu.txtCDG.Text);
            clsBienToanCuc.ListVK.Add(new VanKhuon(dayday, daythanh, gamago, viewTrangChu.txtName.Text, ccg));
            List<string> nameVK = new List<string>();
            foreach(VanKhuon vanKhuon in clsBienToanCuc.ListVK)
            {
                nameVK.Add(vanKhuon.Name);
            }
            viewTrangChu.cboMaterial.ItemsSource = nameVK;
            MessageBox.Show("Thêm vật liệu thành công");
            viewTrangChu.cboMaterial.SelectedIndex = 0;

        }
    }
}
