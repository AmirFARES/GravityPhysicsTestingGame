using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cubeMove : MonoBehaviour
{
    private float timer;
    [SerializeField] private int newtarget;
    private UnityEngine.AI.NavMeshAgent nav;
    private Vector3 target;
    private float stopTimer;
    void Start()
    {
        nav = gameObject.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    [System.Obsolete]
    void Update()
    {
        if (!pauseMenu.gamePaused)
        {
            if (Input.GetMouseButtonUp(0))
            {
                stop();
            }
            stopTimer -= Time.deltaTime;
            if (stopTimer <= 0)
            {
                nav.Resume();
                timer += Time.deltaTime;
                if (timer >= newtarget)
                {
                    newTarget();
                    timer = 0;
                }
            }
        }
    }
    
    void newTarget()
    {
        float xPos = Random.Range(-7.5f, 7.5f);
        float zPos = Random.Range(-7.5f, 7.5f);

        target = new Vector3(xPos, gameObject.transform.position.y, zPos);
        nav.SetDestination(target);
    }

    [System.Obsolete]
    void stop()
    {
        stopTimer = 2;
        nav.Stop();
    }
}
