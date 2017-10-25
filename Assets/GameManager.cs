using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour {

    public static GameManager instance;

    public GameObject[] objs;
    public int[] levels = { 7, 15, 29, 52, 78, 114, 154, 214, 278, 352, 440, 540, 660, 790, 945, 1110, 
            1310, 1520, 1750, 2030, 2330, 2665, 3030, 3340, 3890, 4380, 4930, 5530, 6190, 6915, 7700, 8550, 
            9430, 10370, 11370, 12430, 13560, 14740, 16000, 17345, 18750, 20260, 21860, 23500 };

    private float minX = -13f;
    private float maxX = 13f;
    private float minY = -9f;
    private float maxY = 8.5f;

    public bool destroyMob0 = false;
    public bool destroyMob1 = false;
    public bool destroyMob2 = false;
    public Text textScore;
    public Text levelText;
    public int score = 0;
    public GameObject model1;
    public GameObject model2;

    private int level = 1;
    private int firstindex = 0;
    private bool instantiateModel2 = true;
    private GameObject player;
    public bool shootModel2 = false;
    public bool shootModel1 = false;

    private void Awake()
    {
        instance = this;
    }

    // Use this for initialization
    void Start () {
        SpawnResourse();
        UpdateScore(0);
        SpawnModel1();
    }
	
	// Update is called once per frame
	void Update () {
        if (destroyMob0)
        {
            destroyMob0 = false;
            GameObject obj = Instantiate(objs[0]) as GameObject;
            obj.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }

        if (destroyMob1)
        {
            destroyMob1 = false;
            GameObject obj = Instantiate(objs[1]) as GameObject;
            obj.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }

        if (destroyMob2)
        {
            destroyMob2 = false;
            GameObject obj = Instantiate(objs[2]) as GameObject;
            obj.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        }

        if (level >= 5)
        {
            if (instantiateModel2)
            {
                instantiateModel2 = false;
                shootModel2 = true;
                GameObject obj = Instantiate(model2) as GameObject;
                obj.transform.position = player.gameObject.transform.position;
                Destroy(player);
                shootModel1 = false;
            }
            
            

        }
    }

    private void SpawnModel1()
    {
        shootModel1 = true;
        player = Instantiate(model1) as GameObject;
        player.transform.position = new Vector2(0, 0);
    }

    private void SpawnResourse()
    {
        for(int i=0; i < objs.Length; i++)
        {
            GameObject obj = Instantiate(objs[i]) as GameObject;
            obj.transform.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            
        }
    }

    public void UpdateScore(int count)
    {
        score += count;
        textScore.text = score.ToString();
        UpdateLevel();
    }


    private void UpdateLevel()
    {
        for(int i=0; i < levels.Length; i++)
        {
            if (score <= levels[i])
            {
                level = i+1;
                break;
            }
            
        }
        levelText.text = level.ToString();
    }


}
