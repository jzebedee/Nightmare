
namespace Bloodstream.Interfaces
{
    public static class IValidatableHelper
    {
        public static bool Valid(this IValidatable obj)
        {
            return obj != null && obj.Valid;
        }
        public static bool Invalid(this IValidatable obj)
        {
            return !obj.Valid();
        }
    }

    public interface IValidatable
    {
        bool Valid { get; }
    }
}