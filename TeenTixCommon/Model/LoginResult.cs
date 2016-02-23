using System;

namespace TeenTix.Common.Model
{
	public class LoginResult
	{
		// TODO: combine *Result classes under common abstract class that has Success and ErrorMessage. (thomasvandoren, 2016-02-22)

		public bool Success { get; set; }
		public string ErrorMessage { get; set; }
		public string Session { get; set; }

		public LoginResult ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[LoginResult: Success={0}, ErrorMessage={1}, Session={2}]", Success, ErrorMessage, Session);
		}

		public static LoginResult Succeeded(string session) {
			var result = new LoginResult ();
			result.Success = true;
			result.Session = session;
			return result;
		}

		public static LoginResult Failed(string message) {
			var result = new LoginResult ();
			result.Success = false;
			result.ErrorMessage = message;
			return result;
		}
	}
}

