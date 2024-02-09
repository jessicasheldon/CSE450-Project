using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code
{
    public class ColorMix : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;

        private Color mixedColor = Color.white;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void MixColor(Color colorToAdd)
        {
            //calculate mixed color (right now just averaging) 
            mixedColor = (spriteRenderer.color + colorToAdd)/2;
            
            // Update the color of the sprite
            spriteRenderer.color = mixedColor;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
