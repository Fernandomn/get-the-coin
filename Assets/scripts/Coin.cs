using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public static int CoinCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        ++Coin.CoinCount;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Colidiu");
        if (other.CompareTag("Player"))
        {
            Debug.Log("BOOOOM!!!");
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        --Coin.CoinCount;

        if (Coin.CoinCount <= 0)
        {
            GameObject Timer = GameObject.Find("LevelTimer");
            Destroy(Timer);

            GameObject[] FireworksSystems = GameObject.FindGameObjectsWithTag("Fireworks");
            foreach (GameObject firework in FireworksSystems)
            {
                firework.GetComponent<ParticleSystem>().Play();
            }
        }
    }

}
