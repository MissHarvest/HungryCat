using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    public GameObject[] prefabs_Cats;

    public GameObject ReplayBtn;

    public GameObject levelGroup;

    int level = 1;

    int cat = 0;

    private void Awake()
    {
        if(null == instance)
        {
            instance = this;
        }
    }

    public enum EType { Noraml, Fat, Pirate, Max };
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        InvokeRepeating("SpawnCats", 0, 2.0f);
    }

    void SpawnCats()
    {
        for(int i = 0; i < level; ++i)
        {
            int x = Random.Range(0, (int)EType.Max);
            Instantiate(prefabs_Cats[x]);
        }
    }

    public void Gameover()
    {
        Time.timeScale = 0;
        ReplayBtn.SetActive(true);
    }

    public void AddCat()
    {
        ++cat;
        level = cat / 5 + 1;

        levelGroup.transform.Find("front").transform.localScale = new Vector3((float)cat % 5 / 5, 1, 1);
        levelGroup.transform.Find("level").GetComponent<Text>().text = level.ToString();
    }
}
