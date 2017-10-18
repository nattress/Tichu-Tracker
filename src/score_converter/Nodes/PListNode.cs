using System.Diagnostics;

namespace ScoreConverter
{
    abstract class PListNode
    {
        public PListDictionaryNode AsDictionaryNode()
        {
            Debug.Assert(this is PListDictionaryNode);
            return (PListDictionaryNode)this;
        }

        public PListArrayNode AsArrayNode()
        {
            Debug.Assert(this is PListArrayNode);
            return (PListArrayNode)this;
        }

        public double AsDouble()
        {
            Debug.Assert(this is PListValueNode<double>);
            return ((PListValueNode<double>)this).Value;
        }

        public bool AsBool()
        {
            Debug.Assert(this is PListValueNode<bool>);
            return ((PListValueNode<bool>)this).Value;
        }

        public int AsInt()
        {
            Debug.Assert(this is PListValueNode<int>);
            return ((PListValueNode<int>)this).Value;
        }

        public string AsString()
        {
            Debug.Assert(this is PListValueNode<string>);
            return ((PListValueNode<string>)this).Value;
        }
    }
}