using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class ApproachAndRobState : State
{
	Toteable targetToteable;

	float acceptableDistance = .5f;
	float speed = .2f;

	Character character;

	public ApproachAndRobState(PsycheEnv psycheEnv, Toteable targetToteable) : base(psycheEnv)
	{
		this.targetToteable = targetToteable;
	}

	public void GiveControlOfCharacter(Character character)
	{
		this.character = character;
	}

	public override void Execute()
	{
		/*float distance = Vector3.Distance(psycheEnv.gameObject.transform.position, targetToteable.transform.position);

		if (distance < acceptableDistance)
		{
			psycheEnv.character.PickUpItem(targetToteable);
			psycheEnv.brain.PopState();
		}

		psycheEnv.gameObject.transform.position = Vector3.MoveTowards(psycheEnv.gameObject.transform.position, targetToteable.transform.position, speed);
		Debug.Log(distance);*/
		//Debug.Log("Waaaaaah not me");
	}
}
