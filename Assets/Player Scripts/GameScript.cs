using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public int x;
    public int y;
    
    public TileMap tiles;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
        y = tiles.height - 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkColor()
    {

    }
}
