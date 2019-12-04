using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiComDemo.Models
{
	public class Account
	{
		public Account(string username, string pass, string name, string avatar)
		{
			this.Username = username;
			this.Password = pass;
			this.Name = name;
			this.Avatar = avatar;
			//this.prognoses = new List<Prognosis>();
		}
		public string Username { get; set; }
		public string Password { get; set; }
		public string Name { get; set; }
		public string Avatar { get; set; }
		//public List<Prognosis> prognoses { get; set; }
	}
}
