using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class GrannyAIBase : MonoBehaviour
{

    public Transform[] walkpoints;

    NavMeshAgent agent;
    Animator anim;
    [SerializeField] GameObject startPoint;

    private enum State
    {
        Sitting,
        StandingUp,
        Walking,
        Idle
    }

    State currentState = State.Sitting;
    int currentWalkpointIndex = 0;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        anim.SetTrigger("isSitting");
        //Asunsion quieta
        agent.isStopped = true; 
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartSequence();
        }
    }

    // Llamar para empezar
    public void StartSequence()
    {
        if (currentState == State.Sitting)
        {
            currentState = State.StandingUp;
            anim.SetBool("isSitting", false);   
            anim.SetTrigger("StandUp");
            StartCoroutine(OnStandUpFinished());
        }
    }

    // Este método puedes llamarlo desde un Animation Event
    IEnumerator OnStandUpFinished()
    {
        yield return new WaitForSeconds(2f); // Espera un segundo antes de empezar a caminar
        currentState = State.Walking;
        agent.isStopped = false;

        anim.SetBool("isWalking", true);
        agent.SetDestination(walkpoints[currentWalkpointIndex].position);

       
    }
    
    void OnEnable()
    {
        currentState = State.Sitting;
        currentWalkpointIndex = 0;
        agent.isStopped = true;
        anim.SetBool("isWalking", false);
        anim.SetTrigger("isSitting");
        if (startPoint != null)
        {
            agent.Warp(startPoint.transform.position);
            transform.rotation = startPoint.transform.rotation;
        }   
    }

    void Update()
    {
        if (currentState == State.Walking)
        {
            if (!agent.pathPending && agent.remainingDistance < 0.2f)
            {
                GoToNextWaypoint();
            }
        }
    }

    void GoToNextWaypoint()
    {

        currentWalkpointIndex++;
        if (currentWalkpointIndex < walkpoints.Length)
        {
            agent.SetDestination(walkpoints[currentWalkpointIndex].position);
        }
        else
        {
            currentState = State.Idle;
            agent.isStopped = true;

            anim.SetBool("isWalking", false);
        }
    }
}
