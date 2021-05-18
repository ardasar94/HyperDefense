using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavesController : MonoBehaviour
{
    [SerializeField] int waveCount;
    [SerializeField] float TimeBtwWaves = 5f;

    bool isSpawnEnd = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartWaves());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartWaves()
    {
        for (int i = 0; i < waveCount; i++)
        {
            yield return new WaitForSeconds(TimeBtwWaves);
            transform.GetChild(i).gameObject.SetActive(true);
        }
            //if (i + 1 == waveCount)
            //{
                isSpawnEnd = true;
            //}

    }

    public bool IsSpawnEnd() => isSpawnEnd;
}
