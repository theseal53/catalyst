using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class LocationObjective : Objective
{

	Vector3 targetLocation;

	public LocationObjective(PsycheEnv psycheEnv, Vector3 targetLocation) : base(psycheEnv)
	{
		this.targetLocation = targetLocation;
		weightedChancePairs = new List<WeightedChancePair>()
		{
			//new WeightedChancePair(new MovementMotion(psycheEnv, targetLocation), (x)=>{ return 1.0f; } ),
			//new WeightedChancePair(new TeleportMotion(psycheEnv, targetLocation), (x)=>{ return 1.0f; } )
		};
	}

	public override bool IsCompleted()
	{
		if (psycheEnv.gameObject.transform.position == targetLocation)
		{
			return true;
		} else
		{
			return false;
		}
	}
}
