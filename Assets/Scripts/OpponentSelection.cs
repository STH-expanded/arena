using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class OpponentSelection : MonoBehaviour
{
    public int opponentsToGenerate = 3;
    public const string
        EASY_LEVEL_OPPONENT = "easy",
        MEDIUM_LEVEL_OPPONENT = "medium",
        HARD_LEVEL_OPPONENT = "hard"
    ;

    public List<Button> ButtonsArrayList;

    [SerializeField] private Canvas _opponentSelectionCanvas;

    // Start is called before the first frame update
    void Start()
    {
        _opponentSelectionCanvas.transform.SetParent(this.transform);

        string[] opponentLevels = GetOpponentLevels();


        if (opponentLevels.Length == opponentsToGenerate)
        {
            foreach (string opponentLevel in opponentLevels)
            {
                GeneratePlayer(opponentLevel);
            }
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GeneratePlayer(string level)
    {
        switch (level)
        {
            case EASY_LEVEL_OPPONENT:
                Debug.Log(level);

                break;
            case MEDIUM_LEVEL_OPPONENT:
                Debug.Log(level);

                break;
            case HARD_LEVEL_OPPONENT:
                Debug.Log(level);

                break;
            default:
                Debug.Log("Unknown opponent player.");
                break;
        }
    }

    static string[] GetOpponentLevels()
    {
        string[] opponentLevels = {
            EASY_LEVEL_OPPONENT,
            MEDIUM_LEVEL_OPPONENT,
            HARD_LEVEL_OPPONENT
        };

        return opponentLevels;
    }
}
