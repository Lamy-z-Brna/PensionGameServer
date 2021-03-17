using System;

namespace PensionGame.Web.Data.Entities
{
    public record GameData(int Year, ClientData ClientData, bool IsFinished)
    {
    }
}