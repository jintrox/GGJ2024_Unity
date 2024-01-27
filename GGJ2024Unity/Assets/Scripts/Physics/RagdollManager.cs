using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManager : MonoBehaviour
{
    public Animator anim;
    public Rigidbody[] bodyparts;
    
    // Start is called before the first frame update
    void Start()
    {
        bodyparts = GetComponentsInChildren<Rigidbody>();
    }

    public void OnDie()
    {
        if (anim.enabled)
        {
            anim.enabled = false;
            foreach (var part in bodyparts)
            {
                part.isKinematic = false;
            }
        }
    }
}
