using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Walking : MonoBehaviour {

    NavMeshAgent agent;
    public AiState currState;
    public GameObject checkObject;
    public GameObject falling;
    private Health health;
    Vector3 checkPos = new Vector3(0, 0, 0);
    float timer = 4f;
    bool hold = true;
    int rand;

	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        rand = Random.Range(0, 10);
        agent.speed = 3;

        if (gameObject.tag != "Target" && gameObject.tag != "Spesial")
        {
            switch (currState)
            {
                case AiState.wandering:
                    StartCoroutine("Wandering");
                    break;
                case AiState.stop:
                    StartCoroutine("Stop");
                    break;
                default:
                    break;
            }
        }
    }

    // Update is called once per frame
	void Update () {
        if (Shoot.shoot >= 4 || Health.die > 0)
        {
            StartCoroutine("Panic");
            currState = AiState.panic;
        }

        if(falling == null && hold && (Shoot.shoot < 4)){
            StartCoroutine("Stop2");
            currState = AiState.stop2;
            timer = 5;
        }

        if (gameObject.tag != "Target" && gameObject.tag != "Spesial")
        {
            if (falling != null)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                timer = 4;
                rand = Random.Range(0, 10);
            }
        }
    }

    IEnumerator Wandering()
    {
        while (!health.isDead)
        {
            Vector3 randomPos = transform.position + Random.onUnitSphere * 5;
            randomPos.y = transform.position.y;
            agent.SetDestination(randomPos);

            if (currState != AiState.wandering)
            {
                break;
                yield return null;
            }

            if (rand == 3)
            {
                rand = 0;
                if (falling != null) {
                    StartCoroutine("Stop");
                    currState = AiState.stop;
                }
                break;
                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(5, 12));

            if (currState != AiState.wandering)
            {
                break;
                yield return null;
            }
        }
        yield return null;
    }

    IEnumerator Panic()
    {
        while (!health.isDead)
        {
            agent.speed = 5;
            Vector3 randomPos = transform.position + Random.onUnitSphere * 5;
            randomPos.y = transform.position.y;
            agent.SetDestination(randomPos);

            yield return new WaitForSeconds(Random.Range(1, 4));

            if (currState != AiState.panic)
            {
                break;
                yield return null;
            }
        }
        yield return null;
    }

    IEnumerator Checking()
    {
        while (!health.isDead)
        {
            if (hold) {
                checkPos = checkObject.transform.position + Random.insideUnitSphere * 5;
                hold = false;
                currState = AiState.checking;
            }
            checkPos.y = transform.position.y;
            agent.SetDestination(checkPos);

            yield return new WaitForSeconds(5);

            if (currState != AiState.checking)
            {
                break;
                yield return null;
            }
        }
        yield return null;
    }

    IEnumerator Stop()
    {
        while (!health.isDead)
        {
            if (currState != AiState.stop)
            {
                break;
                yield return null;
            }

            agent.SetDestination(transform.position);
            if (rand != 3 && rand != 4)
            {
                rand = 0;
                if (falling != null)
                {
                    StartCoroutine("Wandering");
                    currState = AiState.wandering;
                }
                break;
                yield return null;
            }

            yield return new WaitForSeconds(Random.Range(1, 4));

            if (currState != AiState.stop)
            {
                break;
                yield return null;
            }
        }
        yield return null;
    }

    IEnumerator Stop2()
    {
        while (!health.isDead)
        {
            timer -= Time.deltaTime;
            agent.SetDestination(transform.position);
            if (timer <= 0) {
                timer = 4;
                StartCoroutine("Checking");
                currState = AiState.checking;
                break;
            }
            yield return null;

            if (currState != AiState.stop2)
            {
                break;
                yield return null;
            }
        }
        yield return null;
    }
}
