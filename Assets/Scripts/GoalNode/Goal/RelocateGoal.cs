using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class RelocateGoal : Goal
{

	Objective locationObjective;

	Vector3 targetLocation;

	public RelocateGoal(PsycheEnv psycheEnv, Vector3 targetLocation) : base(psycheEnv)
	{
		this.targetLocation = targetLocation;
		subGoals = new List<GoalNode>()
		{
			new LocationObjective(psycheEnv, targetLocation)
		};
	}

}
