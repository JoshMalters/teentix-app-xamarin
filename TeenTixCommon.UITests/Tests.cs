using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

using TeenTix.Common;
using TeenTix.Common.Model;

namespace TeenTix.Common.UITests
{
	// TODO: [TestFixture (Platform.Android)] (thomasvandoren, 2016-02-13)
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);
		}

		[Test]
		public void AppLaunches ()
		{
			app.Screenshot ("First screen.");
		}

		[Test]
		public async void IsEmailAvailable_ShouldBeAvailable() {
			string email = "thomas@NOT-A-REAL-ADDRESS.com";
			bool result = await AccountManager.IsEmailAvailable(email);
			Assert.IsTrue (result);
		}

		[Test]
		public async void IsEmailAvailable_NotAvailable() {
			string email = "info@teentix.org";
			bool result = await AccountManager.IsEmailAvailable (email);
			Assert.IsFalse (result);
		}
	}
}

