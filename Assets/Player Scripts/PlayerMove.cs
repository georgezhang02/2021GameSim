using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    bool isRolling = false;
    public float duration;
    float scale;
    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale.x / 2;
        duration = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!isRolling)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.forward,
                    Vector3.right, 90f));
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.back,
                    Vector3.right, -90f));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.left,
                    Vector3.forward, 90f));
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                Debug.Log(" Pressed");
                StartCoroutine(rotateAbout(transform.position + scale * Vector3.right,
                    Vector3.forward, -90f));
                
            }
           
        }
        
    }


    IEnumerator rotateAbout(Vector3 pivot, Vector3 axis, float angle)
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



        transform.eulerAngles = new Vector3(90f * Mathf.Round(transform.rotation.x / 90f),
                                       Mathf.Round(transform.rotation.y / 90f),
                                       Mathf.Round(transform.rotation.z / 90f));

        transform.position = new Vector3(Mathf.Round(transform.position.x),
                                       0.5f,
                                       Mathf.Round(transform.position.z));

        isRolling = false;

    }
}
