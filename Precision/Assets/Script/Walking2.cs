using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Walking2 : MonoBehaviour
{

    NavMeshAgent agent;
    public AiState currState;
    private Health health;
    Vector3 checkPos = new Vector3(0, 0, 0);
    float timer = 4f;
    bool hold = true;
    bool hold2 = true;
    bool hold3 = true;
    int rand;
    public GameObject gembok;
    public GameObject kandang;
    public GameObject cat;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        health = GetComponent<Health>();
        rand = Random.Range(0, 10);
        agent.speed = 1;
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

    // Update is called once per frame
    void Update()
    {
        if (Shoot.shoot >= 4 || Health.die > 0)
        {
            StartCoroutine("Panic");
            currState = AiState.panic;
        }
        timer -= Time.deltaTime;

        if ((gameObject.tag == "Target" || gameObject.tag == "Spesial") && gembok == null && !hold2 && hold3)
        {
            timer = 4;
            StartCoroutine("Stop2");
            currState = AiState.stop2;
        }

        if (gembok == null && Vector3.Distance(GameObject.FindWithTag("Spesial").transform.position, cat.transform.position) < 2 && hold2)
        {
            hold2 = false;
        }

        if (timer <= 0)
        {
            timer = 4;
            rand = Random.Range(0, 10);
        }
    }

    IEnumerator Wandering()
    {
        while (!health.isDead)
        {
            Vector3 randomPos = transform.position + Random.onUnitSphere * 5;
            agent.SetDestination(randomPos);

            if (rand == 3)
            {
                rand = 0;
                StartCoroutine("Stop");
                currState = AiState.stop;
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

            if (hold)
            {
                checkPos = kandang.transform.position;
                hold = false;
            }
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
                StartCoroutine("Wandering");
                currState = AiState.wandering;
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
            if (((Vector3.Distance(this.gameObject.transform.position, cat.gameObject.transform.position) < 2 && gameObject.tag == "Spesial") || gameObject.tag == "Target") && gembok == null)
            {
                hold2 = false;
                StartCoroutine("Checking");
                currState = AiState.checking;
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

