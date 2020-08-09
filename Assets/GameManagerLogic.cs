using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManagerLogic : MonoBehaviour
{
    public int totalItemCnt;
    public int stage;
    public Text stageCntText;
    public Text playItemCntText;

    private void Awake()
    {
        stageCntText.text = " / " + totalItemCnt.ToString();
    }
    public void getItem(int cnt)
    {
        playItemCntText.text = cnt.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            SceneManager.LoadScene(stage);
        }
    }

}
