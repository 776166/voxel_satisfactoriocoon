using VoxelTycoon;
using VoxelTycoon.Modding;
using VoxelTycoon.Notifications;
using VoxelTycoon.UI;
using VoxelTycoon.Localization;

namespace HelloVoxelWorldMod
{
    public class HelloVoxelWorldMod : Mod
    {
        //public static readonly Locale locale = LazyManager<LocaleManager>.Current.Locale;
        protected override void OnGameStarted()
        {    
            var priority = NotificationPriority.Default;
            var color = Company.Current.Color;
            //var foo = Company.Current.Name
            var locale = LazyManager<LocaleManager>.Current.Locale;
            var title = locale.GetString("voxel_satisfactoriocoon" + "/greet_title");
            var message = locale.GetString("voxel_satisfactoriocoon" + "/greet_text");
            //var title = "Voxel Satisfactoriotoon";
            //var message = "Let's make transport tycoons greate again!";

            var action = new HelloVoxelWorldNotificationAction();

            // If you don't need any action, just pass default value (null).
            // var action = default(INotificationAction);

            // Use custom FontAwesome (https://fontawesome.com/icons) icon
            var icon = FontIcon.FaSolid("\uf7e4");

            // And finally, call the API
            NotificationManager.Current.Push(priority, color, title, message, action, icon);
        }

        protected override void OnGameStarting()
        {
            var notificationTypeId = "hello_voxel_world_mod/hello_world_notification_action".GetHashCode();
            NotificationManager.Current.RegisterNotificationAction<HelloVoxelWorldNotificationAction>(notificationTypeId);
        }
    }
}