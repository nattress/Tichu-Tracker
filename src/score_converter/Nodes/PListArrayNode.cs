using System.Collections.Generic;
using System.Diagnostics;

namespace ScoreConverter
{
    class PListArrayNode : PListIndirectNode
    {
        List<PListNode> _array;
        List<object> _objs;
        public PListArrayNode(PListParser parser, List<object> objs) : base(parser)
        {
            _objs = objs;
        }

        public PListNode this[int index]
        {
            get
            {
                if (_array == null)
                    LazyInit();

                return _array[index];
            }
        }

        public int Count
        {
            get
            {
                if (_array == null)
                    LazyInit();

                return _array.Count;
            }
        }
        private void LazyInit()
        {
            _array = new List<PListNode>();
            foreach (object obj in _objs)
            {
                _array.Add(_parser.CreateNode(obj));
            }
            _objs = null;
        }
    }
}