using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
	public GameObject Ghost;
	
	public float MoveSpeed;
	public float Threshold;
	
	public GameObject ZombieUp;
	public GameObject ZombieDown;
	public GameObject ZombieLeft;
	public GameObject ZombieRight;
	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if(Ghost.transform.position.y < transform.position.y)
		{
			transform.position = new Vector2(transform.position.x, transform.position.y - MoveSpeed * Time.deltaTime);
			ZombieDown.SetActive(true);
			ZombieUp.SetActive(false);
		}
		else if(Ghost.transform.position.y > transform.position.y)
		{
			transform.position = new Vector2(transform.position.x, transform.position.y + MoveSpeed * Time.deltaTime);
			ZombieUp.SetActive(true);
			ZombieDown.SetActive(false);
		}
		else
		{
			ZombieUp.SetActive(false);
			ZombieDown.SetActive(true);
		}
		
		if(Ghost.transform.position.x + Threshold > transform.position.x && Ghost.transform.position.x - Threshold < transform.position.x)
		{
			ZombieLeft.SetActive(false);
			ZombieRight.SetActive(false);
		}
		else if(Ghost.transform.position.x < transform.position.x)
		{
			transform.position = new Vector2(transform.position.x - MoveSpeed * Time.deltaTime, transform.position.y);
			ZombieLeft.SetActive(true);
			ZombieRight.SetActive(false);
			ZombieUp.SetActive(false);
			ZombieDown.SetActive(false);
		}
		else if(Ghost.transform.position.x > transform.position.x)
		{
			transform.position = new Vector2(transform.position.x + MoveSpeed * Time.deltaTime, transform.position.y);
			ZombieRight.SetActive(true);
			ZombieLeft.SetActive(false);
			ZombieUp.SetActive(false);
			ZombieDown.SetActive(false);
		}
		else
		{
			ZombieLeft.SetActive(false);
			ZombieRight.SetActive(false);
		}
    }
}
