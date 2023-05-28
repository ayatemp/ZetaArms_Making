using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public ArticulationBody[] articulationBodies;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            print("Q");
            var xDrive = this.articulationBodies[2].xDrive;
            xDrive.target -= 1f;
            this.articulationBodies[2].xDrive = xDrive;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            print("W");
            var xDrive = this.articulationBodies[2].xDrive;
            xDrive.target += 1f;
            this.articulationBodies[2].xDrive = xDrive;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            print("A");
            var xDrive = this.articulationBodies[1].xDrive;
            xDrive.target -= 1f;
            this.articulationBodies[1].xDrive = xDrive;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            print("S");
            var xDrive = this.articulationBodies[1].xDrive;
            xDrive.target += 1f;
            this.articulationBodies[1].xDrive = xDrive;
        }
    }

}
