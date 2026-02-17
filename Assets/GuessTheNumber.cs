using TMPro;
using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] TMP_Text header;
    [SerializeField] TMP_InputField guessInput;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    int numberToGuess;
    int attempts;
    bool gameStateOver;

    void Start()
    {
        GameSetup();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void GameSetup()
    {
        numberToGuess = Random.Range(1, 11);
        attempts = 3;
        gameStateOver = false;

        header.text = "I'm thinking of a number between 1 and 10. You have " + attempts + " attempts to guess it";
        guessInput.text = "";
        guessInput.interactable = true;
    }
    public void SubmitGuess()
    {
        if (gameStateOver == true)
        {
            return;
        }

        int userGuess = 0;
        bool inputIsNumber = int.TryParse(guessInput.text, out userGuess);

        if (inputIsNumber == false)
        {
            header.text = "Please enter numbers only, you have " + attempts + " attempts remaining";
            guessInput.text = "";
            return;
        }

        if (userGuess == numberToGuess)
        {
            header.text = "Congratulations you won!!!";
            gameStateOver = true;
            guessInput.interactable = false;
        }
        else
        {
            attempts = attempts - 1;

            if (attempts <= 0)
            {
                header.text = "You lose! better luck next time";
                gameStateOver = true;
                guessInput.interactable = false;
            }
            else
            {
                if(userGuess < numberToGuess)
                {
                    header.text = "Number is too low, you have " + attempts + " attempts left";
                }
                else
                {
                    header.text = "Number is too high, you have " + attempts + " attempts left";
                }
            }
        }

        guessInput.text = "";
    }
}
