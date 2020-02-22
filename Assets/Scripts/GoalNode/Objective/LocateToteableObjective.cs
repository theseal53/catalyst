using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class LocateToteableObjective : Objective, IReportEntityReceiver
{
	//Necessary information
	public TypeTag desiredType = TypeTag.NULL;

	public Toteable locatedToteable;

	public LocateToteableObjective(PsycheEnv psycheEnv) : base(psycheEnv)
	{
		weightedChancePairs = new List<WeightedChancePair>()
		{
			new WeightedChancePair(()=>{ return new ScanSurroundingsForObjectMotion(psycheEnv, this, desiredType); }, (x)=>{ return 1.0f; } )
		};
	}

	public override bool IsCompleted()
	{
		if (locatedToteable == null)
		{
			return false;
		}
		return true;
	}

	public override bool HasNecessaryData()
	{
		if (desiredType == TypeTag.NULL)
		{
			return false;
		}
		return true;
	}

	public void LoadNecessaryData(TypeTag desiredType)
	{
		this.desiredType = desiredType;
	}

	public void ReceiveReport(ICollection<Entity> entities)
	{
		locatedToteable = MostAttractiveOption(entities);
		if (locatedToteable != null)
		{
			EventHub.PickupEvent += OnAnyItemPickup;
		}
	}

	Toteable MostAttractiveOption(ICollection<Entity> discoveredEntities)
	{
		Toteable mostAttractive = null;
		float bestDistance = 0;
		foreach(Toteable toteable in discoveredEntities)
		{
			if (mostAttractive == null)
			{
				mostAttractive = toteable;
				bestDistance = Vector3.Distance(psycheEnv.gameObject.transform.position, toteable.gameObject.transform.position);
			} else
			{
				float newDistance = Vector3.Distance(psycheEnv.gameObject.transform.position, toteable.gameObject.transform.position);
				if (newDistance < bestDistance)
				{
					if (mostAttractive.beingHeld && !toteable.beingHeld)
					{
						mostAttractive = toteable;
					}
				}
			}
		}
		return mostAttractive;
	}

	private void OnAnyItemPickup(Character character, Toteable toteable)
	{
		if (toteable == locatedToteable && character != psycheEnv.character)
		{
			locatedToteable = null;
		}
	}
}
