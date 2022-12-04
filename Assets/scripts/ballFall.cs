using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballFall : MonoBehaviour
{
    Vector3 cubePosition;

    [SerializeField] private Camera mainCamera;

    private float forceCounter;
    [SerializeField] private float forcetime;
    private float force;
    private bool isShooting;

    [SerializeField] private Image bar;

    private float fallTimer;
    private bool isFalling;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
    void Update()
    {
        if (!pauseMenu.gamePaused)
        {
            FallBall();
            ShootBall();
        }
    }
    void FallBall()
    {
        if (Input.GetMouseButtonDown(0))
        {
            isFalling = true;
            fallTimer = 0.3f;
            force = 0;
        }
        fallTimer -= Time.deltaTime;
        if (fallTimer <= 0 && isFalling)
        {
            cubePosition = GameObject.Find("cube").transform.position;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            gameObject.transform.position = new Vector3(cubePosition.x, 8, cubePosition.z);
            isFalling = false;
        }
    }
    void ShootBall()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            isShooting = true;
            force = 50;
            forceCounter = forcetime;
        }
        if (Input.GetKey(KeyCode.Mouse1) && isShooting)
        {
            if (forceCounter > 0)
            {
                force += 20;
                forceCounter -= Time.deltaTime;
            }
            else
            {
                isShooting = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            RaycastHit hit;
            if (Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward, out hit))
            {
                GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                transform.position = mainCamera.transform.position;
                var dir = hit.point - transform.position;
                dir = dir.normalized;
                GetComponent<Rigidbody>().AddForce(dir * force);
            }
            isShooting = false;
        }
        bar.fillAmount = force / 2200;
    }
}
