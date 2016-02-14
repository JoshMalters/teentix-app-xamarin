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
	}
}

