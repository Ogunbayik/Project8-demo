using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private bool isRight = true;
    [Header("Borders")]
    [SerializeField] private float maximumX;
    [SerializeField] private float minimumX;
    [Space]
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.Instance.currentState == GameManager.GameStates.InGame)
        Movement();
    }

    private void Movement()
    {
        if (isRight)
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
            
            if(transform.position.x >= maximumX)
            {
                isRight = false;
            }
        }
        else
        {
            transform.position -= new Vector3(speed, 0, 0) * Time.deltaTime;

            if(transform.position.x <= minimumX)
            {
                isRight = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.currentState = GameManager.GameStates.GameOver;
        }
    }
}
