using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ApproachAndPickupMotion : Motion
{
	Toteable targetObject;

	public ApproachAndPickupMotion(PsycheEnv psycheEnv, Toteable targetObject) : base(psycheEnv)
	{
		this.targetObject = targetObject;
	}

	public override void ExecuteMotion(PsycheEnv psycheEnv)
	{
		psycheEnv.brain.PushState(new ApproachAndPickupState(psycheEnv, targetObject));
	}
}
