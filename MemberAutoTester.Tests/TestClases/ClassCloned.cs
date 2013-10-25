using System;

namespace MemberAutoTester.Tests
{
	public class ClassCloned: ICloneable
	{
		public IntCloned Prop{ get; set;}

		#region ICloneable implementation

		public object Clone ()
		{
			return new ClassCloned { Prop = Prop.Clone() as IntCloned };
		}

		#endregion
	}
	public class ClassNotCloned: ICloneable
	{
		public IntCloned Prop{ get; set;}

		#region ICloneable implementation

		public object Clone ()
		{
			return new ClassCloned ();
		}

		#endregion
	}
	public class ClassWithoutDefaultConstructor: ICloneable
	{
		public bool Works{ get; set;}
		public ClassWithoutDefaultConstructor(string s, IntCloned i, byte b){}

		#region ICloneable implementation
		public object Clone ()
		{
			return new ClassWithoutDefaultConstructor (null, null, 1) { Works = this.Works };
		}
		#endregion
	}
}

