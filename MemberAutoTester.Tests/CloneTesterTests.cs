using NUnit.Framework;
using System;

namespace MemberAutoTester.Tests
{
	[TestFixture ()]
	public class CloneTesterTests
	{
		private CloneTester _tester;

		[SetUp]
		public void SetUp()
		{
			_tester = new CloneTester ();
		}
		[Test, ExpectedException(ExceptionType = typeof(AssertionException))]
		public void RunSucceedsWhenNoTypes ()
		{
			_tester.Run ();
		}

		[Test]
		public void RunSucceedsWhenStringCloned ()
		{
			_tester.AddType (typeof(StringCloned));
			Assert.IsTrue (_tester.Run ());
		}
		[Test, ExpectedException(ExceptionType = typeof(AssertionException))]
		public void RunFailsWhenStringNotCloned ()
		{
			_tester.AddType (typeof(StringNotCloned));
			_tester.Run ();
		}
		[Test, ExpectedException(ExceptionType = typeof(AssertionException))]
		public void RunFailsWhenNotSameType ()
		{
			_tester.AddType (typeof(StringCloneWrongType));
			_tester.Run ();
		}
		[Test]
		public void RunSucceedsWhenIntCloned ()
		{
			_tester.AddType (typeof(IntCloned));
			Assert.IsTrue (_tester.Run ());
		}
		[Test, ExpectedException(ExceptionType = typeof(AssertionException))]
		public void RunFailsWhenIntNotCloned ()
		{
			_tester.AddType (typeof(IntNotCloned));
			_tester.Run ();
		}
		[Test]
		public void RunSucceedsWhenClassCloned ()
		{
			_tester.AddType (typeof(ClassCloned));
			Assert.IsTrue (_tester.Run ());
		}

		[Test, ExpectedException(ExceptionType = typeof(AssertionException))]
		public void RunFailsWhenClassNotCloned ()
		{
			_tester.AddType (typeof(ClassNotCloned));
			_tester.Run ();
		}
		[Test]
		public void RunSucceedsWhenClassWithoutDefaultConstructorCloned ()
		{
			_tester.AddType (typeof(ClassWithoutDefaultConstructor));
			Assert.IsTrue (_tester.Run ());
		}

		[Test()]
		public void RunFiltersOutIgnoredMembers()
		{
			_tester.TypeMembersToIgnore = (t,m) => t==typeof(IntNotCloned) && m=="Val";
			_tester.AddType (typeof(IntNotCloned));
			_tester.AddType (typeof(IntCloned));
			Assert.IsTrue (_tester.Run());
		}
	}
}
