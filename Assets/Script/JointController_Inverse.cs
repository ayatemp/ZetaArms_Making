using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace InverseKinematics
{
    public class JointController_Inverse: MonoBehaviour
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
                sliderVal[i]= slider[i].GetComponent<Slider>().value;

                posText[i]=GameObject.Find("Ref_"+i.ToString());
                angText[i]=GameObject.Find("Ang_"+i.ToString());
                
            }
        }

        void Update()
        {
            for(int i = 0; i<joint.Length; i++)
            {
                sliderVal[i]= slider[i].GetComponent<Slider>().value;
            }
            float x = sliderVal[0];
            float y = sliderVal[1];

            float a = Mathf.Acos((armL[0]* armL[0]+ armL[1]* armL[1]- x * x - y * y)/(2f* armL[0]* armL[1]));
            float b = Mathf.Acos((armL[0]* armL[0]+ x * x + y * y- armL[1]* armL[1])/(2f* armL[0]* Mathf.Sqrt(x * x + y * y)));

            angle[1].z = -Mathf.PI + a;
            angle[0].z = Mathf.Atan2(y,x) +b;

            for(int i=0;i<joint.Length;i++)
            {
                joint[i].transform.localEulerAngles = angle[i] * Mathf.Rad2Deg;
                posText[i].GetComponent<Text>().text = sliderVal[i].ToString("f2");
            }
            angText[0].GetComponent<Text>().text = ( angle[0].z * Mathf.Rad2Deg).ToString("f2");
            angText[1].GetComponent<Text>().text = ( angle[1].z * Mathf.Rad2Deg).ToString("f2");
        }
        
    }
}
