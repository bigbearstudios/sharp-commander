using System;

using SharpCommander.Internal;

namespace SharpCommander.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class OptionListAttribute : BaseOptionAttribute
	{
		private char separator = ' ';

		public char Separator
		{
			get { return this.separator; }
		}

		public OptionListAttribute(char shortName, String longName = null, char separator = ' ', Boolean required = false, Object defaultValue = null, String helpMessage = null) 
			: base(shortName, longName, required, defaultValue, helpMessage)
		{
			this.separator = separator;
		}
	}
}

