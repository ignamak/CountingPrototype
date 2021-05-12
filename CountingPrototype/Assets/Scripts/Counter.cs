using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public enum CounterType { ZERO, FIFTY, HUNDRED, TWOHUNDRED}

    public CounterType counterType;

    public Text CounterText;

    static int Count = 0;

    private void Start()
    {
        Count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (counterType)
        {
            case CounterType.ZERO:
                
                break;
            case CounterType.FIFTY:
                Count += 50;
                CounterText.text = "SCORE : " + Count;
                break;
            case CounterType.HUNDRED:
                Count += 100;
                CounterText.text = "SCORE : " + Count;
                break;
            case CounterType.TWOHUNDRED:
                Count += 200;
                CounterText.text = "SCORE : " + Count;
                break;
            default:
                break;
        }

        Destroy(other.gameObject);


    }
}
