using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public Maze mazePrefab;
        public Player rewardPrefab;
        public InsideMazeTeleporter teleporterPrefab;
        public TimeReducerLoactions timeReducerPrefab;
        public Animator buttonPressedAnimation;
        public GameObject startingTeleporter;

        private Maze _mazeInstance;
        private bool _readyToGenerate;
        private Player _rewardInstance;
        private InsideMazeTeleporter _mazeTeleporterInstance;
        private TimeReducerLoactions _mazeTimeReducerInstances, _mazeTimeReducerInstances2, _mazeTimeReducerInstances3, _mazeTimeReducerInstances4;
        private static readonly int ButtonPressed = Animator.StringToHash("ButtonPressed");

        // Start is called before the first frame update
        private void Start()
        {
//            BeginGame();
            _mazeInstance = Instantiate(mazePrefab) as Maze;
            RestartGame();
        }

        // Update is called once per frame
        private void Update()
        {
            // Prompts player to press "E" to generate mazes
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Creates teleporter/effects to enter the maze
                FindObjectOfType<AudioManager>().Play("ButtonPress");
//                buttonPressedAnimation.SetTrigger(ButtonPressed);
                RestartGame();
            }
        }
    
        //Begin game
        private IEnumerator BeginGame()
        {
            // Instantiate entire maze
            yield return new WaitForSeconds(.4f);
            _mazeInstance = Instantiate(mazePrefab) as Maze;
            StartCoroutine(_mazeInstance.Generate());
        }
    
        //Restart game
        private void RestartGame()
        {
            // when restarting stop any current co-routines and destroy current maze instances to allow for creation of a new random one 
            StopAllCoroutines();
            Destroy(_mazeInstance.gameObject);
            StartCoroutine(BeginGame());
        }

        private void OnTriggerEnter(Collider other)
        {
            // Alloow player to generate maze by pressing the button
            _readyToGenerate = true;
            GameObject.Find("ButtonPressCanvas/PressButtonText").GetComponent<Text>().enabled = true;
        }

        private void OnTriggerExit(Collider other)
        {
            // When player moves away from the button they can no longer press it
            _readyToGenerate = false;
            GameObject.Find("ButtonPressCanvas/PressButtonText").GetComponent<Text>().enabled = false;
        }

        public void RestartAfterReward()
        {
            // Similar to previous Restart except its called from the reward the player uses to leave the maze
            StopAllCoroutines();
            Destroy(_mazeInstance.gameObject);
            if (_rewardInstance != null) {
                Destroy(_rewardInstance.gameObject);
            }
            if (_mazeTimeReducerInstances != null) {
                Destroy(_mazeTimeReducerInstances.gameObject);
            }
            if (_mazeTimeReducerInstances2 != null) {
                Destroy(_mazeTimeReducerInstances2.gameObject);
            }
            if (_mazeTimeReducerInstances3 != null) {
                Destroy(_mazeTimeReducerInstances3.gameObject);
            }
            if (_mazeTimeReducerInstances4 != null) {
                Destroy(_mazeTimeReducerInstances4.gameObject);
            }
            if (_mazeTeleporterInstance != null) {
                Destroy(_mazeTeleporterInstance.gameObject);
            }
            _mazeInstance = Instantiate(mazePrefab) as Maze;
        }
    }
}

