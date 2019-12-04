using DiComDemo.Models;
using DiComDemo.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiComDemo
{
	public partial class frmLogin : Form
	{
		public frmLogin()
		{
			InitializeComponent();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		#region place holder cho input
		private void TxtUsername_Enter(object sender, EventArgs e)
		{
			if (txtUsername.Text == "Tên đăng nhập")
			{
				txtUsername.Text = "";
				txtUsername.ForeColor = Color.Black;
				//txtUsername.TextAlign = HorizontalAlignment.Left;
			}
		}

		private void TxtUsername_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtUsername.Text))
			{
				txtUsername.Text = "Tên đăng nhập";
				txtUsername.ForeColor = Color.Gray;
			}
		}

		private void TxtPassword_Enter(object sender, EventArgs e)
		{
			if (txtPassword.Text == "Mật khẩu")
			{
				txtPassword.Text = "";
				txtPassword.ForeColor = Color.Black;
				txtPassword.UseSystemPasswordChar = true;
			}
		}

		private void TxtPassword_Leave(object sender, EventArgs e)
		{
			if (string.IsNullOrWhiteSpace(txtPassword.Text))
			{
				txtPassword.Text = "Mật khẩu";
				txtPassword.ForeColor = Color.Gray;
				txtPassword.UseSystemPasswordChar = false;
			}
		}
		#endregion

		private void BtnLogin_Click(object sender, EventArgs e)
		{
			try
			{
				Account account = AccountServices._accountServices.Login(txtUsername.Text, txtPassword.Text);
				//_account = account;
				if (account != null)
				{
					//giao diện
					lblError.Visible = false;
					txtPassword.Text = "";
					frmMainControl frmTemp = new frmMainControl(account);
					this.Hide();
					frmTemp.ShowDialog();
					this.Show();
					return;
				}

				lblError.Visible = true;
			}
			catch (Exception ex)
			{

				MessageBox.Show("Có lỗi xảy ra\r\n" + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
			finally
			{

			}
		}
	}
}
