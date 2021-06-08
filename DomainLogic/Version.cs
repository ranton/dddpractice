namespace DomainLogic
{
    public class Version : ValueObject<Version>
    {
        public int Major { get; protected set; }
        public int Minor { get; protected set; }
        public int Patch { get; protected set; }
        public Version(int major, int minor, int patch)
        {
            Major = major;
            Minor = minor;
            Patch = patch;
        }
    }


}
