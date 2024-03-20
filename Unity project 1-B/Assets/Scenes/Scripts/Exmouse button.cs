using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exmousebutton : MonoBehaviour
{
    public int Hp = 100;
    public Text textUI;

    // Start is called before the first frame update
    void Start()
    {
       
    }
    

    // Update is called once per frame
    void Update()
    {
        textUI.text = "체력 :" + Hp.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            Hp = -10;
            Debug.Log("체력 : " + Hp);
            if( Hp <= 0)
            {
                textUI.text = "체력 :" + Hp.ToString();
                Destroy(gameObject);
            }

        }
    }
}
