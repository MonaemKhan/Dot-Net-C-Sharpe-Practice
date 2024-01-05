using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InvenTrackPro.Infrastructure.Persistence;
public static class Extensions
{
    public static bool HasChangedOwnedEntities(this EntityEntry entry)
    {
        return entry.References.Any(r =>
            r.TargetEntry is { } entityEntry &&
            entityEntry.Metadata.IsOwned() &&
            entityEntry.State is EntityState.Added or EntityState.Modified);
    }
}