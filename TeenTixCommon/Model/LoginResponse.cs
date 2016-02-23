using System;
using System.Collections.Generic;

namespace TeenTix.Common.Model
{
	public class LoginResponse
	{
		public List<LoginResponseData> Data { get; set; }
		public string Message { get; set; }
		public bool Success { get; set; }

		public LoginResponse ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[LoginResponse: Data={0}, Message={1}, Success={2}]", Data, Message, Success);
		}
	}
}

