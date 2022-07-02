using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class playerController : MonoBehaviour
{

    private Rigidbody playerRigidbody;
    private float moveX, moveY;
    public float speed = 0;
    public TextMeshProUGUI coinsText;
    public TextMeshProUGUI winText;
    private int count = 0;
    public int winCount;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        setCount();
        checker();

        winText.text = "You Won the Game";
        winText.gameObject.SetActive(false);
    }

    void OnMove(InputValue playerInput)
    {
        Vector2 moveVec = playerInput.Get<Vector2>();
        moveX = moveVec.x;
        moveY = moveVec.y;
    }

    void setCount()
    {
        coinsText.text = "Coins: " + count;

        if (count >= winCount)
        {
            winText.gameObject.SetActive(true);
        }

    }


    void checker()
    {
        Vector3 mypos = new Vector3();
        mypos = transform.position;
        if(mypos.y <= -0.01f)
        {
            winText.text = "You lost";
            winText.gameObject.SetActive(true);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 playerMover = new Vector3(moveX, 1.0f, moveY);
        playerRigidbody.AddForce(playerMover * speed);

        setCount();
        checker();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coins"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
    }

}

