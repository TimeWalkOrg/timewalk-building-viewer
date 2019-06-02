using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeWalkShowObjects : MonoBehaviour
{
    //define a list where the prefabs will be stored
    public static List<GameObject> myListObjects = new List<GameObject>();

    //I used this to keep track of the number of objects I spawned in the scene.
    public static int numSpawned = 0;
    public static int numToSpawn = 3;
    public static int currentObjectIndex = 0;
    public static int objectsListLength = 0;
    public static GameObject currentObject;

    public AudioSource audioData;

    void Start()
    {
        // NOTE: make sure all building prefabs are inside this folder: "Assets/Resources/Prefabs"

        Object[] subListObjects = Resources.LoadAll("Prefabs", typeof(GameObject));
        foreach (GameObject subListObject in subListObjects)
        {
            GameObject lo = (GameObject)subListObject;
            myListObjects.Add(lo);
            ++objectsListLength;
        }
        GameObject myObj = Instantiate(myListObjects[currentObjectIndex]) as GameObject;
        currentObject = myObj;

        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
        Debug.Log("started");
    }



    void SpawnNextObject()
    {
        Destroy(currentObject);
        currentObjectIndex++;
        if(currentObjectIndex == objectsListLength)
        {
            currentObjectIndex = 0;
        }
        GameObject myObj = Instantiate(myListObjects[currentObjectIndex]) as GameObject;
        //myObj.transform.position = transform.position;
        currentObject = myObj;
    }

    void Update()
    {
        //if (OVRInput.GetUp(OVRInput.Button.One, OVRInput.Controller.RTouch))
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        // or Input.GetKeyDown(KeyCode.RightArrow)
        // Add in test for keyboard press too ("N" for next building?)

        {
            SpawnNextObject();
        }
    }

}
