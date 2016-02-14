using System;

namespace TeenTix.Common.Model
{
	public class SignUpAccount
	{
		public string Email { get; set; }
		public string ScreenName { get; set; }
		public string Password { get; set; }
		public bool AgreedToTOS { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string BirthDate { get; set; }

		public SignUpAccount ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[SignUpAccount: Email={0}, ScreenName={1}, Password={2}, AgreedToTOS={3}, FirstName={4}, LastName={5}, BirthDate={6}]",
				Email, ScreenName, Password, AgreedToTOS, FirstName, LastName, BirthDate);
		}
	}
}

