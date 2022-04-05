using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI countText, winText, timeText, loseText;
    // private Rigidbody rb;
    public float speed = 20.0f;
    public float turnSpeed = 50.0f;
    private int count;
    public float timeRemaining = 10;
    
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        count = 0;
        Debug.Log(SystemInfo.deviceUniqueIdentifier);
    }

    private void Update() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * speed * moveVertical);

        transform.Rotate(Vector3.up * Time.deltaTime * turnSpeed * moveHorizontal);

        if(timeRemaining > 0 && count < 37) {
            timeRemaining -= Time.deltaTime;
            if(timeRemaining < 0) timeRemaining = 0;
        }
        else if (timeRemaining == 0)
        {
            loseText.gameObject.SetActive(true);
            winText.gameObject.SetActive(false);
        }

        timeText.text = "Time : " + timeRemaining.ToString();
        
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("coin"))
        {
            other.gameObject.SetActive(false);
            count++;
            countText.text = "Score : " + count.ToString();
            if(count >= 37){
                winText.gameObject.SetActive(true);
                loseText.gameObject.SetActive(false);
            }
        }
    }

}
