using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Script enemy movement using NavMesh.
public class EnemyMove : MonoBehaviour
{
    [SerializeField]
    Transform[] _destination;
    [SerializeField] 
    LayerMask layermask;

    private Vector3 targetVector;
    private Transform _upDatePoint;
    private int _upDateAgent;

    NavMeshAgent _navMeshAgent;

    public GameObject player;
    public bool lookPlayer;
    public bool doubtPlayer;

    private void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
    }
    private void Update()
    {
        //Without the player the script will not run.
        if (player == null)
        {
            return;
        }

        //If an enemy encounters it, the player will walk towards the player.
        if (lookPlayer)
            MovetoPlayer();

        //If the enemy is suspicious, it will turn to the suspicious direction.
        else if (doubtPlayer)
            lookforPlayer();

        else
            UpDatePoint();

    }

    //Function to determine enemy's moving point.
    private void UpDatePoint()
    {
        _upDatePoint = _destination[_upDateAgent];

        if (_navMeshAgent == null)
        {
            Debug.LogError("The nav mesh agent component is not attached to" + gameObject.name);
        }
        else
        {
            SetDestination();
        }

        if (_upDateAgent >= _destination.Length)
        {
            _upDateAgent = 0;
        }
    }

    //Function Set Destination for enemies.
    private void SetDestination()
    {
        if(_destination != null)
        {
            targetVector = _upDatePoint.transform.position;
            _navMeshAgent.SetDestination(targetVector);

            if (_navMeshAgent.transform.position.x == _upDatePoint.transform.position.x && _navMeshAgent.transform.position.z == _upDatePoint.transform.position.z)
            {
                _upDateAgent++;
            }
        }
    }

    //Enemy function walks towards the player.
    private void MovetoPlayer()
    {
        targetVector = player.transform.position;
        _navMeshAgent.SetDestination(targetVector);
    }

    //Enemy function looks for player.
    private void lookforPlayer()
    {
        _navMeshAgent.transform.forward = player.transform.position;
    }
}
