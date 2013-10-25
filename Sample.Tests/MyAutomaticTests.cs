using NUnit.Framework;
using System;

namespace Sample.Tests
{
	[TestFixture ]
	public class MyAutomaticTests
	{
		[Test]
		public void CheckClonning ()
		{
			var tester = new MemberAutoTester.CloneTester ();
			tester.TypeMembersToIgnore = ShouldIgnore;
			tester.AddAssembly (typeof(MyClass).Assembly);
			tester.Run ();
		}

		bool ShouldIgnore(Type t, string member)
		{
			if (t == typeof(MyClass) && member == "SkipThisProperty") {
				return true;
			}
			return false;
		}
	}
}

