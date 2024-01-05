namespace InvenTrackPro.SharedKernel.Common.Collection;

#nullable disable
public interface IDropdown<T>
{
    public IList<T> Data { get; set; }
}