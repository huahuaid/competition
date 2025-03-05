using UnityEngine;

public class QuestionOne : MonoBehaviour
{
private string[] questions = { "QuestionOne", "QuestionTwo", "QuestionThree", "QuestionFour", "QuestionFive" };

	private string[] options = {"A" , "B" , "A" , "C" , "B"};


    void Start()
    {
        
    }

	void Update()
	{

	}

	public bool Judege(string option , string questionName)
	{
		int count = 0;

		for (int i = 0; i < questions.Length; i++)
		{
			if (questions[i] == questionName)
			{
				count = i;
				break;
			}
		}

		return options[count] == option.Split(' ')[0];
	}
}
