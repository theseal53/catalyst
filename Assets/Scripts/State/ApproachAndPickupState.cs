using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class ApproachAndPickupState : State
{

	Toteable targetToteable;

	float acceptableDistance = .5f;
	float speed = .2f;

	public ApproachAndPickupState(PsycheEnv psycheEnv, Toteable targetToteable) : base(psycheEnv)
	{
		this.targetToteable = targetToteable;
		EventHub.PickupEvent += OnAnyItemPickup; 
	}

	public override void Execute()
	{
		psycheEnv.character.animator.SetBool("IsWalking", true);
		Vector3 selfPosition = psycheEnv.gameObject.transform.position;
		Vector3 targetPosition = targetToteable.transform.position;
		targetPosition.y = selfPosition.y;
		float distance = Vector3.Distance(selfPosition, targetPosition);

		if (distance <  acceptableDistance)
		{
			psycheEnv.character.PickUpItem(targetToteable);
			psycheEnv.brain.PopState();
			psycheEnv.brain.PushState(new RagdollState(psycheEnv, 5));
			psycheEnv.character.animator.SetBool("IsWalking", false);
			psycheEnv.character.animator.SetBool("GettingUp", true);
		}

		psycheEnv.gameObject.transform.position = Vector3.MoveTowards(selfPosition, targetPosition, speed);
		psycheEnv.character.TurnTowards(targetPosition);
	}
	private void OnAnyItemPickup(Character character, Toteable toteable)
	{
		if (toteable == targetToteable && character != psycheEnv.character)
		{
			psycheEnv.brain.PopState();
		}
	}
}

