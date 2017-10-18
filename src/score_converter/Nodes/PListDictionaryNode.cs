using System.Collections.Generic;

namespace ScoreConverter
{
    class PListDictionaryNode : PListIndirectNode
    {
        Dictionary<string, PListNode> _dict;
        Dictionary<string, object> _objs;
        public PListDictionaryNode(PListParser parser, Dictionary<string, object> objs) : base(parser)
        {
            _objs = objs;
        }

        public PListNode this[string key]
        {
            get
            {
                if (_dict == null)
                    LazyInit();
                return _dict[key];
            }
        }

        public bool ContainsKey(string key)
        {
            if (_dict == null)
                    LazyInit();
            return _dict.ContainsKey(key);
        }

        private void LazyInit()
        {
            _dict = new Dictionary<string, PListNode>();
            foreach (KeyValuePair<string, object> kvp in _objs)
            {
                _dict.Add(kvp.Key, _parser.CreateNode(kvp.Value));
            }
            _objs = null;
        }
    }
}