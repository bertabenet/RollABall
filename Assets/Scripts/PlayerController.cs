using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;

    // this is to hold the reference of the rigidbody we want to edit
    private Rigidbody rb;
    private int count;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //movement of left and right keys
        float moveVertical = Input.GetAxis("Vertical"); //movement of up and down keys

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // adds force in order to move
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // If it is an object that is tagged as "Pick Up"
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // Make the object disappear (not be destroyed)
            other.gameObject.SetActive(false);
            count += 1;
            setCountText();
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 12)
        {
            winText.text = "You Win!";
        }
    }
}
