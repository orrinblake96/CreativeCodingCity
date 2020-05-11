using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class TimeManager : MonoBehaviour
    {

        private TextMeshProUGUI _timerMinutes;
        private TextMeshProUGUI _timerSeconds;
        private TextMeshProUGUI _timerSeconds100;

        private float _startTime;
        private float _stopTime;
        private float _timerTime;
        private bool _isRunning = false;
        private float _timeToReduce = 0;

        // Start is called before the first frame update
        private void Start()
        {
            _timerMinutes = GameObject.Find("UI/TimerCanvas/Minutes").GetComponent<TextMeshProUGUI>();
            _timerSeconds = GameObject.Find("UI/TimerCanvas/Seconds").GetComponent<TextMeshProUGUI>();
            _timerSeconds100 = GameObject.Find("UI/TimerCanvas/SecondsHundred").GetComponent<TextMeshProUGUI>();

            TimerReset();
        }

        // Update is called once per frame
        private void Update()
        {
            _timerTime = _stopTime + (Time.time - _startTime);
            

            if (Input.GetKeyDown(KeyCode.H))
            {
                TimerStart();
            }
            
            if (Input.GetKeyDown(KeyCode.J))
            {
                TimerStop();
            }
            
            if (Input.GetKeyDown(KeyCode.K))
            {
                TimerReset();
            }
        }

        private void LateUpdate()
        {
            int minutesInt = (int)_timerTime / 60;
            int secondsInt = (int)_timerTime % 60;
            int seconds100Int = (int)(Mathf.Floor((_timerTime - (secondsInt + minutesInt * 60)) * 100));
            
            if (_isRunning)
            {
                _timerMinutes.text = (minutesInt < 10) ? "0" + minutesInt : minutesInt.ToString();
                _timerSeconds.text = (secondsInt < 10) ? "0" + secondsInt : secondsInt.ToString();
                _timerSeconds100.text = (seconds100Int < 10) ? "0" + seconds100Int : seconds100Int.ToString();
            }
        }


        public void TimerStart()
        {
            if (!_isRunning)
            {
                _isRunning = true;
                _startTime = Time.time;       
            }
        }

        public void TimerStop()
        {
            if (_isRunning)
            {
                _isRunning = false;
                _stopTime = _timerTime - _timeToReduce;
            }
        }

        public void TimerReset()
        {
            _stopTime = 0;
            _isRunning = false;
            _timerMinutes.text = _timerSeconds.text = _timerSeconds100.text = "00";
        }

        public void TimerReduced(GameObject timeReducer)
        {
            _timeToReduce += 3;
            Debug.Log("Time reduced: " + _timeToReduce);
            Destroy(timeReducer);
        }
    }
}
