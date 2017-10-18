namespace ScoreConverter
{
    abstract class PListIndirectNode : PListNode
    {
        protected PListParser _parser;

        public PListIndirectNode(PListParser parser)
        {
            _parser = parser;
        }
    }
}