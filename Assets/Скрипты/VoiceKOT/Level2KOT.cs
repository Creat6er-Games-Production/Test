using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Level2KOT : MonoBehaviour
{
    public GameObject voice1;
    public GameObject voice2;
    public GameObject voice3;
    public GameObject voice4;
    public GameObject voice5;
    public GameObject obj;
    public bool go;
    public bool go2;

    public bool doc1;
    public bool doc2;
    public bool doc3;

    public float time1;
    public float time2;
    public float time3;
    public float time4;

    public bool timeBool;

    public bool timeBoolDOC1;
    public bool timeBoolDOC2;
    public bool timeBoolDOC3;

    public GameObject BankCarta;
    public GameObject TrudBook;
    public GameObject Passport;

    public GameObject money;

    FirstPersonController controller;
    public GameObject pauseManager;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<FirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBool == true)
        {
            voice1.SetActive(true);
            time1 += Time.deltaTime;

            if(time1 >= 37.5f)
            {
                go = true;
                voice1.SetActive(false);
                time1 = 0;
                timeBool = false;
            }
        }

        if (go == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 2))
                {
                    if (hit.collider.tag == "BankCart")
                    {
                        BankCarta.SetActive(true);
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        controller.enabled = false;
                        go2 = false;
                        timeBoolDOC1 = true;
                        pauseManager.GetComponent<PauseManager>().go = false;
                        Destroy(hit.collider.gameObject);
                    }

                    if (hit.collider.tag == "TrudBook")
                    {
                        TrudBook.SetActive(true);
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        controller.enabled = false;
                        go2 = false;
                        timeBoolDOC2 = true;
                        pauseManager.GetComponent<PauseManager>().go = false;
                        Destroy(hit.collider.gameObject);
                    }

                    if (hit.collider.tag == "Passport")
                    {
                        Passport.SetActive(true);
                        Cursor.visible = true;
                        Cursor.lockState = CursorLockMode.None;
                        controller.enabled = false;
                        go2 = false;
                        timeBoolDOC3 = true;
                        pauseManager.GetComponent<PauseManager>().go = false;
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }

        if(timeBoolDOC1 == true)
        {
            voice2.SetActive(true);
            time2 += Time.deltaTime;

            if(time2 >= 7)
            {
                voice2.SetActive(false);
                go2 = true;
                time2 = 0;
                timeBoolDOC1 = false;
            }
        }

        if (timeBoolDOC2 == true)
        {
            voice3.SetActive(true);
            time3 += Time.deltaTime;

            if (time3 >= 2.4f)
            {
                voice3.SetActive(false);
                go2 = true;
                time3 = 0;
                timeBoolDOC2 = false;
            }
        }

        if (timeBoolDOC3 == true)
        {
            voice4.SetActive(true);
            time4 += Time.deltaTime;

            if (time4 >= 1.22f)
            {
                voice4.SetActive(false);
                go2 = true;
                time4 = 0;
                timeBoolDOC3 = false;
            }
        }

        if(doc1 == true && doc2 == true && doc3 == true)
        {
            voice5.SetActive(true);
            Destroy(obj);
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Trigger")
        {
            timeBool = true;
            Destroy(other.gameObject);
        }
    }


    public void CartButton()
    {
        if (go2 == true)
        {
            BankCarta.SetActive(false);
            doc1 = true;
            pauseManager.GetComponent<PauseManager>().go = true;
            money.SetActive(true);
        }
    }

    public void BookButton()
    {
        if (go2 == true)
        {
            TrudBook.SetActive(false);
            doc2 = true;
            pauseManager.GetComponent<PauseManager>().go = true;
        }
    }
    public void PassportButton()
    {
        if (go2 == true)
        {
            Passport.SetActive(false);
            doc3 = true;
            pauseManager.GetComponent<PauseManager>().go = true;
        }
    }
}
