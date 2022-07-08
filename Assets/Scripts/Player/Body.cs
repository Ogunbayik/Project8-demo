using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Body : MonoBehaviour 
{
    private Movement movement;
    public bool isSlowing = false;

    [Header("Speed")]
    [SerializeField] private float setScale = 4f;
    [Header("Borders")]
    [SerializeField] private float maxScale = 7f;
    [SerializeField] private float minScale = 3f;
    // Start is called before the first frame update
    void Start()
    {
        movement = FindObjectOfType<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentState == GameManager.GameStates.InGame)
        {
            BodyController();

            SetBorder();
        }

        SlowMovement();
    }

    private void BodyController()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.localScale += new Vector3(setScale, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.localScale -= new Vector3(setScale, 0, 0) * Time.deltaTime;
        }
    }

    private void SetBorder()
    {
        if (transform.localScale.x >= maxScale)
        {
            transform.localScale = new Vector3(maxScale, 1, 1);
        }
        else if (transform.localScale.x <= minScale)
        {
            transform.localScale = new Vector3(minScale, 1, 1);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("FinishLine"))
        {
            isSlowing = true;

          
            Debug.Log("Finish");
        }
    }
    public void SlowMovement()
    {
        if(isSlowing)
        movement.speed -= 1f * Time.deltaTime;

        if (movement.speed <= 0)
        {
            movement.speed = 0;
            GameManager.Instance.currentState = GameManager.GameStates.NextLevel;
        }
    }
}
