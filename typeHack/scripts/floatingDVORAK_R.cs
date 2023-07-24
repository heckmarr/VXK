using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class floatingDVORAK_R : MonoBehaviour
{
    public GameObject gonne;
    public GameObject[] row1;

    private bool shown;
    private Renderer rend;
    private float spinStart;
    private float spinEnd;
    private float radiusAdded;
    private float oldRadius;
    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<Renderer>();
        rend.enabled = false;
        shown = false;
        radiusAdded = 0.0f;
        oldRadius = 0.0f;
        gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        //gameObject.SetActive(false);
    }
    List<Vector3> createVertices(float startAngle, float endAngle)
    {
        float radius = 0.0f;
        int segments = 6;
        
        if (gameObject.name.IndexOf("key0") != -1)
        {
            radius = 0.128f;

        }
        else if (gameObject.name.IndexOf("key1") != -1)
        {
            radius = 0.198f;

        }
        else if (gameObject.name.IndexOf("key2") != -1)
        {
            radius = 0.268f;

        }
        List<Vector3> arcPoints = new List<Vector3>();
        float angle = startAngle;
        float arcLength = endAngle - startAngle;
        for (int i = 0; i <= segments; i++)
        {
            float x = (Mathf.Sin(Mathf.Deg2Rad * angle) * radius);
            float y = (Mathf.Cos(Mathf.Deg2Rad * angle) * radius);

            arcPoints.Add(new Vector3((gonne.transform.position.x + x), (gonne.transform.position.y + y), gonne.transform.position.z));

            angle += (arcLength / 6);
        }

        return arcPoints;
    }
    // Update is called once per frame
    void Update()
    {
        
        bool frame = false;
        if (Input.GetButtonDown("XRI_Right_GripButton"))
        {
            rend.enabled = true;
            shown = true;    
        }
        if (Input.GetButtonUp("XRI_Right_GripButton"))
        {
            rend.enabled = false;
            shown = false;
        }
        //draw the keyboard
        List<Vector3> verts = createVertices(0.0f, 90.0f);
        for (int i = 0; i < verts.Count; i++)
        {

            if (shown)
            {
                //List<Vector3> vertInner = createVertices(0.0f, 90.0f);
                //row1[i].transform.position = verts[i];
                //gameObject.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);

            }
            else 
            {

                

                row1[i].transform.position = verts[i];

                
            }

        }
        

    }

}
