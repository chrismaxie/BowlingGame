namespace BowlingGame
{
    public class Calculator : ICalculator
    {
        public int GetScoreForAllRollsInGame(int[] rolls)
        {
            int score = 0;
            int rollIndex = 0;

            for (int frame = 0; frame < 10; frame++)
            {
                if (IsStrike(rolls, rollIndex))
                {
                    score += 10 + rolls[rollIndex + 1] + rolls[rollIndex + 2];
                }
                else if (IsSpare(rolls, rollIndex))
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

            return score;
        }

        private bool IsSpare(int[] rolls, int rollIndex)
        {
            return rolls[rollIndex] + rolls[rollIndex + 1] == 10;
        }

        private bool IsStrike(int[] rolls, int rollIndex)
        {
            return rolls[rollIndex] == 10;
        }
    }
}
