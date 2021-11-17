using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIScript : MonoBehaviour
{
    public float lookRadius;
    private float minDistance = 15f;
    private float maxDistance = 35f;
    private Vector3 targetSpot;
    private bool setPos = true;

    public EnemyLauncher launcher;

    public Transform target;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        //target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        Debug.Log(transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance > lookRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();
        }
        else
        {
            if (setPos == true || targetSpot == new Vector3(0f, 0f, 0f))
            {
                launcher.LaunchGrenade();
                targetSpot = RandomNavSphere(target.position, maxDistance, minDistance, -1);
                setPos = false;
                StartCoroutine(moveTime());
            }
            else
            {
                agent.SetDestination(targetSpot);
                FaceTarget();
            }
        }



        /*if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            FaceTarget();

            if (distance <= agent.stoppingDistance)
            {
                //FaceTarget();
                
            }
        }*/
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float distance, float minDistance, int layermask)
    {
        Vector3 randomDirection = UnityEngine.Random.onUnitSphere * Random.Range(minDistance, distance);

        randomDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
        //Debug.Log(randomDirection);

        return navHit.position;
    }


    IEnumerator moveTime()
    {
        yield return new WaitForSeconds(2.5f);
        setPos = true;
    }
}