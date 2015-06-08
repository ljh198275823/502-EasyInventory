using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using LJH.Inventory.BusinessModel;

namespace WebAPIFormTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 私有变量
        private string _UserName = null;
        #endregion

        #region 私有方法
        private string GetUserName()
        {
            string auth = AppSettings.Current.GetConfigContent("Authenticate");
            if (string.IsNullOrEmpty(auth)) return null;
            auth = UTF8Encoding.UTF8.GetString(Convert.FromBase64String(auth));
            if (string.IsNullOrEmpty(auth)) return null;
            return auth.Split(':')[0];
        }

        private bool CheckAccount()
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("请输入会员名称");
                return false;
            }
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("请输入会员密码");
                return false;
            }
            if (txtPassword.Text != txtPasswordConfirm.Text)
            {
                MessageBox.Show("输入的密码与确认密码不一致");
                return false;
            }
            return true;
        }
        #endregion

        #region 事件处理程序
        private void Form1_Load(object sender, EventArgs e)
        {
            txtBaseAddress.Text = AppSettings.Current.GetConfigContent("BaseAddress");
            _UserName = GetUserName();
            if (!string.IsNullOrEmpty(_UserName)) lblUserName.Text = string.Format("你好，{0}", _UserName);
        }

        private void txtBaseAddress_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Current.SaveConfig("BaseAddress", txtBaseAddress.Text.Trim());
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (!CheckAccount()) return;
            if (string.IsNullOrEmpty(txtBaseAddress.Text.Trim()))
            {
                MessageBox.Show("请指定服务器地址");
                return;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(txtBaseAddress.Text.Trim());
            var account = new { UserName = txtUserName.Text.Trim(), Password = txtPassword.Text.Trim() };
            var response = await client.PostAsJsonAsync("api/accounts/", account);
            if (response.StatusCode == HttpStatusCode.Created)
            {
                string auth = string.Format("{0}:{1}", account.UserName, account.Password);
                auth = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(auth));
                AppSettings.Current.SaveConfig("Authenticate", auth);
                MessageBox.Show("注册成功");

                if (!string.IsNullOrEmpty(_UserName)) lblUserName.Text = string.Format("你好，{0}", account.UserName);
            }
            else
            {
                MessageBox.Show("注册失败: " + response.Content.ReadAsStringAsync().Result);
            }
        }

        private async void btnSignIn_Click(object sender, EventArgs e)
        {

        }

        private async void btnYouhuiquan_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            if (string.IsNullOrEmpty(txtBaseAddress.Text.Trim()))
            {
                MessageBox.Show("请指定服务器地址");
                return;
            }
            if (string.IsNullOrEmpty(_UserName))
            {
                MessageBox.Show("请先登录");
                return;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(txtBaseAddress.Text.Trim());
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/jason"));
            string auth = AppSettings.Current.GetConfigContent("Authenticate");
            if (!string.IsNullOrEmpty(auth)) client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("basic", auth);
            HttpResponseMessage response = await client.GetAsync(string.Format("api/accounts/{0}/youhuiquan/", _UserName), new CancellationToken());
            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var items = await response.Content.ReadAsAsync<YouhuiQuan[]>();
                    var item = items[0];
                    if (item != null)
                    {
                        this.Invoke((Action)(() =>
                        {
                            this.panel1.Visible = true;
                            this.qrYouhuiquan.Text = new Uri(new Uri(txtBaseAddress.Text), "api/Youhuiquan/" + item.ID).ToString();
                            this.lblAmount.Text = item.Amount.ToString();
                        }));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(response.StatusCode.ToString());
            }
        }
        #endregion
    }
}
