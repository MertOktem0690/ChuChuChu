using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainCheck : MonoBehaviour
{
    public Text ScoreCheck;

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Train")
        {
            if (collision.transform.GetChild(0).GetComponent<SpriteRenderer>().color == gameObject.GetComponent<Image>().color)
            {
                GameController.instance.score++;
                ScoreCheck.text = "Score :" + GameController.instance.score;
                //Debug.Log("increase score");
            }
            Destroy(collision.gameObject);
            GameController.instance.aliveTrainCount--;
        }
    }
}