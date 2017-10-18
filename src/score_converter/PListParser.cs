using System;
using System.Collections.Generic;
using System.Diagnostics;
using PlistCS;

namespace ScoreConverter
{
    class PListParser
    {
        PListArrayNode _objects;
        PListDictionaryNode _pList;

        public PListParser(string fileName)
        {
            _pList = CreateNode(Plist.readPlist(fileName)).AsDictionaryNode();
            _objects = _pList["$objects"].AsArrayNode();
        }

        public PListNode CreateNode(object obj)
        {
            if (obj is Dictionary<string, object>)
            {
                Dictionary<string, object> dictNode = obj as Dictionary<string, object>;
                Debug.Assert(dictNode != null);

                // Check for indirection node
                if (dictNode.ContainsKey("CF$UID"))
                {
                    Debug.Assert(_objects != null, "Tried to access $objects before PList was fully initialized");
                    return _objects[(int)dictNode["CF$UID"]];
                }

                return new PListDictionaryNode(this, dictNode);
            }

            if (obj is List<object>)
            {
                List<object> array = obj as List<object>;
                Debug.Assert(array != null);

                return new PListArrayNode(this, array);
            }

            if (obj is string)
            {
                return new PListValueNode<string>((string)obj);
            }

            if (obj is int)
            {
                return new PListValueNode<int>((int)obj);
            }

            if (obj is bool)
            {
                return new PListValueNode<bool>((bool)obj);
            }

            if (obj is double)
            {
                return new PListValueNode<double>((double)obj);
            }
            
            throw new NotImplementedException($"Add support for creating {obj.GetType().ToString()} nodes");
        }

        public PListNode RootNode
        {
            get
            {
                return _pList["$top"].AsDictionaryNode()["root"];
            }
        }
    }
}