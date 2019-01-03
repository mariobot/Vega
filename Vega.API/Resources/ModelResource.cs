namespace Vega.API.Resources
{
    public class ModelResource
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public MakeResource Make { get; set; }
        
    }
}