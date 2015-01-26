using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.IO;
using System.Text.RegularExpressions;

public class High_score : MonoBehaviour {

	public Text Best_TINY;
	public Text Average_TINY;
	public Text Best_SMALL;
	public Text Average_SMALL;
	public Text Best_MEDIUM;
	public Text Average_MEDIUM;
	public Text Best_HUGE;
	public Text Average_HUGE;
	public Text Best_DYED;
	public Text Average_DYED;


	// Use this for initialization
	void Start () {
		float [,] times = new float[5,3]{
			{0.0f,0.0f,0.0f},
			{0.0f,0.0f,0.0f},
			{0.0f,0.0f,0.0f},
			{0.0f,0.0f,0.0f},
			{0.0f,0.0f,0.0f}
		};
		string path = @"Maze Mania_Data\\hs.mhs";
		string [] temp;
		if(File.Exists(path)){
			string[] high_score = System.IO.File.ReadAllLines(path);
			for(int i = 0; i < 5; i++){
				temp=Regex.Split(high_score[i], " ");
				times[i,0]=(float)Convert.ToDecimal(temp[0]);
				times[i,1]=(float)Convert.ToDecimal(temp[1]);
			}
		}
		else{
			var fileName = path;
			var hs = File.CreateText(fileName);
			for(int i = 0; i < 5; i++){
				hs.WriteLine("0 0 0");
			}
			hs.Close();
		}

		Best_TINY.text=times[0,0].ToString();
		Average_TINY.text=times[0,1].ToString();
		Best_SMALL.text=times[1,0].ToString();
		Average_SMALL.text=times[1,1].ToString();
		Best_MEDIUM.text=times[2,0].ToString();
		Average_MEDIUM.text=times[2,1].ToString();
		Best_HUGE.text=times[3,0].ToString();
		Average_HUGE.text=times[3,1].ToString();
		Best_DYED.text=times[4,0].ToString();
		Average_DYED.text=times[4,1].ToString();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
