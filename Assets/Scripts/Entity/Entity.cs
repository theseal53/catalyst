using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public enum TypeTag
{
	NULL,
	PLAYER,
	CHARACTER,
	APPLE
}

public class Entity : MonoBehaviour
{
	//This must be set from the editor
	public List<TypeTag> typeTags;

}
