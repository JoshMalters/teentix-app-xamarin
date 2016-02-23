using System;

namespace TeenTix.Common.Model
{
	public class LoginRequest
	{
		public string Username { get; set; }
		public string Password { get; set; }

		public LoginRequest ()
		{
		}

		public override string ToString ()
		{
			// TODO: hide password from ToString() result... (thomasvandoren, 2016-02-22)
			return string.Format ("[LoginRequest: Username={0}, Password={1}]", Username, Password);
		}
	}
}

