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
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string BirthDate { get; set; }
		public bool AgreedToTOS { get; set; }

		public Account ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[Account: Id={0}, Email={1}, Username={2}, ScreenName={3}, Password={4}, FirstName={5}, LastName={6}, BirthDate={7}, AgreedToTOS={8}]",
				Id, Email, Username, ScreenName, Password, FirstName, LastName, BirthDate, AgreedToTOS);
		}
	}
}

