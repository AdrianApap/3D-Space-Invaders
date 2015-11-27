﻿using UnityEngine;
using System.Collections;

public class Invaders : MonoBehaviour {
    public static int invaderCount = 20;
    public int step = 1;
    public GameObject invader;
    public Transform target;
    private GameObject[] invaders;

    // Use this for initialization
    void Start() {
        invaders = new GameObject[invaderCount];
        this.spawnInvaders();
    }

    // Update is called once per frame
    void Update() {
        for (int i = 0; i < invaderCount; i++) {
            if (invaders[i] != null) {
                Vector3 pos = invaders[i].transform.position;
                invaders[i].transform.LookAt(target);
                invaders[i].transform.position = Vector3.MoveTowards(pos, new Vector3(0, 0, 0), 1 * step * Time.deltaTime);
            }
        }
    }

    void spawnInvaders() {
        for (int i = 0; i < invaderCount; i++) {
            Vector3 pos = makeNew();
            invaders[i] = Instantiate(invader, pos, transform.rotation) as GameObject;
            invaders[i].name = "Spawn" + i.ToString();
        }
    }

    void hitInvaderRemove(string name) {
        // print("Spawned new invader after killing invader " + name);
        int index = 0;
        System.Int32.TryParse(name.Substring(5), out index);
        //print("Index of Killed Invader: " + index);
        Vector3 pos = makeNew();
        invaders[index] = Instantiate(invader, pos, transform.rotation) as GameObject;
        invaders[index].name = "Spawn" + index.ToString();
    }

    //to make them not spawn close to the camera
    Vector3 makeNew() {
        int x = Random.Range(-50, 50);
        int y = Random.Range(-10, 70);
        int z = Random.Range(10, 60);

        if (x < 0) {
            x -= 10;
        } else {
            x += 10;
        }

        if (y < 0) {
            y -= 10;
        } else {
            y += 10;
        }

        if (z < 0) {
            z -= 10;
        } else {
            z += 10;
        }
        Vector3 pos = new Vector3(x, y, z);
        return pos;
    }
}
