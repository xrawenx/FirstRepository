//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//[RequireComponent(typeof(BoxCollider2D))]
//public class Enemy : MonoBehaviour
//{
    //Reference to waypoints 
    //public List<Transform> points;
    //The int value for next point index
    //public int nextID;
    //The value of that applies to ID for changing
    //int idChangeValue = 1;

    //private void Reset()
    //{
    //Init();
    //}


    //void Init()
    //{
    //Make box collider trigger
    //GetComponent<BoxCollider2D>().isTrigger = true;

    //Create Root object
    //Gameobject root = new GameObject(name + "_Root");
    //Reset Position of Root to enemy object
    //root.transform.position = transform.position;
    //Set enemy object as child of Root
    //transform.SetParent(root.transform);
    //Create waypoints object
    //GameObject waypoints = new GameObject("waypoints");
    //Reset waypoints position to root

    //Make waypoints object child of root
    //waypoints.transform.SetParent(root.transform);
    //waypoints.transform.position = root.transform.position;
    //Create two points (gamerobject) and reset their position to waypoints object
    //Make the points children of waypoint object
    //GameObject p1 = new GameObject("Point1");p1.transform.SetParent(waypoints.transform);p1.transform.position = root.transform.position;
    //GameObject p2 = new GameObject("Point2");p1.transform.SetParent(waypoints.transform);p2.transform.position = root.transform.position;

    //Init points list then add the points to it
    //points = new List<Transform>();
    //points.Add(p1.transform);
    //points.Add(p2.transform);
    //}
//}
