using System;

namespace Sample
{
	public class MyClass: ICloneable
	{
		public string Prop1{ get; set;}
		public int Prop2 { get; set;}

		public byte SkipThisProperty{ get; set;}

		public MyClass ()
		{
		}

		#region ICloneable implementation

		public object Clone ()
		{
			return new MyClass { Prop1 = this.Prop1, Prop2 = this.Prop2 };
		}

		#endregion
	}
}

