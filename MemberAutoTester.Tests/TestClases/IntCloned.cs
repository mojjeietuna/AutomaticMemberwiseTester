using System;

namespace MemberAutoTester.Tests
{
	public class IntCloned:ICloneable
	{
		public int Val{ get; set;}

		#region ICloneable implementation

		public object Clone ()
		{
			return new IntCloned () { Val = this.Val };
		}

		#endregion
	}
	public class IntNotCloned:ICloneable
	{
		public int Val{ get; set;}


		#region ICloneable implementation

		public object Clone ()
		{
			return new IntNotCloned () ;
		}

		#endregion
	}
}

