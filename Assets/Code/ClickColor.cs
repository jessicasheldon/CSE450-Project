using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code{
    public class ClickColor : MonoBehaviour
    {
        // Start is called before the first frame update
        private Color color;
        private ColorMix colorMix; 
        void Start()
        {
            SpriteRenderer sprite = GetComponent<SpriteRenderer>();
            color = sprite.color;
        }

        private void OnMouseDown()
        {
            Debug.Log("Clicked on " + gameObject.name); 
            colorMix = FindObjectOfType<ColorMix>(); 
            colorMix.MixColor(color); 
        }
    }
}
