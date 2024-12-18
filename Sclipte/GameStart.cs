using CharacterChoice;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SelectCharacter
{
    public class GameStart : MonoBehaviour
    {
        private GameDataManager myGameManagerData;
        GameObject spone;

        // Start is called before the first frame update
        void Start()
        {
            spone = GameObject.Find("sponeblock");
            Vector3 Spone= spone.transform.position;
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
            Instantiate(myGameManagerData.GetCharacter(), Spone, Quaternion.Euler(0, 90, 0));
        }
    }
}