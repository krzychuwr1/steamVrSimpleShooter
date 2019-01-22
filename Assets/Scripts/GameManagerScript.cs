using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public int currentLevel;
    public Rigidbody targetRigidbody;
    public int _currentLevelMaxTargetCount;
    private int _targetCount;
    private float _lastLevelChangeTime;

	// Use this for initialization
	void Start ()
    {
        currentLevel = 1;
        this._lastLevelChangeTime = Time.time;
        StartLevel(currentLevel);
    }
	
	// Update is called once per frame
	void Update ()
    {
        var activeTargetsCount = GameObject.FindGameObjectsWithTag("target").Length;
        if (_targetCount == _currentLevelMaxTargetCount && activeTargetsCount == 0 && (Time.time - _lastLevelChangeTime) > 3)
        {
            this._lastLevelChangeTime = Time.time;
            currentLevel++;
            StartLevel(currentLevel);
        } 
    }

    IEnumerator Spawn(Vector3 initialPosition, Vector3[] waypoints)
    {
        while (_targetCount < _currentLevelMaxTargetCount)
        {
            _targetCount++;
            yield return new WaitForSeconds(1f);
            var newProjectile = Instantiate(targetRigidbody, initialPosition, Quaternion.identity);
            var movementScript = newProjectile.gameObject.GetComponent<MovingTargetScript>();
            newProjectile.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            movementScript.wayPointList = waypoints;
        }
    }

    private void StartLevel(int levelNumber)
    {
        _targetCount = 0;
        GameObject.FindGameObjectWithTag("infoLabel").GetComponent<TextMesh>().text = "Level " + levelNumber;
        switch (levelNumber)
        {
            case 1:
                StartLevel1();
                break;
            case 2:
                StartLevel2();
                break;
            case 3:
                StartLevel3();
                break;
            case 4:
                StartCoroutine(EndGame(true));
                break;
        }
    }

    public IEnumerator EndGame(bool victory)
    {
        if (victory)
        {
            GameObject.FindGameObjectWithTag("infoLabel").GetComponent<TextMesh>().text = "You win!";
        }
        else
        {
            GameObject.FindGameObjectWithTag("infoLabel").GetComponent<TextMesh>().text = "You lose!";
        }
        yield return new WaitForSeconds(5f);
        QuitGame();
    }

    private void StartLevel1()
    {
        this._currentLevelMaxTargetCount = 5;
        StartCoroutine(Spawn(
            initialPosition: new Vector3(-5, 3, 10),
            waypoints: new []
            {
                new Vector3(-5, 3, 10),
                new Vector3(-5, 6, 10),
                new Vector3(5, 6, 10),
                new Vector3(5, 3, 10)
            }));
    }
    private void StartLevel2()
    {
        this._currentLevelMaxTargetCount = 7;
        StartCoroutine(Spawn(
            initialPosition: new Vector3(-7, 0, 10),
            waypoints: new[]
            {
                new Vector3(-5, 3, 10),
                new Vector3(-3, 0, 10),
                new Vector3(-1, 3, 10),
                new Vector3(1, 0, 10),
                new Vector3(3, 3, 10),
                new Vector3(5, 0, 10),
                new Vector3(7, 3, 10),
                new Vector3(7, -2, 10),
                new Vector3(-7, -2, 10),
            }));
    }
    private void StartLevel3()
    {
        this._currentLevelMaxTargetCount = 7;
        StartCoroutine(Spawn(
            initialPosition: new Vector3(-7, 0, 10),
            waypoints: new[]
            {
                new Vector3(-5, 3, 10),
                new Vector3(-3, 0, 10),
                new Vector3(-1, 3, 10),
                new Vector3(1, 0, 10),
                new Vector3(3, 3, 10),
                new Vector3(5, 0, 10),
                new Vector3(7, 3, 10),
                new Vector3(7, -2, 10),
                new Vector3(-7, -2, 10),
            }));
        StartCoroutine(Spawn(
            initialPosition: new Vector3(7, 0, 7),
            waypoints: new[]
            {
                new Vector3(5, 3, 7),
                new Vector3(3, 0, 7),
                new Vector3(1, 3, 7),
                new Vector3(-1, 0, 7),
                new Vector3(-3, 3, 7),
                new Vector3(-5, 0, 7),
                new Vector3(-7, 3, 7),
                new Vector3(-7, -2, 7),
                new Vector3(7, -2, 7),
            }));
    }

    public void QuitGame()
    {
        // save any game data here
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}
