using System;

namespace TeenTix.Common.Model
{
	public class Account
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string ScreenName { get; set; }
		public string Password { get; set; }
		public bool AgreedToTOS { get; set; }

		public Account ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[Account: Id={0}, Email={1}, Username={2}, ScreenName={3}, Password={4}, AgreedToTOS={5}]",
				Id, Email, Username, ScreenName, Password, AgreedToTOS);
		}
	}
}

