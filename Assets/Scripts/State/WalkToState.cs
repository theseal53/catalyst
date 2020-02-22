using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using UnityEngine;

class WalkToState : State
{
	public WalkToState(PsycheEnv psycheEnv) : base(psycheEnv)
	{

	}

	public override void Execute()
	{
		Debug.Log("I vant to valk");
	}
}
