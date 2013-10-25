using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace MemberAutoTester
{
	public class CloneTester: MemberTesterBase
	{
		public bool Run ()
		{
			var sw = new System.Diagnostics.Stopwatch ();
			sw.Start ();

			var typesTested = doRun ();

			if (typesTested == 0) {
				Assert.Greater(typesTested,0,"No types implementing IClonable found");
			}
			Console.WriteLine (typesTested + " types tested in " + sw.Elapsed);
			return true;
		}

		private int doRun ()
		{
			int typesTested = 0;
			var types = GetTypes ().Where (t => typeof(ICloneable).IsAssignableFrom (t));

			foreach (var t in types) {
				typesTested++;
				ICloneable o = (ICloneable)CreateInstance (t);
				SetMembers (o, t);
				object clone = o.Clone ();
				CompareMembers (o, clone);
			}
			return typesTested;
		}

		private static void SetMembers (object o, Type t)
		{
			foreach (var p in GetProperties (t)) {
				object newValue = CreateSomeValue (p.PropertyType);
				p.SetValue (o, newValue, null);
			}
		}
		private static PropertyInfo[] GetProperties (Type t)
		{
			return t.GetProperties (BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty | BindingFlags.GetProperty);
		}

		private static object CreateSomeValue(Type t){
			if (t == typeof(string))
				return "t";
			if (t == typeof(bool))
				return true;
			if (typeof(IConvertible).IsAssignableFrom (t)) {
				return (byte)1;
			}
			if (typeof(ICloneable).IsAssignableFrom (t)) {
				var newValue = CreateInstance (t);
				SetMembers (newValue, t); //Recursive call
				return newValue;
			}
				
			throw new NotImplementedException ("Need to create some value for " + t.Name);
		}
		private static object CreateInstance (Type t)
		{
			foreach (var constructor in t.GetConstructors()) {
				var parameters = constructor.GetParameters ();
				return constructor.Invoke(parameters.Select(p=> CreateSomeValue(p.ParameterType)).ToArray());
			}
			throw new NotImplementedException ("Dont know how to instanciate type " + t.Name);
		}

		void CompareMembers (object original, object clone)
		{
			Type t = original.GetType ();
			Assert.AreEqual (t, clone.GetType ());

			foreach (var p in GetProperties(t).Where(pr=>!TypeMembersToIgnore(t,pr.Name))) {

				var newValue = p.GetValue (clone,null);

				var originalValue = p.GetValue (original,null);
				var msg = t.Name + "." + p.Name;

				if (typeof(IComparable).IsAssignableFrom (p.PropertyType)) {
					var oc = originalValue as IComparable;
					Assert.AreEqual (0, oc.CompareTo (newValue), "CompareTo for" + msg);
					continue;
				}

				if (p.PropertyType.IsClass) {
						Assert.IsNotNull (newValue,msg);
						continue;
				} 

				Assert.AreEqual (originalValue, newValue, msg);			

			}
		}
	}
}

