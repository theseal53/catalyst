using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ObtainGeneralObjectGoal : Goal
{

	LocateToteableObjective x0;
	ObtainToteableObjective x1;

	public ObtainGeneralObjectGoal(PsycheEnv psycheEnv, TypeTag typeTag) : base(psycheEnv)
	{

		x0 = new LocateToteableObjective(psycheEnv);
		x1 = new ObtainToteableObjective(psycheEnv);

		subGoals = new List<GoalNode>()
		{
			x0,
			x1
		};
	}

	public override void ProvideNecessaryData()
	{
		switch (targetObjectiveIndex)
		{
			case 0:
				x0.LoadNecessaryData(TypeTag.APPLE);
				//In case the target object has changed, we nullify the other's desiredToteable
				x1.desiredToteable = null;
				break;
			case 1:
				x0 = subGoals[0] as LocateToteableObjective;
				x1.desiredToteable = x0.locatedToteable as Toteable;
				break;
		}
		if (!targetSubgoal.HasNecessaryData())
		{
			throw new NecessaryDataNotSuppliedException();
		}
	}

}

