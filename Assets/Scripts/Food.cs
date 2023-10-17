using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Food : MonoBehaviour
{
    public float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
        if(transform.position.y >= 26.0f)
        {
            Destroy(gameObject);
        }
    }
}
