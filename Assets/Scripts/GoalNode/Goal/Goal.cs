using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A goal sits at the root of the tree. Goals have a list of objectives that must be achieved to complete the goal. 
/// Goals can also be subgoals; They will be contained within objectives
/// </summary>
public abstract class Goal : GoalNode {

	public Goal(PsycheEnv psycheEnv) : base(psycheEnv)
	{
	}

	/// <summary>
	/// The motivation to complete this goal. It ranges from 0 to 100
	/// </summary>
	public float motivation;

	/// <summary>
	/// The objectives that must be completed to complete this goal
	/// </summary>
	public List<GoalNode> subGoals;

	public int targetObjectiveIndex;
	public GoalNode targetSubgoal;

	/// <summary>
	/// Recursively find a motion that can be executed
	/// </summary>
	/// <returns></returns>

	public override Motion FindMotion()
	{
		for (int i = targetObjectiveIndex; i < subGoals.Count; ++i)
		{
			if (!subGoals[i].IsCompleted())
			{
				targetSubgoal = subGoals[i];
				targetObjectiveIndex = i;
				break;
			}
		}

		if (targetSubgoal == null)
		{
			return null;
		}
		else
		{
			if (!targetSubgoal.HasNecessaryData())
			{
				ProvideNecessaryData();
			}
			return targetSubgoal.FindMotion();
		}
	}

	/// <summary>
	/// Checks all of the objectives to see if completed
	/// </summary>
	/// <returns></returns>
	public override bool IsCompleted()
	{
		foreach (Objective objective in subGoals)
		{
			if (!objective.IsCompleted())
			{
				return false;
			}
		}
		return true;
	}

}
