using System;

using SharpCommander.Internal;

namespace SharpCommander.Attributes
{
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public class ListAttribute : BaseArgumentAttribute
	{
		public ListAttribute(Boolean required = false, String helpMessage = null) 
			: base(required, helpMessage)
		{

		}
	}
}

