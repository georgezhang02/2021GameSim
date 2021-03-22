using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private bool isRolling = false;
    private float duration;
    private float scale;

    public int[] sides;

    public int[] colorInt;

    public Texture colors;


    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.x / 2;
        duration = 0.5f;
        sides = new int[] { 0, 1, 2, 3, 4, 5 };
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!isRolling)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                int[] sideRot = new int[] { 0, 3, 5,1 };
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.forward,
                    Vector3.right, 90f, sideRot));
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            { 
                int[] sideRot = new int[] { 0, 1, 5, 3 };
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.back,
                        Vector3.right, -90f, sideRot));
                
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                int[] sideRot = new int[] { 0, 4, 5, 2 };
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.left,
                    Vector3.forward, 90f, sideRot));
                
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                int[] sideRot = new int[] { 0, 2, 5, 4 };
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.right,
                        Vector3.forward, -90f, sideRot));
                
            }
           
        }
        
    }


    IEnumerator rotateAbout(Vector3 pivot, Vector3 axis, float angle, int[]sideRot)
    {
        isRolling = true;

        pivot += new Vector3(0, -scale, 0);


        float timeElapsed = 0f;

         while (timeElapsed < duration)
         {
             transform.RotateAround(pivot, axis, angle/duration*Time.deltaTime);
             timeElapsed += Time.deltaTime;

            yield return null;
         }



        transform.eulerAngles = new Vector3(90f * Mathf.Round(transform.eulerAngles.x / 90f),
                                       90f * Mathf.Round(transform.eulerAngles.y / 90f),
                                       90f * Mathf.Round(transform.eulerAngles.z / 90f));

        transform.position = new Vector3(Mathf.Round(transform.position.x),
                                       0f,
                                       Mathf.Round(transform.position.z));

        isRolling = false;

        int temp = sides[sideRot[0]];

        for (int i = 3; i>=0; i--)
        {
            sides[sideRot[(i + 1) % 4]] = sides[sideRot[i]];
        }
        sides[sideRot[1]] = temp;


    }

    public int getColorInt(int side)
    {
        return colorInt[sides[side]];
    }

    
}
