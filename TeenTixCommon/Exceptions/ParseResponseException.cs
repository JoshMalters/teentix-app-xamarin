using System;

namespace TeenTix.Common.Exceptions
{
	public class ParseResponseException : Exception
	{
		public ParseResponseException ()
		{
		}

		public ParseResponseException(string message) : base(message) {
		}

		public ParseResponseException(string message, Exception inner) : base(message, inner) {
		}
	}
}

