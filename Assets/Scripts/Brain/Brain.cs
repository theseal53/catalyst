using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brain {

	public PsycheEnv psycheEnv;

	/// <summary>
	/// The primary goal that the brain wants to complete.
	/// </summary>
	public Goal goal;

	[HideInInspector]
	protected PriorityQueue<State> stateQueue;

	public Brain(PsycheEnv psycheEnv)
	{
		this.psycheEnv = psycheEnv;
		this.stateQueue = new PriorityQueue<State>();
	}
	
	public void DoTheBrainStuff () {
		if (stateQueue.Count() > 0)
		{
			State currentState = stateQueue.Peek();
			currentState.Execute();
		}
		else if (!goal.IsCompleted())
		{
			Motion nextMotion = goal.FindMotion();
			if (nextMotion != null)
			{
				nextMotion.ExecuteMotion(psycheEnv);
			}
		}
	}
	public void PushState(State state)
	{
		stateQueue.Enqueue(state);
	}

	public void PopState()
	{
		stateQueue.Dequeue();
	}
}
