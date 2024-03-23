using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Code
{
    public class Collision : MonoBehaviour
    {
        public GameObject forceField;
        public bool force = false;
        public FallingColorHandling colorHandlingScript;

        void Update()
        {
            if (force == true)
            {

                forceField.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
                forceField.transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;
            }
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.name.Contains("Red"))
            {
                Debug.Log("caught red");
                colorHandlingScript.IncrementRedCount();
                
            }

            if (collision.gameObject.name.Contains("Blue"))
            {
                Debug.Log("caught blue");
                colorHandlingScript.IncrementBlueCount();
              
            }

            if (collision.gameObject.name.Contains("Yellow"))
            {
                Debug.Log("caught yellow");
                colorHandlingScript.IncrementYellowCount(); 
                
            }
            if (collision.gameObject.name.Contains("Water"))
            {
                Debug.Log("caught yellow");
                colorHandlingScript.ResetColorMixing(); 
                
            }
            if (!collision.gameObject.name.Contains("Force Field"))
            {
                Destroy(collision.gameObject); 
            }
            if (collision.gameObject.name.Contains("Force Field"))
            {

                collision.gameObject.transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
                collision.gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").transform.TransformPoint(0, 0, 0);
                force = true;
            }
           
           
        }
    }

}

