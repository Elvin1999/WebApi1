namespace WebApi1.DataAccess
{
    public class FakeRepo
    {
        public NorthwindContext context;

        public FakeRepo(NorthwindContext context)
        {
            this.context = context;
        }

    }
}
