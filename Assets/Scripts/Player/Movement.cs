using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.currentState == GameManager.GameStates.InGame)
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

   
}
