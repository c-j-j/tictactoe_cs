namespace TicTacToe
{
    public class Node<N, V>
    {
        public N Value { get; set; }
        public V Data { get; set; }

        public Node(N nodeValue, V data){
            Value = nodeValue;
            Data = data;
        }
    }
}
