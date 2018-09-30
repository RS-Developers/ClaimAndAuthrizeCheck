namespace TeamTreeHouses.Interfaces
{
    public interface IPermissionManager
    {
        /*** Public Part ***/
        bool HaveAccessToPermission(int userId, int permissionId);
        bool HaveAccessToPermission(int userId, string permissionTitle);
    }
}
