namespace CleanCode.Examples
{
    class Example4
    {
        public class AccountList
        {
            public void Remove(string account) { }

            public void Add(string account) { }
        }

        public class PhoneList
        {
            public void Add(string account) { }

            public string Search() { return null; }

            public void Delete(string phone) { }
        }

        public class DocumentListManager
        {
            public string Find() { return null; }

            public void PutNew(string document) { }

            public void Remove(string document) { }
        }
    }
}
