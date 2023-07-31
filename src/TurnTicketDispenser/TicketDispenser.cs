namespace TDDMicroExercises.TurnTicketDispenser
{
    public class TicketDispenser
    {
        private readonly ITurnNumberSequence _turnNumberSequence;

        public TicketDispenser(ITurnNumberSequence turnNumberSequence)
        {
            _turnNumberSequence = turnNumberSequence;
        }

        public TicketDispenser()
        {
            _turnNumberSequence = new TurnNumberSequence();
        }
        public TurnTicket GetTurnTicket()
        {
            int newTurnNumber = _turnNumberSequence.GetNextTurnNumberNew();
            var newTurnTicket = new TurnTicket(newTurnNumber);

            return newTurnTicket;
        }
    }
}
