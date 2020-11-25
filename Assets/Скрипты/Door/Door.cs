using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    float openDoor;
    [SerializeField]
    float closeDoor;
    [SerializeField]
    float speed = 1;

    public bool isOpen;
    public bool isLocked;
    public int id;
    public GameObject open;
    public GameObject close;
    public float closed;
    public float opend;
    public bool xyz;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }

        if (xyz == false)
        {
            if (transform.eulerAngles.y <= closed)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                close.SetActive(true);
                open.SetActive(false);
            }

            if (transform.eulerAngles.y > closed && transform.eulerAngles.y < opend)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                open.SetActive(true);
                close.SetActive(false);
            }

            if (transform.eulerAngles.y >= opend)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }

        if(xyz == true)
        {
            if (transform.eulerAngles.y >= closed)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
                close.SetActive(true);
                open.SetActive(false);
            }

            if (transform.eulerAngles.y < closed && transform.eulerAngles.y > opend)
            {
                gameObject.GetComponent<BoxCollider>().enabled = false;
                open.SetActive(true);
                close.SetActive(false);
            }

            if (transform.eulerAngles.y <= opend)
            {
                gameObject.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

    void OpenDoor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, openDoor, transform.rotation.z), speed * Time.deltaTime);
    }

    void CloseDoor()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(transform.rotation.x, closeDoor, transform.rotation.z), speed * Time.deltaTime);
    }

}
