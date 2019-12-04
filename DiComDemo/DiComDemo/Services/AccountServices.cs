using DiComDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DiComDemo.Services
{
	public class AccountServices
	{
		private static AccountServices accountServices;

		public static AccountServices _accountServices
		{
			get
			{
				if (accountServices == null)
				{
					accountServices = new AccountServices();
				}
				return accountServices;
			}
			private set
			{
				accountServices = value;
			}
		}
		private AccountServices()
		{

		}

		/// <summary>
		/// Hàm tạo mã hóa MD5
		/// </summary>
		/// <param name="pass">truyền vào chuỗi cần mã hóa</param>
		/// <returns>Trả ra chuỗi đã mã hóa</returns>
		private string myMD5(string pass)
		{
			//Tạo MD5 
			MD5 mh = MD5.Create();
			//Chuyển kiểu chuổi thành kiểu byte
			byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(pass);
			//mã hóa chuỗi đã chuyển
			byte[] hash = mh.ComputeHash(inputBytes);
			//tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < hash.Length; i++)
			{
				sb.Append(hash[i].ToString("X2"));
			}

			//nếu bạn muốn các chữ cái in thường thay vì in hoa thì bạn thay chữ "X" in hoa trong "X2" thành "x"
			return sb.ToString();
		}

		public Account Login(string username, string pass)
		{
			string path = CommonHelper._ACCOUNT_XML_PATH;
			XmlDocument xml = new XmlDocument();
			xml.Load(path);

			foreach (XmlNode item in xml.DocumentElement.ChildNodes)
			{
				if (item.Name == "account")
				{
					if (item.Attributes["username"]?.InnerText == username && item.Attributes["password"]?.InnerText.ToUpper() == myMD5(pass).ToUpper())
					{
						//xử lý obj
						string USERNAME = item.Attributes["username"]?.InnerText;
						string PASS = item.Attributes["password"]?.InnerText;
						string name = item.Attributes["name"]?.InnerText;
						string avatar = item.Attributes["images"]?.InnerText;

						Account account = new Account(USERNAME, PASS, name, avatar);
						return account;

					}
				}
			}
			return null;
		}

	}
}
