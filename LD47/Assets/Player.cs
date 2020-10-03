using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public enum MoveState {circle, eight};

    public Transform centerPoint;
    public float sideOffset = 5;
    public float speed = 10f;
    private bool isRight = true;
    private int inversion = 1;
    public GameObject psObject;

    [HideInInspector]
    public MoveState moveState = MoveState.circle;
    [HideInInspector]
    public bool canSwitch = true;
    public float switchTime = 0.2f;
    private float ticker;
    public Camera cam;
    private Color startColor;
    public Color inputColor;

    private void Start()
    {
        startColor = cam.backgroundColor;
    }

    void Update()
    {
        if(canSwitch)
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                InputMade();
                if (moveState == MoveState.circle)
                {
                    transform.localPosition = new Vector3(0, 0, 0);
                    moveState = MoveState.eight;
                }
                else
                {
                    transform.localPosition = new Vector3(3, 0, 0);
                    moveState = MoveState.circle;
                }
                return;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                InputMade();
                inversion *= -1;
                return;
            }
        }
        else
        {
            ticker -= Time.deltaTime;
            cam.backgroundColor = Color.Lerp(startColor, inputColor, ticker / switchTime);
            if(ticker <= 0)
            {
                canSwitch = true;
            }
        }


        
    }

    private void InputMade()
    {
        canSwitch = false;
        ticker = switchTime;
        cam.backgroundColor = inputColor;

    }

    private void FixedUpdate()
    {

            switch (moveState)
            {
                case (MoveState.circle):

                    transform.RotateAround(centerPoint.position, Vector3.forward * inversion, speed * Time.fixedDeltaTime);

                    break;

                case (MoveState.eight):
                    
                if(isRight)
                {
                    transform.RotateAround(centerPoint.position + new Vector3(0, sideOffset, 0), Vector3.forward * inversion, speed * Time.fixedDeltaTime);

                    if(inversion > 0)
                    {
                        if (transform.localPosition.y < 0.02f && transform.localPosition.x <= 0f)
                        {
                            transform.localPosition = new Vector3(0, 0, 0);
                            isRight = false;
                            break;
                        }
                    } 
                    else
                    {
                        if (transform.localPosition.y < 0.02f && transform.localPosition.x >= 0f)
                        {
                            transform.localPosition = new Vector3(0, 0, 0);
                            isRight = false;
                            break;
                        }
                    }
                    

                }

                if (!isRight)
                {
                    transform.RotateAround(centerPoint.position + new Vector3(0, -sideOffset, 0), Vector3.back * inversion, speed * Time.fixedDeltaTime);

                    if(inversion > 0)
                    {
                        if (transform.localPosition.y > -0.02f && transform.localPosition.x <= 0f)
                        {
                            transform.localPosition = new Vector3(0, 0, 0);
                            isRight = true;
                            break;
                        }
                    }
                    else
                    {
                        if (transform.localPosition.y > -0.02f && transform.localPosition.x >= 0f)
                        {
                            transform.localPosition = new Vector3(0, 0, 0);
                            isRight = true;
                            break;
                        }
                    }
                    

                }


                break;

                default:

                    break;
            }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            var obj = Instantiate(psObject, transform.position, Quaternion.identity);
            Destroy(obj, 10f);
            Destroy(gameObject);
        }
    }
}
