using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CatWalking : MonoBehaviour {

    public GameObject gembok;
    public GameObject master;
    NavMeshAgent agent;
    private float time = 3;
    private AiState currState;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        currState = AiState.catstop;
	}
	
	// Update is called once per frame
	void Update () {
        if (gembok == null)
        {
            StartCoroutine("Jalan");
            currState = AiState.catjalan;
        }
	}

    IEnumerator Jalan()
    {
        while (true)
        {
            agent.SetDestination(master.transform.position + Random.insideUnitSphere * 2);
            yield return new WaitForSeconds(Random.Range(1, 4));
            if (currState != AiState.catjalan)
            {
                yield return null;
            }
            
        }
        yield return null;
    }

    IEnumerator Stop()
    {
        while (true)
        {
            agent.SetDestination(transform.position);
            yield return new WaitForSeconds(Random.Range(1, 4));

            if (currState != AiState.catstop)
            {
                yield return null;
            }

        }
        yield return null;
    }
}
