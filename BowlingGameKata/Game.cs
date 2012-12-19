using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingGameKata
{
    public class Game
    {
        private int[] rolls = new int[21];
        private int currentRoll = 0;

        public void Roll(int pins)
        {
            rolls[currentRoll++] = pins;
        }

        private bool isSpare(int firstInFrame)
        {
            return rolls[firstInFrame] + rolls[firstInFrame + 1] == 10;
        }

        private bool isStrike(int firstInFrame)
        {
            return rolls[firstInFrame] == 10;
        }

        private int nextTwoBallsForStrike(int firstInFrame)
        {
            return rolls[firstInFrame + 1] + rolls[firstInFrame + 2];
        }

        private int nextBallForSpare(int firstInFrame)
        {
            return rolls[firstInFrame + 2];
        }

        private int twoBallsInFrame(int firstInFrame)
        {
            return rolls[firstInFrame] + rolls[firstInFrame + 1];
        }

        public int Score()
        {
            int score = 0;
            int firstInFrame = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (isStrike(firstInFrame))
                {
                    score += 10 + nextTwoBallsForStrike(firstInFrame);
                    firstInFrame++;
                }
                else if (isSpare(firstInFrame))
                {
                    score += 10 + nextBallForSpare(firstInFrame);
                    firstInFrame += 2;
                }
                else
                {
                    score += twoBallsInFrame(firstInFrame);
                    firstInFrame += 2;
                }
            }

            return score;
        }
    }
}
