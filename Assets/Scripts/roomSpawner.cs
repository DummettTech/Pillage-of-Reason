using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.IO;

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
        string[] oneRooms = Directory.GetFiles("Assets/Prefab/Rooms/1", "*.prefab", SearchOption.AllDirectories);
        string[] twoRooms = Directory.GetFiles("Assets/Prefab/Rooms/2", "*.prefab", SearchOption.AllDirectories);
        string[] threeRooms = Directory.GetFiles("Assets/Prefab/Rooms/3", "*.prefab", SearchOption.AllDirectories);
        string[] fourRooms = Directory.GetFiles("Assets/Prefab/Rooms/4", "*.prefab", SearchOption.AllDirectories);

        string[][] roomsList = new string[][] { oneRooms, twoRooms, threeRooms, fourRooms };

        System.Random rnd = new System.Random();

        int roomSize;

        int numberOfRooms = GameObject.FindGameObjectsWithTag("room").Length;

        if (numberOfRooms >= 10)
        {
            roomSize = 0;
        } else
        {
            roomSize = rnd.Next(0, 4);
        }

        int roomNum = rnd.Next(0, roomsList[roomSize].Length);

        roomtToSpawn = (GameObject)AssetDatabase.LoadAssetAtPath(roomsList[roomSize][roomNum], typeof(GameObject));

        spawnRoom(roomtToSpawn);
    }

    void spawnRoom (GameObject roomToSpawn)
    {
        Quaternion rot = new Quaternion();
        
        Transform entranceDoor = roomtToSpawn.transform.Find("Entrance").Find("SpawnPoint");

        rot.Set(0, 0, 0, 0);
        var spawnedRoom = Instantiate(roomtToSpawn, transform.position, rot) as GameObject;
        Debug.Log(spawnedRoom.transform.position);
        Vector3 spawnDir = transform.position - spawnedRoom.transform.position;
        Vector3 newDir = Vector3.RotateTowards(spawnedRoom.transform.forward, spawnDir, Mathf.Infinity, 0.0f);

        // Debug.Log(newDir);
        spawnedRoom.transform.rotation = Quaternion.LookRotation(newDir);
    }
}
