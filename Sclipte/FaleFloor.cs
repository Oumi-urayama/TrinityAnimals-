using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaleFloor : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]
    private float derayTime=0;


    public FlagManager flagManager;
    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        Character chara = other.gameObject.GetComponent<Character>();
        if (other.gameObject.tag == "Player")
        {
            if (flagManager.Sneek == false)
            {
                Invoke("noKinematic", derayTime);
            }
        }
        if (other.gameObject.tag == "Ground" && rb.isKinematic == false)
        {
            Destroy(gameObject);
        }
    }
    void noKinematic()
    {
        rb.isKinematic = false;
    }

}
