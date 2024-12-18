using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// チュートリアルの処理を制御する
/// </summary>
public class TutorialBlock : MonoBehaviour
{
    [SerializeField]
    private GameObject tutorial;

    GameObject player;
    Rigidbody rb;
    Character chara;

    void Start()
    {
        tutorial.SetActive(false);
    }

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

    /// <summary>
    /// チュートリアルを閉じる
    /// </summary>
    public void Back()
    {
        Time.timeScale = 1;
        tutorial.SetActive(false);
        #if UNITY_EDITOR
        Debug.Log("Back");
        #endif
    }
}
