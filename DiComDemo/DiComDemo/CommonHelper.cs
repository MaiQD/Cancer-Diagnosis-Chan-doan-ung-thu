using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiComDemo
{
	public static class CommonHelper
	{
		public static readonly string PATH = "";
		/// <summary>
		/// đường dẫn đến file account
		/// </summary>
		public static readonly string _ACCOUNT_XML_PATH = Application.StartupPath + "\\account.xml";
		/// <summary>
		/// đường dẫn tới thư mục chứa kết quả phân tích
		/// </summary>
		public static readonly string _SESSION_PATH = Application.StartupPath + "\\_Session\\";
		/// <summary>
		/// đường dẫn tới thư mục chứa ảnh dại diện
		/// </summary>
		public static readonly string _AVATAR_PATH = Application.StartupPath + "\\images\\avatar\\";
	}
}
