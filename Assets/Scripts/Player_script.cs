using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class Player_script : Main_script
{
    float XInput ;
    private bool tutorialTriggered = false;
    void Update()
    {
        XInput = Input.GetAxisRaw("Horizontal");
        Ground_collision();

        if (isGrounded && !tutorialTriggered)
        {
            tutorialTriggered = true;
            FindFirstObjectByType<TutorialManager>().PlayerLanded();
        }

        handel_input();
        handel_animations();
    }

    // for input of the horizon where our player and for the input of the keyboard for the movement 

    protected void handel_input()
    {
        movement_info(XInput);
        if(Input.GetKeyDown(KeyCode.Space)&& isGrounded)
            jump_info(XInput);
        flip(XInput);
    }

    // for handeling animations also animations for everything is diffrent so we make animations diffrenate for everything u can't re use the same animations 
    protected virtual void handel_animations()
    {
        anime.SetFloat("xVelocity", rb.linearVelocity.x);
        anime.SetFloat("yVelocity", rb.linearVelocity.y);
        anime.SetBool("isGrounded" , isGrounded);
    }
}
