using System;

using SharpCommander.Internal;

namespace SharpCommander.Attributes
{

	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class OptionAttribute : BaseOptionAttribute
	{		
		public OptionAttribute(char shortName, String longName = null, Boolean required = false, Object defaultValue = null, String helpMessage = null) 
			: base(shortName, longName, required, defaultValue, helpMessage)
		{

		}
	}

}

