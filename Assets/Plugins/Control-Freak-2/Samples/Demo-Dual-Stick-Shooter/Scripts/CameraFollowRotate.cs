using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowRotate : MonoBehaviour {

    [SerializeField]
    private Transform target, LookPoint;

    [SerializeField]
    private Vector3 offsetPosition;

    [SerializeField]
    private Space offsetPositionSpace = Space.Self;

    [SerializeField]
    private bool lookAt = true;
    public bool kid;
    public void Start(){
        if (!kid)
        {
            target.gameObject.GetComponent<CapsuleCollider>().height = 3;
            target.gameObject.GetComponent<CapsuleCollider>().radius = 2;
        }
    }
    private void LateUpdate()
    {
        Refresh();
    }

    public void Refresh()
    {
        if (target == null)
        {
            Debug.LogWarning("Missing target ref !", this);

            return;
        }

        // compute position
        if (offsetPositionSpace == Space.Self)
        {
            transform.position = target.TransformPoint(offsetPosition);
        }
        else
        {
            transform.position = target.position + offsetPosition;
        }

        // compute rotation
        transform.LookAt(LookPoint);
        if (lookAt)
        {
            transform.LookAt(target);
        }
        else
        {
            transform.rotation = target.rotation;
        }
    }
}
