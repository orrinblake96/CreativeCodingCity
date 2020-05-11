using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityBuildingsBuilder : MonoBehaviour
{
    public GameObject[] buildings;

    public int wallWidth = 20;
    public int mapHeight = 20;

    public int spacing = 3;
    // Start is called before the first frame update
    private void Start()
    {
        for (int h = -2; h < mapHeight - 97; h++)
        {
            for (int w = -30; w < wallWidth - 30; w += 60)
            {
                if (w == -30)
                {
                    Vector3 pos = new Vector3(w * 2, 0, h * spacing);
                    int n = Random.Range(0, buildings.Length);
                    Instantiate(buildings[n], pos, Quaternion.Euler(0, 90, 0));   
                }
                else
                {
                    Vector3 pos = new Vector3(w * 2, 0, h * spacing);
                    int n = Random.Range(0, buildings.Length);
                    Instantiate(buildings[n], pos, Quaternion.Euler(0, -90, 0));
                }
            }
        }
        
        for (int h = -2; h < mapHeight - 97; h += 4)
        {
            for (int w = -3; w < wallWidth - 105; w++)
            {
                if (h == -2)
                {
                    Vector3 pos = new Vector3(w * spacing, 0, h * spacing);
                    int n = Random.Range(0, buildings.Length);
                    Instantiate(buildings[n], pos, Quaternion.identity);
                }
                else
                {
                    Vector3 pos = new Vector3(w * spacing, 0, h * spacing);
                    int n = Random.Range(0, buildings.Length);
                    Instantiate(buildings[n], pos, Quaternion.Euler(0, 180, 0));
                }
            }
        }
    }
}
