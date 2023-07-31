namespace TDDMicroExercises.TurnTicketDispenser
{
    public interface ITurnNumberSequence
    {
        int GetNextTurnNumberNew();
    }
    public class TurnNumberSequence : ITurnNumberSequence
    {
        private static int _turnNumber = 0;

        public int GetNextTurnNumberNew()
        {
            return _turnNumber++;
        }

        public static int GetNextTurnNumber()
        {
            TurnNumberSequence turnNumberSequence = new TurnNumberSequence();
            return turnNumberSequence.GetNextTurnNumberNew();
        }
    }
}
