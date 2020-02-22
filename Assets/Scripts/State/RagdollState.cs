using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

class RagdollState : State
{

	float knockoutTime;
	float passedTime = 0;
	public RagdollState(PsycheEnv psycheEnv, float knockoutTime = 5) : base(psycheEnv)
	{
		this.knockoutTime = knockoutTime;
		psycheEnv.character.ragdollController.ActivateRagdoll();
	}
	public override void Execute()
	{
		passedTime += Time.deltaTime;
		if (passedTime > knockoutTime)
		{
			psycheEnv.character.ragdollController.DeactivateRagdoll();
			psycheEnv.brain.PopState();
		}
	}
}