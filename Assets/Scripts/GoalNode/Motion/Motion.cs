using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/// <summary>
/// These are the base endpoints in the goal tree. They are the direct actions that a Brain can take, not just pathways
/// This should generally add stuff to the state machine
/// </summary>
public abstract class Motion
{

	public PsycheEnv psycheEnv;

	public Motion(PsycheEnv psycheEnv)
	{
		this.psycheEnv = psycheEnv;
	}

	public abstract void ExecuteMotion(PsycheEnv psycheEnv);
}
