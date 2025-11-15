using System;
using UnityEngine;
public class FireExHand:MonoBehaviour
{
    public string parentTag;

    private void Start()
    {
        parentTag = transform.parent.tag;
        Debug.Log("Parent tag is: " + parentTag);
    }
}
