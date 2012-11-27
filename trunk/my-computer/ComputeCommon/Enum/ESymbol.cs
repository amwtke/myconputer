using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputeCommon.Enum
{
    public enum Esymbol
    {
        LeftBracket,
        RightBracket,
        Plus,
        Subtraction,
        Muliply,
        Division,
        Power,
        Fan,
        JieChen,
        Huo,
        Yu,
        Nothing,
    }
    public static class SymbolContainer
    {
        static Dictionary<char, Esymbol> _dic = null;
        static SymbolContainer()
        {
            _dic = new Dictionary<char, Esymbol>();
            _dic.Add('(', Esymbol.LeftBracket);
            _dic.Add(')', Esymbol.RightBracket);
            _dic.Add('+', Esymbol.Plus);
            _dic.Add('-', Esymbol.Subtraction);
            _dic.Add('*', Esymbol.Muliply);
            _dic.Add('/', Esymbol.Division);
            _dic.Add('^', Esymbol.Power);
            _dic.Add('!', Esymbol.JieChen);
            _dic.Add('~',Esymbol.Fan);
            _dic.Add('|', Esymbol.Huo);
            _dic.Add('&', Esymbol.Yu);
        }
        public static Dictionary<char, Esymbol> SymbolDic
        {
            get { return _dic; }
        }
    }
}
