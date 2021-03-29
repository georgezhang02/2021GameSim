using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RefRot : MonoBehaviour
{
    private bool isRolling = false;
    private float duration;

    public int[] sides;

    public GameObject[] indicators;
    public Texture2D colorMap;
    public int tileRes;

    public Texture colors;


    private int pressed;

    void Start()
    {


        duration = 0.25f;
        sides = new int[] { 0, 1, 2, 3, 4, 5 };
        pressed = -1;



    }

    // Update is called once per frame
    void Update()
    {


        if (!isRolling)
        {
            if (Input.GetKey(KeyCode.UpArrow) || pressed == (int)KeyCode.UpArrow)
            {
                int[] sideRot = new int[] { 0, 3, 5, 1 };
                StartCoroutine(rotate(Vector3.right, 90f, sideRot));

            }
            else if (Input.GetKey(KeyCode.DownArrow) || pressed == (int)KeyCode.DownArrow)
            {

                int[] sideRot = new int[] { 0, 1, 5, 3 };
                StartCoroutine(rotate( Vector3.right, -90f, sideRot));


            }
            else if (Input.GetKey(KeyCode.LeftArrow) || pressed == (int)KeyCode.LeftArrow)
            {
                int[] sideRot = new int[] { 0, 4, 5, 2 };
                StartCoroutine(rotate(Vector3.forward, 90f, sideRot));


            }
            else if (Input.GetKey(KeyCode.RightArrow) || pressed == (int)KeyCode.RightArrow)
            {
                int[] sideRot = new int[] { 0, 2, 5, 4 };
                StartCoroutine(rotate(Vector3.forward, -90f, sideRot));


            }
        }
        

    }


    IEnumerator rotate(Vector3 euler, float angle, int[] sideRot)
    {
        isRolling = true;



        float timeElapsed = 0f;

        while (timeElapsed < .5 * duration)
        {
            transform.Rotate(euler, angle / duration * Time.deltaTime);
            timeElapsed += Time.deltaTime;


            yield return null;
        }


        while (timeElapsed < duration)
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
            transform.Rotate(euler, angle / duration * Time.deltaTime);
            timeElapsed += Time.deltaTime;


            yield return null;
        }



        transform.eulerAngles = new Vector3(90f * Mathf.Round(transform.eulerAngles.x / 90f),
                                       90f * Mathf.Round(transform.eulerAngles.y / 90f),
                                       90f * Mathf.Round(transform.eulerAngles.z / 90f));




        int temp = sides[sideRot[0]];

        for (int i = 3; i >= 0; i--)
        {
            sides[sideRot[(i + 1) % 4]] = sides[sideRot[i]];
        }
        sides[sideRot[1]] = temp;

        isRolling = false;

        pressed = -1;

        Texture2D tex = new Texture2D(tileRes, tileRes);
        for (int i = 0; i<4; i++)
        {
            Color[] p = colorMap.GetPixels(sides[1+i]* tileRes, 0, tileRes, tileRes);
            MeshRenderer mr = indicators[i].GetComponent<MeshRenderer>();
            mr.sharedMaterials[0].mainTexture = tex;

            tex.filterMode = FilterMode.Point;
            tex.wrapMode = TextureWrapMode.Clamp;
            tex.Apply();

        }

    }

    public void reset()
    {
        transform.eulerAngles = new Vector3(90, 0, 0);
    }


}
