using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{

    private PlayerMove player;
    public TileMap tiles;
    public TileMap target;
    public int completion;
    public int done;
    public int numTiles;

    public int moves;

    public Texture2D colorMap;


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

        }
        
    }
    public void checkColor()
    {
        if(player.x>=0 && player.y>=0 && player.x<target.width && player.y < target.height)
        {
            if (target.colors[player.y, player.x] != -1)
            {
                if (target.colors[player.y, player.x] != tiles.colors[player.y, player.x] && 
                    player.getColorInt(5) == target.colors[player.y, player.x]) done++;
                else if(target.colors[player.y, player.x] == tiles.colors[player.y, player.x] &&
                    player.getColorInt(5) != target.colors[player.y, player.x]) done--;
            }

            tiles.colors[player.y, player.x] = player.getColorInt(5);
        }

        tiles.buildTexture();

        completion = done * 10000 / numTiles;
    }


    public void reset()
    {
        player.reset();
    }
}
