using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Code{
    public class TutorialController : MonoBehaviour
    {
        //public FallingColorHandling FallingColorHandlingScript ;

        public static TutorialController instance;

        public GameObject tutorial1;
        public GameObject tutorial2;
        public GameObject tutorial3;
        public GameObject tutorial4;
        public GameObject tutorial5;
        public GameObject tutorial6;
        public GameObject tutorial7;


        void Awake() {
            instance = this;
            Hide();
        }

        public void Show(){
            ShowTutorialOne();
            gameObject.SetActive(true);
            Time.timeScale = 0;
            //FallingColorHandlingScript.Pause();
        }

        public void Hide(){
            gameObject.SetActive(false);
            Time.timeScale = 1;
            //FallingColorHandlingScript.StartAgain();
        }

        void SwitchScreen(GameObject someScreen){
            tutorial1.SetActive(false);
            tutorial2.SetActive(false);
            tutorial3.SetActive(false);
            tutorial4.SetActive(false);
            tutorial5.SetActive(false);
            tutorial6.SetActive(false);
            tutorial7.SetActive(false);

            someScreen.SetActive(true);
            
        }

        public void ShowTutorialOne () {
            SwitchScreen(tutorial1);
        }

        public void ShowTutorialTwo () {
            SwitchScreen(tutorial2);
        }

        public void ShowTutorialThree () {
            SwitchScreen(tutorial3);
        }

        public void ShowTutorialFour () {
            SwitchScreen(tutorial4);
        }

        public void ShowTutorialFive () {
            SwitchScreen(tutorial5);
        }

        public void ShowTutorialSix () {
            SwitchScreen(tutorial6);
        }

        public void ShowTutorialSeven () {
            SwitchScreen(tutorial7);
        }
    }
}
