using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastVoiceKotLevel1 : MonoBehaviour
{
    public float time;
    public bool timeBool;
    public bool but;
    public GameObject gm;

    public GameObject voice1;
    public GameObject hp;
    public GameObject gm1;
    public GameObject gm2;

    public GameObject voice2;
    public GameObject gm3;
    public GameObject gm4;
    public GameObject gm5;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && but == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 2))
            {
                if(hit.collider.tag == "Button1")
                {
                    gm.GetComponent<Animator>().SetTrigger("button");
                    voice1.SetActive(true);
                    hp.SetActive(true);
                    gm1.GetComponent<Animator>().SetTrigger("go");
                    gm2.GetComponent<Animator>().SetTrigger("go");
                    timeBool = true;
                }
            }
        }

        if (timeBool == true)
        {
            time += Time.deltaTime;
        }

        if (time >= 28)
        {
            voice2.SetActive(true);
            gm3.GetComponent<Animator>().SetTrigger("go");
            gm4.GetComponent<Animator>().SetTrigger("go");
            gm5.GetComponent<Animator>().SetTrigger("go");
        }
    }
}
