using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TrainManager : MonoBehaviour
{
    public float degrees=-90;

    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(TrainStart());
    }

    IEnumerator TrainStart()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = transform.up;

        yield return new WaitForSeconds(2f);

        Rotateobject();
    }

    public void Rotateobject()
    {
        Quaternion newRot = Quaternion.AngleAxis(degrees, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, newRot, 0.03f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "RailButton")
        {
            if (other.gameObject.GetComponent<Image>().sprite.name == "1")
            {
                degrees -= 90;
                Rotateobject();
            }
            if (other.gameObject.GetComponent<Image>().sprite.name == "1.1")
            {
                degrees += 90;
                Rotateobject();
            }
            if (other.gameObject.GetComponent<Image>().sprite.name == "2")
            {
                degrees += 90;
                Rotateobject();
            }
            if (other.gameObject.GetComponent<Image>().sprite.name == "2.1")
            {
                degrees -= 90;
                Rotateobject();
            }
            if (other.gameObject.GetComponent<Image>().sprite.name == "3")
            {
                degrees -= 90;
                Rotateobject();
            }
            if (other.gameObject.GetComponent<Image>().sprite.name == "3.1")
            {
                degrees += 90;
                Rotateobject();
            }
            if (other.gameObject.GetComponent<Image>().sprite.name == "4")
            {
                degrees += 90;
                Rotateobject();
            }
            if (other.gameObject.GetComponent<Image>().sprite.name == "4.1")
            {
                degrees -= 90;
                Rotateobject();
            }
        }
    }
}