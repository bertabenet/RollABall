using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public Text countText;
    public Text winText;
    public AudioSource pickUpSound;
    public AudioSource winningSound;
    public Material greenMaterial;
    public GameObject fadingWall;

    // this is to hold the reference of the rigidbody we want to edit
    private Rigidbody rb;
    private int count;
    private bool canFade;
    private Color alpha;
    private float timeToFade = 2.0f;
    private int totalPickUps;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        setCountText();
        winText.text = "";
        canFade = false;
        alpha = fadingWall.GetComponent<MeshRenderer>().material.color;
        alpha.a = 0;
        totalPickUps = 14;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal"); //movement of left and right keys
        float moveVertical = Input.GetAxis("Vertical"); //movement of up and down keys

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        // adds force in order to move
        rb.AddForce(movement * speed);

        if (canFade)
        {
            fadingWall.GetComponent<MeshRenderer>().material.color = Color.Lerp(fadingWall.GetComponent<MeshRenderer>().material.color, alpha, timeToFade * Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If it is an object that is tagged as "Pick Up"
        if (other.gameObject.CompareTag("Pick Up"))
        {
            // Make the object disappear (not be destroyed)
            other.gameObject.SetActive(false);
            count += 1;
            if (count < totalPickUps) pickUpSound.Play();
            else winningSound.Play();
            setCountText();
        }

        if (other.gameObject.CompareTag("Button"))
        {
            other.gameObject.GetComponent<MeshRenderer>().material = greenMaterial;
            fadingWall.GetComponent<Collider>().enabled = false;
            canFade = true;
        }
    }

    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= totalPickUps)
        {
            winText.text = "You Win!";
        }
    }
}
