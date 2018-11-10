using Fusers;

public class Core
{
    private ElementType coreType;
    protected int count;
    public int Count { get { return count; } set { count = value; } }

    public Core(ElementType e)
    {
        coreType = e;
    }

    public Core(ElementType e, int n)
    {
        coreType = e;
        count = n;
    }

    public ElementType CoreType
    {
        get
        {
            return coreType;
        }

        set
        {
            coreType = value;
        }
    }
}