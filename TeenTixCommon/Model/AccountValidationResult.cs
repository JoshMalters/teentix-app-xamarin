using System;

namespace TeenTix.Common.Model
{
	public class AccountValidationResult
	{
		public bool Valid { get; set; }
		public string Message { get; set; }
	
		public AccountValidationResult ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[AccountValidationResult: Valid={0}, Message={1}]", Valid, Message);
		}

		public static AccountValidationResult ValidAccount() {
			var result = new AccountValidationResult();
			result.Valid = true;
			return result;
		}

		public static AccountValidationResult InvalidAccount(string message) {
			var result = new AccountValidationResult();
			result.Valid = false;
			result.Message = message;
			return result;
		}
	}
}

