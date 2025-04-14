using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckTriangle_23_Duy_40_Tien
{
    public class Triangle_40_Tien
    {
        private double canhA_40_Tien, canhB_40_Tien, canhC_40_Tien;
        private double dienTich_40_Tien, chuVi_40_Tien;
        public Triangle_40_Tien(double canhA_40_Tien,double canhB_40_Tien,double canhC_40_Tien)
        {
            this.canhA_40_Tien = canhA_40_Tien;
            this.canhB_40_Tien = canhB_40_Tien;
            this.canhC_40_Tien = canhC_40_Tien;
        }

        public bool IsCheckTG_40_Tien()
        {
            return canhA_40_Tien > 0 && canhB_40_Tien > 0 && canhC_40_Tien > 0 &&
                   canhA_40_Tien + canhB_40_Tien > canhC_40_Tien &&
                   canhA_40_Tien + canhC_40_Tien > canhB_40_Tien &&
                   canhB_40_Tien + canhC_40_Tien > canhA_40_Tien;
        }

        public string CheckLoaiTamGiac_40_Tien()
        {
            if (!IsCheckTG_40_Tien())
                return "Không phải tam giác";

            bool isVuong_40_Tien = Math.Abs(canhA_40_Tien * canhA_40_Tien + canhB_40_Tien * canhB_40_Tien - canhC_40_Tien * canhC_40_Tien) < 1e-5 ||
                           Math.Abs(canhA_40_Tien * canhA_40_Tien + canhC_40_Tien * canhC_40_Tien - canhB_40_Tien * canhB_40_Tien) < 1e-5 ||
                           Math.Abs(canhB_40_Tien * canhB_40_Tien + canhC_40_Tien * canhC_40_Tien - canhA_40_Tien * canhA_40_Tien) < 1e-5;

            if (canhA_40_Tien == canhB_40_Tien && canhB_40_Tien == canhC_40_Tien)
                return "Tam giác đều";

            if (canhA_40_Tien == canhB_40_Tien || canhB_40_Tien == canhC_40_Tien || canhA_40_Tien == canhC_40_Tien)
            {
                if (isVuong_40_Tien)
                    return "Tam giác vuông cân";
                return "Tam giác cân";
            }

            if (isVuong_40_Tien)
                return "Tam giác vuông";

            return "Tam giác thường";
        }
        public double TinhChuVi_40_Tien()
        {
            if (!IsCheckTG_40_Tien())
                return 0;
            chuVi_40_Tien = canhA_40_Tien + canhB_40_Tien + canhC_40_Tien;
            return Math.Round(chuVi_40_Tien, 2);
        }

        public double TinhDienTich_40_Tien()
        {
            if (!IsCheckTG_40_Tien())
                return 0;
            double p_40_Tien = TinhChuVi_40_Tien() / 2;
            dienTich_40_Tien = Math.Sqrt(p_40_Tien * (p_40_Tien - canhA_40_Tien) * (p_40_Tien - canhB_40_Tien) * (p_40_Tien - canhC_40_Tien));
            return Math.Round(dienTich_40_Tien, 2);
        }
    }
}
