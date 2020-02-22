using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ObtainToteableObjective : Objective
{

	public Toteable desiredToteable;

	public ObtainToteableObjective(PsycheEnv psycheEnv) : base(psycheEnv)
	{
		weightedChancePairs = new List<WeightedChancePair>()
		{
			new WeightedChancePair(()=>{ return new ApproachAndPickupMotion(psycheEnv, desiredToteable); },(x)=>{
				if (!desiredToteable.beingHeld) {
					return 1.0f;
				} else
				{
					return 0;
				}
			}),

			new WeightedChancePair(()=>{ return new ApproachAndRobMotion(psycheEnv, desiredToteable); },(x)=>{
				if (desiredToteable.beingHeld) {
					return 1.0f;
				} else
				{
					return 0;
				}
			}),

		};
	}

	public override bool IsCompleted()
	{
		if (psycheEnv.character.heldItems.Contains(desiredToteable))
		{
			return true;
		}
		return false;
	}
	public void LoadNecessaryData(Toteable desiredToteable)
	{
		this.desiredToteable = desiredToteable;
	}

	public override bool HasNecessaryData()
	{
		if (desiredToteable == null)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

}
