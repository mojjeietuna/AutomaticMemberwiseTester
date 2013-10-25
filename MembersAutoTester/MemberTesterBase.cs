using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace MemberAutoTester
{
	public abstract class MemberTesterBase
	{
		protected List<Assembly> _assemblies = new List<Assembly>();
		protected List<Type> _types = new List<Type>();

		public Func<Type,bool> TypesToIgnore = t=> false;
		public Func<Type,string,bool> TypeMembersToIgnore = (t,m) => false;

		protected IEnumerable<Type> GetTypes(){
			return _assemblies.SelectMany (a => a.GetTypes ()).Concat (_types).Where (t => !TypesToIgnore(t));
		}
		public void AddAssembly(Assembly a){
			_assemblies.Add (a);
		}
		public void AddType(Type t){
			_types.Add (t);
		}


	}
}

