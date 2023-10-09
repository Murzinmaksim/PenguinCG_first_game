using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject[] fishPrefab;
    private bool _decelerationEffect;
    private bool _startDeth;
    [SerializeField] private GameObject _music;

    void Start()
    {
        StartCoroutine(createFish());
        StartCoroutine(StartDeth());
    }

    private void MusicOn()
    {
        _music.SetActive(true);
    }

    private IEnumerator decelerationEffect()
    {
        yield return new WaitForSeconds(15f);
        _decelerationEffect = false;
    }

    private IEnumerator StartDeth()
    {
        yield return new WaitForSeconds(10f);
        _startDeth = true;
    }

    public void startDecelerationEffect()
    {
        _decelerationEffect = true;
        StartCoroutine(decelerationEffect());
        MusicOn();
    }

    private IEnumerator createFish()
    {
        yield return new WaitForSeconds(Random.Range(1f, 2f));

        int chance = Random.Range(0, 101);
        int fishId = 0;

        if (chance <= 40 && _startDeth == true)
        {
           fishId = 3;
        }
        else if(chance >= 55)
        {
           fishId = Random.Range(0, 3);
        }
        else
        {
           fishId = Random.Range(4, fishPrefab.Length);
        }

        GameObject fish = Instantiate(fishPrefab[fishId]);

        if (_decelerationEffect == true) {
            fish.GetComponent<Fish>().ifDecelerationEffect();
        }

        bool rightFish = Random.Range(0, 3) == 1;

        float y = Random.Range(-4.59f, 0f);
        float x;

        if (rightFish)
        {
            x = 11;
            fish.GetComponent<Fish>()._movment.x = -0.4f;
            fish.GetComponent<Transform>().Rotate(0f, 180f, 0f);

        } else{
            x = -11;
            fish.GetComponent<Fish>()._movment.x = 0.4f;
        }



        fish.GetComponent<Transform>().position = new Vector3(x,y,1);

        StartCoroutine(createFish());
    }
}
