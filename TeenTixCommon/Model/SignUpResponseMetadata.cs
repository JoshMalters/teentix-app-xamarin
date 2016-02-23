using System;

namespace TeenTix.Common.Model
{
	public class SignUpResponseMetadata
	{
		public int Id { get; set; }

		public SignUpResponseMetadata ()
		{
		}

		public override string ToString ()
		{
			return string.Format ("[SignUpResponseMetadata: id={0}]", Id);
		}
	}
}

