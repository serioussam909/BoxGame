using UnityEngine;
using System.Collections;

public enum SpinnerSymbol{
   
    Arrow,
    Pentagram,
    Command,
    FourSquares,
    Square,
    Drop,
    Triangle,
    Circle
};

public class Spinner : PuzzleObject {

    public bool turning=false;
    public int turningDirection = 0;

    public SpinnerSymbol targetSymbol = SpinnerSymbol.Arrow;
    public SpinnerSymbol currentSymbol = SpinnerSymbol.Arrow;


    public void Turn(int direction)
    {
        if (turning)
        {
            return;
        }
        turning = true;
        turningDirection = direction;
        if (((int)currentSymbol + direction) > 7)
        {
            targetSymbol = SpinnerSymbol.Arrow;
        }
        if (((int)currentSymbol + direction) < 0)
        {
            targetSymbol = SpinnerSymbol.Circle;
        }
        else {
            targetSymbol = currentSymbol + direction;
        }
        

    }

    public SpinnerSymbol getCurrentSymbol()
    {
        return (SpinnerSymbol)Mathf.FloorToInt(transform.localEulerAngles.z / 45);
    }

	// Use this for initialization
	public new void Start () {
        base.Start();
	}
	
	// Update is called once per frame
	public new void Update () {

        if (((int)targetSymbol) > 7)
        {
            targetSymbol = SpinnerSymbol.Arrow;
        }
        if (((int)targetSymbol) < 0)
        {
            targetSymbol = SpinnerSymbol.Circle;
        }
        if (((int)currentSymbol) > 7)
        {
            currentSymbol = SpinnerSymbol.Arrow;
        }
        if (((int)currentSymbol) < 0)
        {
            currentSymbol = SpinnerSymbol.Circle;
        }


        if (turning)
        {
            transform.Rotate(new Vector3(0,0, turningDirection*60*Time.deltaTime),Space.Self);
            if (Mathf.RoundToInt(transform.localEulerAngles.z/45) == ((int)targetSymbol) 
                || (((Mathf.RoundToInt(transform.localEulerAngles.z/45)==8) || (Mathf.RoundToInt(transform.localEulerAngles.z/45) == 0)) && targetSymbol==SpinnerSymbol.Arrow)
                )
            {
                transform.localEulerAngles = new Vector3(0, 90, ((int)targetSymbol * 45));
                turning = false;
                currentSymbol = targetSymbol;
            }
        }
        else
        {
            transform.localEulerAngles = new Vector3(0, 90, ((int)targetSymbol * 45));
        }
        base.Update();
	}
}
