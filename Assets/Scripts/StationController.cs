using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using System.Security.Cryptography;

public class StationController : MonoBehaviour
{
    public List<Image> stationImages = new List<Image>();

    void Start()
    {
        for (int i = 0; i < stationImages.Count; i++)
        {
            stationImages[i].color = GameController.instance.trainColors[i];
        }
    }
}
