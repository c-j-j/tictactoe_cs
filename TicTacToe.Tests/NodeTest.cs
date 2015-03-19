using NUnit.Framework;

namespace TicTacToe
{
    [TestFixture]
    public class NodeTest
    {
        [Test]
        public void CreatesTrackingChildNode()
        {
            const int node = 0;
            const string tracker = "Tracker";
            var trackingNode = new Node<int, string>(node, tracker);
            Assert.AreEqual(trackingNode.Value, 0);
            Assert.AreEqual(trackingNode.Data, tracker);
        }
    }
}
