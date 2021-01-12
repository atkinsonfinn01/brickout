using UnityEngine;
using UnityEngine.UI;


class Bat : MonoBehaviour
{

    // Defining variables to detect key inputs
    public KeyCode moveLeftKey = KeyCode.LeftArrow;
    public KeyCode moveRightKey = KeyCode.RightArrow;

    // Boolean variables to detect if the bat can move or not
    bool canMoveLeft = true;
    bool canMoveRight = true;

    // determines speed and default direction of the paddle
    public float speed = 0.2f;
    float direction = 0.0f;

   
    


    void FixedUpdate()
    {

        Vector3 position = transform.localPosition;
        position.x += speed * direction;
        transform.localPosition = position;

    }


    
    void Update()
    {

     
        
        // Detects if key inputs are made 
        bool isLeftPressed = Input.GetKey(moveLeftKey);
        bool isRightPressed = Input.GetKey(moveRightKey);

       
        // For moving left
        if (isLeftPressed && canMoveLeft)
        {
            direction = -1.0f;
        }

        // For moving right
        else if (isRightPressed && canMoveRight)
        {
            direction = 1.0f;
        }

        // For not moving
        else
        {
            direction = 0.0f;
        }

    }


    // detects collisions against walls
    void OnCollisionEnter2D(Collision2D other)
    {

        // to check if the bat can move 
        switch (other.gameObject.name)
        {
            case "Left Wall":
                canMoveLeft = false;
                break;

            case "Right Wall":
                canMoveRight = false;
                break;
        }

    }


    // collision detection against walls
    void OnCollisionExit2D(Collision2D other)
    {

        // checks if bat is not touching walls 
        switch (other.gameObject.name)
        {
            case "Left Wall":
                canMoveLeft = true;
                break;

            case "Right Wall":
                canMoveRight = true;
                break;
        }

    }

}
    

