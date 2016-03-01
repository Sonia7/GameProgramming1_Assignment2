using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {
	// PRIVATE INSTANCE VARIABLES
	private int _scoreValue;
	private int _livesValue;
   
    private AudioSource _gameOverSound;

	// PUBLIC ACCESS METHODS
	public int ScoreValue {
		get {
			return this._scoreValue;
		}

		set {
			this._scoreValue = value;
			this.ScoreLabel.text = "Score: " + this._scoreValue;
		}
	}

	public int LivesValue {
		get {
			return this._livesValue;
		}

		set {
			this._livesValue = value;
			if (this._livesValue <= 0) {
				this._endGame ();
			} else {
				this.LiveLabel.text = "Lives: " + this._livesValue;
			}
		}
	}
		
	// PUBLIC INSTANCE VARIABLES
	public Text LiveLabel;
	public Text ScoreLabel;
	public Text GameOverLabel;
	public Text HighScoreLabel;
	public Button RestartButton;
    public HeroController hero;

	// Use this for initialization
	void Start () {
		this._initialize ();
        
       
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//PRIVATE METHODS ++++++++++++++++++

	//Initial Method
	private void _initialize() {
		this.ScoreValue = 0;
		this.LivesValue = 5;
		this.GameOverLabel.gameObject.SetActive (false);
		this.HighScoreLabel.gameObject.SetActive (false);
		this.RestartButton.gameObject.SetActive(false);
	}

	private void _endGame() {
		this.HighScoreLabel.text = "High Score: " + this._scoreValue;
		this.GameOverLabel.gameObject.SetActive (true);
		this.HighScoreLabel.gameObject.SetActive (true);
        this.LiveLabel.gameObject.SetActive(false);// hide on end of game
        this.ScoreLabel.gameObject.SetActive(false);// hide on end of game
        this.RestartButton.gameObject.SetActive(true);// show up restart button on game over
      //  this._gameOverSound.Play();//plays game end track
        
        
	}

	// PUBLIC METHODS

	public void RestartButtonClick() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
      
	}
}
