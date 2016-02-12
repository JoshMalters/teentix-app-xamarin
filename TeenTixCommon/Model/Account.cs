using System;

namespace TeenTix.Common.Model
{
	public class Account
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string BirthDate { get; set; }
		public string Email { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }

		public Account ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[Account: FirstName={0}, LastName={1}, BirthDate={2}, Email={3}, Username={4}, Password={5}]", FirstName, LastName, BirthDate, Email, Username, Password);
		}
	}
}

