using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayBrock : MonoBehaviour
{
    [SerializeField]
    BoxCollider boxCollider;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(boxCollider + "box");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(other.gameObject.tag);
            boxCollider.enabled = true;
        }
    }
}
