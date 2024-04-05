using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Code
{
    public class Collision : MonoBehaviour
    {
        public Sprite forceField;
        public Sprite circle;
        public bool force = false;
        public FallingColorHandling colorHandlingScript;
        private int count = 0;

        void Update()
        {
            if (force)
            {
                count += 1;


                if (count == 10000)
                {
                    count = 0;
                    force = false;
                    SpriteRenderer playerSprite = gameObject.GetComponent<SpriteRenderer>();
                    playerSprite.sprite = circle;
                }

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
            if (collision.gameObject.name.Contains("White"))
            {
                Debug.Log("caught white");
                colorHandlingScript.IncrementWhiteCount(); 
                
            }
            if (collision.gameObject.name.Contains("Black"))
            {
                Debug.Log("caught black");
                colorHandlingScript.IncrementBlackCount(); 
                
            }
            if (collision.gameObject.name.Contains("Water"))
            {
                Debug.Log("caught water");
                colorHandlingScript.ResetColorMixing(); 
                
            }
            if (collision.gameObject.name.Contains("Force Field"))
            {
                SpriteRenderer playerSprite = gameObject.GetComponent<SpriteRenderer>();
                playerSprite.sprite = forceField;
                force = true;
            }
            if (collision.gameObject.name.Contains("Star"))
            {
                colorHandlingScript.ActivateInvincibility(colorHandlingScript.invincibilityDuration);
            }
            Destroy(collision.gameObject);

        }
    }

}

