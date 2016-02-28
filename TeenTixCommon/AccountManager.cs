using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using TeenTix.Common.Exceptions;
using TeenTix.Common.Model;
using TeenTix.Common.Util;

namespace TeenTix.Common
{
	public class AccountManager
	{
		private static string HOST_URL = "http://localhost:9000";

		// New accounts are assigned to group 4, which is "Pending email verification".
		private static string DEFAULT_SIGN_UP_GROUP = "4";

		private static int MINIMUM_PASSWORD_LENGTH = 5;

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

		private static bool StringIsValid(string s) {
			return !string.IsNullOrWhiteSpace (s);
		}

		public static AccountValidationResult ValidateAccount(SignUpAccount newAccount) {
			// Discount account validate in here. Will need to make it more robust in future.

			List<String> invalidThings = new List<string> ();

			if (!StringIsValid(newAccount.ScreenName)) {
				invalidThings.Add ("enter valid username");
			}

			if (!StringIsValid(newAccount.Email)) {
				invalidThings.Add ("enter valid email");
			}

			if (!StringIsValid(newAccount.Password) || newAccount.Password.Length < MINIMUM_PASSWORD_LENGTH) {
				invalidThings.Add ("password must be " + MINIMUM_PASSWORD_LENGTH + " or more characters");
			}

			if (invalidThings.Count == 0) {
				return AccountValidationResult.ValidAccount ();
			} else {
				string msg = string.Join (", ", invalidThings);
				return AccountValidationResult.InvalidAccount (msg);
			}
		}

		public static async Task<CreateAccountResult> CreateAccount(SignUpAccount newAccount) {
			Debug.WriteLine ("Creating new account: {0}", newAccount.ToString ());

			if (!newAccount.AgreedToTOS) {
				return CreateAccountResult.Failed("TOS must be agreed to before creating account!");
			}

			// FIXME: validate fields of newAccount! (thomasvandoren, 2016-02-22)

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
			var optionalResponse = ParseJson<SignUpResponse> (responseBody);
			if (!optionalResponse.isPresent ()) {
				return CreateAccountResult.Failed (string.Format("Failed to parse create account JSON response body: {0}", responseBody));
			}
			var response = optionalResponse.get ();
			Debug.WriteLine ("Create account response: {0}", response);

			if (!response.Success) {
				Debug.WriteLine ("Account creation failed with message: {0}", response.Message);
				return CreateAccountResult.Failed (response.Message);
			}

			var account = new Account ();
			account.Id = response.Id;
			account.Email = newAccount.Email;
			account.Username = newAccount.Email;
			account.ScreenName = newAccount.ScreenName;
			account.AgreedToTOS = newAccount.AgreedToTOS;
			account.Password = newAccount.Password;

			return CreateAccountResult.Succeeded (account);
		}

		public static async Task<LoginResult> Login(LoginRequest loginRequest) {
			Debug.WriteLine ("Logging in user: {0}", loginRequest);

			// FIXME: check that both fields are set and valid. (thomasvandoren, 2016-02-22)

			var qs = QueryString (
				QueryParam("data[username]", loginRequest.Username),
				QueryParam("data[password]", loginRequest.Password),
				QueryParam("data[new_session]", "yes")
			);

			var url = GetUrl ("/webservice/rest/authenticate_username" + qs);

			string responseBody = await GetRequest (url);

			var optionalResponse = ParseJson<LoginResponse> (responseBody);
			if (!optionalResponse.isPresent ()) {
				return LoginResult.Failed (string.Format("Failed to parse Login JSON response body: {0}", responseBody));
			}
			var response = optionalResponse.get ();
			Debug.WriteLine ("Login response: {0}", response);

			if (!response.Success) {
				Debug.WriteLine ("Login failed with message: {0}", response.Message);
				return LoginResult.Failed (response.Message);
			}

			if (response.Data.Count < 1) {
				return LoginResult.Failed ("Login response did not contain anything in data field.");
			}

			return LoginResult.Succeeded (response.Data [0].SessionId);
		}

		private static Optional<T> ParseJson<T>(string responseBody) {
			try {
				return Optional<T>.ofNullable(JsonConvert.DeserializeObject<T> (responseBody));
			} catch (JsonReaderException e) {
				Debug.WriteLine ("Failed to parse JSON response body as LoginResponse error: {0} body: {1}", e.Message, responseBody);
				return Optional<T>.empty ();
			}
		}

		private static string QueryParam(string key, string value) {
			return string.Format ("{0}={1}", WebUtility.UrlEncode(key), WebUtility.UrlEncode(value));
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
	