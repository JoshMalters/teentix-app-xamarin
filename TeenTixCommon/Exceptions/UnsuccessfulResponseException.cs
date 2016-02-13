using System;

namespace TeenTix.Common.Exceptions
{
	public class UnsuccessfulResponseException : Exception
	{
		public UnsuccessfulResponseException ()
		{
		}

		public UnsuccessfulResponseException(string message) : base (message) {
		}

		public UnsuccessfulResponseException(string message, Exception inner) : base(message, inner) {
		}
	}
}

