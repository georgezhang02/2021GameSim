using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{

    private PlayerMove player;
    public TileMap tiles;
    public int completion;
    public int done;
    public int numTiles;

    // Start is called before the first frame update
    void Start()
    {
        player= this.GetComponent<PlayerMove>();
        done = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (done==numTiles)
        {

        }
        else
        {
            if (player.getColorInt(5) == tiles.colors[player.x, player.y]
            && !tiles.complete[player.x, player.y])
            {
                tiles.complete[player.x, player.y] = true;
                done++;
                
            }

            if (player.getColorInt(5) != tiles.colors[player.x, player.y]
            && tiles.complete[player.x, player.y])
            {
                tiles.complete[player.x, player.y] = false;
                done--;
            }
            completion = done * 10000 / numTiles;
        }
        
    }

    public void checkColor()
    {

    }
}
