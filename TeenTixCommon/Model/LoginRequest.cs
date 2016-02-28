using System;

namespace TeenTix.Common.Model
{
	public class LoginRequest
	{
		public string Email { get; set; }
		public string Password { get; set; }

		public LoginRequest ()
		{
		}

		public override string ToString ()
		{
			// TODO: hide password from ToString() result... (thomasvandoren, 2016-02-22)
			return string.Format ("[LoginRequest: Email={0}, Password={1}]", Email, Password);
		}
	}
}

