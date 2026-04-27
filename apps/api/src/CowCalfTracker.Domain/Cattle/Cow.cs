namespace CowCalfTracker.Domain.Cattle
{
    public sealed class Cow
    {
        private Cow() {}

        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public int TagNumber { get; private set; }
        
        public static Cow Create(string? name, int tagNumber)
        {
            var cow = new Cow
            {
                Id = Guid.NewGuid(),
                Name = name,
                TagNumber = tagNumber
            };
               
            return cow;
        }
    }
}
