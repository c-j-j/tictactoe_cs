namespace TicTacToe
{
    public class TrackingNode<N, T>
    {
        public N Node { get; set; }
        public T Tracker { get; set; }

        public TrackingNode(N childNode, T tracker){
            Node = childNode;
            Tracker = tracker;
        }
    }
}
