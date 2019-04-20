using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Collections;

public class roomSpawner : MonoBehaviour
{
    GameObject roomtToSpawn;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Called on object initiation
    void Awake()
    {
        roomtToSpawn = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/Prefab/Rooms/2/Corridor.prefab", typeof(GameObject));
        Quaternion rot = new Quaternion();
        rot.Set(0, 0, 0, 0);

        Transform entranceDoor = roomtToSpawn.transform.Find("Entrance").Find("SpawnPoint");
        Debug.Log(entranceDoor);
        Transform spawnTransform = transform;
        spawnTransform.rotation = rot;
        var spawnedRoom = Instantiate(roomtToSpawn, transform.position, rot);
        spawnedRoom.transform.Find("Entrance").position.Set(transform.position.x, transform.position.y, transform.position.z);
        
    }
}
