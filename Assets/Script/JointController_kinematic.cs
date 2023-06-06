using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InverseKinematics
{
    public class JointController_kinematic: MonoBehaviour
    {
        //robot
        private GameObject[] joint = new GameObject[2];
        private GameObject[] arm = new GameObject[2];
        private float[] armL = new float[2];
        private Vector3[] angle = new Vector3[2];
        private GameObject[] slider = new GameObject[2];
        private float[] sliderVal = new float[2];
        private GameObject[] angText = new GameObject[2];
        private GameObject[] posText = new GameObject[2];

        void Start()
        {
            //check();
            //robot
            for(int i = 0; i<joint.Length; i++)
            {
                joint[i] = GameObject.Find("Joint_"+i.ToString());
                arm[i] = GameObject.Find("Arm_"+i.ToString());
                armL[i] = arm[i].transform.localScale.x;
            }

            //UIsetting
            for(int i =0; i<joint.Length;i++)
            {
                slider[i] = GameObject.Find("Slider_"+i.ToString());
                angText[i]= GameObject.Find("Angle_"+i.ToString());
                sliderVal[i]= slider[i].GetComponent<Slider>().value;

                /*
                if (angText[i] != null)
                {
                    print(angText[i].GetComponent<Text>().text);
                }
                else
                {
                Debug.LogError("angText[" + i + "]がnullです。");
                }
                */
                print(angText[i].GetComponent<Text>());
            }

            posText[0]=GameObject.Find("Pos_X");
            posText[1]=GameObject.Find("Pos_Y");
        }

        void Update()
        {
            for(int i = 0; i<joint.Length; i++)
            {
                sliderVal[i]= slider[i].GetComponent<Slider>().value;
                print("Slider_"+i.ToString()+":"+sliderVal[i].ToString("f2"));

                angText[i].GetComponent<Text>().text = sliderVal[i].ToString("f2");
                
                angle[i].z = sliderVal[i];
                joint[i].transform.localEulerAngles = angle[i];
            }

            float px = armL[0] * Mathf.Cos(angle[0].z * Mathf.Deg2Rad) + armL[1] * Mathf.Cos((angle[0].z + angle[1].z) * Mathf.Deg2Rad);
            float py = armL[0] * Mathf.Sin(angle[0].z * Mathf.Deg2Rad) + armL[1] * Mathf.Sin((angle[0].z + angle[1].z) * Mathf.Deg2Rad);

            posText[0].GetComponent<Text>().text = px.ToString();
            posText[1].GetComponent<Text>().text = py.ToString();
        }

        void check()
        {
            for(int i =0; i<2; i++)
            {
                if(GameObject.Find("Joint_"+i.ToString())) print("Joint_"+i.ToString());
                if(GameObject.Find("Arm_"+i.ToString())) print("Arm_"+i.ToString());
                if(GameObject.Find("Slider_"+i.ToString())) print("Slider_"+i.ToString());
                if(GameObject.Find("Angle_"+i.ToString())) print("Angle_"+i.ToString());
            }
            if(GameObject.Find("Pos_X")) print("Pos_X");
            if(GameObject.Find("Pos_Y")) print("Pos_Y");
        }
    }
}

