using System.Collections.Generic;

namespace BotOfScreenShots_Application.Interfaces
{
    public interface ISerializer
    {
        void Serialize(List<Profile> list);
        List<Profile> Deserialize();
    }
}
