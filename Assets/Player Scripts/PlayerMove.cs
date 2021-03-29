using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private GameScript game;
    private bool isRolling = false;
    private float duration;
    private float scale;

    public int[] sides;

    public int[] colorInt;

    public Texture colors;

    public bool falling;

    private int pressed;

    public int x = 0;
    public int y = 5;

    private int ogX;
    private int ogY;

    // Start is called before the first frame update
    void Start()
    {
        ogX = x;
        ogY = y;

        scale = transform.localScale.x / 2;
        duration = 0.25f;
        sides = new int[] { 0, 1, 2, 3, 4, 5 };
        pressed = -1;

        transform.position.Set(transform.position.x + x
            , transform.position.y, transform.position.z+y);
        falling = false;

        game = this.GetComponent<GameScript>();

    }

    // Update is called once per frame
    void Update()
    {
        

        if (!isRolling && !falling)
        {
            if (Input.GetKey(KeyCode.UpArrow) || pressed == (int)KeyCode.UpArrow)
            {
                int[] sideRot = new int[] { 0, 3, 5,1 };
                y--;
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.forward,
                    Vector3.right, 90f, sideRot));
                
            }
            else if (Input.GetKey(KeyCode.DownArrow) || pressed == (int)KeyCode.DownArrow)
            {
                
                int[] sideRot = new int[] { 0, 1, 5, 3 };
                y++;
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.back,
                        Vector3.right, -90f, sideRot));
                
                
            }
            else if (Input.GetKey(KeyCode.LeftArrow) || pressed == (int)KeyCode.LeftArrow)
            {
                int[] sideRot = new int[] { 0, 4, 5, 2 };
                x--;
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.left,
                    Vector3.forward, 90f, sideRot));
                
                
            }
            else if (Input.GetKey(KeyCode.RightArrow) || pressed == (int)KeyCode.RightArrow)
            {
                int[] sideRot = new int[] { 0, 2, 5, 4 };
                x++;
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.right,
                        Vector3.forward, -90f, sideRot));
                
                
            }
        } else if (!isRolling && falling)
        {
            if (transform.position.y > -20f)
            {
                transform.position.Set(transform.position.x,
                    transform.position.y - 20f / 100000f * Time.deltaTime,
                    transform.position.z);
            }
            else
            {
                falling = false;
                game.reset();
            }
        }
        
    }


    IEnumerator rotateAbout(Vector3 pivot, Vector3 axis, float angle, int[]sideRot)
    {
        isRolling = true;

        pivot += new Vector3(0, -scale, 0);


        float timeElapsed = 0f;

         while (timeElapsed < .5*duration)
         {
             transform.RotateAround(pivot, axis, angle/duration*Time.deltaTime);
             timeElapsed += Time.deltaTime;


            yield return null;
         }


        while (timeElapsed <  duration)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                pressed = (int)KeyCode.UpArrow;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                pressed = (int)KeyCode.DownArrow;

            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                pressed = (int)KeyCode.LeftArrow;

            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                pressed = (int)KeyCode.RightArrow;

            }
            transform.RotateAround(pivot, axis, angle / duration * Time.deltaTime);
            timeElapsed += Time.deltaTime;


            yield return null;
        }



        transform.eulerAngles = new Vector3(90f * Mathf.Round(transform.eulerAngles.x / 90f),
                                       90f * Mathf.Round(transform.eulerAngles.y / 90f),
                                       90f * Mathf.Round(transform.eulerAngles.z / 90f));

        transform.position = new Vector3(Mathf.Round(transform.position.x),
                                       0f,
                                       Mathf.Round(transform.position.z));

        

        int temp = sides[sideRot[0]];

        for (int i = 3; i>=0; i--)
        {
            sides[sideRot[(i + 1) % 4]] = sides[sideRot[i]];
        }
        sides[sideRot[1]] = temp;

        isRolling = false;

        pressed = -1;

        game.checkColor();
        game.moves++;


    }

    

    public int getColorInt(int side)
    {
        return colorInt[sides[side]];
    }

    public void reset()
    {
        x = ogX;
        y = ogY;
        transform.eulerAngles = new Vector3(0, 0 , 0);
        transform.position.Set(transform.position.x + x
            , transform.position.y, transform.position.z + y);
        falling = false;
    }


}
