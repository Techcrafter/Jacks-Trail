using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ghost : MonoBehaviour
{
	public float MoveSpeed;
    public GameObject GhostIdle;
	public GameObject GhostUp;
    public GameObject GhostDown;
    public GameObject GhostLeft;
    public GameObject GhostRight;
	
	public AudioSource DieAudio;
	public AudioSource LevelCompletedAudio;
	
    // Start is called before the first frame update
    void Start()
    {
		PlayerPrefs.SetInt("GhostDied", 0);
        PlayerPrefs.SetFloat("GhostStartPositionX", transform.position.x);
		PlayerPrefs.SetFloat("GhostStartPositionY", transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
		if(PlayerPrefs.GetInt("PumpkinLeft") == 1 && PlayerPrefs.GetInt("PumpkinRight") == 1)
		{
			GhostIdle.SetActive(true);
            GhostLeft.SetActive(false);
            GhostRight.SetActive(false);
		}
        else if(PlayerPrefs.GetInt("PumpkinRight") == 1)
        {
			transform.position = new Vector2(transform.position.x - MoveSpeed, transform.position.y);
            GhostIdle.SetActive(false);
            GhostLeft.SetActive(true);
            GhostRight.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("PumpkinLeft") == 1)
        {
			transform.position = new Vector2(transform.position.x + MoveSpeed, transform.position.y);
            GhostIdle.SetActive(false);
			GhostLeft.SetActive(false);
            GhostRight.SetActive(true);
        }
		else
		{
			GhostLeft.SetActive(false);
            GhostRight.SetActive(false);
		}
        
		if(PlayerPrefs.GetInt("PumpkinTop") == 1 && PlayerPrefs.GetInt("PumpkinBottom") == 1)
		{
			if(PlayerPrefs.GetInt("PumpkinLeft") == 0 && PlayerPrefs.GetInt("PumpkinRight") == 0)
			{
				GhostIdle.SetActive(true);
			}
            GhostUp.SetActive(false);
            GhostDown.SetActive(false);
		}
		else if(PlayerPrefs.GetInt("PumpkinTop") == 1)
        {
			transform.position = new Vector2(transform.position.x, transform.position.y - MoveSpeed);
            GhostIdle.SetActive(false);
            GhostUp.SetActive(false);
            GhostDown.SetActive(true);
			GhostLeft.SetActive(false);
            GhostRight.SetActive(false);
        }
        else if(PlayerPrefs.GetInt("PumpkinBottom") == 1)
        {
			transform.position = new Vector2(transform.position.x, transform.position.y + MoveSpeed);
            GhostIdle.SetActive(false);
            GhostUp.SetActive(true);
            GhostDown.SetActive(false);
			GhostLeft.SetActive(false);
            GhostRight.SetActive(false);
        }
		else
		{
			GhostUp.SetActive(false);
            GhostDown.SetActive(false);
		}
        
		if(PlayerPrefs.GetInt("PumpkinBottom") == 0 && PlayerPrefs.GetInt("PumpkinTop") == 0 && PlayerPrefs.GetInt("PumpkinLeft") == 0 && PlayerPrefs.GetInt("PumpkinRight") == 0)
        {
            GhostIdle.SetActive(true);
            GhostUp.SetActive(false);
            GhostDown.SetActive(false);
            GhostLeft.SetActive(false);
            GhostRight.SetActive(false);
        }
    }
	
	void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.tag == "KillGhost")
		{
			die();
		}
		
		if(collision.gameObject.tag == "LevelExit")
		{
			levelCompleted();
		}
	}
	
	void die()
	{
		PlayerPrefs.SetInt("ResetPumpkins", 1);
		DieAudio.GetComponent<AudioSource>().Play();
		transform.position = new Vector2(PlayerPrefs.GetFloat("GhostStartPositionX"), PlayerPrefs.GetFloat("GhostStartPositionY"));
	}
	
	void levelCompleted()
	{
		PlayerPrefs.SetInt("ResetPumpkins", 1);
		LevelCompletedAudio.GetComponent<AudioSource>().Play();
		
		switch(SceneManager.GetActiveScene().name)
		{
			case "Level1":
				SceneManager.LoadScene("Level2", LoadSceneMode.Single);
				break;
			case "Level2":
				SceneManager.LoadScene("Level3", LoadSceneMode.Single);
				break;
			case "Level3":
				SceneManager.LoadScene("Level4", LoadSceneMode.Single);
				break;
			case "Level4":
				SceneManager.LoadScene("Level5", LoadSceneMode.Single);
				break;
			case "Level5":
				SceneManager.LoadScene("Level6", LoadSceneMode.Single);
				break;
			case "Level6":
				SceneManager.LoadScene("GameCompleted", LoadSceneMode.Single);
				break;
		}
	}
}
