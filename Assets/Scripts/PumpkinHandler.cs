using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinHandler : MonoBehaviour
{
	public GameObject PumpkinTop;
	public GameObject PumpkinTopOff;
	public GameObject PumpkinBottom;
	public GameObject PumpkinBottomOff;
	public GameObject PumpkinLeft;
	public GameObject PumpkinLeftOff;
	public GameObject PumpkinRight;
	public GameObject PumpkinRightOff;
	
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("PumpkinTop", 0);
		PlayerPrefs.SetInt("PumpkinBottom", 0);
		PlayerPrefs.SetInt("PumpkinLeft", 0);
		PlayerPrefs.SetInt("PumpkinRight", 0);
    }

    // Update is called once per frame
    void Update()
    {
		if(PlayerPrefs.GetInt("ResetPumpkins") == 1)
		{
			PlayerPrefs.SetInt("ResetPumpkins", 0);
			PlayerPrefs.SetInt("PumpkinTop", 0);
			PlayerPrefs.SetInt("PumpkinBottom", 0);
			PlayerPrefs.SetInt("PumpkinLeft", 0);
			PlayerPrefs.SetInt("PumpkinRight", 0);
			PumpkinTop.SetActive(false);
			PumpkinTopOff.SetActive(true);
			PumpkinBottom.SetActive(false);
			PumpkinBottomOff.SetActive(true);
			PumpkinLeft.SetActive(false);
			PumpkinLeftOff.SetActive(true);
			PumpkinRight.SetActive(false);
			PumpkinRightOff.SetActive(true);
		}
		
        if(Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown("w"))
		{
			if(PlayerPrefs.GetInt("PumpkinTop") == 0)
			{
				PlayerPrefs.SetInt("PumpkinTop", 1);
				PumpkinTop.SetActive(true);
				PumpkinTopOff.SetActive(false);
			}
			else
			{
				PlayerPrefs.SetInt("PumpkinTop", 0);
				PumpkinTopOff.SetActive(true);
				PumpkinTop.SetActive(false);
			}
		}
		
		if(Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown("s"))
		{
			if(PlayerPrefs.GetInt("PumpkinBottom") == 0)
			{
				PlayerPrefs.SetInt("PumpkinBottom", 1);
				PumpkinBottom.SetActive(true);
				PumpkinBottomOff.SetActive(false);
			}
			else
			{
				PlayerPrefs.SetInt("PumpkinBottom", 0);
				PumpkinBottomOff.SetActive(true);
				PumpkinBottom.SetActive(false);
			}
		}
		
		if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown("a"))
		{
			if(PlayerPrefs.GetInt("PumpkinLeft") == 0)
			{
				PlayerPrefs.SetInt("PumpkinLeft", 1);
				PumpkinLeft.SetActive(true);
				PumpkinLeftOff.SetActive(false);
			}
			else
			{
				PlayerPrefs.SetInt("PumpkinLeft", 0);
				PumpkinLeftOff.SetActive(true);
				PumpkinLeft.SetActive(false);
			}
		}
		
		if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown("d"))
		{
			if(PlayerPrefs.GetInt("PumpkinRight") == 0)
			{
				PlayerPrefs.SetInt("PumpkinRight", 1);
				PumpkinRight.SetActive(true);
				PumpkinRightOff.SetActive(false);
			}
			else
			{
				PlayerPrefs.SetInt("PumpkinRight", 0);
				PumpkinRightOff.SetActive(true);
				PumpkinRight.SetActive(false);
			}
		}
    }
}
