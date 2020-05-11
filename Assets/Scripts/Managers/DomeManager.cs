using UnityEngine;

public class DomeManager : MonoBehaviour
{
    public GameObject domeObjects;
    public float domeRadius = 20;

    private void Start()
    {
        BuildDome(domeRadius);
    }

    public void BuildDome(float domeRadius)
    {
        float radius = domeRadius;
        int range = (int)domeRadius;
        
        for (int j=0;j <= range; j++)
        {
            radius = domeRadius * (Mathf.Cos(Mathf.PI / 2f * (j/ domeRadius) ));
            for (int i=0;i<360;i++)
            {
                float x = radius * Mathf.Sin(Mathf.PI * 2f * (((float)i) / 360f));
                float z = radius * Mathf.Cos(Mathf.PI * 2f * (((float)i) / 360f));
                float y = j;

                if ((i  >= 45 && i <= 90) || (i >= 225 && i <= 270) || (i >= 155 && i <= 175) || (i >= 325 && i <= 345))
                {
                     GameObject newDome = Instantiate(domeObjects, new Vector3(Mathf.RoundToInt(x), j, Mathf.RoundToInt(z)), Quaternion.identity);
                     newDome.transform.parent = gameObject.transform;   
                }

            }
        }
    }
}
