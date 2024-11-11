namespace Homework
{
    public class ResourceItem : IResource
    {
        public string Id { get; }

        public ResourceItem(string id)
        {
            Id = id;
        }
    }
}