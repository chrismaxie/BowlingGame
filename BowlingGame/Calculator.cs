namespace BowlingGame
{
    class Calculator
    {
        private int[] rolls;

        private Calculator(int[] rolls)
        {
            this.rolls = rolls;
        }

        public static Calculator GetRollCalculator(int[] rolls)
        {
            return new Calculator(rolls);
        }

        public void GetScoreForAllRollsInGame(ref int score)
        {
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rollIndex))
                {
                    score += 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
                }
                else if (IsSpare(rollIndex))
                {
                    score += 10 + rolls[rollIndex + 2];
                    rollIndex++;
                }
                else
                {
                    score += rolls[rollIndex] + rolls[rollIndex + 1];
                    rollIndex++;
                }

                rollIndex++;
            }
        }

        private bool IsSpare(int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        private bool IsStrike(int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }
    }
}
