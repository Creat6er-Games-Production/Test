using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1KOT2 : MonoBehaviour
{
    public GameObject voice;
    public GameObject box;

    public float time;
    public bool timeBool;

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

        if(time >= 7.3f)
        {
            Destroy(box);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            voice.SetActive(true);
            timeBool = true;
        }
    }
}
