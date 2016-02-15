using System;

namespace TeenTix.Common.Model
{
	public class CreateAccountResult
	{
		public bool Success { get; set; }
		public string ErrorMessage { get; set; }
		public Account Account { get; set; }

		public CreateAccountResult ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[CreateAccountResult: success={0}, ErrorMessage={1}, Account={2}]", Success, ErrorMessage, Account);
		}

		public static CreateAccountResult Succeeded(Account account) {
			var result = new CreateAccountResult ();
			result.Success = true;
			result.Account = account;
			return result;
		}

		public static CreateAccountResult Failed(string message) {
			var result = new CreateAccountResult ();
			result.Success = false;
			result.ErrorMessage = message;
			return result;
		}
	}
}

