using System;

namespace TeenTix.Common
{
	public class TeenTixException : Exception
	{
		public TeenTixException ()
		{
		}

		public TeenTixException(string message) : base(message) {
		}

		public TeenTixException(string message, Exception inner) : base(message, inner) {
		}
	}
}
