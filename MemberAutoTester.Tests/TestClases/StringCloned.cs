using System;

namespace MemberAutoTester.Tests
{
	public class StringCloned:ICloneable
	{
		public string Name{ get; set;}
	

		#region ICloneable implementation

		public object Clone ()
		{
			return new StringCloned () { Name = this.Name };
		}

		#endregion
	}
	public class StringNotCloned:ICloneable
	{
		public string Name{ get; set;}
	

		#region ICloneable implementation

		public object Clone ()
		{
			return new StringNotCloned ();
		}

		#endregion
	}
	public class StringCloneWrongType:ICloneable
	{
		public string Name{ get; set;}


		#region ICloneable implementation

		public object Clone ()
		{
			return new StringCloned ();
		}

		#endregion
	}
}

