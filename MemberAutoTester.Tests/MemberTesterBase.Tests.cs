using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemberAutoTester.Tests
{
	[TestFixture()]
	public class MemberTesterBaseTests
	{
		class MemberTesterBaseTestChild: MemberTesterBase{
			public IEnumerable<Type> GetTheTypes(){
				return GetTypes();
			}
		}

		[Test()]
		public void GetTypesFiltersOutIgnoredTypes()
		{
			var tester = new MemberTesterBaseTestChild ();
			tester.AddAssembly (GetType ().Assembly);
			tester.TypesToIgnore = t =>  t == typeof(MemberTesterBaseTests);
			var types = tester.GetTheTypes ();
			Assert.Greater (types.Count(),0);
			Assert.IsFalse (types.Any (t => t == typeof(MemberTesterBaseTests)));
		}
	}
}

