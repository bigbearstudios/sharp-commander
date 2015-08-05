using System;
using System.Collections.Generic;

using SharpTest;
using SharpTest.Exceptions;

using SharpCommander.Parsers;
using SharpCommander.Attributes;

namespace Tests
{
	public class Options : ArgumentParser
	{
		[OptionAttribute('f', "filename")]
		public String Filename { get; set; }
	}

	public class SingleArgumentTest : TestSuite
	{
		public void ShortArgumentWithoutSpace()
		{
			Options.Parse<Options>(new string[]{"-fsomething.png"});
		}

		public void ShortArgumentWithSpace()
		{
			Options.Parse<Options>(new string[]{"-f", "something.png"});
		}

		public void ShortArgumentWithEquals()
		{
			Options.Parse<Options>(new string[]{"-f=something.png"});
		}

		public void LongArgumentWithoutSpace()
		{
			Options.Parse<Options>(new string[]{"--filenamesomething.png"});
		}

		public void LongArgumentWithSpace()
		{
			Options.Parse<Options>(new string[]{"--filename", "something.png"});
		}

		public void LongArgumentWithEquals()
		{
			Options.Parse<Options>(new string[]{"--filename=something.png"});
		}
	}
}

