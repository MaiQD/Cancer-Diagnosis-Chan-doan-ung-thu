using DiComDemo.Models;
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
	public partial class frmMainControl : Form
	{
		private Account account;
		public frmMainControl()
		{
			InitializeComponent();
		}
		public frmMainControl(Account account)
		{
			this.account = account;
			InitializeComponent();
			if (this.account != null)
			{
				string path = CommonHelper._AVATAR_PATH + this.account.Avatar;
				picBAvatar.ImageLocation = path;

				lblName.Text = account.Name;
				lblFromWhen.Text = DateTime.Now.TimeOfDay.Hours.ToString() + "h :" + DateTime.Now.TimeOfDay.Minutes.ToString() + "m";


			}
			var mdi = Controls.OfType<MdiClient>().FirstOrDefault();
			if (mdi!= null)
			{
				mdi.BackColor = System.Drawing.ColorTranslator.FromHtml("#CCCDCD");
				//mdi.BackgroundImage = imageList1.Images[0];
				//mdi.BackgroundImageLayout = ImageLayout.Stretch;
			}
			
		}

		private void BtnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void BtnMini_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		
	}
}
