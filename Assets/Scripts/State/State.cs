using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class State : IComparable<State>
{

	protected PsycheEnv psycheEnv;

	public State(PsycheEnv psycheEnv)
	{
		this.psycheEnv = psycheEnv;
	}

	public int priority;

	/// <summary>
	/// Because these states are put in a priority queue, they must be able to compare to each other.
	/// This is done using a base priority
	/// </summary>
	/// <param name="other"></param>
	/// <returns></returns>
	public int CompareTo(State other)
	{
		return this.priority.CompareTo(other.priority);
	}

	public abstract void Execute();
}
