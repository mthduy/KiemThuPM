using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckTriangle_23_Duy_40_Tien
{
    public partial class CheckTriangle_23_Duy_40_Tien : Form
    {
        public CheckTriangle_23_Duy_40_Tien()
        {
            InitializeComponent();
        }

        private void btnCheck_40_Tien_Click(object sender, EventArgs e)
        {
            double canhA_40_Tien = double.Parse(txtCanhA_40_Tien.Text);
            double canhB_40_Tien = double.Parse(txtCanhB_40_Tien.Text);
            double canhC_40_Tien = double.Parse(txtCanhC_40_Tien.Text);

            Triangle_40_Tien tamGiac_40_Tien = new Triangle_40_Tien(canhA_40_Tien, canhB_40_Tien, canhC_40_Tien);
            txtCheckTriangle_40_Tien.Text = tamGiac_40_Tien.CheckLoaiTamGiac_40_Tien();
            txtTinhDT_40_Tien.Text = tamGiac_40_Tien.TinhDienTich_40_Tien().ToString();
            txtTinhCV_40_Tien.Text = tamGiac_40_Tien.TinhChuVi_40_Tien().ToString();
        }
    }
}
