using System;
using System.Diagnostics;

using TeenTix.Common.Model;

namespace TeenTix.Common
{
	public class AccountManager
	{
		public AccountManager ()
		{
		}

		public static void CreateAccount(Account newAccount) {
			Debug.WriteLine ("Creating new account: {0}", newAccount.ToString ());
		}
	}
}

