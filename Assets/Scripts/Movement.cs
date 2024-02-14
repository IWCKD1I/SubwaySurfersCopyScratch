using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forwardSpeed;
    public float laneWidth;
    private int currentLane; // 0 Med, -1 Left, 1 Right
    private Vector3 targetPosition;
    public int SlideSpeed;
    
    public GameObject objectToActivate1;
    public GameObject objectToActivate2;
    
    public GameObject GameOver;

    // Start is called before the first frame update
    void Start()
    {
        objectToActivate1.SetActive(false);
        objectToActivate2.SetActive(false);
        GameOver.SetActive(false);
        targetPosition = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        HandleInput();

        
        // Smoothly move to the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, SlideSpeed * Time.deltaTime);
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow)&&(currentLane>-1))
        {
            currentLane--;
            MoveToLeftLane();
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow)&&(currentLane<1))
        {
            currentLane++;
            MoveToRightLane();
        }
    }

    void MoveToLeftLane()
    {
        // Calculate the new position in the left lane
        targetPosition = new Vector3(targetPosition.x - laneWidth, targetPosition.y, targetPosition.z);
    }
    
    void MoveForward()
    {
        // Move the player forward
        targetPosition = new Vector3(targetPosition.x, targetPosition.y, targetPosition.z + forwardSpeed * Time.deltaTime);
    }

    void MoveToRightLane()
    {
        // Calculate the new position in the right lane
        targetPosition = new Vector3(targetPosition.x + laneWidth, targetPosition.y, targetPosition.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coins"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Barrier"))
        {
            GameOver.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Game Over ");
        }
    }
    
    private void OnTriggerStay (Collider other)
    {
        

        if (other.CompareTag("Water"))
        {
            forwardSpeed = 2;
            objectToActivate1.SetActive(true);
            objectToActivate2.SetActive(true);
        }
        else 
        {
            forwardSpeed = 5;
            objectToActivate2.SetActive(false);
            objectToActivate1.SetActive(false);
        }
        }
}