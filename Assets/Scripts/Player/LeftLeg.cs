using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftLeg : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed = 1f;
    [Header("Borders")]
    [SerializeField] private float minimumX = -3.1f;
    [SerializeField] private float maximumX = -1.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.currentState == GameManager.GameStates.InGame)
        {
            SetBorder();

            LegController();
        }
    }

    private void LegController()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
    }

    private void SetBorder()
    {
        if (transform.position.x <= minimumX)
        {
            transform.position = new Vector3(minimumX, transform.position.y, transform.position.z);
        }
        else if (transform.position.x >= maximumX)
        {
            transform.position = new Vector3(maximumX, transform.position.y, transform.position.z);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Lav"))
        {
            GameManager.Instance.currentState = GameManager.GameStates.GameOver;
        }
    }

}
