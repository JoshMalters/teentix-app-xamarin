using System;

using Newtonsoft.Json;

namespace TeenTix.Common.Model
{
	public class LoginResponseData
	{
		[JsonProperty("member_id")]
		public string MemberId { get; set; }
		[JsonProperty("session_id")]
		public string SessionId { get; set; }

		public LoginResponseData ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[LoginResponseData: MemberId={0}, SessionId={1}]", MemberId, SessionId);
		}
	}
}

