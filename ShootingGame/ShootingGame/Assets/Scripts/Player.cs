using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float Movement;
    float Delta;
    Animator animator;
    float aniMovement;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        this.Movement = 0.25f;
        this.Delta = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Delta += Time.deltaTime;

        this.animator.speed = 3f;

        if (Delta > 0.05f)
        {
            Delta = 0;

            Move();
        }

    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (!CheckLeft())
            {
                MoveLeft();
                this.animator.SetTrigger("LeftTrigger");
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            if (!CheckRight())
            {
                MoveRight();
                this.animator.SetTrigger("RightTrigger");
            }
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            if (!CheckDown())
                MoveDown();
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (!CheckUp())
                MoveUp();
        }
    }

    public bool CheckLeft()
    {
        bool isCheck = false;

        if (this.transform.position.x == -2.25f)
            isCheck = true;

        return isCheck;
    }

    public bool CheckRight()
    {
        bool isCheck = false;

        if (this.transform.position.x == 2.25f)
            isCheck = true;

        return isCheck;
    }

    public bool CheckDown()
    {
        bool isCheck = false;

        if (this.transform.position.y == -4.5f)
            isCheck = true;

        return isCheck;
    }

    public bool CheckUp()
    {
        bool isCheck = false;

        if (this.transform.position.y == 4.5f)
            isCheck = true;

        return isCheck;
    }

    public void MoveLeft()
    {
        this.transform.Translate(Vector2.left * Movement);
    }

    public void MoveRight()
    {
        this.transform.Translate(Vector2.right * Movement);
    }

    public void MoveDown()
    {
        this.transform.Translate(Vector2.down * Movement);
    }

    public void MoveUp()
    {
        this.transform.Translate(Vector2.up * Movement);
    }
}
