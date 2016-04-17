using UnityEngine;
using System.Collections;

public class Clock : PuzzleObject {

    // Use this for initialization

    public ClockHand hourHand; //0 = 12, 90 = 3, 180 = 6, 270 = 9 +90
    public ClockHand minuteHand; // +90

    public int Hour;
    public int Minute;
    public int HourOffset = 0;

    public void setHands(int h, int m)
    {
        
        hourHand.transform.localEulerAngles = new Vector3(90, (h * 30) + (m / 2) + 90,0);
        minuteHand.transform.localEulerAngles = new Vector3(90, (m * 6) + 90,0);
    }

    public void readTime()
    {

    }

    float prevMinAngle = 0;
    


    public void updateHourHandFromMinuteHand()
    {
        float minDelta = minuteHand.transform.localEulerAngles.y - prevMinAngle;
        minDelta = (((minDelta + 180) % 360 + 360) % 360) - 180;
        hourHand.transform.localEulerAngles += new Vector3(0,  minDelta / 60,0);
        prevMinAngle = minuteHand.transform.localEulerAngles.y;
        Minute = Mathf.FloorToInt((minuteHand.transform.localEulerAngles.y-90) / 6);
        Hour = Mathf.FloorToInt((hourHand.transform.localEulerAngles.y-90) / 30);
        if(Minute < 0)
        {
            Minute += 60;
        }

        if (Hour < 0)
        {
            Hour += 12;
        }
        if (Hour == 0)
        {
            Hour = 12;
        }
    }

	public new void Start () {
        base.Start();
        if (!isTicking)
        {
            Hour =  Random.Range(1, 13);
            Minute = Random.Range(0, 60);
            prevMinAngle = (Minute * 6) + 90;
            setHands(Hour, Minute);

        }
        else
        {
            Hour = System.DateTime.UtcNow.Hour;
            
            if(Hour > 12)
            {
                Hour -= 12;
            }
            Hour+=HourOffset;
            if (Hour > 12)
            {
                Hour -= 12;
            }
            Minute = System.DateTime.UtcNow.Minute;
            setHands(Hour, Minute);
        }
        
	}
    public bool isTicking = false;




    // Update is called once per frame
    public new void Update () {
        base.Update();
        if (isTicking)
        {
            Hour = System.DateTime.UtcNow.Hour;

            if (Hour > 12)
            {
                Hour -= 12;
            }
            Hour += HourOffset;
            if (Hour > 12)
            {
                Hour -= 12;
            }
            Minute = System.DateTime.UtcNow.Minute;
            setHands(Hour, Minute);

        }
        else //hax
        {
            updateHourHandFromMinuteHand();
        }
	}

}
