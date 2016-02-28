using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

using FluentAssertions;

using TeenTix.Common;
using TeenTix.Common.Exceptions;
using TeenTix.Common.Model;

namespace TeenTix.Common.UITests
{
	// TODO: [TestFixture (Platform.Android)] (thomasvandoren, 2016-02-13)
	[TestFixture (Platform.iOS)]
	public class AccountManagerTests
	{
		private static Random RANDOM = new Random();

		Platform platform;

		public AccountManagerTests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			AppInitializer.StartApp (platform);
		}

		[Test]
		public async void IsEmailAvailable_ShouldBeAvailable() {
			string email = "thomas@NOT-A-REAL-ADDRESS.com";
			bool result = await AccountManager.IsEmailAvailable(email);
			result.Should ().BeTrue ();
		}

		[Test]
		public async void IsEmailAvailable_NotAvailable() {
			string email = "info@teentix.org";
			bool result = await AccountManager.IsEmailAvailable (email);
			result.Should ().BeFalse ();
		}

		[Test]
		public async void IsUsernameAvailable_ShouldBeAvailable() {
			string username = "thomas" + Guid.NewGuid ().ToString ();
			bool result = await AccountManager.IsUsernameAvailable (username);
			result.Should ().BeTrue ();
		}

		[Test]
		public async void IsUsernameAvailable_NotAvailable() {
			string username = "teentix";
			bool result = await AccountManager.IsUsernameAvailable (username);
			result.Should ().BeFalse ();
		}

		[Test]
		public async void CreateAccount() {
			var signUpAccount = GetAccount ("test-" + RandomInt());
			var createdAccount = await AccountManager.CreateAccount (signUpAccount);

			Console.WriteLine ("Created account: {0}", createdAccount);
			createdAccount.Success.Should ().BeTrue ();
			CheckAccount (createdAccount.Account, signUpAccount);
		}

		[Test]
		public async void CreateAccount_ScreenNameTooLong() {
			var signUpAccount = GetAccount ("test-" + Guid.NewGuid().ToString() + Guid.NewGuid().ToString());
			var createdAccount = await AccountManager.CreateAccount(signUpAccount);
			createdAccount.Success.Should ().BeFalse ();
			createdAccount.Account.Should ().BeNull ();
		}

		[Test]
		public async void CreateAccount_PasswordTooLong() {
			var signUpAccount = GetAccount ("test-" + RandomInt ());
			signUpAccount.Password = "0123456789012345678901234567890123456789012345678901234567890123456789";
			var createdAccount = await AccountManager.CreateAccount (signUpAccount);
			createdAccount.Success.Should ().BeFalse ();
			createdAccount.Account.Should ().BeNull ();
		}

		[Test]
		public async void CreateAccount_DidNotAgreeToTOS() {
			var signUpAccount = GetAccount ("test-" + RandomInt ());
			signUpAccount.AgreedToTOS = false;
			var createdAccount = await AccountManager.CreateAccount(signUpAccount);
			createdAccount.Success.Should ().BeFalse ();
			createdAccount.Account.Should ().BeNull ();
		}

		[Test]
		public async void Login() {
			var loginRequest = new LoginRequest ();
			loginRequest.Email = "thomas.vandoren+tester123@gmail.com";
			loginRequest.Password = "000000";
			var result = await AccountManager.Login (loginRequest);

			result.Success.Should ().BeTrue ();
			result.Session.Should ().NotBeNullOrWhiteSpace ();
		}

		[Test]
		public async void Login_BadEmail() {
			var loginRequest = new LoginRequest ();
			loginRequest.Email = "test-" + RandomInt () + "@fake-email-address-here.com";
			loginRequest.Password = "000000";
			var result = await AccountManager.Login (loginRequest);

			result.Success.Should ().BeFalse ();
			result.Session.Should ().BeNull ();
		}

		[Test]
		public async void Login_BadPassword() {
			var loginRequest = new LoginRequest ();
			loginRequest.Email = "thomas.vandoren+tester123@gmail.com";
			loginRequest.Password = Guid.NewGuid ().ToString ();
			var result = await AccountManager.Login (loginRequest);

			result.Success.Should ().BeFalse ();
			result.Session.Should ().BeNull ();
		}

		private static async Task<Account> CreateAccount(string screenName) {
			var a = GetAccount (screenName);
			var result = await AccountManager.CreateAccount(a);
			result.Success.Should ().BeTrue ();
			return result.Account;
		}

		private static SignUpAccount GetAccount(string screenName) {
			var a = new SignUpAccount();
			a.ScreenName = screenName;
			a.Email = a.ScreenName + "@THIS-IS-A-FAKE-EMAIL.com";
			a.Password = "000000";
			a.AgreedToTOS = true;
			return a;
		}

		private static void CheckAccount(Account actualAccount, SignUpAccount originalAccount) {
			actualAccount.Id.Should ().BeGreaterOrEqualTo (1);
			actualAccount.Email.ShouldBeEquivalentTo (originalAccount.Email);
			actualAccount.Username.ShouldBeEquivalentTo (originalAccount.Email);
			actualAccount.ScreenName.ShouldBeEquivalentTo (originalAccount.ScreenName);
			actualAccount.Password.ShouldBeEquivalentTo (originalAccount.Password);
		}

		private static int RandomInt() {
			return RANDOM.Next (-1000000000, 1000000000);
		}
	}
}

