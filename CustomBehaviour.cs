/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;

    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    // Set walls parameters
    string[] wallNames = { "wallNearRight","wallNearLeft",
                           "WallNear", "WallFar",
                           "wallRight", "wallLeft",
                           "wallUp", "wallDown"
                         };
    Vector3[] wallPositions = { new Vector3(35.5f, 39, 0), new Vector3(-35.5f, 39, 0),
                                new Vector3(0, 71.5f, 0f), new Vector3(0, 39, 89.5f),
                                new Vector3(52f, 39, 45), new Vector3(-52f, 39, 45),
                                new Vector3(0, 79, 45), new Vector3(0, -1, 45),
                              };
    Vector3[] wallScales = { new Vector3(34, 80, 1), new Vector3(34, 80, 1),
                             new Vector3(38, 15, 1), new Vector3(104, 80, 1),
                             new Vector3(1, 80, 90), new Vector3(1, 80, 90),
                             new Vector3(105, 1, 90), new Vector3(105, 1, 90),
                           };
    Vector3[] wallOffset = { -Vector3.forward, -Vector3.forward,
                             -Vector3.forward, Vector3.forward,
                             Vector3.right, -Vector3.right,
                             Vector3.up, -Vector3.up,
                           };


    // Use this for initialization
    void Start()
    {
        // Add RemoteTransformations script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Check if this is the door game object
        if (this.gameObject.name.Equals("Door.glb")) {
            // Get materials
            Material matBrick = (Material) Resources.Load("Materials/Brick");
            Material matInvisible = (Material) Resources.Load("Invisible");
            Material[] wallMaterials = { null, null,
                                         null, matBrick,
                                         matBrick, matBrick,
                                         null, null };
            // Create walls
            Debug.Log("Creating walls...");
            for (int i = 0; i < wallNames.Length; i++){
                // Create wall
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.name = wallNames[i];
                wall.transform.parent = this.transform;
                wall.transform.position = wallPositions[i];
                wall.transform.localScale = wallScales[i];
                if (wallMaterials[i]) wall.GetComponent<Renderer>().material =  wallMaterials[i];
            }

            // Create invisible walls
            Debug.Log("Creating invisible walls...");
            for (int i = 0; i < wallNames.Length; i++){
                // Create wall
                GameObject wall = GameObject.CreatePrimitive(PrimitiveType.Cube);
                wall.name = wallNames[i] + "_Invisible";
                wall.transform.parent = this.transform;
                wall.transform.position = wallPositions[i] + wallOffset[i];
                wall.transform.localScale = wallScales[i] + Vector3.one;
                wall.GetComponent<Renderer>().material =  matInvisible;
            }

        }            
    }

    // Update is called once per frame
    void Update()
    {
            
    }
}