using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TileMap : MonoBehaviour
{

    public int width;
    public int height;
    private float tileSize = 1.0f;
    public int tileRes;

    public Texture2D colorMap;
    public int[,] colors;
    


    void Start()
    {
        buildMesh();
        buildTexture();
        colors = new int[width, height];
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void buildMesh()
    {
        int numVert = (width + 1) * (height + 1);
        Vector3[] vertices = new Vector3[numVert];
        Vector3[]normals = new Vector3[numVert];
        Vector2[] uv = new Vector2[numVert];

        int[] triangles = new int[2 * width * height * 3];

        for (int z = 0; z < height+1; z++)
        {
            for (int x = 0; x<width+1; x++)
            {
                int cur = z * (width+1) + x;
                vertices[cur] = new Vector3(x * tileSize, 0, z * tileSize);
                normals[cur] = Vector3.up;
                uv[cur] = new Vector2((float)(x) / width , (float)(z) / height );
            }
        }

        for (int z = 0; z < height; z++)
        {
            for (int x = 0; x < width; x++)
            {
                int cur = z * width + x;
                int triIndex = cur * 6;

                int corner = z * (width + 1) + x;


                triangles[triIndex] = corner;
                triangles[triIndex+1] = corner+ ( width+1);
                triangles[triIndex + 2] = corner + (width + 1) + 1;
                triangles[triIndex+3] = corner;
                triangles[triIndex+4] = corner+(width+1) +1;
                triangles[triIndex + 5] = corner + 1;



            }
        }

        Mesh m = new Mesh();
        m.vertices =vertices;
        m.triangles = triangles;
        m.normals = normals;
        m.uv = uv;

        MeshFilter mf = GetComponent < MeshFilter > ();
        MeshRenderer mr = GetComponent<MeshRenderer>();
        MeshCollider mc = GetComponent<MeshCollider >();


        mf.mesh = m;
        mc.sharedMesh = m;
    }

    public void buildTexture()
    {
        Texture2D tex = new Texture2D(tileRes * width, tileRes * height);
        Debug.Log(tex.width);
        Debug.Log(tex.height);

        for (int y = 0; y<height; y++)
        {
            for(int x = 0; x<width; x++)
            {
                Color[] p = colorMap.GetPixels(colors[y, x]*tileRes, 0, tileRes, tileRes);
                tex.SetPixels(x * tileRes, y * tileRes, tileRes, tileRes, p);
            }
        }

        
        MeshRenderer mr = GetComponent<MeshRenderer>();
        mr.sharedMaterials[0].mainTexture = tex;
        setTransparent(mr.sharedMaterials[0]);

        tex.filterMode = FilterMode.Point;
        tex.wrapMode = TextureWrapMode.Clamp;
        tex.Apply();
    }

    void setTransparent(Material material)
    {
        material.SetOverrideTag("RenderType", "Transparent");
        material.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.One);
        material.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
        material.SetInt("_ZWrite", 0);
        material.DisableKeyword("_ALPHATEST_ON");
        material.DisableKeyword("_ALPHABLEND_ON");
        material.EnableKeyword("_ALPHAPREMULTIPLY_ON");
        material.renderQueue = (int)UnityEngine.Rendering.RenderQueue.Transparent;
    }
}

