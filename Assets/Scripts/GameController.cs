using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Security.Cryptography;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameObject TrainPrefab;
    public Transform CapsulePanel;
    private int maxTrainCount;
    public int level;
    private bool isFirstOneDestroyed;
    public List<Color32> trainColors;
    public int score;
    public int aliveTrainCount;

    private void Awake()
    {
        instance = this;

        trainColors = new List<Color32>()
        {
            new Color32(255, 255, 0, 255), new Color32(255, 150, 0, 255), new Color32(255, 0, 0, 255),
            new Color32(255, 0, 255, 255), new Color32(150, 0, 255, 255), new Color32(0, 0, 255, 255),
            new Color32(0, 255, 255, 255), new Color32(0, 255, 0, 255), new Color32(0, 0, 0, 255),
            new Color32(150, 150, 150,255)
        };

        ShuFfle(trainColors);
    }

    //Tahmin edilemez sonuçlar almak için bu karýþtýrma fonksiyonunu hazýr kullandým.
    void ShuFfle<T>(List<T> list)
    {
        RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
        int n = list.Count;

        while (n > 1)
        {
            byte[] box = new byte[1];
            do provider.GetBytes(box);
            while (!(box[0] < n * (byte.MaxValue / n)));

            int k = (box[0] % n);
            n--;
            T temp = list[k];
            list[k] = list[n];
            list[n] = temp;

        }
    }

    void Start()
    {
        maxTrainCount = 0;
        InvokeRepeating("TrainMaking", 1f, 2f);
        TrainMaking();
        aliveTrainCount = level * 4;
    }

    private void Update()
    {
        if(aliveTrainCount <= 0)
        {
            SceneManager.LoadScene("GameScene 0");
        }
    }

    private void TrainMaking()
    {
        if(maxTrainCount<level*4)
        {
            GameObject Capsule = Instantiate(TrainPrefab, CapsulePanel);
            int Rnd = Random.Range(0, level * 2);
            Capsule.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().color = trainColors[Rnd];
            Capsule.transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = trainColors[Rnd];
            maxTrainCount++;
            if(!isFirstOneDestroyed)
            {
                Destroy(Capsule);
                maxTrainCount--;
                isFirstOneDestroyed = true;
            }
        }
    }
}