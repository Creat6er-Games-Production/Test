using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1KOT : MonoBehaviour
{
    public float time;
    public bool timeBool;
    public GameObject player;

    public GameObject voice1;

    public GameObject voice2;
    public GameObject gm1;
    public GameObject gm2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBool == true)
        {
            time += Time.deltaTime;
        }

        if(time >= 14)
        {
            voice2.SetActive(true);
            gm1.GetComponent<Animator>().SetTrigger("go");
            gm2.GetComponent<Animator>().SetTrigger("go");
        }

        if(time >= 22)
        {
            player.GetComponent<RayCastVoiceKotLevel1>().but = true;
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            voice1.SetActive(true);
            timeBool = true;
        }
    }
}
