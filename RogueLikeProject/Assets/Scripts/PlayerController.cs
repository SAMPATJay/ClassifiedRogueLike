using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private Rigidbody2D rb;
    
    void Start()
    {
        
    }

    void Update()
    {
        float moveX = Input.GetAxis("XMove") * moveSpeed;
        float moveY = Input.GetAxis("YMove") * moveSpeed;
        Debug.Log(moveX + " " + moveY);
        rb.velocity = new Vector2(moveX,moveY);
    }
}
