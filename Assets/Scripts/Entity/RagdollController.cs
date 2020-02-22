using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollController : MonoBehaviour
{
    // Start is called before the first frame update\

    CharacterController characterCollider;
    List<Collider> colliders;
    Animator animator;
    void Awake()
    {
        characterCollider = GetComponentInChildren<CharacterController>();
        colliders = new List<Collider>(GetComponentsInChildren<Collider>());
        colliders.Remove(characterCollider);
        animator = GetComponentInChildren<Animator>();
    }

    public void ActivateRagdoll()
    {
        foreach(Collider collider in colliders)
        {
            collider.enabled = true;
            characterCollider.enabled = false;
            animator.enabled = false;
        }
    }
    public void DeactivateRagdoll()
    {
        foreach (Collider collider in colliders)
        {
            collider.enabled = false;
            characterCollider.enabled = true;
            animator.enabled = true;
        }
    }
}
