using System;

namespace SharpCommander.Internal
{
	public class BaseOptionAttribute : BaseArgumentAttribute
	{
		protected char shortName = '\0';
		protected String longName = null;
		protected Object defaultValue;

		public char ShortName
		{
			get { return this.shortName; }
			protected set { this.shortName = value; }
		}

		public String LongName
		{
			get { return this.longName; }
			protected set { this.longName = value; }
		}

		public Object DefaultValue
		{
			get { return this.defaultValue; }
			protected set { this.defaultValue = value; }
		}

		public BaseOptionAttribute(char shortName, String longName = null, Boolean required = false, Object defaultValue = null, String helpMessage = null) 
			: base(required, helpMessage)
		{
			ShortName = shortName;
			LongName = longName;
			DefaultValue = defaultValue;
		}

		public BaseOptionAttribute(String longName = null, Boolean required = false, Object defaultValue = null, String helpMessage = null) 
			: base(required, helpMessage)
		{
			ShortName = shortName;
			LongName = longName;
			DefaultValue = defaultValue;
		}
	}
}

