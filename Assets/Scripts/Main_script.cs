using System.Diagnostics;
using UnityEditor.Callbacks;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.UIElements;

public class Main_script : MonoBehaviour
{
    [Header (" movement ")]
    [SerializeField] protected float speed;
    [SerializeField] protected float jump ;

    [Header (" component ")]
    protected Rigidbody2D rb ;
    protected Animator anime ;

    [Header(" Ground ")]
    [SerializeField] protected bool isGrounded;
    [SerializeField] protected float Ground_distance ;
    [SerializeField] protected LayerMask What_is_ground;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anime = GetComponentInChildren<Animator>();
    }
    
    // for basic movement and jump 
    protected virtual void movement_info(float direction) => rb.linearVelocity = new Vector2(speed*direction ,rb.linearVelocity.y);
    protected virtual void jump_info(float direction) => rb.linearVelocity = new Vector2(rb.linearVelocity.x , jump);

    // is for the Ground Check and Distance info and can be use with the basic jumps 
    protected virtual void Ground_collision() => isGrounded = Physics2D.Raycast(transform.position , Vector2.down,Ground_distance, What_is_ground);
    protected virtual void OnDrawGizmos() => Gizmos.DrawLine(transform.position , transform.position + new Vector3 (0,-Ground_distance));

    // flip code for the main which can be reused in the player and enemny 
    protected void flip(float direction)
    {
        if(direction == 0 ) return;

        Vector3 scale = transform.localScale;
        scale.x = direction >0 ? 1 : -1 ;
        transform.localScale = scale;
    }
}
