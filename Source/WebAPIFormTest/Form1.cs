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
using Newtonsoft.Json;
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

        private bool CheckAccount()
        {
            if(string.IsNullOrEmpty (txtEmail .Text ))
            {
            }
            return true ;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBaseAddress.Text.Trim()))
            {
                MessageBox.Show("请指定服务器地址");
                return;
            }
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(txtBaseAddress.Text.Trim());
            var account = new { Email = txtEmail.Text.Trim(), UserName = txtUserName.Text.Trim(), Password = txtPassword.Text.Trim() };
            HttpContent content = new StringContent(JsonConvert.SerializeObject(account));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpResponseMessage response = await client.PostAsync("api/accounts/", content, new CancellationToken());
            if (response.StatusCode == HttpStatusCode.Created)
            {
                string auth = string.Format("{0}:{1}", account.Email, account.Password);
                auth = Convert.ToBase64String(UTF8Encoding.UTF8.GetBytes(auth));
                AppSettings.Current.SaveConfig("Authenticate", auth);
                MessageBox.Show("注册成功");
            }
            else
            {
                MessageBox.Show("注册失败: " + response.Content.ReadAsStringAsync().Result);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtBaseAddress .Text  = AppSettings.Current.GetConfigContent("BaseAddress");
        }

        private void txtBaseAddress_TextChanged(object sender, EventArgs e)
        {
            AppSettings.Current.SaveConfig("BaseAddress", txtBaseAddress.Text.Trim());
        }
    }
}
