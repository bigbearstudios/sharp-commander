using System;
using System.Text;
using System.Reflection;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using SharpCommander.Internal;
using SharpCommander.Attributes;

namespace SharpCommander.Parsers
{
	internal enum ArgumentDetectionType
	{
		None,
		Single,
		Long
	}

	internal class ArgumentPart
	{
		private String toParse;

		internal String ToParse
		{
			get { return this.toParse; }
			set { this.toParse = value; }
		}

		public ArgumentPart(String toParse)
		{
			ToParse = toParse;
		}
	}

	internal class ShortArgumentPart : ArgumentPart
	{
		public ShortArgumentPart(String toParse) : base(toParse)
		{

		}
	}

	internal class LongArgumentPart : ArgumentPart
	{
		public LongArgumentPart(String toParse) : base(toParse)
		{

		}
	}

	internal class ListArgumentPart : ArgumentPart
	{
		public ListArgumentPart(String toParse) : base(toParse)
		{

		}
	}

	public abstract class ArgumentParser
	{
		private Dictionary<char, OptionAttribute> shortAttributes;
		private Dictionary<String, OptionAttribute> longAttributes;
		private List<OptionListAttribute> listAttributes;

		public ArgumentParser()
		{
			
		}

		protected virtual void DisplayHelp(StringBuilder builder)
		{

		}

		private void ParseAttributes()
		{
			PropertyInfo[] properties = this.GetType().GetProperties();

			List<BaseOptionAttribute> optionAttributes = new List<BaseOptionAttribute>();
			foreach(PropertyInfo property in properties)
			{
				BaseOptionAttribute[] attributes = (BaseOptionAttribute[]) property.GetCustomAttributes(typeof(BaseOptionAttribute));
				foreach(BaseOptionAttribute attribute in attributes)
				{
					attribute.Type = property.GetType();
					optionAttributes.Add(attribute);
				}
			}
		}
			
		private Boolean Parse(string[] args)
		{
			ParseAttributes();
			List<ArgumentPart> parsedArguments = ParseArguments(args);

			foreach(ArgumentPart part in parsedArguments)
			{

			}

			return true;
		}

		private void SeparateShortArguments(List<ArgumentPart> arguments, List<BaseOptionAttribute> options)
		{
			//Foreach of the parts we need to attempt to seperate the short Arguments into 
			//Seperate arguments
			foreach(ArgumentPart part in arguments)
			{
				foreach(char parsedArgument in part.ToParse)
				{

				}
			}
		}

		private List<ArgumentPart> ParseArguments(string[] args)
		{
			String joinedArgs = String.Join("", args);
			String trimmed = Regex.Replace(joinedArgs, @"\s+", " ");

			List<ArgumentPart> parts = new List<ArgumentPart>();

			ArgumentDetectionType detectionType = ArgumentDetectionType.None;
			int lastDetectionIndex = 0;

			StringBuilder builder = new StringBuilder();
			for(int i = 0; i < trimmed.Length; ++i)
			{
				char currentCharacter = trimmed[i];

				if(currentCharacter == '-')
				{
					//Here we have found a new delimiter to its time to reset
					//the builder and store the computed value
					if(builder.Length > 0)
					{
						parts.Add(BuildArgumentPart(detectionType, builder));
					}

					/*
					 * We already have a detection type stored in our stringbuilder
					 * Here we need to make sure we aren't looking for a 'long' type
					 */
					if(detectionType == ArgumentDetectionType.Single)
					{
						if(lastDetectionIndex == i - 1)
						{
							//Here we are actually parsing a long type
							detectionType = ArgumentDetectionType.Long;
						}
					}

					detectionType = ArgumentDetectionType.Single;
				}
				else if(i == (trimmed.Length - 1))
				{
					builder.Append(currentCharacter);
					parts.Add(BuildArgumentPart(detectionType, builder));
				}
				else
				{
					builder.Append(currentCharacter);
				}
			}

			return parts;
		}

		private ArgumentPart BuildArgumentPart(ArgumentDetectionType detectionType, StringBuilder builder)
		{
			ArgumentPart part = null;
			if(detectionType == ArgumentDetectionType.None)
			{
				part = new ListArgumentPart(builder.ToString());
			}
			else if(detectionType == ArgumentDetectionType.Single)
			{
				part = new ShortArgumentPart(builder.ToString());
			}
			else if(detectionType == ArgumentDetectionType.Long)
			{
				part = new LongArgumentPart(builder.ToString());
			}

			builder.Clear();

			return part;
		}
			
		public static Boolean Parse<T>(string[] args) where T: ArgumentParser,  new()
		{
			T runner = new T();
			return runner.Parse(args);
		}
	}
}

