using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckTriangle_23_Duy_40_Tien;
using ClosedXML.Excel;
using System.Linq;

namespace TriangleTester_23_Duy_40_Tien
{
    [TestClass]

    public class TriangleTester_23_Duy
    {
        private Triangle_40_Tien triangle_23_Duy;
        [TestMethod]
        //TC1_TinhChuVi_TriangleVuong:
        //a = 3, b = 4, c = 5 → expectedPerimeter = 12 → result = Pass
        public void TC1_TinhChuVi_TriangleVuong()
        {
            triangle_23_Duy = new Triangle_40_Tien(3, 4, 5); // Tam giác vuông
            double expected_23_Duy = 12;
            double actual_23_Duy = triangle_23_Duy.TinhChuVi_40_Tien();
            Assert.AreEqual(expected_23_Duy, actual_23_Duy, 0.01);
        }

        [TestMethod]
        //TC2_TinhDienTich_TriangleVuong:
        //a = 3, b = 4, c = 5 → expectedArea = 6 → result = Pass
        public void TC2_TinhDienTich_TriangleVuong()
        {
            triangle_23_Duy = new Triangle_40_Tien(3, 4, 5); // Tam giác vuông
            double expected_23_Duy = 6;
            double actual_23_Duy = triangle_23_Duy.TinhDienTich_40_Tien();
            Assert.AreEqual(expected_23_Duy, actual_23_Duy, 0.01);
        }

        [TestMethod]
        //TC3_TinhChuVi_TriangleCan:
        //a = 5, b = 5, c = 8 → expectedPerimeter = 18 → result = Pass
        public void TC3_TinhChuVi_TriangleCan() //Tam giác cân
        {
            triangle_23_Duy = new Triangle_40_Tien(5, 5, 8);
            double expected_23_Duy = 18;
            double actual_23_Duy = triangle_23_Duy.TinhChuVi_40_Tien();
            Assert.AreEqual(expected_23_Duy, actual_23_Duy, 0.01);
        }

        [TestMethod]
        //TC4_TinhDienTich_TriangleCan:
        //a = 5, b = 5, c = 8 → expectedArea = 12 → result = Pass
        public void TC4_TinhDienTich_TriangleCan()
        {
            triangle_23_Duy = new Triangle_40_Tien(5, 5, 8);
            double expected_23_Duy = 12; // Tính theo công thức Heron
            double actual_23_Duy = triangle_23_Duy.TinhDienTich_40_Tien();
            Assert.AreEqual(expected_23_Duy, actual_23_Duy, 0.01);
        }

        [TestMethod]
        //TC5_TinhChuVi_TriangleDeu:
        //a = 6, b = 6, c = 6 → expectedPerimeter = 18 → result = Pass
        public void TC5_TinhChuVi_TriangleDeu()
        {
            triangle_23_Duy = new Triangle_40_Tien(6, 6, 6);
            double expected_23_Duy = 18;
            double actual_23_Duy = triangle_23_Duy.TinhChuVi_40_Tien();
            Assert.AreEqual(expected_23_Duy, actual_23_Duy, 0.01);
        }

        [TestMethod]
        //TC6_TinhDienTich_TriangleDeu:
        //a = 6, b = 6, c = 6 → expectedArea = 15.59 → result = Pass
        public void TC6_TinhDienTich_TriangleDeu()
        {
            triangle_23_Duy = new Triangle_40_Tien(6, 6, 6);
            double expected_23_Duy = 15.59; // sqrt(3)/4 * 6^2
            double actual_23_Duy = triangle_23_Duy.TinhDienTich_40_Tien();
            Assert.AreEqual(expected_23_Duy, actual_23_Duy, 0.01);
        }

        [TestMethod]
        //TC7_TinhChuVi_InvalidTriangle:
        //a = 1, b = 2, c = 3 → expectedPerimeter = 0 → result = Pass
        public void TC7_TinhChuVi_InvalidTriangle()
        {
            triangle_23_Duy = new Triangle_40_Tien(1, 2, 3); // Không phải tam giác hợp lệ
            double expected_23_Duy = 0;
            double actual_23_Duy = triangle_23_Duy.TinhChuVi_40_Tien();
            Assert.AreEqual(expected_23_Duy, actual_23_Duy);
        }

        [TestMethod]
        //TC8_TinhDienTich_InvalidTriangle:
        //a = 1, b = 2, c = 3 → expectedArea = 0 → result = FAIL 
        //expected_23_Duy = 0
        public void TC8_TinhDienTich_InvalidTriangle()
        {
            triangle_23_Duy = new Triangle_40_Tien(1, 2, 3); // Không phải tam giác hợp lệ
            double expected_23_Duy = 6;
            double actual_23_Duy = triangle_23_Duy.TinhDienTich_40_Tien();
            Assert.AreEqual(expected_23_Duy, actual_23_Duy);
        }
          
        [TestMethod]
        //TC10_Excel4Dong_23_Duy:
        //a_23_Duy = 3, b_23_Duy = 4, c_23_Duy = 5, expectedPerimeter = 12, expectedArea = 6, result = Pass
        //a_23_Duy = 5, b_23_Duy = 5, c_23_Duy = 8, expectedPerimeter = 18, expectedArea = 12, result = Pass
        //a_23_Duy = 6, b_23_Duy = 6, c_23_Duy = 6, expectedPerimeter = 18, expectedArea = 15.59, result = Pass
        //a_23_Duy = 1, b_23_Duy = 2, c_23_Duy = 3, expectedPerimeter = 0, expectedArea = 0, result = Pass
        public void TC9_Triangle_WithExcel_ManualLoop()
        {
            // Đường dẫn đến file Excel
            string filePath = @"D:\TriangleTestData.xlsx";
            // Mở workbook.
            var workbook = new XLWorkbook(filePath);
            var worksheet = workbook.Worksheet("Sheet1");
            // kết quả ở cột 6
            worksheet.Cell(1, 6).Value = "results_23_Duy"; 

            foreach (var row in worksheet.RowsUsed().Skip(1)) // Bỏ qua header
            {
                double a_23_Duy = row.Cell(1).GetDouble();
                double b_23_Duy = row.Cell(2).GetDouble();
                double c_23_Duy = row.Cell(3).GetDouble();
                double expectedPerimeter_23_Duy = row.Cell(4).GetDouble();
                double expectedArea_23_Duy = row.Cell(5).GetDouble();

                // Arrange
                var triangle = new Triangle_40_Tien(a_23_Duy, b_23_Duy , c_23_Duy);

                // Act
                double actualPerimeter_23_Duy = triangle.TinhChuVi_40_Tien();
                double actualArea_23_Duy = triangle.TinhDienTich_40_Tien();
                string type_23_Duy = triangle.CheckLoaiTamGiac_40_Tien();

                string result_23_Duy = "Pass";

                try
                {
                    Assert.AreEqual(expectedPerimeter_23_Duy, actualPerimeter_23_Duy, 0.01, "Chu vi sai");
                    Assert.AreEqual(expectedArea_23_Duy, actualArea_23_Duy, 0.01, "Diện tích sai");
                }
                catch
                {
                    result_23_Duy = "Fail";
                }

                // Ghi lại kết quả vào cột 6
                row.Cell(6).Value = result_23_Duy;

                // Optional log
                Console.WriteLine($"A={a_23_Duy}, B={b_23_Duy}, C={c_23_Duy} → {type_23_Duy}, CV={actualPerimeter_23_Duy}, DT={actualArea_23_Duy}, KQ={result_23_Duy}");
            }

            workbook.Save();
        }


        public TestContext TestContext { get; set; }
            [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
                @".\Data_23_Duy_40_Tien\TestData_23_Duy_40_Tien.csv", "TestData_23_Duy_40_Tien#csv", DataAccessMethod.Sequential)]
            [TestMethod]
        //a = 3, b = 4, c = 5, expectedPerimeter = 12, expectedArea = 6 -> PASS
        //a = 5, b = 5, c = 5, expectedPerimeter = 15, expectedArea = 10.83 -> PASS
        //a = 6, b = 8, c = 10, expectedPerimeter = 24, expectedArea = 24 -> PASS
        //a = 5, b = 5, c = 6, expectedPerimeter = 10, expectedArea = 12 -> FAIL (16) 
        //a = 1, b = 2, c = 3, expectedPerimeter = 0, expectedArea = 0 -> PASS

        public void TC10_Triangle_TestWithCSV_23_Duy()
            {
            double a_23_Duy = double.Parse(TestContext.DataRow[0].ToString());
            double b_23_Duy = double.Parse(TestContext.DataRow[1].ToString());
            double c_23_Duy = double.Parse(TestContext.DataRow[2].ToString());
            double expectedP_23_Duy = double.Parse(TestContext.DataRow[3].ToString());
            double expectedS_23_Duy = double.Parse(TestContext.DataRow[4].ToString());


            Triangle_40_Tien triangle_23_Duy = new Triangle_40_Tien(a_23_Duy, b_23_Duy, c_23_Duy);

                double actualPerimeter_23_Duy = triangle_23_Duy.TinhChuVi_40_Tien();
                double actualArea_23_Duy = triangle_23_Duy.TinhDienTich_40_Tien();

                Assert.AreEqual(expectedP_23_Duy, actualPerimeter_23_Duy, 0.01, "Chu vi sai");
                Assert.AreEqual(expectedS_23_Duy, actualArea_23_Duy, 0.01, "Diện tích sai");
            }
    }
}