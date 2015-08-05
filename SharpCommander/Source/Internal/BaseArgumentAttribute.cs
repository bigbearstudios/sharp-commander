using System;

namespace SharpCommander.Internal
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class BaseArgumentAttribute : Attribute
	{
		protected Boolean fulfilled = false;
		protected Boolean required = false;
		protected String helpMessage = null;

		private Type type = null;

		public Boolean Required
		{
			get { return this.required; }
			protected set { this.required = value; }
		}

		public String HelpMessage
		{
			get { return this.helpMessage; }
			protected set { this.helpMessage = value; }
		}

		internal Type Type
		{
			get { return this.type; }
			set { this.type = value; }
		}

		public Boolean Fulfilled
		{
			get { return this.fulfilled; }
		}

		public BaseArgumentAttribute(Boolean required, String helpMessage)
		{
			Required = required;
			HelpMessage = helpMessage;
		}

		public virtual void AttemptToFulfill()
		{

		}
	}
}

