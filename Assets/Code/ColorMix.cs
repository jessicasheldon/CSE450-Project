using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Scrtwpns.Mixbox; 

namespace Code
{
    public class ColorMix : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private Color mixedColor; 

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void MixColor(Color colorToAdd)
        {
            //calculate mixed color (right now just averaging) 
            mixedColor = Mixbox.Lerp(spriteRenderer.color, colorToAdd, 0.5f);
            Debug.Log("Color that is mixed: " + mixedColor); 
            // Update the color of the sprite
            spriteRenderer.color = mixedColor;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
