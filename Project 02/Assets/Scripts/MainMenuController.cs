using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    [SerializeField] AudioClip _startingSong;
    [SerializeField] Text _highScoreTextView;


    //Start is called before first frame update
    private void Start()
    {
        //load high score
        int highScore = PlayerPrefs.GetInt("HighScore");
        _highScoreTextView.text = highScore.ToString();
        // play song at start
        if(_startingSong !=null)
        {
            AudioManager.Instance.PlaySong(_startingSong);
        }
    }
}
