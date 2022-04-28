using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRaycast : MonoBehaviour
{
    [SerializeField] LayerMask layermask;

    RaycastHit hitinfo;

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));

        if(Physics.Raycast(ray,out RaycastHit hitinfo, 20f, layermask, QueryTriggerInteraction.Ignore))
        {
            //Debug.Log("Hit something");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
        }
        else
        {
            //Debug.Log("Hit nothing");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);
        }
    }
}
