using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(Move());
    }


    IEnumerator Move()
    {

        //transform.Translate(transform.positio);
        yield return null;
    }
}
