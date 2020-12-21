using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zmz_EyesRange : MonoBehaviour
{
    public static bool IsTrriger;
    private void Awake()
    {
        IsTrriger = false;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("1");
        if (collision.transform.tag == "enemy")
            IsTrriger = true;
        Debug.Log("2");

    }
    void OnTriggerExit(Collider collision)
    {
        if (collision.transform.tag == "enemy")
            IsTrriger = false;
    }
}
