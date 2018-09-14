using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suzuha.arc
{

    #region Custom Exceptions

    public class ArcParsingException : Exception
    {

        public ArcParsingException() { }

        public ArcParsingException(string message)
            : base(message)
        {

        }

        public ArcParsingException(string message, Exception inner)
            : base(message, inner)
        {

        }

    }

    #endregion

    // simple command line parser   WARNING: bugs may appear :/ , do not use until complete validation and testing of this class

    // flags foramt: f.e. "f:hvq"
    // if a flag ist followed by `:', u can specify an argument behind the flag
    // it ist further possible to give an alternativ long name: "[file]", wich is invocable by using two `-'

    public class Arc
    {
        private string[] Args { get; }
        private string Flags { get; }
        private string LongformFlags { get; }
        private char Seperator { get => ' '; }
        private char FlagSign { get => '-'; }
        private char ArgSign { get => ':'; }

        public Arc(string[] args, string flags)
        {
            if (args == null || flags == null) throw new ArgumentNullException();
            Args = args;
            if (flags.Contains("[") || flags.Contains("]")) throw new ArgumentException("[ and ] ar not allowed for short form flag specification.");
            Flags = flags;
        }

        public Arc(string[] args, string flags, string longformFlags)
            : this(args, flags)
        {
            if (longformFlags == null) throw new ArgumentNullException();
            LongformFlags = longformFlags;
        }


        private bool CheckForFlag(char flag)
        {
            if (Flags.Contains(flag) && flag != ArgSign)
                return true;
            return false;
        }

        private bool CheckForAltFlag(string flag)
        {
            if (LongformFlags.Contains("[" + flag + "]"))
                return true;
            return false;
        }

        private bool HasFlagArgument(char flag)
        {
            var p = Flags.IndexOf(flag);
            if (!(p == Flags.Length-1))
            {
                if (Flags[p + 1] == ArgSign)
                    return true;
            }
            return false;
        }

        private bool HasAltFlagArgument(string flag)
        {
            var p = LongformFlags.IndexOf(flag);
            p += flag.Length;
            if (!(p == LongformFlags.Length - 1))
            {
                if (LongformFlags[p + 1] == ArgSign)
                    return true;
            }
            return false;
        }

        public List<Tuple<string, string>> Parse()
        {
            var echo = new List<Tuple<string, string>>();

            // The parsing begins here ..
            int p = 0;
            ArcParseState state = ArcParseState.FLAG_CHECK;

            string currentFlag = null;

            foreach (var arg in Args)
            {
                if (state == ArcParseState.FLAG_CHECK)
                {
                    p = 0;
                    if (arg[p] != FlagSign)
                    {
                        continue;
                    }
                    if (arg.Length == 1)
                    {
                        if (!CheckForFlag(arg[p])) throw new ArcParsingException("Invalid flag, empty flag not specified");
                        echo.Add(new Tuple<string, string>("" + FlagSign, null));
                        continue;
                    }
                    p += 1;
                    if (arg[p] == FlagSign)
                    {
                        state = ArcParseState.ALT_NAME;
                        p += 1;
                    }
                    else
                    {
                        state = ArcParseState.MULTI_FLAG;
                    }

                }
                    
                if (state == ArcParseState.ALT_NAME)
                {
                    if (arg.Length == 2)
                    {
                    // todo: specify Flags field format for -- empty long flag
                        echo.Add(new Tuple<string, string>("" + FlagSign + FlagSign, null));
                        state = ArcParseState.FLAG_CHECK;
                        continue;
                    }

                    currentFlag = arg.Substring(p);
                    if (!CheckForAltFlag(currentFlag)) throw new ArcParsingException("Invalid Flag (alternative long form). Flag is " + currentFlag + ".");
                    if (!HasAltFlagArgument(currentFlag))
                    {
                        echo.Add(new Tuple<string, string>(currentFlag, null));
                        currentFlag = null;
                        state = ArcParseState.FLAG_CHECK;
                    }
                    else
                    {
                        state = ArcParseState.ARG_TOKEN;
                    }
                    
                    continue;
                }

                if (state == ArcParseState.ARG_TOKEN)
                {
                    if (arg[p] == FlagSign) throw new ArcParsingException("Expected argument token, got new flag section instead.");
                    echo.Add(new Tuple<string, string>(currentFlag, arg));
                    currentFlag = null;
                    state = ArcParseState.FLAG_CHECK;
                    continue;
                }

                if (state == ArcParseState.MULTI_FLAG)
                {
                    while (p < arg.Length)
                    {
                        var flag = arg[p];
                        if (!CheckForFlag(flag)) throw new ArcParsingException("Invalid Flag. Flag is " + flag + ".");
                        if (HasFlagArgument(flag))
                        {
                            if (p != arg.Length - 1) throw new ArcParsingException("Flags with argument not at the end of an multiflag. Flag is " + flag + ".");
                            currentFlag = flag.ToString();
                            state = ArcParseState.ARG_TOKEN;
                            break;
                        }
                        else
                        {
                            echo.Add(new Tuple<string, string>("" + flag, null));
                        }
                        p += 1;
                    }
                    if (state == ArcParseState.MULTI_FLAG)
                        state = ArcParseState.FLAG_CHECK;
                    continue;
                }
            }
            if (state == ArcParseState.ARG_TOKEN) throw new ArcParsingException("Argument expected for flag " + currentFlag + ".");
            return echo;
        }
        
        #region State Enum

        enum ArcParseState
        {
            BASE = 0,
            FLAG_CHECK,
            ALT_NAME,
            MULTI_FLAG,
            ARG_TOKEN,
            END
        }

        #endregion

    }
}