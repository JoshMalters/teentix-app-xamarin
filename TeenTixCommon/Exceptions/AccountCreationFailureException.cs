using System;

namespace TeenTix.Common.Exceptions
{
	public class AccountCreationFailureException :Exception
	{
		public AccountCreationFailureException ()
		{
		}

		public AccountCreationFailureException(string message) :base(message) {
		}

		public AccountCreationFailureException(string message, Exception inner) : base(message, inner) {
		}
	}
}

