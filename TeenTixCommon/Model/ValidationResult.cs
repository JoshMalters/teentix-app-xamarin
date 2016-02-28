using System;

namespace TeenTix.Common.Model
{
	public class ValidationResult
	{
		public bool Valid { get; set; }
		public string Message { get; set; }
	
		public ValidationResult ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[AccountValidationResult: Valid={0}, Message={1}]", Valid, Message);
		}

		public static ValidationResult ValidAccount() {
			var result = new ValidationResult();
			result.Valid = true;
			return result;
		}

		public static ValidationResult InvalidAccount(string message) {
			var result = new ValidationResult();
			result.Valid = false;
			result.Message = message;
			return result;
		}
	}
}

