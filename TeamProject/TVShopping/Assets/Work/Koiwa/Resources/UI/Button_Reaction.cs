using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Button_Reaction : MonoBehaviour
{
    public bool isClick = false;
    ScenarioSetter _scenario;
    ScoreManager _score;

    public void OnClick()
    {
        isClick = true;

        if (this.name == "Button(0)")
        {
            _score.ScoreValueUp(Random.Range(1.0f, 15.0f));
            _scenario.SetRoute = ScenarioSetter.Route.A;
        }

        if (this.name == "Button(1)")
        {
            _score.ScoreValueUp(Random.Range(10.0f, 20.0f));
            _scenario.SetRoute = ScenarioSetter.Route.B;
        }

        if (this.name == "Button(2)")
        {
            _score.ScoreValueUp(Random.Range(10.0f, 10.0f));
            _scenario.SetRoute = ScenarioSetter.Route.C;
        }
    }

    void Start()
    {
        _scenario = GameObject.FindObjectOfType<ScenarioSetter>();
        _score = GameObject.FindObjectOfType<ScoreManager>();
    }
}
