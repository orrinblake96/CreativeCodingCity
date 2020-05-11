using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;
using UnityEngine;

public class MazeNumber : MonoBehaviour
{
    public int mazeNumber;

    private bool _gameOver = false;    
    private TextMeshProUGUI _mazeNumberText;
    // Start is called before the first frame update
    private void Start()
    {
        _mazeNumberText = GetComponent<TextMeshProUGUI>();
        _mazeNumberText.text = "Maze: " + mazeNumber;
    }

    private void Update()
    {
        if(mazeNumber == 5) _gameOver = true;
        if (_gameOver)
        {
            StartCoroutine(GameOver());
            _gameOver = false;
        }
    }

    public void UpdateMazeNumber()
    {
        _mazeNumberText.text = "Maze: " + mazeNumber;
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
