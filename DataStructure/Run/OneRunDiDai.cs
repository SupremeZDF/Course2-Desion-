using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructure.Run
{
    public class OneRunDiDai<T> : IEnumerable<T>
    {
        public List<T> _List;

        public OneRunDiDai() 
        {
            _List = new List<T>();
        }

        public void Add(T t) 
        {
            _List.Add(t);
        }

        public struct Enumerator<T> : IEnumerator<T>
        {

            private List<T> _List;

            private OneRunDiDai<T> _diDai;

            private T _Currcont;

            private int index;

            public Enumerator(OneRunDiDai<T> diDai) 
            {
                _List = diDai._List;
                _diDai = diDai;
                _Currcont = default(T);
                index = -1;
            }

            public object Current { 
                get {
                    return _Currcont;
                } 
            }

            T IEnumerator<T>.Current
            {
                get
                {
                    return _Currcont;
                }
            }

            public void Dispose()
            {
               ;
            }

            public bool MoveNext()
            {
                if (_List == null) 
                {
                    return false;
                }
                if (_List.Count > ++index)
                {
                    _Currcont = _List[index];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }

        public struct Enumerator : IEnumerator
        {

            private List<T> _List;

            private OneRunDiDai<T> _diDai;

            private T _Currcont;

            private int index;

            public Enumerator(OneRunDiDai<T> diDai)
            {
                _List = diDai._List;
                _diDai = diDai;
                _Currcont = default(T);
                index = -1;
            }

            public object Current
            {
                get
                {
                    return _Currcont;
                }
            }

            public void Dispose()
            {
                ;
            }

            public bool MoveNext()
            {
                if (_List == null)
                {
                    return false;
                }
                if (_List.Count > ++index)
                {
                    _Currcont = _List[index];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                index = -1;
            }
        }


        //public IEnumerator GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new Enumerator(this);
        }

        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return new Enumerator(this);
        //}
    }

    public class StuDent 
    {

       public int ID { get; set; }

       public string Name { get; set; }

       public string Age { get; set; }
    }

    public interface A 
    {
        void AA();
    }

    public interface B:A
    {
        int AA();

        void Name();
    }

    public class C : B
    {
        public int AA()
        {
            throw new NotImplementedException();
        }

        public void Name()
        {
            throw new NotImplementedException();
        }

        void A.AA()
        {
            throw new NotImplementedException();
        }
    }
}
