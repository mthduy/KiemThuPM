using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace WebDriver_23_Duy_40_Tien
{
    public partial class formWebDriver23_Duy40_Tien: Form
    {
        public formWebDriver23_Duy40_Tien()
        {
            InitializeComponent();
        }

        private void btnDangNhap_23_Duy_Click(object sender, EventArgs e)
        {

            
            // đóng màn hình đen khi chạy
            ChromeDriverService chrome_23_Duy = ChromeDriverService.CreateDefaultService();
            chrome_23_Duy.HideCommandPromptWindow = true;
            IWebDriver driver_23_Duy = new ChromeDriver(chrome_23_Duy);

            //Dang nhap
            // Mở trang đăng nhập Gmail
            driver_23_Duy.Navigate().GoToUrl("https://mail.google.com/");
            IWebElement e_23_Duy = driver_23_Duy.FindElement(By.Name("identifier"));
            e_23_Duy.SendKeys("duyduy22510102047@gmail.com");
            IWebElement btnNext_23_Duy = driver_23_Duy.FindElement(By.XPath("//*[@id=\"identifierNext\"]/div/button")); 
            btnNext_23_Duy.Click();

            // Đợi ô nhập mật khẩu hiển thị với timeout là 10 giây
            WebDriverWait wait_23_Duy = new WebDriverWait(driver_23_Duy, TimeSpan.FromSeconds(10));

            IWebElement p_23_Duy = wait_23_Duy.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='password']")));
            p_23_Duy.SendKeys("23_Duy_2251012047");
            IWebElement btnContinue_23_Duy = driver_23_Duy.FindElement(By.XPath("//*[@id=\"passwordNext\"]/div/button"));
            btnContinue_23_Duy.Click();
            wait_23_Duy.Until(ExpectedConditions.UrlContains("mail.google.com/mail/u/"));
            Console.WriteLine("Đang nhap thanh cong!");

        }

        private void btnGuiMail_23_Duy_Click(object sender, EventArgs e)
        {

            // đóng màn hình đen khi chạy
            ChromeDriverService chrome_23_Duy = ChromeDriverService.CreateDefaultService();
            chrome_23_Duy.HideCommandPromptWindow = true;
            IWebDriver driver_23_Duy = new ChromeDriver(chrome_23_Duy);

            //Dang nhap
            driver_23_Duy.Navigate().GoToUrl("https://mail.google.com/");
            IWebElement e_23_Duy = driver_23_Duy.FindElement(By.Name("identifier"));
            e_23_Duy.SendKeys("duyduy22510102047@gmail.com");
            IWebElement btnNext = driver_23_Duy.FindElement(By.XPath("//*[@id=\"identifierNext\"]/div/button"));
            btnNext.Click();

            WebDriverWait wait_23_Duy = new WebDriverWait(driver_23_Duy, TimeSpan.FromSeconds(10));
            IWebElement p_23_Duy = wait_23_Duy.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("input[type='password']")));

            p_23_Duy.SendKeys("23_Duy_2251012047");
            IWebElement btnContinue_23_Duy = driver_23_Duy.FindElement(By.XPath("//*[@id=\"passwordNext\"]/div/button"));
            btnContinue_23_Duy.Click();
            wait_23_Duy.Until(ExpectedConditions.UrlContains("mail.google.com/mail/u/"));
            Console.WriteLine("Đăng nhập thành công!");


            //Gửi mail

            // Đảm bảo đang ở Gmail inbox
            wait_23_Duy.Until(ExpectedConditions.ElementExists(By.CssSelector("div[gh='cm']"))); // vùng chứa nút Soạn thư

            // Click nút soạn thư
            IWebElement btnCompose_23_Duy = driver_23_Duy.FindElement(By.CssSelector("div[gh='cm']"));
            btnCompose_23_Duy.Click();


            // Nhập người nhận
            //wait_23_Duy.Until(ExpectedConditions.ElementIsVisible(By.Id(":bz"))).SendKeys("mthduy7@gmail.com");
            wait_23_Duy.Until(ExpectedConditions.ElementIsVisible(By.ClassName("agP"))).SendKeys("mthduy7@gmail.com");

            // Tiêu đề
            driver_23_Duy.FindElement(By.Name("subjectbox")).SendKeys("Mail tự động có file đính kèm");

            // Nội dung thư
            driver_23_Duy.FindElement(By.XPath("//*[@id=\":9n\"]")).SendKeys("Xin chào, đây là mail có tệp đính kèm.");

            // File đính kèm
            IWebElement fileInput_23_Duy = driver_23_Duy.FindElement(By.CssSelector("input[type='file']"));
            fileInput_23_Duy.SendKeys(@"D:\Duy_CV_SIC.docx");

            Thread.Sleep(3000); // hoặc đợi element báo upload xong

            // Gửi
            wait_23_Duy.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//*[@id=\":7x\"]"))).Click();


        }
    }
}
