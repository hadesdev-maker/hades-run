using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public float laneDistance = 4f; // The distance between lanes
    public float jumpHeight = 2f; // Height of the jump
    public float jumpDuration = 0.5f; // Duration of the jump

    private Rigidbody rb;

    private int currentLane = 1; // 0 = left, 1 = center, 2 = right
    private Vector3 targetPosition;

    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    private bool isSwiping = false;
    private float minSwipeDistance = 50f; // Minimum swipe distance to recognize a swipe

    private bool isJumping = false; // Track if the player is jumping

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false; // Disable gravity to allow manual jump control
        UpdateTargetPosition();
        Debug.Log("PlayerController script started.");
    }

    void Update()
    {
        // Handle swipe input
        DetectSwipe();

        // Smoothly move towards the target position
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
        rb.MovePosition(newPosition);

        Debug.Log("Current Position: " + transform.position + " | Target Position: " + targetPosition);
    }

    void DetectSwipe()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                touchStartPos = touch.position;
                isSwiping = true;
            }
            else if (touch.phase == TouchPhase.Ended && isSwiping)
            {
                touchEndPos = touch.position;
                isSwiping = false;
                HandleSwipe();
            }
        }
    }

    void HandleSwipe()
    {
        float swipeDistance = (touchEndPos - touchStartPos).magnitude;
        if (swipeDistance >= minSwipeDistance)
        {
            Vector2 swipeDirection = touchEndPos - touchStartPos;
            if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
            {
                if (swipeDirection.x > 0)
                {
                    MoveRight();
                    Debug.Log("Swiped Right");
                }
                else
                {
                    MoveLeft();
                    Debug.Log("Swiped Left");
                }
            }
            else
            {
                if (swipeDirection.y > 0 && !isJumping)
                {
                    StartCoroutine(Jump());
                    Debug.Log("Swiped Up (Jump)");
                }
            }
        }
    }

    void MoveLeft()
    {
        if (currentLane > 0)
        {
            currentLane--;
            UpdateTargetPosition();
            Debug.Log("Moved Left to lane: " + currentLane);
        }
        else
        {
            Debug.Log("Already in the leftmost lane");
        }
    }

    void MoveRight()
    {
        if (currentLane < 2)
        {
            currentLane++;
            UpdateTargetPosition();
            Debug.Log("Moved Right to lane: " + currentLane);
        }
        else
        {
            Debug.Log("Already in the rightmost lane");
        }
    }

    void UpdateTargetPosition()
    {
        targetPosition = new Vector3((currentLane - 1) * laneDistance, transform.position.y, transform.position.z);
        Debug.Log("Updated Target Position: " + targetPosition);
    }

    IEnumerator Jump()
    {
        isJumping = true;
        float elapsedTime = 0f;
        Vector3 startPosition = transform.position;
        Vector3 jumpPeak = new Vector3(transform.position.x, transform.position.y + jumpHeight, transform.position.z);

        // Move up to the peak
        while (elapsedTime < jumpDuration / 2)
        {
            transform.position = Vector3.Lerp(startPosition, jumpPeak, (elapsedTime / (jumpDuration / 2)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Move down back to the start position
        elapsedTime = 0f;
        while (elapsedTime < jumpDuration / 2)
        {
            transform.position = Vector3.Lerp(jumpPeak, startPosition, (elapsedTime / (jumpDuration / 2)));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = startPosition;
        isJumping = false;
    }

    void OnCollisionEnter(Collision other)
    {
        // Handle collision with the ground or other objects if needed
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Collided with Ground.");
        }
    }

    void OnCollisionExit(Collision other)
    {
        // Handle exit collision with the ground or other objects if needed
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Exited collision with Ground.");
        }
    }
}
