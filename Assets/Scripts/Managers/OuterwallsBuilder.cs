using UnityEngine;

public class OuterwallsBuilder : MonoBehaviour
{

    public GameObject[] walls;

    public int wallWidth = 20;
    public int mapHeight = 20;

    public int spacing = 3;
    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            for (int h = -40; h < mapHeight - 40; h += 79)
            {
                for (int w = -20; w < wallWidth - 20; w++)
                {
                    if (i == 0)
                    {
                        Vector3 pos = new Vector3(w * spacing, i, h * spacing);
                        int n = Random.Range(0, walls.Length);
                        Instantiate(walls[n], pos, Quaternion.identity);
                    }
                    else if(w % 2 == 0)
                    {
                        Vector3 pos = new Vector3(w * spacing, i, h * spacing);
                        int n = Random.Range(0, walls.Length);
                        Instantiate(walls[n], pos, Quaternion.identity);
                    }
                }
            }
        }

        for (int i = 0; i < 2; i++)
        {
            for (int h = -40; h < mapHeight - 40; h++)
            {
                for (int w = -20; w < wallWidth - 20; w += 40)
                {
                    if (i == 0)
                    {
                        Vector3 pos = new Vector3(w * spacing, i, h * spacing);
                        int n = Random.Range(0, walls.Length);
                        Instantiate(walls[n], pos, Quaternion.identity);
                    }
                    else if( h % 2 == 0)
                    {
                        Vector3 pos = new Vector3(w * spacing, i, h * spacing);
                        int n = Random.Range(0, walls.Length);
                        Instantiate(walls[n], pos, Quaternion.identity);
                    }
                }
            }
        }
    }
}
