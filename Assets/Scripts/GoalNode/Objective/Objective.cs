using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// An objective has a logical statement that must be completed to mark it as done. It also contains a list of goals (subgoals)
/// that can be done to make the objective happen
/// </summary>
public abstract class Objective : GoalNode {

	public Objective(PsycheEnv psycheEnv) : base(psycheEnv)
	{
	}

	/// <summary>
	/// A list of goals that might bring the objective to fruition
	/// </summary>
	public List<WeightedChancePair> weightedChancePairs;

	//The selected node will remain after it has been chosen.
	public Goal selectedSubgoal;

	public WeightedChancePair SelectRandomPair()
	{
		float totalWeight = 0;
		//Find how much each pair weighs
		for (int i = 0; i < weightedChancePairs.Count; ++i)
		{
			totalWeight += weightedChancePairs[i].chanceExpression(psycheEnv);
		}
		if (totalWeight == 0)
		{
			return null;
		}
		//Select a random number
		float randomNumber = Random.Range(0, totalWeight);
		//Iteratively subtract the weights until the random number is greater, then select that pair
		for (int i = 0; i < weightedChancePairs.Count; ++i)
		{
			WeightedChancePair pair = weightedChancePairs[i];
			totalWeight -= pair.chanceExpression(psycheEnv);
			if (totalWeight < randomNumber)
			{
				//Set the instance to have selected this pair
				return weightedChancePairs[i];
			}
		}
		return null;
	}


	/// <summary>
	/// Recursively search to find a motion that can be executed. Will also select an action plan if one has not been selected.
	/// </summary>
	/// <returns></returns>
	/// 
	public override Motion FindMotion()
	{
		if (selectedSubgoal == null)
		{
			WeightedChancePair pair = SelectRandomPair();
			Motion motion = pair.motionReturnExpression();
			return motion;
			//This may also select a subgoal, which will be used in future iterations
		} else
		{
			return selectedSubgoal.FindMotion();
		}
	}

	/// <summary>
	/// Check the logical condition to see if it has been completed
	/// </summary>
	/// <returns></returns>
	public abstract override bool IsCompleted();


}
