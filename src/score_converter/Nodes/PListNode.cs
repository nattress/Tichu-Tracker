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
    }
}