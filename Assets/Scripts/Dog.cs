using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEditor;
using UnityEngine;

public class Dog : MonoBehaviour
{
    public GameObject prefab_Food;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnFood", 0, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float x = mousePos.x > 9.0f ? 9.0f : mousePos.x < -9.0f ? -9.0f : mousePos.x;
        transform.position = new Vector3(x, transform.position.y, 0);
    }

    void SpawnFood()
    {
        Instantiate(prefab_Food, transform.position + Vector3.up, Quaternion.identity);
    }
}
