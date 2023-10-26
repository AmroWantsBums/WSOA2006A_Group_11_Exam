using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickup : MonoBehaviour
{
    public Vector3 CarryPoint;
    public GameObject CarryPointObject;
    public float RayLength;
    public TextMeshProUGUI PickupTxt;
    public GameObject PickupTxtObject;
    public bool Holding = false;
    public GameObject ObjectToDrop;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PickupTxtObject.SetActive(false);
        CarryPoint = CarryPointObject.transform.position;
        RaycastHit Hit;
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * RayLength, Color.green);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Hit, RayLength))
        {
            PickupTxtObject.SetActive(true);
            if (Hit.transform.gameObject.CompareTag("Liftable") && Input.GetKeyDown("f") && !Holding)
            {
                Holding = true;
                PickupObject(Hit.transform.gameObject);
            }
            if (Input.GetKeyDown("f") && Holding)
            {
                PickupTxt.text = "Press 'F' to drop the object";
                DropObject(ObjectToDrop);
            }
        }
    }

    void PickupObject(GameObject PickedObject)
    {
        PickedObject.transform.SetParent(gameObject.transform);
        PickedObject.transform.forward = gameObject.transform.forward;
        PickedObject.transform.position = CarryPoint;
        ObjectToDrop = PickedObject;
    }

    void DropObject(GameObject PickedObject)
    {
        PickedObject.transform.SetParent(null);
        Holding = false;
    }
}
