using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using TeenTix.Common.Exceptions;
using TeenTix.Common.Model;

namespace TeenTix.Common
{
	public class AccountManager
	{
		private static string HOST_URL = "http://localhost:9000";

		public AccountManager ()
		{
		}

		public static async Task<bool> IsEmailAvailable(string email) {
			// FIXME: sanitize email address! (thomasvandoren, 2016-02-11)

			var url = new Uri( string.Format (HOST_URL + "/_ajax/email_check/{0}", email));
			HttpClient client = new HttpClient();
			var response = await client.GetAsync (url);

			if (response.IsSuccessStatusCode) {
				var content = await response.Content.ReadAsStringAsync ();

				Debug.WriteLine(string.Format( "Response from {0} is: {1}", url, content));

				string cleanContent = content.Trim ();

				if ("1".Equals (cleanContent)) {
					return false;
				} else if ("0".Equals (cleanContent)) {
					return true;
				} else {
					string message = string.Format ("Unexpected response from check email API {0} call: {1}", url, cleanContent);
					Debug.WriteLine (message);
					throw new ParseResponseException (message);
				}
			} else {
				string message =string.Format( "Unsuccessful reponse from check email API {0} call: {1}", url, response.StatusCode + " " + response.ReasonPhrase);
				throw new UnsuccessfulResponseException (message);
			}
		}

		public static void CreateAccount(Account newAccount) {
			Debug.WriteLine ("Creating new account: {0}", newAccount.ToString ());




		}
	}
}

