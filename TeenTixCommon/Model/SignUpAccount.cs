using System;

namespace TeenTix.Common.Model
{
	public class SignUpAccount
	{
		public string Email { get; set; }
		public string ScreenName { get; set; }
		public string Password { get; set; }
		public bool AgreedToTOS { get; set; }

		public SignUpAccount ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[SignUpAccount: Email={0}, ScreenName={1}, Password={2}, AgreedToTOS={3}",
				Email, ScreenName, Password, AgreedToTOS);
		}
	}
}

