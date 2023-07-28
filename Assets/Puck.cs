using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puck : MonoBehaviour, IHittable
{
    [SerializeField] bool debug;
    [SerializeField] LayerMask layerMask;
    [SerializeField] float rayDistance;
    private Rigidbody rb;
    private Vector3 lastPosition;
    private RaycastHit hit;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //WallCheck();
    }

    private void FixedUpdate()
    {
        lastPosition = transform.position;
        WallCheck();
    }

    private void LateUpdate()
    {
       
    }

    private void WallCheck()
    {

        var direct = (transform.position - lastPosition).normalized;

        if (Physics.Raycast(transform.position, direct, rayDistance, layerMask))
        {
            Debug.Log("Puck Hit");
        }
    }

    private void OnDrawGizmos()
    {
        var direct = (transform.position - lastPosition).normalized;
        Gizmos.DrawRay(transform.position, direct *rayDistance);
    }


    //private void Overlap()
    //{
    //    Collider[] colliders = Physics.OverlapSphere(transform.position, range);
    //    foreach (Collider collider in colliders)
    //    {

    //    }
    //}

    //private void OnDrawGizmosSelected()
    //{
    //    if (!debug)
    //        return;

    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawWireSphere(transform.position, range);
    //}

    //            yield return new WaitForFixedUpdate();




    //private void WallCheck()    // 의미없음
    //{
    //    if (rb.worldCenterOfMass.x < -3.2f || rb.worldCenterOfMass.x > 5f)
    //        rb.velocity = new Vector3(-rb.velocity.x, 0, rb.velocity.y);
    //    if (rb.worldCenterOfMass.z < -3.5f || rb.worldCenterOfMass.z > 3f)
    //        rb.velocity = new Vector3(rb.velocity.x, 0, -rb.velocity.z);
    //}

    public void TakeHit(int damage)
    {
        Debug.Log("Puck Hit");
    }
}
