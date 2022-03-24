using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    public Material highlightedMaterial;
    Material previousMaterial;

    bool status;
    int limitForSelectable;
    GameObject objCurrent;
    [SerializeField] Text textObj;

    void Start()
    {
        Debug.Log(limitForSelectable);
    }

    void Update()
    {
        //-----------------Cast ray to the center of screen-------------------------------------------
        var ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        RaycastHit hit;

        //------------If Ray Hit Any Object (STARTS)----------------------------------------------
        if (Physics.Raycast(ray, out hit))
        {
            Debug.DrawRay(Camera.main.transform.position, hit.point, Color.red);
            var selection = hit.collider.gameObject;

            //-----------For Selectable Items only (STARTS)----------------------
            if (selection.CompareTag("Selectable"))
            {
                Debug.Log("Before Incr: " + limitForSelectable);
                limitForSelectable++;
                Debug.Log("After Incr: " + limitForSelectable);
                if (limitForSelectable == 1)
                {
                    objCurrent = hit.transform.gameObject;
                    previousMaterial = selection.GetComponent<Renderer>().material;
                    textObj.text = objCurrent.name;

                    Debug.Log(previousMaterial.name);
                    Debug.Log("if part Limit 1 gameobject: " + objCurrent.name);

                    selection.GetComponent<Renderer>().material = highlightedMaterial;
                    status = true;
                }
                else
                {
                    if (objCurrent != selection)
                    {
                        Debug.Log(limitForSelectable);
                        limitForSelectable = 0;
                        Debug.Log("Current Obj= " + selection);

                        textObj.text = "";

                        objCurrent.GetComponent<Renderer>().material = previousMaterial;
                        status = false;
                    }
                }
               
            }
            //-----------For Selectable Items only (ENDS)----------------------

            //----------For Floor or Any other objects raycast (STARTS)--------------
            //========USED Ignore Raycast Layer on floor-----------------------------
/*            else
            {
                if (status)
                {
                    limitForSelectable = 0;

                    Debug.Log("Else Part GameObject:==" + objCurrent.name);
                    Debug.Log("------" + previousMaterial.name);

                    textObj.text = "";

                    objCurrent.GetComponent<Renderer>().material = previousMaterial;
                    status = false;
                }
            }*/
            //----------For Floor or Any other objects raycast (ENDS)--------------
        }
        //-------------------If Ray Hit Any Object (ENDS)------------------------------------------

        //------------If Ray Does NOT Hit Any Object (STARTS)--------------------------------------
        else
        {
            if (status)
            {
                limitForSelectable = 0;

                Debug.Log("Else Part GameObject:==" + objCurrent.name);
                Debug.Log("------" + previousMaterial.name);

                textObj.text = "";

                objCurrent.GetComponent<Renderer>().material = previousMaterial;
                status = false;
            }

        }
        //------------If Ray Does NOT Hit Any Object (ENDS)--------------------------------------
    }
}