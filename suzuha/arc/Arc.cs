using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace suzuha.arc
{
    // simple command line parser
    class Arc : IEnumerable<Tuple<string, string>>
    {
        private string[] Args { get; }
        private string Flags { get; }

        public Arc(string[] args, string flags)
        {
            if (args == null || flags == null) throw new ArgumentNullException();
            Args = args;
            Flags = flags;
        }

        public IEnumerator<Tuple<string, string>> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class ArcEnumerator : IEnumerator<Tuple<string, string>>
        {
            public Tuple<string, string> Current => throw new NotImplementedException();

            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public bool MoveNext()
            {
                throw new NotImplementedException();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
}