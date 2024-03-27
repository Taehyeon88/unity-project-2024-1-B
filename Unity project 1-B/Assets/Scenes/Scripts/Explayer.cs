using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     //UI�� ����ϱ� ���ؼ�

public class Explayer : MonoBehaviour

    
{
    public Rigidbody m_Rigidbody;
    public int Force = 100;
    public int point = 0;
    public float checkTime = 0;   //
    public Text m_Text;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
          m_Rigidbody.AddForce(transform.up * Force);
        }

        checkTime += Time.deltaTime;         //point =point + 1
        if(checkTime >= 1.0f)                //1�ʰ� ������� �ʱ�ȭ (0�� -> 1�� -> 0�� -> 1��)
        {
            point += 1;
            checkTime = 0.0f;
        }

        m_Text.text = point.ToString();        //UI ǥ��
          
    }
    private void OnCollisionEnter(Collision collision)  //�浹�� ���۵Ǿ��� ��
    {
        if(collision != null)                          //�浹��ü�� ������ ���
        {
            point = 0;
            gameObject.transform.position = new Vector3(0.0f, 3.0f, 0.0f);
            Debug.Log(collision.gameObject.name);      //�ش������Ʈ�� �̸��� ����Ѵ�
        }
    }
}
