using System;

namespace app.tests.integration.Middleware
{
    public class TestOrderAttribute : Attribute
    {
        public int Order { get; }

        public TestOrderAttribute(int order)
        {
            Order = order;
        }
    }
}