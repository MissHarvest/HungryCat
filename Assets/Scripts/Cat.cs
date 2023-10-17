using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cat : MonoBehaviour
{
    float full = 5.0f;
    float energy = 0.0f;
    public GameObject energyBar;

    public float speed;

    enum EState { HUNGRY, FULL };
    EState curState = EState.HUNGRY;

    public GameManager.EType type;

    // Start is called before the first frame update
    void Start()
    {
        float x = Random.Range(-8.5f, 8.5f);
        transform.position = new Vector3(x, 30.0f, 0);
        energyBar.transform.localScale = new Vector3(0, 1, 1);

        switch(type)
        {
            case GameManager.EType.Noraml:
                full = 5.0f;
                speed = 5.0f;
                break;

            case GameManager.EType.Fat:
                full = 10.0f;
                speed = 3.0f;
                break;

            case GameManager.EType.Pirate:
                full = 3.0f;
                transform.localScale = new Vector3(0.8f, 0.8f, 0.8f);
                speed = 8.0f;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch(curState)
        {
            case EState.HUNGRY:
                transform.Translate(Vector3.down * speed * Time.deltaTime);
                if (transform.position.y < -18.0f) GameManager.Instance.Gameover();
                break;

            case EState.FULL:
                transform.Translate((transform.position.x >= 0 ? Vector3.right : Vector3.left) * speed * Time.deltaTime);                
                break;
        }        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Food"))
        {
            Destroy(collision.gameObject);
            energy += 1.0f;
            if (energy >= full)
            {
                energy = full;
                curState = EState.FULL;
                gameObject.transform.Find("full").gameObject.SetActive(true);
                gameObject.transform.Find("hungry").gameObject.SetActive(false);
                Destroy(gameObject, 3.0f);
                GetComponent<Collider2D>().enabled = false;
                GameManager.Instance.AddCat();
            }
            energyBar.transform.localScale = new Vector3(energy / full, 1, 1);
        }
    }
}
