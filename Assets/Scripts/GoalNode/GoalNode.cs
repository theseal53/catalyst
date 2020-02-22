using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class GoalNode
{

	public PsycheEnv psycheEnv;

	public GoalNode(PsycheEnv psycheEnv)
	{
		this.psycheEnv = psycheEnv;
	}

	/// <summary>
	/// Used to determine if a goal or objective is complete. A motion will always return as complete
	/// </summary>
	/// <returns></returns>
	public abstract bool IsCompleted();

	/// <summary>
	/// Do a tree search to find a motion, which should put a state on the tree.
	/// </summary>
	/// <returns></returns>
	public abstract Motion FindMotion();

	/// <summary>
	/// Sometimes, an objective need prior information to accomplish its task outside of a psycheEnv.
	/// </summary>
	/// <returns></returns>
	public virtual bool HasNecessaryData()
	{
		return true;
	}

	/// <summary>
	/// If it's found that the current objective does not have all of its data, it should be provided here (probably from past objectives)
	/// </summary>
	public virtual void ProvideNecessaryData()
	{
		//If there are any subgoals that need specific data, provide them here
	}


}
