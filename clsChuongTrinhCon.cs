using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TinhToanCotThep.Class
{
    public static class clsChuongTrinhConVanDay
    {
        public static (double gtc1,double gtt1) TrongLuongBTKetCau(double n, double B, double H, double gamaBT)
        {
            double Gtc1 = gamaBT * B * H;
            double Gtt1 = n * Gtc1;

            return (Gtc1,Gtt1);
        }

        public static (double gtc2, double gtt2) TrongLuongBTVanDay(double n, double B, double h, double gamaG)
        {
            double Gtc2 = gamaG * B * h;
            double Gtt2 = n * Gtc2;

            return (Gtc2, Gtt2);
        }
        public static  (double Ptc1, double Ptt1) HTDamRung(double B, double n)
        {
            double Ptc1 = 200 * B;
            double Ptt1 = n * Ptc1;
            return (Ptc1, Ptt1);
        }
        //n là hệ số vượt tải B là rộng dầm, H là cao dầm, b,h là rộng dày của ván khuôn
        public static (double Ptc2, double Ptt2) HTDoBeTong(double B, double n)
        {
            double Ptc2 = 600 * B;
            double Ptt2 = n * Ptc2;
            return (Ptc2, Ptt2);
        }
        public static (double Qtc, double Qtt) ToHopTaiTrong(double gtc1,double gtt1,double gtc2, double gtt2, double ptt1,double ptt2)
        {
            double QTCvd = gtc1 + gtc2;
            double Qttvd = gtt1 + gtt2 + 0.9 * (ptt1 + ptt2);
            return (QTCvd, Qttvd);
        }

        public static double TTKCTheoDKBen(double Qttvd,double B,double h, double CDgo)
        {
            double W = B * Math.Pow(h, 2) / 6;
            double Lcc = Math.Sqrt((CDgo * Math.Pow(10, 4)*W*10)/Qttvd);
            return Lcc;
        }

        public static bool KTKCCotChongTheoDKBienDang(double qtc, double L, double B, double h)
        {
            double E = 1.1*Math.Pow(10, 9);
            double J = B*Math.Pow(h, 3)/12;
            double f = (qtc * Math.Pow(L, 4))/(128*E*J);
            if (f <= L / 0.4)
            {
                return true;
            }
            else { return false; }
        }

        public static double BoTriCotChong(double Ldam, double B, double Lcc)
        {
            double n = (Ldam - B) / Lcc + 1;
            return n;
        }
    }
    public static class ChuongTrinhConVanThanh 
    { 
        public static (double Ptc1Thanh,double Ptt1Thanh,double Ptc2Thanh,double Ptt2Thanh, double Ptc3Thanh, double Ptt3Thanh
            ) TaiTrongTDPNgangVanThanh(double gamaBT,double Lcc, double H,double s,double n)
        {
            double Ptc1Thanh = gamaBT * H * (H - s);
            double Ptt1Thanh = n*Ptc1Thanh;

            double Ptc2Thanh = 600 * (H - s);
            double Ptt2Thanh = n*Ptc2Thanh;

            double Ptc3Thanh = 200 * (H - s);
            double Ptt3Thanh = n*Ptc3Thanh;

            return (Ptc1Thanh, Ptt1Thanh, Ptc2Thanh, Ptt2Thanh, Ptc3Thanh, Ptt3Thanh);
        }

        public static (double Qtcvt,double Qttvt) ToHopTaiTrong(double Ptc1Thanh, double Ptt1Thanh, double Ptt2Thanh, double Ptt3Thanh)
        {
            double Qtcvt = Ptc1Thanh;
            double Qttvt = Ptt1Thanh+Ptt2Thanh+Ptt3Thanh;
            return (Qtcvt,Qttvt);
        }

        public static double TinhToanKhoangCachNepDung(double Qttvt,double H,double h, double s,double CDgo)
        {
            double W = (H - s) * Math.Pow(h, 2) / 6;
            double Lnepdung = Math.Sqrt((CDgo * Math.Pow(10, 4) * W * 10) / Qttvt);
            return Lnepdung;
        }

        public static bool KiemTraKCNepDungTheoDKBienDang(double Qttvt, double Lnepdung, double H, double h,double s)
        {
            double E = 1.1 * Math.Pow(10, 9);
            double J = (H-s) * Math.Pow(h, 3) / 12;
            double f = (Qttvt * Math.Pow(Lnepdung, 4)) / (128 * E * J);
            if (f <= Lnepdung / 4)
            {
                return true;
            }
            else { return false; }
        }

        public static double BoTriNepDung(double Ldam, double B, double Lnd)
        {
            double n = (Ldam - B) / Lnd + 1;
            return n;
        }
    }
}
