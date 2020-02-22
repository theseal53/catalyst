using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ApproachAndRobMotion : Motion
{
	Toteable targetObject;

	public ApproachAndRobMotion(PsycheEnv psycheEnv, Toteable targetObject) : base(psycheEnv)
	{
		this.targetObject = targetObject;
	}

	public override void ExecuteMotion(PsycheEnv psycheEnv)
	{
		psycheEnv.brain.PushState(new ApproachAndRobState(psycheEnv, targetObject));
	}
}