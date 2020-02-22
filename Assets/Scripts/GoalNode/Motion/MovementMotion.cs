using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class MovementMotion : Motion
{
	Vector3 targetLocation;

	public MovementMotion(PsycheEnv psycheEnv, Vector3 targetLocation) : base(psycheEnv)
	{
		this.targetLocation = targetLocation;
		
	}

	public override void ExecuteMotion(PsycheEnv psycheEnv)
	{
		psycheEnv.brain.PushState(new WalkToState(psycheEnv));
	}
}
