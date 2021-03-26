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

    public int lives;

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
        else if (lives == 0)
        {

        }
        else
        {
            if(player.x<0 || player.x> tiles.width ||player.y<0 ||player.y>tiles.height||
                tiles.colors[player.x, player.y]==-1)
            {
                lives--;
                reset();
            }
            else if (player.getColorInt(5) == tiles.colors[player.x, player.y]
            && !tiles.complete[player.x, player.y])
            {
                tiles.complete[player.x, player.y] = true;
                done++;
                
            }

            else if (player.getColorInt(5) != tiles.colors[player.x, player.y]
            && tiles.complete[player.x, player.y])
            {
                tiles.complete[player.x, player.y] = false;
                done--;
            }
            completion = done * 10000 / numTiles;


        }
        
    }

    public void reset()
    {

    }
}
