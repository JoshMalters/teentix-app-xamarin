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

		// New accounts are assigned to group 4, which is "Pending email verification".
		private static string DEFAULT_SIGN_UP_GROUP = "4";

		public AccountManager ()
		{
		}

		public static async Task<bool> IsUsernameAvailable(string username) {
			// FIXME: sanitize username! (thomasvandoren, 2016-02-13)

			var url = GetUrl ("/_ajax/screen_name_check/" + username);
			var content = await GetRequest (url);
			return CheckTrueFalseResult (content, url);
		}

		public static async Task<bool> IsEmailAvailable(string email) {
			// FIXME: sanitize email address! (thomasvandoren, 2016-02-11)

			var url = GetUrl("/_ajax/email_check/" + email);
			var content = await GetRequest (url);
			return CheckTrueFalseResult (content, url);
		}

		public static async Task<Account> CreateAccount(SignUpAccount newAccount) {
			Debug.WriteLine ("Creating new account: {0}", newAccount.ToString ());

			if (!newAccount.AgreedToTOS) {
				throw new DidNotAgreeToTOSException ("TOS must be agreed to before creating account!");
			}

			var qs = QueryString (
				QueryParam ("auth[api_key]", "28de9268-245b-4a75-8615-d4787c7d6b02"),
				QueryParam ("data[username]", newAccount.Email),
				QueryParam ("data[email]", newAccount.Email),
				QueryParam ("data[screen_name]", newAccount.ScreenName),
				QueryParam ("data[password]", newAccount.Password),
				QueryParam ("data[group_id]", DEFAULT_SIGN_UP_GROUP)
			);

			var url = GetUrl ("/webservice/rest/create_member" + qs);

			string responseBody = await GetRequest (url);

			var response = JsonConvert.DeserializeObject<SignUpResponse> (responseBody);
			Debug.WriteLine ("Create account response: {0}", response);

			var account = new Account ();
			account.Id = response.Id;
			account.Email = newAccount.Email;
			account.Username = newAccount.Email;
			account.ScreenName = newAccount.ScreenName;
			account.FirstName = newAccount.FirstName;
			account.LastName = newAccount.LastName;
			account.BirthDate = newAccount.BirthDate;
			account.AgreedToTOS = newAccount.AgreedToTOS;

			return account;
		}

		private static string QueryParam(string key, string value) {
			// TODO: urlencode keys and values! (thomasvandoren, 2016-02-13)
			return string.Format ("{0}={1}", key, value);
		}

		private static string QueryString(params string[] paramList) {
			return "?" + string.Join ("&", paramList);
		}

		private static Uri GetUrl(string path) {
			return new Uri (HOST_URL + path);
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

