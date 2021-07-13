using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePlayer : MonoBehaviour
{
    public float movespeed = 3.5f;
    public float shootspeed = 0.5f;
    public float xTravel = 5.0f;
    private CubeShot[] cubeshots;
    private float markTime;

    private void Start()
    {
        markTime = Time.time;
        cubeshots = GameObject.Find("ShotPool").GetComponentsInChildren<CubeShot>();
    }
    private void Update()
    {
        if (Input.GetButton("Fire1") == true || Input.GetKeyDown(KeyCode.Space) == true)
        {
            doShoot();
        }

        float xDelta = Input.GetAxis("Horizontal") * movespeed * Time.deltaTime;
        float x = this.transform.position.x;
        if ((xDelta > 0 && x < xTravel) || (xDelta < 0 && x > -xTravel))
        {
            this.transform.Translate(new Vector3(xDelta, 0, 0));
        }

    }
    private void doShoot()
    {
        bool bFound = false;
        if (Time.time - markTime > shootspeed)
        {
            markTime = Time.time;
            for (int i = 0; i < cubeshots.Length; i++)
            {
                CubeShot script = cubeshots[i].GetComponent<CubeShot>();
                if (script.setActive() == true)
                {
                    bFound = true;
                    break;
                }
            }
            if (bFound == false)
            {
                this.GetComponent<AudioSource>().Play();
            }
        }
    }
}