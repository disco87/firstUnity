using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerBall : MonoBehaviour
{
    Rigidbody rigid;
    public float jumpPower;
    bool isJump;
    AudioSource audio;
    public int itemCnt;
    public GameManagerLogic manager;


    private void Awake()
    {
        isJump = false;
        rigid = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    void Start()
    {
        
    }

    private void FixedUpdate()
    {//물리기반 업데이트
     //입력값을 변수에 넣는다
        float h = Input.GetAxis("Horizontal");
        float w = Input.GetAxis("Vertical");


        Vector3 vector3 = new Vector3(w , 0, h * -1);//x,y,z
        rigid.AddForce(vector3, ForceMode.Impulse);//기본적인 이동
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump") && isJump == false)
        {
            isJump = true;
            rigid.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            isJump = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Item")//tag로 비교하여 중복되는 gameobject도 동일하게 하나의 오브젝트로 사용가ㅛ
        {
            itemCnt++;
            audio.Play();
            other.gameObject.SetActive(false);
            manager.getItem(itemCnt);   
            Debug.Log(itemCnt);
        }else if(other.tag == "Finish")
        {
            if(manager.totalItemCnt == itemCnt)
            {
                Debug.Log("Game Clear");

                SceneManager.LoadScene((manager.stage + 1));
            }
            else
            {
                //restart
                SceneManager.LoadScene(manager.stage);

            }
        }
    }
}
