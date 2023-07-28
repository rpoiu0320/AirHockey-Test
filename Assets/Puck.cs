using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.EventSystems;

public class Puck : MonoBehaviour, IHittable
{
    [SerializeField] LayerMask layerMask;
    [SerializeField][Range(0f, 300f)] float rayDistance;
    private Rigidbody rb;
    private Vector3 lastPosition;
    private RaycastHit hit;
    [SerializeField][Range(0f, 300f)] float velocitySpeed;
    private int count = 1;

    private void VelocitySpeed()
    {
        rb.velocity = new Vector3(velocitySpeed, 0, rb.velocity.z);
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        //Time.timeScale = 0.05f;
    }

    private void Start()
    {
        coroutine = StartCoroutine(WallCheckRoutine());
    }

    private void Update()
    {
        //WallCheck();
        //Debug.Log(Time.deltaTime);
        //lastPosition = transform.position;
        //VelocitySpeed();
        Debug.Log(rb.velocity);
    }

    private void FixedUpdate()
    {
        //Debug.Log("FixedUpdate");
         lastPosition = transform.position;
        //WallCheck();
    }

    private void LateUpdate()
    {
        //WallCheck();
    }

    private void WallCheck()
    {
        //if (count != 1)
        //    return;

         

        var direct = (transform.position - lastPosition).normalized;
        var nowSpeed = transform.position + (direct * Time.deltaTime);
        //Debug.Log(direct);
        //if (Physics.Raycast(transform.position, direct, Vector3.Distance(transform.position, lastPosition), layerMask))
        if (Physics.Raycast(transform.position, direct,out RaycastHit hitinfo ,rayDistance, layerMask))
        {
            Debug.Log("Puck Hit");
            transform.position = lastPosition;


            var colliderNormal = hitinfo.normal;
            
            var reflectVector = Vector3.Reflect(direct, colliderNormal);

            rb.velocity = reflectVector * 5f;

            //if (Mathf.Abs(rb.velocity.x) > Mathf.Abs(rb.velocity.z))
            //{
            //    rb.velocity = new Vector3(-rb.velocity.x, 0, rb.velocity.z);
            //}
            //else
            //{
            //    rb.velocity = new Vector3(rb.velocity.x, 0, -rb.velocity.z);

            //}
        }
    }

    Coroutine coroutine;
    IEnumerator WallCheckRoutine()
    {
        Debug.Log("StartCoroutine");
        while (true)
        {
            yield return new WaitForFixedUpdate();
            WallCheck();
            //yield return new WaitForFixedUpdate();


            //VelocitySpeed();
        }
    }

    private void OnDrawGizmos()
    {
        var direct = (transform.position - lastPosition).normalized;
        Gizmos.DrawRay(transform.position, direct * Vector3.Distance(transform.position, lastPosition));
        //Gizmos.DrawRay(transform.position, -direct * Vector3.Distance(transform.position, lastPosition));
        //Gizmos.DrawRay(transform.position, direct * rayDistance);

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
