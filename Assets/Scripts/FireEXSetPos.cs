using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FireEXSetPos : MonoBehaviour
{
    [SerializeField] private List<Transform> fireExPos;
    [SerializeField] private GameObject fireEx;
    private int index;
    private void Start()
    {
        //fireExPos = new List<Transform>(4);
        index = Random.Range(0, 3);
        Debug.Log(index);
        Instantiate(fireEx, fireExPos[index]);
    }
}
