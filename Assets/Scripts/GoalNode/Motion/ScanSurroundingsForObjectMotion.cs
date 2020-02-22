using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class ScanSurroundingsForObjectMotion : Motion
{

	TypeTag desiredType;

	//TODO: Put this somewhere appropriate
	float radius = 100;

	IReportEntityReceiver reportReceiver;

	public ScanSurroundingsForObjectMotion(PsycheEnv psycheEnv, IReportEntityReceiver reportReceiver, TypeTag desiredType) : base(psycheEnv)
	{
		this.reportReceiver = reportReceiver;
		this.desiredType = desiredType;
	}

	public override void ExecuteMotion(PsycheEnv psycheEnv)
	{
		Collider[] nearbyColliders = Physics.OverlapSphere(psycheEnv.gameObject.transform.position, radius);
		ICollection<Entity> discoveredEntities = new List<Entity>();
		foreach (Collider collider in nearbyColliders)
		{
			Entity entity = collider.GetComponent<Entity>();
			if (entity != null)
			{
				if (entity.typeTags.Contains(desiredType))
				{
					discoveredEntities.Add(entity);
				}
			}
		}
		reportReceiver.ReceiveReport(discoveredEntities);
	}
	/*Entity MostAttractiveOption(ICollection<Entity> discoveredEntities)
	{
		Entity mostAttractive = null;
		float bestDistance = 0;
		foreach(Entity entity in discoveredEntities)
		{
			if (mostAttractive == null)
			{
				mostAttractive = entity;
				bestDistance = Vector3.Distance(psycheEnv.gameObject.transform.position, entity.gameObject.transform.position);
			} else
			{
				float newDistance = Vector3.Distance(psycheEnv.gameObject.transform.position, entity.gameObject.transform.position);
				if (newDistance < bestDistance)
				{
					if (mostAttractive.beingHeld && !entity.beingHeld)
					{
						mostAttractive = entity;
					}
				}
			}
		}
		return mostAttractive;
	}*/
}
