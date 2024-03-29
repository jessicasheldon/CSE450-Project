using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Code{
    public class TutorialController : MonoBehaviour
    {
        public static TutorialController instance;

        public GameObject tutorial1;
        public GameObject tutorial2;
        public GameObject tutorial3;
        public GameObject tutorial4;
        public GameObject tutorial5;
        public GameObject tutorial6;


        void Awake() {
            instance = this;
            Hide();
        }

        public void Show(){
            ShowTutorialOne();
            gameObject.SetActive(true);
        }

        public void Hide(){
            gameObject.SetActive(false);
        }

        void SwitchScreen(GameObject someScreen){
            tutorial1.SetActive(false);
            tutorial2.SetActive(false);
            tutorial3.SetActive(false);
            tutorial4.SetActive(false);
            tutorial5.SetActive(false);
            tutorial6.SetActive(false);

            someScreen.SetActive(true);
        }

        public void ShowTutorialOne () {
            SwitchScreen(tutorial1)
        }

        public void ShowTutorialTwo () {
            SwitchScreen(tutorial2)
        }

        public void ShowTutorialThree () {
            SwitchScreen(tutorial3)
        }

        public void ShowTutorialFour () {
            SwitchScreen(tutorial4)
        }

        public void ShowTutorialFive () {
            SwitchScreen(tutorial5)
        }

        public void ShowTutorialSix () {
            SwitchScreen(tutorial6)
        }
    }
}

