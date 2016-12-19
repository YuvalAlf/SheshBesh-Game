using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SheshBeshGame.Utils.DataTypesUtils;

namespace SheshBeshGame.Utils.ImmutableList
{
    public abstract class ImList<T> : IEnumerable<T>
    {
        public bool IsNil => this is NilList;
        public bool IsCons => this is ConsList;

        public abstract T HeadUnsafe { get; }
        public abstract ImList<T> TailUnsafe { get; }

        public static ImList<T> Create(IEnumerable<T> values)
        {
            var valuesArray = values.ToArray();
            ImList<T> list = Nil;
            for (int i = valuesArray.Length - 1; i >= 0; i--)
                list = new ConsList(valuesArray[i], list);
            return list;
        }
        public static ImList<T> Create(params T[] values) => Create(Enumerable.AsEnumerable(values));

        public static ImList<T> Nil { get; } = new NilList(); 
        public static ImList<T> Cons(T head, ImList<T> tail) => new ConsList(head, tail);


        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public IEnumerator<T> GetEnumerator()
        {
            var list = this;
            while (list.IsCons)
            {
                yield return list.HeadUnsafe;
                list = list.TailUnsafe;
            }
        }

        public override string ToString() => this.MkString(", ", "[", "]");


        private sealed class NilList : ImList<T>
        {
            public override T HeadUnsafe { get {throw new NilListException();} }
            public override ImList<T> TailUnsafe { get { throw new NilListException(); } }
        }

        private sealed class ConsList : ImList<T>
        {
            public override T HeadUnsafe { get; }
            public override ImList<T> TailUnsafe { get; }

            public ConsList(T headUnsafe, ImList<T> tailUnsafe)
            {
                HeadUnsafe = headUnsafe;
                TailUnsafe = tailUnsafe;
            }
        }

        public sealed class NilListException : Exception
        { }

    }
}
