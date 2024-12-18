using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialBlock : MonoBehaviour
{
    public GameObject tutorial;
    GameObject player;
    Rigidbody rb;
    Character chara;
    // Start is called before the first frame update
    void Start()
    {
        tutorial.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(player == null)
        {
            player = GameObject.FindWithTag("Player");
            rb = player.GetComponent<Rigidbody>();
        }
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Time.timeScale = 0;
            tutorial.SetActive(true);
        }
    }
    public void Back()
    {
        Time.timeScale = 1;
        tutorial.SetActive(false);
        Debug.Log("Back");
    }
}
