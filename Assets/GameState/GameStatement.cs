using UnityEngine;

public class GameStatement : MonoBehaviour
{
    public static GameStatement Instance;
    public enum State {PrePlay,Play,Finish}

    [SerializeField] Road road;
    [SerializeField] GameObject drawboard;

    public State currentState = State.PrePlay;
    void Start()
    {
        Instance = this;
    }

    public void FromPrePlayToPlay()
    {
        currentState = State.Play;
        road.speed = .3f;
    }

    public void FromPLayToFinish()
    {
        drawboard.SetActive(false);
        currentState = State.Finish;
        road.speed = 0;
    }
}
