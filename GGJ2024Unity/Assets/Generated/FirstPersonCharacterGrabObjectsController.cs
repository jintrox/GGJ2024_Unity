using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCharacterGrabObjectsController : MonoBehaviour
{
    [SerializeField] float grabDistance = 1.5f;
    [SerializeField] LayerMask grabbableObjectsLayerMask;
    [SerializeField] Transform grabPoint;

    [Tooltip("The object currently being held")]
    public Rigidbody grabbedObject;

    void Update()
    {
        if (grabbedObject == null && Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, grabDistance, grabbableObjectsLayerMask))
            {
                Rigidbody rb = hit.rigidbody;
                if (rb != null)
                {
                    grabbedObject = rb;
                    grabbedObject.isKinematic = true;
                    grabbedObject.transform.position = grabPoint.position;
                    grabbedObject.transform.rotation = Quaternion.Euler(0, grabPoint.eulerAngles.y, 0);
                }
            }
        }
        else if (grabbedObject != null && Input.GetMouseButtonUp(0))
        {
            grabbedObject.isKinematic = false;
            grabbedObject = null;
        }
    }
}