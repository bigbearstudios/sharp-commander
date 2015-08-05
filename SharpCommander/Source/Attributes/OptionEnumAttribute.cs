using System;

using SharpCommander.Internal;

namespace SharpCommander.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class OptionEnumAttribute : BaseOptionAttribute
	{
		
		public OptionEnumAttribute()
		{
			
		}
	}
}

