using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeShot : MonoBehaviour
{
    public enum enumState
    {
        pooled,
        active
    }

    public float movespeed = 3.0f;
    public float zTravel = 5.0f;
    private enumState state = enumState.pooled;
    private GameObject player = null;

    private void Start()
    {
        player = GameObject.Find("CubePlayer");
    }
    private void Update()
    {
        switch (state)
        {
            case enumState.pooled:
                break;
            case enumState.active:
                this.transform.Translate(new Vector3(0, 0, movespeed * Time.deltaTime));
                if (this.transform.position.z > zTravel)
                    setPooled();
                break;
        }
    }
    private void setPooled()
    {
        state = enumState.pooled;
        this.GetComponent<Renderer>().enabled = false;
    }
    public bool setActive()
    {
        bool ret = false;
        if (state == enumState.pooled)
        {
            state = enumState.active;
            this.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
            this.transform.rotation = new Quaternion(player.transform.rotation.x, player.transform.rotation.y, player.transform.rotation.z, player.transform.rotation.w);
            this.GetComponent<Renderer>().enabled = true;
            this.GetComponent<AudioSource>().Play();
            ret = true;
        }
        return ret;
    }
}