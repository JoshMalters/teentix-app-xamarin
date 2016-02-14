using System;

namespace TeenTix.Common.Exceptions
{
	public class DidNotAgreeToTOSException : Exception
	{
		public DidNotAgreeToTOSException ()
		{
		}

		public DidNotAgreeToTOSException(string message) : base(message) {
		}

		public DidNotAgreeToTOSException(string message, Exception inner) : base(message, inner) {
		}
	}
}

