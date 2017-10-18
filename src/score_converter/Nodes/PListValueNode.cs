using System.Diagnostics;

namespace ScoreConverter
{
    class PListValueNode<T> : PListNode
    {
        public T Value { get; private set; }

        public PListValueNode(T value)
        {
            Value = value;
        }
    }
}