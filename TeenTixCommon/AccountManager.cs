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

		public static async Task<bool> IsUsernameAvailable(string username) {
			// FIXME: sanitize username! (thomasvandoren, 2016-02-13)

			var url = getUri ("/_ajax/screen_name_check/" + username);
			var content = await GetRequest (url);
			return CheckTrueFalseResult (content, url);
		}

		public static async Task<bool> IsEmailAvailable(string email) {
			// FIXME: sanitize email address! (thomasvandoren, 2016-02-11)

			var url = getUri("/_ajax/email_check/" + email);
			var content = await GetRequest (url);
			return CheckTrueFalseResult (content, url);
		}

		public static void CreateAccount(Account newAccount) {
			Debug.WriteLine ("Creating new account: {0}", newAccount.ToString ());




		}

		private static Uri getUri(string path) {
			return new Uri( string.Format (HOST_URL + path));
		}

		private static async Task<string> GetRequest(Uri url) {
			var client = new HttpClient ();
			var response = await client.GetAsync (url);

			if (response.IsSuccessStatusCode) {
				var content = await response.Content.ReadAsStringAsync ();

				Debug.WriteLine(string.Format( "Response from {0} is: {1}", url, content));

				return content;
			} else {
				string message =string.Format( "Unsuccessful reponse from check email API {0} call: {1}", url, response.StatusCode + " " + response.ReasonPhrase);
				throw new UnsuccessfulResponseException (message);
			}
		}

		private static bool CheckTrueFalseResult(string responseContent, Uri url) {
			string cleanContent = responseContent.Trim ();

			if ("1".Equals (cleanContent)) {
				return false;
			} else if ("0".Equals (cleanContent)) {
				return true;
			} else {
				string message = string.Format ("Unexpected response from check email API {0} call: {1}", url, responseContent);
				Debug.WriteLine (message);
				throw new ParseResponseException (message);
			}
		}

	}
}

