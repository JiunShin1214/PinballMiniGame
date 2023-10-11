using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Plane")
        {
            Destroy(gameObject);
            Debug.Log(GameObject.FindGameObjectsWithTag("Pin").Length-1);

        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
