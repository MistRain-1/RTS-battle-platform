using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript :MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string a = "ad11";
       reverseString(ref a);
        Debug.Log(a);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void reverseString(ref string pstring)
    {

        char[] a = pstring.ToCharArray();

        for (int i = 0; i < pstring.Length; i++)
        {
            Debug.Log(i);
            a[i] = pstring[pstring.Length - 1 - i];
        }

        pstring = string.Concat<char>(a);
    }
}
