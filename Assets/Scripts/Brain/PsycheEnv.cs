using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

[Serializable]
public class PsycheEnv
{
	//Personality traits
	public float intelligence = 50;
	public float belligerence = 50;
	public float honor = 50;

	//Emotions
	public float insanity = 50;
	public float happiness = 50;
	public float determination = 50;

	//Emotions toward others
	public Dictionary<Character, CharacterOpinion> characterOpinions;

	public GameObject gameObject;
	public Brain brain;
	public Character character;

	public PsycheEnv()
	{
		characterOpinions = new Dictionary<Character, CharacterOpinion>();
	}
}

public class CharacterOpinion
{
	public float regard;
	public float love;
}
