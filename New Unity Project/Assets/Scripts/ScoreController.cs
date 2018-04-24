using UnityEngine;
using System.Collections;

public class ScoreController : MonoBehaviour
{
    private int oneDiskScore = 10;
    private int oneDiskFail = 5;

    private SceneController scene;

    void Awake()
    {
        scene = SceneController.getInstance();
        scene.setScoreController(this);
    }


    public void hitDisk(int round)
    {
        float beisu=1;
        switch (round)
        {
            case 1:
                beisu = 1;
                break;
            case 2:
                beisu = 1.2f;
                break;
            case 3:
                beisu = 1.5f;
                break;
            case 4:
                beisu = 2f;
                break;
        }
        scene.setScore(scene.getScore() + (int)(beisu* oneDiskScore));
    }

    public void hitGround(int input)
    {
        scene.setScore(scene.getScore() - oneDiskFail * input * input);
    }
    public void wasteBullet()
    {
        scene.setScore(scene.getScore() - 2);
    }
}