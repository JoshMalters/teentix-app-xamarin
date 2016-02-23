using System;

namespace TeenTix.Common.Model
{
	public class SignUpResponse
	{
		public Int32 Id { get; set; }
		public string Message { get; set; }
		public bool Success { get; set; }
		public SignUpResponseMetadata Metadata { get; set; }

		public SignUpResponse ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[SignUpResponse: id={0}, message={1}, success={2}, metadata={3}]", Id, Message, Success, Metadata);
		}
	}
}

