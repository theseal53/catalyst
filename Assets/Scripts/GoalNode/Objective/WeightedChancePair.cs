
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class WeightedChancePair
{
	/// <summary>
	/// The delegate describing what form the expression calculating the chance of selecting action must take
	/// </summary>
	/// <param name="psycheEnv"></param>
	/// <returns></returns>
	public delegate float ChanceExpression(PsycheEnv psycheEnv);

	/// <summary>
	/// The form that the expression describing how to find a motion
	/// </summary>
	/// <param name="psycheEnv"></param>
	/// <returns></returns>
	public delegate Motion MotionReturnExpression();

	public MotionReturnExpression motionReturnExpression;

	/// <summary>
	/// This expression is used to calculate how likely its actionable is to be selected
	/// </summary>
	/// <param name="psycheEnv"></param>
	/// <returns></returns>
	public ChanceExpression chanceExpression;

	public WeightedChancePair(MotionReturnExpression motionReturnExpression, ChanceExpression chanceExpression)
	{
		this.motionReturnExpression = motionReturnExpression;
		this.chanceExpression = chanceExpression;
	}
}
