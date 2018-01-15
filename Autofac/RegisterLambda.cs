
var builder = new ContainerBuilder();
builder.Register<man>((a, b) =>
            {
                if (b.Named<string>("name") == "spike")
                {
                    return new man();
                }
                else
                {
                    return new man();
                }
            }).OnActivating(e=>e.Instance.Do());
public class man
{
    public string name { get; set; }
    public void Do()
    {
    }
}
