namespace CleanCode.Examples
{
    class Example4_Result
    {
        public class AccountList
        {
            public void Remove(string account) { }

            public void Add(string account) { }
        }

        public class PhoneList
        {
            public void Add(string account) { }

            public string Find() { return null; }

            public void Remove(string phone) { }
        }

        public class DocumentListManager
        {
            public string Find() { return null; }

            public void Add(string document) { }

            public void Remove(string document) { }
        }
    }
}
