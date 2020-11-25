using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHp : MonoBehaviour
{
    public float Hp;
    public float Eat;

    public GameObject ObjHp;
    public GameObject ObjEat;
    public GameObject Objaudio;

    public int scene;

    // Start is called before the first frame update
    void Start()
    {
        if (!PlayerPrefs.HasKey("Eat"))
        {
            PlayerPrefs.SetFloat("Eat", 0.7f);
        }
        else
        {
            Eat = PlayerPrefs.GetFloat("Eat");
        }

        if (!PlayerPrefs.HasKey("Hp"))
        {
            PlayerPrefs.SetFloat("Hp", 1);
        }
        else
        {
            Hp = PlayerPrefs.GetFloat("Hp");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 2))
            {
                if (hit.collider.tag == "Food")
                {
                    if (Eat < 1)
                    {
                        Eat += 0.25f;
                        Destroy(hit.collider.gameObject);
                        Objaudio.GetComponent<AudioSource>().Play();
                    }
                }

                if (hit.collider.tag == "Hp")
                {
                    if (Hp < 1)
                    {
                        Hp += 0.25f;
                        Destroy(hit.collider.gameObject);
                    }
                }
            }
        }

        ObjHp.GetComponent<Slider>().value = Hp;
        ObjEat.GetComponent<Slider>().value = Eat;
        

        if (Eat > 0)
        {
            Eat -= 0.005f * Time.deltaTime;
            PlayerPrefs.SetFloat("Eat", Eat);
        }
        else
        {
            Hp -= 0.01f * Time.deltaTime;
            PlayerPrefs.SetFloat("Hp", Hp);
        }

        if(Hp <= 0)
        {
            Eat += 0.50f;
            Hp += 0.50f;
            SceneManager.LoadScene(scene);
        }

        if(Eat > 1)
        {
            Eat = 1;
        }
    }
}
