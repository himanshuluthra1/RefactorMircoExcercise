using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDDMicroExercises.TurnTicketDispenser;

namespace UnitTests
{
    [TestClass]
    public class TurnNumberSequenceTests
    {
        [TestMethod]
        public void GetTurnTicket_ShouldReturnNewTurnTicket()
        {
            
            var mockTurnNumberSequence = new Mock<ITurnNumberSequence>();
            mockTurnNumberSequence.SetupSequence(s => s.GetNextTurnNumberNew())
                                 .Returns(1)
                                 .Returns(2)
                                 .Returns(3);

            var ticketDispenser = new TicketDispenser(mockTurnNumberSequence.Object);

            
            TurnTicket ticket1 = ticketDispenser.GetTurnTicket();
            TurnTicket ticket2 = ticketDispenser.GetTurnTicket();
            TurnTicket ticket3 = ticketDispenser.GetTurnTicket();

            
            Assert.AreEqual(1, ticket1.TurnNumber);
            Assert.AreEqual(2, ticket2.TurnNumber);
            Assert.AreEqual(3, ticket3.TurnNumber);
        }
    }
}
