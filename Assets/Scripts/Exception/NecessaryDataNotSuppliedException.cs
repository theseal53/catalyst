using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class NecessaryDataNotSuppliedException : Exception
{
	public NecessaryDataNotSuppliedException() { }
	public NecessaryDataNotSuppliedException(string message) : base(message) { }
}