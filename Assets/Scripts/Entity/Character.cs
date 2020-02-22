using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class Character : Entity
{
	Brain brain;

	[SerializeField]
	PsycheEnv psycheEnv;

	CharacterController controller;

	public Animator animator;
	public RagdollController ragdollController;

	public float gravity = 1;
	//Radians
	public float turnSpeed = .1f;

	public List<StageProp> heldItems = new List<StageProp>();

	public void Start()
	{
		psycheEnv.gameObject = gameObject;
		brain = new Brain(psycheEnv);
		psycheEnv.brain = brain;
		psycheEnv.character = this;
		brain.goal = new ObtainGeneralObjectGoal(psycheEnv, TypeTag.APPLE);
		controller = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator>();
		ragdollController = GetComponent<RagdollController>();
		ragdollController.DeactivateRagdoll();
	}

	public void Update()
	{
		brain.DoTheBrainStuff();
		ApplyPhysics();
	}

	public void ApplyPhysics()
	{
		Vector3 movement = new Vector3(0, 0, 0);
		if (!controller.isGrounded)
		{
			movement.y = movement.y - gravity;
			controller.Move(movement * Time.deltaTime);
		}
	}

	public void TurnTowards(Vector3 lookPosition)
	{
		lookPosition.y = transform.position.y;
		Vector3 lookDirection = lookPosition - transform.position;
		Vector3 newDirection = Vector3.RotateTowards(transform.forward, lookDirection, turnSpeed, 0.0f);
		transform.rotation = Quaternion.LookRotation(newDirection);
	}

	public void PickUpItem(Toteable toteable)
	{
		heldItems.Add(toteable);
		toteable.gameObject.SetActive(false);
		toteable.beingHeld = true;
		toteable.holder = this;
		EventHub.PickupBroadcast(this, toteable);
	}

}